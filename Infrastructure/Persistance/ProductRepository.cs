using Application.Common.Interfaces;
using Domain.Models.Products;
using Infrastructure.PostgreSQL;
using Npgsql;
using System.Data;

namespace Infrastructure.Persistance
{
    public class ProductRepository : IProductRepository
    {
        private PostgreSqlConfiguration _connectionString;

        public ProductRepository(PostgreSqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection DbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<GetProductModel>> GetAll()
        {
            List<GetProductModel> productList;
            using (var cn = DbConnection())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("get_allproducts", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                productList = new List<GetProductModel>();
                while (reader.Read())
                {
                    GetProductModel product = new GetProductModel()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDouble(2)
                    };
                    productList.Add(product);
                }

            }
            return productList;
        }

        public async Task<GetProductModel> Get(int id)
        {
            GetProductModel product = new GetProductModel();
            using (var cn = DbConnection())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("get_productdetail", cn);
                cmd.Parameters.AddWithValue(new NpgsqlParameter("p1_id", DbType.Int32)).Value = id;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    product = new GetProductModel()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDouble(2)
                    };
                }

            }
            return product;
        }

        public async Task<bool> Insert(InsertProductModel product)
        {
            bool saved = false;
            using (var cn = DbConnection())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("call public.save_product(:p_name, :p_price)", cn);
                cmd.Parameters.AddWithValue("p_name", DbType.String).Value = product.Name;
                cmd.Parameters.AddWithValue("p_price", DbType.Double).Value = product.Price;
                cmd.CommandType = CommandType.Text;//don't set stored procedure
                cn.Open();
                var result = await cmd.ExecuteNonQueryAsync();
                saved = result == -1;
            }
            return saved;

        }

        public async Task<bool> Update(UpdateProductModel product)
        {
            bool saved = false;
            using (var cn = DbConnection())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("call public.update_product(:p_name, :p_price, :p_id)", cn);
                cmd.Parameters.AddWithValue("p_name", DbType.String).Value = product.Name;
                cmd.Parameters.AddWithValue("p_price", DbType.Double).Value = product.Price;
                cmd.Parameters.AddWithValue("p_id", DbType.Int32).Value = product.Id;
                cmd.CommandType = CommandType.Text;//don't set stored procedure
                cn.Open();
                var result = await cmd.ExecuteNonQueryAsync();
                saved = result == -1;
            }
            return saved;
        }

        public async Task<bool> Delete(int id)
        {
            bool deleted = false;
            using (var cn = DbConnection())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("call delete_product(:p_id)", cn);
                cmd.Parameters.AddWithValue("p_id", DbType.Int32).Value = id;
                cmd.CommandType = CommandType.Text; //don't set stored procedure
                cn.Open();
                var result = await cmd.ExecuteNonQueryAsync();
                deleted = result == -1;
            }
            return deleted;
        }

    }
}
