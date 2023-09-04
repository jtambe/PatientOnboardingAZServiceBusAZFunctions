using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientServices.Models
{
    public class Patient
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public Address? Address { get; set; }
        public Insurance? Insurance { get; set; }
        public Contact? Contact { get; set; }
    }
}
