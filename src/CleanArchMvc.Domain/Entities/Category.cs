using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;
public sealed class Category : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public ICollection<Product>? Products { get; set; }

    public Category(string name)
    {
        ValidateDomain(name);
    }

    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0,
            ResourceErrorMessages.CATEGORY_ID_REQUIRED);
        Id = id;

        ValidateDomain(name);
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
            ResourceErrorMessages.CATEGORY_NAME_REQUIRED);
        DomainExceptionValidation.When(name.Length < 3,
            ResourceErrorMessages.CATEGORY_NAME_TOO_SHORT);

        Name = name;
    }

    public void UpdateName(string name)
    {
        ValidateDomain(name);
    }

}