using Microsoft.AspNetCore.Mvc;

namespace HospitalInformationSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        public IActionResult Book()
        {
            return View();
        }

        public IActionResult Confirmation(int appointmentId)
        {
            // Retrieve appointment details using appointmentId
            return View();
        }
    }
}
