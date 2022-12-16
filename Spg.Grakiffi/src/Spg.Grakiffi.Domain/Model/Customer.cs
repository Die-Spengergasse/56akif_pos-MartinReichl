using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Grakiffi.Domain.Model
{
    public enum Genders { Male = 0, Female = 1, Other = 2 }

    public class Customer
    {
        private List<ShoppingCart> _shoppingCarts = new();

        public int Id { get; private set; }
        public Genders Gender { get; set; }
        public string CustomerNumber { get; private set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public Address? Address { get; set; } = default!;
        public string? TelephoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public DateTime RegistrationDateTime { get; private set; }
        public IReadOnlyList<ShoppingCart> ShoppingCarts  => _shoppingCarts;

        public Customer(Genders gender, 
                        string customerNumber, 
                        string firstName, 
                        string lastName, 
                        string eMail, 
                        DateTime birthDate, 
                        DateTime registrationDateTime)
        {
            Gender = gender;
            CustomerNumber = customerNumber;
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            BirthDate = birthDate;
            RegistrationDateTime = registrationDateTime;
        }

        protected Customer()
        { }
    }
}
