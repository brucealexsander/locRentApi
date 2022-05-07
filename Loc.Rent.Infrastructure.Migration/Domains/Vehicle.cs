using Loc.Rent.Domain.Entities.Base;

namespace Loc.Rent.ApplicationCore.Domains
{
    public class Vehicle : EntityBase
    {
        public virtual int Description { get; set; }  
        public virtual int ManufactureYear { get; set; }
        public virtual int ModelYear { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }               
        public virtual Model Model { get; set; }
    }
}
