using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams) : base(X =>
        (string.IsNullOrEmpty(productParams.Search) || X.Name.ToLower().Contains(productParams.Search)) &&
        (!productParams.BrandId.HasValue || X.ProductBrandId == productParams.BrandId) &&
        (!productParams.TypeId.HasValue || X.ProductTypeId == productParams.TypeId))
        {

        }
    }
}