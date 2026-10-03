using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_System.Models
{
    [PrimaryKey(nameof(PatientId),nameof(DoctorId))]
    public class PatientAppointDoctor
    {
        public int PatientId { set; get; }

        public int DoctorId{ set; get; }
        [ForeignKey(nameof(PatientId))]
        public Patient patient { set; get; }
        [ForeignKey(nameof(DoctorId))]
        public Doctor doctor { set; get; }

        public DateOnly DateOfAppointment { set; get; }
        public TimeOnly TimeOfAppointment { set; get; }
    }
}
