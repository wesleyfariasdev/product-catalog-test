using ProductCatalog.Domain.AuxModels;

namespace ProductCatalog.Domain.Models
{
    public sealed class Product
    {
        public Product(int id, string name, decimal price, string description, ProductType productType, DateTime registrationDate)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            ProductType = productType;
            RegistrationDate = registrationDate;
        }

        public Product(string name, decimal price, string description, ProductType productType, DateTime registrationDate)
        {
            Name = name;
            Price = price;
            Description = description;
            ProductType = productType;
            RegistrationDate = registrationDate;
        } 

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public ProductType ProductType { get; private set; }
        public DateTime RegistrationDate { get; private set; }
    }
}
