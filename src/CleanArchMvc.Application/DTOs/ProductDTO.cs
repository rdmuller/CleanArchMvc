using CleanArchMvc.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CleanArchMvc.Domain.Validation;
using System.Text.Json.Serialization;

namespace CleanArchMvc.Application.DTOs;
public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessageResourceName = "PRODUCT_NAME_REQUIRED", ErrorMessageResourceType = typeof(ResourceErrorMessages))]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessageResourceName = "PRODUCT_DESCRIPTION_REQUIRED", ErrorMessageResourceType = typeof(ResourceErrorMessages))]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Price is Required")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The Stock is Required")]
    [Range(1, 9999)]
    [DisplayName("Stock")]
    public int Stock { get; set; }

    [MaxLength(250)]
    [DisplayName("Product Image")]
    public string Image { get; set; } = string.Empty;

    [JsonIgnore]
    public Category? Category { get; set; }

    [DisplayName("Category")]
    public int CategoryId { get; set; }
}
