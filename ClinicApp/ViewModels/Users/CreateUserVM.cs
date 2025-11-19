using System.ComponentModel.DataAnnotations;

namespace ClinicApp.ViewModels.Users;

public class CreateUserVM
{
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;
    
    [EnumDataType(typeof(AppRoles))]
    public string Role { get; set; } = null!;
}