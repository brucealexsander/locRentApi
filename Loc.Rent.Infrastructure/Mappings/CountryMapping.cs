using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations.Mappings
{
    public class CountryMapping : BaseMapping<Country>
    {
        public CountryMapping() : base()
        {
            Table("country");
            Map(x => x.Name).Column("name").Length(255).Not.Nullable();

            HasMany(x => x.States)
            .KeyColumn("country_id")
            .LazyLoad().Inverse()
            .Fetch.Subselect()
            .Cascade.AllDeleteOrphan();
        }
    }
}
