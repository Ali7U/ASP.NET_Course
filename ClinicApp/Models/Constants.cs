namespace ClinicApp.Models;

public class Constants
{
    public static List<Patient> Patients =
    [
        new Patient
        {
            Id = 1,
            FullName = "John Miller",
            NationalId = "1002345678",
            Email = "john.miller@example.com",
            PhoneNumber = "+1-202-555-0143",
            DateOfBirth = new DateOnly(1990, 3, 12)
        },
        new Patient
        {
            Id = 2,
            FullName = "Emily Johnson",
            NationalId = "1003456789",
            Email = "emily.johnson@example.com",
            PhoneNumber = "+1-202-555-0197",
            DateOfBirth = new DateOnly(1988, 7, 24)
        },
        new Patient
        {
            Id = 3,
            FullName = "Michael Smith",
            NationalId = "1004567890",
            Email = "michael.smith@example.com",
            PhoneNumber = "+1-202-555-0172",
            DateOfBirth = new DateOnly(1995, 11, 3)
        }
    ];

    public static List<Doctor> Doctors =
    [
        new Doctor
        {
            Id = 1,
            FirstName = "William",
            LastName = "Anderson",
            Email = "william.anderson@clinic.com",
            PhoneNumber = "+1-202-555-0123",
            HireDate = new DateTime(2015, 6, 12)
        },
        new Doctor
        {
            Id = 2,
            FirstName = "Olivia",
            LastName = "Brown",
            Email = "olivia.brown@clinic.com",
            PhoneNumber = "+1-202-555-0167",
            HireDate = new DateTime(2018, 3, 27)
        },
        new Doctor
        {
            Id = 3,
            FirstName = "David",
            LastName = "Wilson",
            Email = "david.wilson@clinic.com",
            PhoneNumber = "+1-202-555-0111",
            HireDate = new DateTime(2020, 9, 15)
        }
    ];
}