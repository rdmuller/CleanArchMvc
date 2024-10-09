using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests.Entities;
public class ProductUnitTest1
{
    [Fact(DisplayName = "Create product success")]
    public void CreateProduct_Success()
    {
        Action action = () => new Product(1, "Sample", "sample description", 9.99m, 99, "");

        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create product error with invalid id")]
    public void CreateProduct_Error_Invalid_Id()
    {
        Action action = () => new Product(-1, "Sample", "sample description", 9.99m, 99, "");

        action.Should().Throw<DomainExceptionValidation>().
            WithMessage(ResourceErrorMessages.PRODUCT_ID_REQUIRED);
    }

    [Fact(DisplayName = "Create product error name s to short")]
    public void CreateProduct_Error_Name_Too_Short()
    {
        Action action = () => new Product(1, "aa", "sample description", 9.99m, 99, "");

        action.Should().Throw<DomainExceptionValidation>().
            WithMessage(ResourceErrorMessages.PRODUCT_NAME_TOO_SHORT);
    }

    [Fact(DisplayName = "Create product error empty name")]
    public void CreateProduct_Error_Empty_Name()
    {
        Action action = () => new Product("", "sample description", 9.99m, 99, "");

        action.Should().Throw<DomainExceptionValidation>().
            WithMessage(ResourceErrorMessages.PRODUCT_NAME_REQUIRED);
    }
}
