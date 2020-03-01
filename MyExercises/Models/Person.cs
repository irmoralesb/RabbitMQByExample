using System;

namespace Models
{
    [Serializable]
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public SchoolRoles SchoolRole { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }

    [Serializable]
    public class Student : Person
    {
        public Student(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
            SchoolRole = SchoolRoles.Student;
        }
    }

    [Serializable]
    public class Professor : Person
    {
        public Professor(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
            SchoolRole = SchoolRoles.Professor;
        }
    }

    [Serializable]
    public class InvalidPerson : Person
    {
        public InvalidPerson(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
            SchoolRole = SchoolRoles.Undefined;
        }
    }
}
