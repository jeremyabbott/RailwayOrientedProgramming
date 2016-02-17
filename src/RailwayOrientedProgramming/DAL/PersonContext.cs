using System;
using System.Collections.Generic;
using System.Linq;
using Chessie.ErrorHandling;
using Chessie.ErrorHandling.CSharp;

namespace RailwayOrientedProgramming.DAL
{
    public class PersonContext
    {
        // In memory storage
        public static List<Person> People { get; set; } = new List<Person>();

        private static Result<Person, string> ValidateEmail(Person p)
        {
            if (string.IsNullOrEmpty(p.Email))
            {
                return Result<Person, string>.FailWith("Email cannot be empty");
            }
            if (p.Email.Length > 255)
            {
                return Result<Person, string>.FailWith("Email cannot be longer than 255 characters");
            }
            if (!p.Email.Contains("@"))
            {
                return Result<Person, string>.FailWith("Email address must be valid");

            }
            return Result<Person, string>.Succeed(p);
        }

        private static Result<Person, string> ValidateFirstName(Person p)
        {
            if (string.IsNullOrEmpty(p.FirstName))
            {
                return Result<Person, string>.FailWith("First name cannot be empty");
            }
            if (p.FirstName.Length > 50)
            {
                return Result<Person, string>.FailWith("First name cannot be longer than 50 characters");
            }
            return Result<Person, string>.Succeed(p);
        }

        private static Result<Person, string> ValidateLastName(Person p)
        {
            if (string.IsNullOrEmpty(p.LastName))
            {
                return Result<Person, string>.FailWith("Last name cannot be empty");
            }
            if (p.LastName.Length > 50)
            {
                return Result<Person, string>.FailWith("Last name cannot be longer than 50 characters");
            }
            return Result<Person, string>.Succeed(p);
        }

        // use map to adapt One track function that doesn't need error handling
        private static Person StandardizeEmail(Person p)
        {
            p.Email = p.Email.ToLower().Trim();
            return p;
        }

        private static Person Save(Person p)
        {
            p.ID = People.Count + 1;
            People.Add(p);
            return p;
        }

        // Fail fast (at the first failure)
        public static Result<Person, string> Validate(Person p)
        {
            return from a in ValidateEmail(p)
                   from b in ValidateFirstName(a)
                   from c in ValidateLastName(b)
                   select c;
        }

        // Get all failures
        // The individual functions themselves did not change to get this behavior
        // Only change was in how they were composed.
        public static Result<Person, string> ValidateAll(Person p)
        {
            return from a in ValidateEmail(p)
                   join b in ValidateFirstName(p) on 1 equals 1
                   join c in ValidateLastName(p) on 1 equals 1
                   select c;
        }

        public static Result<Person, string> ValidateAllFunc(Person p)
        {
            return new List<Func<Person, Result<Person, string>>> { ValidateEmail, ValidateFirstName, ValidateLastName }
                   .Select(check => check(p))
                   .Collect()
                   .Select(x => x[0]);
        }

        public static Result<Person, string> Add(Person p)
        {
            //ValidateP
            //ValidateAll(p);
            return ValidateAllFunc(p)
                            .Select(pe => StandardizeEmail(pe)) // one track function (use select/map)
                            .Map(pe => Save(p)); // another one track function (use select/map)
        }
    }
}