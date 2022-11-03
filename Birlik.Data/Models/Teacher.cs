namespace Birlik.Data.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UIN {get; set;}
        public Pedemastership Pedemastership {get; set;}
        public DateOnly JoinDate { get; set; }
        public string Email {get; set;}
        public string PhoneNumber {get; set;}
        public FileModel Resume {get; set;}
        public Teacher()
        {
            
        }
    }
}