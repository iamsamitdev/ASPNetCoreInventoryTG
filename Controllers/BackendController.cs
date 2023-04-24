using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreInventory.Controllers;

[SessionCheck]
public class BackendController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }

    // Logout
    public IActionResult Logout()
    {
        // Clear session
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Frontend");
    }
}
