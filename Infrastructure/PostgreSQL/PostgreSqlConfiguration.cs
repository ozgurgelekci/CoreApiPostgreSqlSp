namespace Infrastructure.PostgreSQL
{
    public class PostgreSqlConfiguration
    {
        public PostgreSqlConfiguration(string connectionString) => ConnectionString = connectionString;
        public string ConnectionString { get; set; }
    }
}
