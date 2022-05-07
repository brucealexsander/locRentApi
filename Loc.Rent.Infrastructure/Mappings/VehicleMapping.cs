using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations.Mappings
{
    public class VehicleMapping : BaseMapping<Vehicle>
    {
        public VehicleMapping() : base()
        {
            Table("vehicle");
            Map(x => x.Plate).Column("plate").Length(255).Not.Nullable();
            Map(x => x.Description).Column("description").Length(255).Not.Nullable();
            Map(x => x.ManufactureYear).Column("manufacturer_year").Not.Nullable();
            Map(x => x.ModelYear).Column("model_year").Not.Nullable();

            References(x => x.Model)
                .Column("model_id")
                .Nullable()
                .LazyLoad()
                .Cascade.SaveUpdate();

            HasMany(x => x.Reservations)
                .KeyColumn("vehicle_id")
                .LazyLoad().Inverse()
                .Fetch.Subselect()
                .Cascade.SaveUpdate();
        }
    }
}
