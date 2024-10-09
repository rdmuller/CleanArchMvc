using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests.Entities;
public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create category success")]
    public void CreateCategory_Success()
    {
        Action action = () => new Category(1, "Sample");

        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create category error with invalid id")]
    public void CreateCategory_Error_Invalid_Id()
    {
        Action action = () => new Category(-1, "Sample");

        action.Should().Throw<DomainExceptionValidation>().
            WithMessage(ResourceErrorMessages.CATEGORY_ID_REQUIRED);
    }

    [Fact(DisplayName = "Create category error name s to short")]
    public void CreateCategory_Error_Name_Too_Short()
    {
        Action action = () => new Category(1, "aa");

        action.Should().Throw<DomainExceptionValidation>().
            WithMessage(ResourceErrorMessages.CATEGORY_NAME_TOO_SHORT);
    }

    [Fact(DisplayName = "Create category error empty name")]
    public void CreateCategory_Error_Empty_Name()
    {
        Action action = () => new Category("");

        action.Should().Throw<DomainExceptionValidation>().
            WithMessage(ResourceErrorMessages.CATEGORY_NAME_REQUIRED);
    }
}
