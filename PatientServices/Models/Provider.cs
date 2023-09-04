using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientServices.Models
{
    public  class Provider
    {
        public int Id { get; set; }
        public string FirstName { get; set; }  = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NPI { get; set; } = string.Empty;
        public Contact? Contact { get; set; }
        public IEnumerable<Address> AddressList { get; set; } = Enumerable.Empty<Address>();
    }
}
