using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations.Mappings
{
    public class CityMapping : BaseMapping<City>
    {
        public CityMapping() : base()
        {
            Table("city");
            Map(x => x.Name).Column("name").Length(255).Not.Nullable();

            References(x => x.State)
                .Column("state_id")
                .Nullable().LazyLoad()
                .Cascade.None();
        }
    }
}
