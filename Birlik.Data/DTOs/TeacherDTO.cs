using Birlik.Data.Models;
using Microsoft.AspNetCore.Http;

namespace Birlik.Data.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UIN {get; set;}
        public string Pedemastership {get; set;}
        public DateOnly JoinDate { get; set; }
        public string Email {get; set;}
        public string PhoneNumber {get; set;}
        public string Resume {get; set;}
    }
    public class CreateTeacherDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UIN {get; set;}
        public int Pedemastership {get; set;}
        public DateOnly JoinDate { get; set; }
        public string Email {get; set;}
        public string PhoneNumber {get; set;}
        public IFormFile Resume {get; set;}
    }
    public class UpdateTeacherDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UIN {get; set;}
        public int Pedemastership {get; set;}
        public DateOnly JoinDate { get; set; }
        public string Email {get; set;}
        public string PhoneNumber {get; set;}
        public IFormFile Resume {get; set;}
    }
}