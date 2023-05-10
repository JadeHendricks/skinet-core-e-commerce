using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    //IMapper interface == IValueResolver
    //takes in the source "Product", destination "ProductToReturnDto" and waht we want the property type to be "string" - as per Resolve
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
            
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}