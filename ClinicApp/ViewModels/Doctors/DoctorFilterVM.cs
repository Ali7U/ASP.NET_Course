using System.ComponentModel.DataAnnotations;

namespace ClinicApp.ViewModels.Doctors;

public class DoctorFilterVM
{
    public int? Id { get; set; }
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; } = null!;

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 2;
    public int TotalCount { get; set; }
    public int PageCount => (int)Math.Ceiling((double)TotalCount / PageSize);
}