using ClinicApp.Models;
using ClinicApp.ViewModels.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers;

public class DoctorsController : Controller
{
    // GET
    public IActionResult Index()
    {
        var doctors = Constants.Doctors.Select(d => d.ToDoctorVM()).ToList();
        return View(doctors);
    }
    public IActionResult Details(int id)
    {
        var doctors = Constants.Doctors.Single(d => d.Id == id).ToDoctorVM();
        return View(doctors);
    }
    
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Register(DoctorCreateVM doctorVm)
    {
        if (!ModelState.IsValid)
        {
            return View(doctorVm);
        }

        var doctor = doctorVm.ToModel();
        doctor.Id = Constants.Doctors.Select(d => d.Id).Max() + 1;
        Constants.Doctors.Add(doctor);
        return RedirectToAction("Details", new {id = doctorVm.Id});
    }
    
    public IActionResult Delete(int id)
    {
        var doctor = Constants.Doctors.Single(d => d.Id == id);
        Constants.Doctors.Remove(doctor);
        
        return Ok();    
    }
}