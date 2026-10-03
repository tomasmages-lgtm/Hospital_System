using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_System.Models
{
    public class Doctor
    {
        [Key]
        public int Id { set; get; }
        [MaxLength(20)]
        [Unicode(false)]
        public string Fname { set; get; }
        [MaxLength(20)]
        [Unicode(false)]
        public string Lname { set; get; }

        [MaxLength(20)]
        [Unicode(false)]
        public string Img { set; get; }

        public int SpecializationId { set; get; }
        [ForeignKey(nameof(SpecializationId))]
        public Specialization specialization { set; get; }
    }
}
