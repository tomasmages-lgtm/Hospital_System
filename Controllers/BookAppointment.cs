using Hospital_System.DataAcces;
using Hospital_System.Models;
using Hospital_System.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Hospital_System.Controllers
{
    public class BookAppointment : Controller
    {
        ApplicationDbContext _MyContext = new ApplicationDbContext();
        public IActionResult index(string name, int SpecializationId=0,int page=1) {
            var query = _MyContext.Doctors.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                    query = query.Where(d => (d.Fname + " " + d.Lname).ToLower().Contains(name));
            }
            if (SpecializationId != 0) 
            { 
                    query = query.Where(d => d.SpecializationId==SpecializationId);
            }
            int SizePage = 4;
            int TotalPages = (int)Math.Ceiling(query.Count() / (decimal)SizePage);
            query = query.Skip((page - 1) * SizePage).Take(SizePage);
            ViewBag.TotalPages = TotalPages;
            return View(new Doctors_SpecializationsVM
            {
                Doctors = query.ToList(),
                Specializations = _MyContext.Specializations.ToList()
            });
        }

        public IActionResult GetForm(int DoctorId) {
            return View(DoctorId);
        }

        [HttpPost]
        public IActionResult Book(PatientBooking bm)
        {
            if (bm.Fname != null && bm.Lname != null) {
                Patient P1 = new Patient();
                P1.Fname = bm.Fname;
                P1.Lname = bm.Lname;
                _MyContext.Patients.Add(P1);
                _MyContext.SaveChanges();
                PatientAppointDoctor A1 = new PatientAppointDoctor();
                A1.PatientId = P1.Id;
                A1.DoctorId = bm.DoctorId;
                A1.DateOfAppointment = bm.DateOfAppointments;
                A1.TimeOfAppointment = bm.TimeOfAppointments;
                _MyContext.PatientAppointments.Add(A1);
                _MyContext.SaveChanges();
            }
            return View();
        }
    }
}
