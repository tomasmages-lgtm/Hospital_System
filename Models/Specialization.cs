using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Hospital_System.Models
{
    public class Specialization
    {
        [Key]
        public int Id { set; get; }
        [MaxLength(20)]
        [Unicode(false)]
        public string name { set; get; }
    }
}
