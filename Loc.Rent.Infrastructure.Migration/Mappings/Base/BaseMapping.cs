using FluentNHibernate.Mapping;
using Loc.Rent.Domain.Entities.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base
{
    public abstract class BaseMapping<T> : ClassMap<T> where T : EntityBase
    {
        public BaseMapping()
        {
            Id(x => x.Id).Column("id").GeneratedBy.Identity();
        }
    }
}
