using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;
public sealed class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; } = string.Empty;

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(id <= 0, ResourceErrorMessages.PRODUCT_ID_REQUIRED);
        Id = id;

        ValidateDomain(name, description, price, stock, image);
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);

        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), 
            ResourceErrorMessages.PRODUCT_NAME_REQUIRED);
        DomainExceptionValidation.When(name.Length < 3,
            ResourceErrorMessages.PRODUCT_NAME_TOO_SHORT);

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description),
            ResourceErrorMessages.PRODUCT_DESCRIPTION_REQUIRED);
        DomainExceptionValidation.When(description.Length < 5, 
            ResourceErrorMessages.PRODUCT_DESCRIPTION_TOO_SHORT);

        DomainExceptionValidation.When(price < 0,
            ResourceErrorMessages.INVALID_PRICE);

        DomainExceptionValidation.When(stock < 0,
            "Invalid stock");

        DomainExceptionValidation.When(image?.Length > 250,
            "Image name is too long, maximum is 250 characters");

        Name = name;
        Description = description;
        Price = price; 
        Stock = stock;
        Image = image;
    }

}
