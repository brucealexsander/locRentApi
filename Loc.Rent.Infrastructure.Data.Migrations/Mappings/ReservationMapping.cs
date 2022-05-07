using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations.Mappings
{
    public class ReservationMapping : BaseMapping<Reservation>
    {
        public ReservationMapping() : base()
        {
            Table("reservation");
            Map(x => x.WithdrawalDate).Column("withdrawal_date").Not.Nullable();
            Map(x => x.ExpectedDateReturn).Column("expected_date_return").Nullable();

            References(x => x.Client)
            .Column("client_id")
            .Nullable()
            .LazyLoad()
            .Cascade.SaveUpdate();

            References(x => x.Vehicle)
            .Column("vehicle_id")
            .Nullable()
            .LazyLoad()
            .Cascade.SaveUpdate();
        }
    }
}
