﻿using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs;
public class RegisterDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "Passwords don´t match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
