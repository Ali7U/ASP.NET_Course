using ClinicApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers;

public class DoctorsController : Controller
{
    // GET
    public IActionResult Index()
    {
        var doctors = Constants.Doctors;
        return View(doctors);
    }
    public IActionResult Details(int id)
    {
        var doctors = Constants.Doctors.Single(d => d.Id == id);
        return View(doctors);
    }
    
}