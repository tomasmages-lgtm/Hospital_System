using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hospital_System.Models
{
    public class Patient
    {
        [Key]
        public int Id { set; get; }
        [MaxLength(20)]
        [Unicode(false)]
        public string Fname { set; get; }
        [MaxLength(20)]
        [Unicode(false)]
        public string Lname { set; get; }
    }
}
