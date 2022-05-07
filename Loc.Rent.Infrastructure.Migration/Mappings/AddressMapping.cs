using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations
{
    public class AddressMapping : BaseMapping<Address>
    {
        public AddressMapping() : base()
        {
            Table("address");

            Map(x => x.ZipCode).Column("zip_code").Length(10).Not.Nullable();
            Map(x => x.Complement).Column("complement").Length(255).Not.Nullable();
            Map(x => x.Neighborhood).Column("neighborhood").Length(255).Not.Nullable();
            Map(x => x.Number).Column("number").Length(255).Not.Nullable();
            Map(x => x.Street).Column("street").Length(255).Not.Nullable();

            References(x => x.City)
            .Column("city_id")
            .Nullable().LazyLoad()
            .Cascade.None();
        }
    }
}
