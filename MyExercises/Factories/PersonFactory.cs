using Models;
using System;

namespace Factories
{

    public static class SchoolMemberFactory
    {
        static string[] firstNames = { "Ralph", "Mike", "Paulina", "Rose", "Carl" };
        static string[] lastNames = { "Simon", "Connor", "Simpsons", "Wasosky", "Smith" };

        public static Person GetSchoolMember()
        {
            var faker = new Bogus.Faker("en");
            SchoolRoles srole = faker.PickRandom<SchoolRoles>();
            PersonFactory factory = null;
            switch (srole)
            {
                case SchoolRoles.Student:
                    factory = new StudentFactory();
                    break;
                case SchoolRoles.Professor:
                    factory = new ProfessorFactory();
                    break;
                case SchoolRoles.Undefined:
                default:
                    factory = new UndefinedFactory();
                    break;
            }

            return factory.CreatePerson(faker.PickRandom(firstNames), faker.PickRandom(lastNames), faker.Random.Int(6, 60));
        }
    }

    public abstract class PersonFactory
    {
        public abstract Person CreatePerson(string firstName, string lastName, int age);
    }

    public class StudentFactory : PersonFactory
    {
        public override Person CreatePerson(string firstName, string lastName, int age)
        {
            Person person = new Student(firstName, lastName, age);
            return person;
        }
    }

    public class ProfessorFactory : PersonFactory
    {
        public override Person CreatePerson(string firstName, string lastName, int age)
        {
            Person person = new Professor(firstName, lastName, age);
            return person;
        }
    }

    public class UndefinedFactory : PersonFactory
    {
        public override Person CreatePerson(string firstName, string lastName, int age)
        {
            Person person = new Professor(firstName, lastName, age);
            return person;
        }
    }
}
