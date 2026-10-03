namespace Hospital_System.ViewModel
{
    public class AllAppointmentsTableVM
    {
        public string? PatientName { set; get; }
        public string? DoctorName { set; get; }
        public DateOnly DateOfAppointments { set; get; }
        public TimeOnly TimeOfAppointments { set; get; }
    }
}
