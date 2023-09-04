using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientServices.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string Group { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
    }
}
