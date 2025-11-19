using ClinicApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers;
[Authorize]
public class PatientsController : Controller
{
    // GET
    public IActionResult Index()
    {
        var patient = Constants.Patients;
        return View(patient);
    }
    public IActionResult Details(int id)
    {
        var patient = Constants.Patients.Single(d => d.Id == id);
        return View(patient);
    }

    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Register(Patient patient)
    {
        if (!ModelState.IsValid)
        {
            return View(patient);
        }
        patient.Id = Constants.Patients.Select(p => p.Id).Max() + 1;
        Constants.Patients.Add(patient);
        return RedirectToAction("Details", new {id = patient.Id});
    }
    
    public IActionResult Delete(int id)
    {
        var patient = Constants.Patients.Single(d => d.Id == id);
        Constants.Patients.Remove(patient);
        
        return Ok();    
    }
}