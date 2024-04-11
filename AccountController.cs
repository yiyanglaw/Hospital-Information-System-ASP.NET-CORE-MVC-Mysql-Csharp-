using Microsoft.AspNetCore.Mvc;

namespace HospitalInformationSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult UserProfile()
        {
            return View();
        }
    }
}
