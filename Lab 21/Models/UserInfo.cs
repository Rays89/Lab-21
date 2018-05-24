using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_21.Models
{
    public class UserInfo
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private string password;

        [Required]
        public string FirstName
        {
            set { firstName = value; }
            get { return firstName; }
        }

        [Required]
        public string LastName
        {
            set { lastName = value; }
            get { return lastName; }
        }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Bad Email!")]
        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        [Required]
        public string PhoneNumber
        {
            set { phoneNumber = value; }
            get { return phoneNumber; }
        }

        [Required]
        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public UserInfo()
        {

        }

        public UserInfo(string firstName, string lastNmae, string email, string phoneNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;

        }
    }
}