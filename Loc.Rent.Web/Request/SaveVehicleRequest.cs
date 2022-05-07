namespace Loc.Rent.Web.Request
{
    public class SaveVehicleRequest
    {
        public string Plate { get; set; }
        public string Description { get; set; }
        public int ManufactureYear { get; set; }
        public int ModelYear { get; set; }
        public int ModelId { get; set; }
    }
}
