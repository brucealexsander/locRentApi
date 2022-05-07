using System;

namespace Loc.Rent.Web.Request
{
    public class SaveClientRequest
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string DriverLicense { get; set; }
        public UpdateAddressRequest Address { get; set; }
    }
}
