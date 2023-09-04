using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using PatientServices.Models;

namespace PatientServices.Services
{
    public class PatientService
    {
        public enum Gender
        {
            Male,
            Female
        }

        public Patient CreatePatient()
        {
            

            var patientFaker = new Faker<Patient>()
                //Basic rules using built-in generators
                .RuleFor(u => u.Id, (f) => { Random rnd = new Random(); int number = rnd.Next(1, 9999999); return number; })
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(u => u.DOB, f => { Random rnd = new Random(); int number = rnd.Next(1, 10); return DateTime.UtcNow.AddMonths(-number); })
                .FinishWith((f, u) =>
                {
                    Console.WriteLine("User Created! Id={0}", u.Id);
                });

            var patient = patientFaker.Generate();

            // Create a Bogus data generator for addresses
            var addressFaker = new Faker<Address>()
                .RuleFor(a => a.Address1, (f, a) => f.Address.StreetAddress())
                .RuleFor(a => a.City, (f, a) => f.Address.City())
                .RuleFor(a => a.State, (f, a) => f.Address.StateAbbr())
                .RuleFor(a => a.Zip, (f, a) => f.Address.ZipCode());

            // Generate a sample address
            var sampleAddress = addressFaker.Generate();

            patient.Address = sampleAddress;

            return patient;


        }

    }
}
