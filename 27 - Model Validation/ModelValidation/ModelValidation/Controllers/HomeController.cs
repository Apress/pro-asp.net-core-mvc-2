using System;
using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelValidation.Controllers {

    public class HomeController : Controller {

        public IActionResult Index() =>
            View("MakeBooking", new Appointment() { Date = DateTime.Now });

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt) {

            if (ModelState.GetValidationState(nameof(appt.Date))
                    == ModelValidationState.Valid
                && ModelState.GetValidationState(nameof(appt.ClientName))
                    == ModelValidationState.Valid
                && appt.ClientName.Equals("Joe", StringComparison.OrdinalIgnoreCase)
                && appt.Date.DayOfWeek == DayOfWeek.Monday) {
                ModelState.AddModelError("",
                    "Joe cannot book appointments on Mondays");
            }

            if (ModelState.IsValid) {
                return View("Completed", appt);
            } else {
                return View();
            }
        }

        public JsonResult ValidateDate(string Date) {
            DateTime parsedDate;

            if (!DateTime.TryParse(Date, out parsedDate)) {
                return Json("Please enter a valid date (mm/dd/yyyy)");
            } else if (DateTime.Now > parsedDate) {
                return Json("Please enter a date in the future");
            } else {
                return Json(true);
            }
        }
    }
}
