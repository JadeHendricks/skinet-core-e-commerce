using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        //BASE => Expression<Func<T, bool>> criteria
        public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId, int? typeId): base(X => 
        (!brandId.HasValue || X.ProductBrandId == brandId) && 
        (!typeId.HasValue || X.ProductTypeId == typeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort)) 
            {
                switch (sort) 
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