using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations.Mappings
{
    public class VehicleMapping : BaseMapping<Vehicle>
    {
        public VehicleMapping() : base()
        {
            Table("vehicle");
            Map(x => x.Description).Column("descricao").Length(255).Not.Nullable();
            Map(x => x.ManufactureYear).Column("manufacture_year").Not.Nullable();
            Map(x => x.ModelYear).Column("model_year").Not.Nullable();

            References(x => x.Manufacturer)
                .Column("manufacturer_id")
                .Nullable().LazyLoad()
                .Cascade.None();

            References(x => x.Model)
                .Column("model_id")
                .Nullable().LazyLoad()
                .Cascade.None();
        }
    }
}
