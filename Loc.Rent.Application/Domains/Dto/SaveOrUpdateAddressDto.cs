namespace Loc.Rent.ApplicationCore.Domains.Dto
{
    public class SaveOrUpdateAddressDto
    {
        public SaveOrUpdateAddressDto(string street, string number, string neighborhood, string complement, string zipCode, int cityId)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            Complement = complement;
            ZipCode = zipCode;
            CityId = cityId;
        }

        public SaveOrUpdateAddressDto(int? id, string street, string number, string neighborhood, string complement, string zipCode, int clientId, int cityId)
        {
            Id = id;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            Complement = complement;
            ZipCode = zipCode;
            ClientId = clientId;
            CityId = cityId;
        }

        public int? Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public int ClientId { get; set; }
        public int CityId { get; set; }
    }
}
