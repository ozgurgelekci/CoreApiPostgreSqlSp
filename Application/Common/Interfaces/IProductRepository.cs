using Domain.Entities;
using Domain.Models.Products;

namespace Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<GetProductModel>> GetAll();
        Task<GetProductModel> Get(int id);
        Task<bool> Insert(InsertProductModel products);
        Task<bool> Update(UpdateProductModel products);
        Task<bool> Delete(int id);
    }
}
