using CleanArchMvc.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs;
public class CategoryDTO
{
    public int Id { get; set; }
    [Required(ErrorMessageResourceName = "CATEGORY_NAME_REQUIRED", ErrorMessageResourceType = typeof(ResourceErrorMessages))]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
