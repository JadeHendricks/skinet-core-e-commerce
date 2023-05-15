using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams): base(X => 
        (!productParams.BrandId.HasValue || X.ProductBrandId == productParams.BrandId) && 
        (!productParams.TypeId.HasValue || X.ProductTypeId == productParams.TypeId))
        {
            
        }
    }
}