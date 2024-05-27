using Microsoft.AspNetCore.Mvc;
using MvcAssagnment1.Models;

namespace MvcAssagnment1.Controllers
{
    public class DoctorController : Controller
    {
        [HttpGet]
        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(float temperature, string scale)
        {
            string message = TemperatureCheck.CheckTemperature(temperature, scale);
            ViewBag.Message = message;
            return View();
        }
    }
}
