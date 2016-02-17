using System.Collections.Generic;

namespace RailwayOrientedProgramming.DAL
{
    public class ImperativePersonContext
    {
        public static List<Person> People { get; set; } = new List<Person>();

        public static CommandResult<Person> Add(Person p)
        {
            var result = new CommandResult<Person> { Entity = p };
            result.Messages.AddRange(Validate(p));

            if (result.Successful)
            {
                return result;
            }
            p.ID = People.Count + 1;
            People.Add(p);
            return result;
        }

        private static IList<string> ValidateEmail(Person p)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(p.Email))
            {
                errors.Add("Email cannot be empty");
                return errors;
            }
            if (p.Email.Length > 255)
            {
                errors.Add("Email cannot be longer than 255 characters");
            }
            if (!p.Email.Contains("@"))
            {
                errors.Add("Email address must be valid");

            }
            return errors;
        }

        private static IList<string> ValidateFirstName(Person p)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(p.FirstName))
            {
                errors.Add("First name cannot be empty");
                return errors;
            }
            if (p.FirstName.Length > 50)
            {
                errors.Add("First name cannot be longer than 50 characters");
            }
            return errors;
        }

        private static IList<string> ValidateLastName(Person p)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(p.LastName))
            {
                errors.Add("Last name cannot be empty");
                return errors;
            }
            if (p.FirstName.Length > 50)
            {
                errors.Add("Last name cannot be longer than 50 characters");
            }
            return errors;
        }

        private static IList<string> Validate(Person p)
        {
            var errors = new List<string>();
            errors.AddRange(ValidateEmail(p));

            errors.AddRange(ValidateFirstName(p));

            errors.AddRange(ValidateLastName(p));

            return errors;
        }

        public static CommandResult<Person> UglyAdd(Person p)
        {
            var result = new CommandResult<Person> { Entity = p };

            // Check Email
            if (string.IsNullOrEmpty(p.Email))
            {
                result.Messages.Add("Email cannot be empty");
                return result;
            }
            if (p.Email.Length > 255)
            {
                result.Messages.Add("Email cannot be longer than 255 characters");
            }
            if (!p.Email.Contains("@"))
            {
                result.Messages.Add("Email address must be valid");

            }
            if (string.IsNullOrEmpty(p.FirstName))
            {
                result.Messages.Add("First name cannot be empty");
                return result;
            }
            if (p.FirstName.Length > 50)
            {
                result.Messages.Add("First name cannot be longer than 50 characters");
            }
            if (string.IsNullOrEmpty(p.LastName))
            {
                result.Messages.Add("Last name cannot be empty");
                return result;
            }
            if (p.FirstName.Length > 50)
            {
                result.Messages.Add("Last name cannot be longer than 50 characters");
            }

            if (result.Successful)
            {
                return result;
            }
            p.ID = People.Count + 1;
            People.Add(p);
            return result;
        }
    }
}