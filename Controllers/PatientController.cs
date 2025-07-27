using Microsoft.AspNetCore.Mvc;
using Website1.Models;
using Website1.ViewModels;

namespace Website1.Controllers
{
    public class PatientController : Controller
    {

        public ClinicContext context;

        public PatientController(ClinicContext context)
        {
            this.context = context;
        }

        public IActionResult Index(PatientFilterVM filter)
        {

            //var Paitents = context.Patients.Select(p => new PatientVM
            //{
            //    Id = p.Id,
            //    FullName = p.FullName,
            //    NationalId = p.NationalId,
            //    Email = p.Email,
            //    PhoneNumber = p.PhoneNumber,
            //    DateOfBirth = p.DateOfBirth
            //}).ToList();/

            var Patients = context.Patients
                                    .Where(p => filter.Id == null || p.Id == filter.Id)
                                    .Where(p => filter.FullName == null || p.FullName.Contains(filter.FullName))
                                    .Where(p => filter.NationalId == null || p.NationalId == filter.NationalId)
                                    .Select(p => p.ToPatientVM())
                                    .ToList();

            var vm = new PatientFilteredVM
            {
                Data = Patients,
                Filters = filter
            };

            return View(vm);
        }

        public IActionResult Pdetails(int ID)
        {

            var Patient = context.Patients.FirstOrDefault(p => p.Id == ID);
            if (Patient == null)
            {
                return NotFound();
            }
            return View(Patient);
        }

        public IActionResult Create()
        {
            var Paitents = new PatientCreateVM();

            return View(Paitents);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PatientCreateVM newPatient)
        {
            if(!ModelState.IsValid)
                {
                    return View(newPatient);
                }

            var Patient = newPatient.ToPatient();
            context.Patients.Add(Patient);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int Id)
        {
            var Patient = context.Patients.FirstOrDefault(p => p.Id == Id);
            if (Patient == null)
            {
                return NotFound();
            }

            var Paitents = Patient.ToPatientUpdateVM();
            return View(Paitents);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id,PatientUpdateVM UpdatedPatient)
        {
            if (!ModelState.IsValid)
            {
                return View(UpdatedPatient);
            }

            var Patient = context.Patients.FirstOrDefault(p => p.Id == Id);
            if (Patient == null)
            {
                return NotFound();  
            }

            UpdatedPatient.ToPatient(Patient);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            var Patient = context.Patients.FirstOrDefault(p => p.Id == Id);
            if (Patient == null)
            {
                return NotFound();
            }
            context.Patients.Remove(Patient);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
