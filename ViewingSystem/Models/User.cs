using System;
using System.Collections.Generic;
using System.Text;

namespace ViewingSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Caller> Callers { get; set; }
    }
}
