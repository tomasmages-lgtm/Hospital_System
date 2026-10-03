namespace Hospital_System.ViewModel
{
    public class PatientBooking
    {
        public string Fname { set; get; }
        public string Lname { set; get; }

        public int DoctorId { set; get; }
        public DateOnly DateOfAppointments { set; get; }
        public TimeOnly TimeOfAppointments { set; get; }
    }
}
