using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loc.Rent.Web.Request
{
    public class UpdateAddressRequest
    {
        public int? Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public int? ClientId { get; set; }
        public int CityId { get; set; }
    }
}
