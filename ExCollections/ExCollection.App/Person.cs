using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExCollection.App
{
    public abstract class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"Full Name: {FirstName} {LastName}";
            }
        }

        public Person() { }
        
        public Person(int id)
        {
            Id = id;
        }

        public virtual string GetAllInfo()
        {
            return $"{Id}{FirstName}{LastName}{FullName}";
        }

        public abstract string GetArriveType();
    }
}
