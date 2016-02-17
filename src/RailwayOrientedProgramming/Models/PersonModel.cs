using System.Collections.Generic;
using RailwayOrientedProgramming.DAL;

namespace RailwayOrientedProgramming.Models
{
    public class PersonModel
    {
        public string Email { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<string> Messages { get; set; }

        public PersonModel()
        {
            Messages = new List<string>();
        }

        public Person ToPerson()
        {
            return new Person
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email
            };
        }
    }
}