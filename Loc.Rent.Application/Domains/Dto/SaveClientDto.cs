using System;

namespace Loc.Rent.ApplicationCore.Domains.Dto
{
    public class SaveClientDto
    {
        public SaveClientDto(string name, string cpf, DateTime birthdayDate, string driverLicense)
        {
            Name = name;
            Cpf = cpf;
            BirthdayDate = birthdayDate;
            DriverLicense = driverLicense;
        }

        public virtual string Name { get; set; }
        public virtual string Cpf { get; set; }
        public virtual DateTime BirthdayDate { get; set; }
        public virtual string DriverLicense { get; set; }
        public virtual SaveOrUpdateAddressDto Address { get; set; }
    }
}
