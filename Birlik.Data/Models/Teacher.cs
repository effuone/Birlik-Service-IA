using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Birlik.Data.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UIN {get; set;}
        [Required]
        public Pedemastership Pedemastership {get; set;}
        public DateTime JoinDate { get; set; }
        [Required]
        public string Email {get; set;}
        [Required]
        public string PhoneNumber {get; set;}
        [ForeignKey("FileModel")]
        public int ResumeId { get; set; }
        public virtual FileModel Resume {get; set;}
        public Teacher()
        {
            
        }
    }
}