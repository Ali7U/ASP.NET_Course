using ClinicApp.Models;
using ClinicApp.ViewModels.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers;

public class DoctorsController : Controller
{
    private readonly ClinicContext _context;
    
    public DoctorsController(ClinicContext context)
    {
        _context = context;
    }
    [HttpGet]
    // GET
    public IActionResult Index(DoctorFilterVM  filter)
    {
        var initQuery = _context.Doctors
            .Where(d => filter.Id == null || d.Id == filter.Id)
            .Where(d => filter.FirstName == null || d.FirstName.Contains(filter.FirstName))
            .Where(d => filter.LastName == null || d.LastName.Contains(filter.LastName))
            .Where(d => filter.PhoneNumber == null || d.PhoneNumber == filter.PhoneNumber);
            
        filter.TotalCount = initQuery.Count();
        
            var doctors = initQuery
                .OrderBy(d => d.Id)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(d => d.ToDoctorVM())
                .ToList();
        
        return View(new DoctorFilterdListVM { Doctors = doctors, Filter = filter });
    }
    public IActionResult Details(int id)
    {
        var doctor = _context.Doctors.Single(d => d.Id == id).ToDoctorVM();
        return View(doctor);
    }
    
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(DoctorCreateVM doctorVm)
    {
        if (!ModelState.IsValid)
        {
            return View(doctorVm);
        }

        var doctor = doctorVm.ToModel();
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
        
        return RedirectToAction("Details", new {id = doctor.Id});
    }
    
    public IActionResult Delete(int id)
    {
        var doctor = _context.Doctors.Single(d => d.Id == id);
        _context.Doctors.Remove(doctor);
        _context.SaveChanges();
        
        return Ok();    
    }
    
    public IActionResult Update(int id)
    {
        var doctor = _context.Doctors.Single(d => d.Id == id).ToUpdateDoctorVM();
        return View(doctor);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(int id, DoctorUpdateVM doctorVm)
    {
        if (!ModelState.IsValid)
        {
            return View(doctorVm);
        }

        var doctor = _context.Doctors.Single(d => d.Id == id);
        
        doctor.FirstName = doctorVm.FirstName;
        doctor.LastName = doctorVm.LastName;
        doctor.Email = doctorVm.Email;
        doctor.HireDate = doctorVm.HireDate;
        doctor.PhoneNumber = doctorVm.PhoneNumber;
        
        _context.SaveChanges();
        
        return RedirectToAction("Details", new { id });
    }
}