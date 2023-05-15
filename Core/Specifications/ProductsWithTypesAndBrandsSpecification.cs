using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        //BASE => Expression<Func<T, bool>> criteria
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams): base(X => 
        (string.IsNullOrEmpty(productParams.Search) || X.Name.ToLower().Contains(productParams.Search)) &&
        (!productParams.BrandId.HasValue || X.ProductBrandId == productParams.BrandId) && 
        (!productParams.TypeId.HasValue || X.ProductTypeId == productParams.TypeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort)) 
            {
                switch (productParams.Sort) 
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        //the ctor with criteria
        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id) //get me the product where the id == the id I passed into ProductsWithTypesAndBrandsSpecification
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}