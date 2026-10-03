using Hospital_System.ViewModel;
using Hospital_System.DataAcces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_System.Controllers
{
    public class AllAppointments : Controller
    {
        ApplicationDbContext _MyContext = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllAppointments()
        {
            var AllAppointments = _MyContext.PatientAppointments.Join(
                _MyContext.Patients,
                a => a.PatientId,
                p => p.Id,
                (Appoint, Patient) => new
                {
                    Appoint,
                    Patient
                }
                ).Join(
                _MyContext.Doctors,
                a => a.Appoint.DoctorId,
                d => d.Id,
                (AppointWithPatient, Doc) => new AllAppointmentsTableVM
                {
                    PatientName = AppointWithPatient.Patient.Fname + " " + AppointWithPatient.Patient.Lname,
                    DoctorName = Doc.Fname + " " + Doc.Lname,
                    DateOfAppointments = AppointWithPatient.Appoint.DateOfAppointment,
                    TimeOfAppointments = AppointWithPatient.Appoint.TimeOfAppointment
                }).ToList();
                
            return View(AllAppointments);
        }
    }
}
