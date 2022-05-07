using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations.Mappings
{
    public class ReservationMapping : BaseMapping<Reservation>
    {
        public ReservationMapping() : base()
        {
            Table("reservation");
            Map(x => x.Date).Column("date").Not.Nullable();            
            Map(x => x.WithdrawalDate).Column("withdrawal_date").Nullable();
            Map(x => x.ExpectedDateReturn).Column("expected_date_return").Not.Nullable();
            Map(x => x.ReturnDate).Column("return_date").Nullable();

            References(x => x.Client)
            .Column("client_id")
            .Nullable()
            .LazyLoad()
            .Cascade.None();

            References(x => x.Vehicle)
            .Column("vehicle_id")
            .Nullable()
            .LazyLoad()
            .Cascade.None();
        }
    }
}
