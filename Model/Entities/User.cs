using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Model.Enum;

namespace File_ConsoleC.Model.Entities
{
    public class User : BaseEntity
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;
        public string PhoneNumber;
        public DateOnly Dob;
        public Gender Gender;

        public string Role;
        public User(int id, string firstName, string lastName, string email, string password, string phoneNumber, DateOnly dob, Gender gender, string role) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Dob = dob;
            Gender = gender;
            Role = role;
        }
        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Email} {Password} {PhoneNumber} {Dob} {Gender} {Role}";
        }
    }
}