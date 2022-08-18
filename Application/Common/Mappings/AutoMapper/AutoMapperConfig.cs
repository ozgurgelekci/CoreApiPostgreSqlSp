using AutoMapper;
using Domain.Entities;
using Domain.Models.Products;

namespace Domain.Mappings.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            ProductsMappings();
        }


        #region Products

        private void ProductsMappings()
        {
            // Insert Product Mapping
            CreateMap<Product, InsertProductModel>().ReverseMap();

            // Update Product Mapping
            CreateMap<Product, UpdateProductModel>().ReverseMap();

            // Get Product Mapping
            CreateMap<Product, GetProductModel>().ReverseMap();
        }

        #endregion

    }
}
