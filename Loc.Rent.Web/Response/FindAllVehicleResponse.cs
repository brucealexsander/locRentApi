namespace Loc.Rent.Web.Response
{
    public class FindAllVehicleResponse
    {
        public FindAllVehicleResponse(string description, int manufactureYear, int modelYear, string model, string manufacturer)
        {
            Description = description;
            ManufactureYear = manufactureYear;
            ModelYear = modelYear;
            Model = model;
            Manufacturer = manufacturer;
        }

        public string Description { get; set; }
        public int ManufactureYear { get; set; }
        public int ModelYear { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
    }
}
