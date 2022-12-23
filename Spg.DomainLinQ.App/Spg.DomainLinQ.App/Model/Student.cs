using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * RegistrationNumber
    /// * FirstName
    /// * LastName
    /// * EMail
    /// * Address
    /// * PhoneNumber
    /// * AccountName = [Die ersten 5 Stellen des LastName + RegistrationNumber]
    /// * Gender
    /// * Guid
    /// (4P)s
    /// </summary>
    public class Student : EntityBase
    {
        // TODO: Implementation
        private List<Subject> _subjects = new();

        public int Id { get; private set; }
        //public long RegistrationNumber { get; private set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public Address Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        //public string AccountName => LastName.Substring(0, 4) + RegistrationNumber.ToString();
        public Gender Gender { get; set; }
        public Guid Guid { get; private set; }
        public int SchoolClassNavigationId { get; set; }
        public virtual SchoolClass SchoolClassNavigation { get; set; } = default!;
        public virtual IReadOnlyList<Subject> Subjects => _subjects;

        protected Student()
        { }

        public Student(long registrationNumber, 
            Guid guid,
            string firstName, 
            string lastName, 
            string eMail, 
            Gender gender,
            SchoolClass schoolClass,
            Address address,
            PhoneNumber phoneNumber)
        {
            //RegistrationNumber = registrationNumber;
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            Gender = gender;
            Guid = guid;
            SchoolClassNavigation = schoolClass;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public void AddSubjects(List<Subject> subjects)
        {
            _subjects.AddRange(subjects);
        }
    }
}
