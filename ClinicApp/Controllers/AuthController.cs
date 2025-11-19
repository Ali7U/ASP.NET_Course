using ClinicApp.ViewModels.Doctors;
using ClinicApp.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
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
    
    [Authorize(Roles = "APP_ADMIN")]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [Authorize(Roles = "APP_ADMIN")]
    public async Task<IActionResult> Create(CreateUserVM userVm)
    {
        if (!ModelState.IsValid)
        {
            return View(userVm);
        }

        var user = new IdentityUser
        {
            UserName = userVm.Email.Split("@")[0],
            Email = userVm.Email
        };
        
        var result = await _userManager.CreateAsync(user, userVm.Password);
        if (!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty, result.Errors.First().Description);
            return View(userVm);
        }
        
        result = await _userManager.AddToRoleAsync(user, userVm.Role);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("Role", "Failed to add role");
            return View(userVm);
        }
        
        return Redirect("/");
    }
}