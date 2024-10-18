using ProductCatalog.Domain.AuxModels;

namespace ProductCatalog.Domain.Models
{
    public sealed class Product(int id, string name, decimal price, string description, ProductType productType, DateTime registrationDate)
    {
        public int Id { get; } = id;
        public string Name { get; } = name;
        public decimal Price { get; } = price;
        public string Description { get; } = description;
        public ProductType ProductType { get; } = productType;
        public DateTime RegistrationDate { get; } = registrationDate;
    }
}
