using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //ForMember allows us to customize for an individual property
            //d => d.ProductBrand == we want to product brand inside of ProductToReturnDto to be set to something
            //o.MapFrom(source => source.ProductBrand.Name) == where to get it from
            //source == Product , destination == ProductToReturnDto
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(source => source.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(source => source.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}