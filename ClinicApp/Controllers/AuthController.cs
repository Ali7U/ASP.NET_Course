using ClinicApp.ViewModels.Doctors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers;

public class AuthController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(SignInManager<IdentityUser> signInManager, 
        UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    // GET
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM loginVm)
    {
        if (!ModelState.IsValid)
        {
            return View(loginVm);
        }
        
        var user = await _userManager.FindByEmailAsync(loginVm.Email);
        
        if (user == null)
        {
            ModelState.AddModelError("Email", "Invalid email or password");
            return View(loginVm);
        }
        
        var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, true, true);
        
        if(!result.Succeeded)
        {
            ModelState.AddModelError("Email", "Invalid email or password");
            return View(loginVm);
        }

        return Redirect("/");
    } 
    
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Redirect("/");
    }
}