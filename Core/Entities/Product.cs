namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        //creates a foreign key pointing to ProductType table
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        //creates a foreign key pointing to ProductBrand table
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}