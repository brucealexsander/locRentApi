using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations.Mappings
{
    public class ModelMapping : BaseMapping<Model>
    {
        public ModelMapping() : base()
        {
            Table("model");
            Map(x => x.Name).Column("name").Length(255).Not.Nullable();
            
            References(x => x.Manufacturer)
                .Column("manufacturer_id")
                .Nullable().LazyLoad()
                .Cascade.None();
        }
    }
}
