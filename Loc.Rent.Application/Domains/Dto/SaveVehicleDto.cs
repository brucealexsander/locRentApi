namespace Loc.Rent.ApplicationCore.Domains.Dto
{
    public class SaveVehicleDto
    {
        public SaveVehicleDto(string plate, string description, int manufactureYear, int modelYear, int modelId)
        {
            Plate = plate;
            Description = description;
            ManufactureYear = manufactureYear;
            ModelYear = modelYear;
            ModelId = modelId;
        }

        public string Plate { get; set; }
        public string Description { get; set; }
        public int ManufactureYear { get; set; }
        public int ModelYear { get; set; }
        public int ModelId { get; set; }
    }
}
