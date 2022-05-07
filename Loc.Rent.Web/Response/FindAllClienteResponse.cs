using System;

namespace Loc.Rent.Web.Response
{
    public class FindAllClienteResponse
    {
        public FindAllClienteResponse(string name, DateTime birhtdayDate, string driverLicense)
        {
            Name = name;
            BirhtdayDate = birhtdayDate;
            DriverLicense = driverLicense;
        }

        public string Name { get; set; }
        public DateTime BirhtdayDate { get; set; }
        public string DriverLicense { get; set; }
    }
}
