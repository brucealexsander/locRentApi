using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations.Mappings
{
    public class ManufacturerMapping : BaseMapping<Manufacturer>
    {
        public ManufacturerMapping() : base()
        {
            Table("manufacturer");
            Map(x => x.Name).Column("nome").Length(255).Not.Nullable();            

            HasMany(x => x.Models)
            .KeyColumn("manufacturer_id")
            .LazyLoad().Inverse()
            .Fetch.Subselect()
            .Cascade.AllDeleteOrphan();
        }
    }
}
