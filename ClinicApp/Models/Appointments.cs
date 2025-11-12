using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicApp.Models;

public class Appointments
{
    public int Id { get; set; }

    public Patient Patient { get; set; } = null!;

    public Doctor Doctor { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}