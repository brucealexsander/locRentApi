using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations.Mappings
{
    public class StateMapping : BaseMapping<State>
    {
        public StateMapping() : base()
        {
            Table("state");
            Map(x => x.Name).Column("name").Length(255).Not.Nullable();
            Map(x => x.Initials).Column("initials").Length(255).Not.Nullable();

            References(x => x.Country)
                .Column("country_id")
                .Nullable().LazyLoad()
                .Cascade.None();

            HasMany(x => x.Cities)
            .KeyColumn("state_id")
            .LazyLoad().Inverse()
            .Fetch.Subselect()
            .Cascade.AllDeleteOrphan();
        }
    }
}
