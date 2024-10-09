﻿using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUI.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "E-mail is required")]
    [EmailAddress(ErrorMessage = "Invalid format e-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", 
        MinimumLength = 5)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public string ReturnUrl { get; set; } = string.Empty;
}
