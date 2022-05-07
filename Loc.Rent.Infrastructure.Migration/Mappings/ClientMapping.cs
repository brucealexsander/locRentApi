﻿using Loc.Rent.ApplicationCore.Domains;
using Loc.Rent.Infrastructure.Data.Migrations.Mappings.Base;

namespace Loc.Rent.Infrastructure.Data.Migrations.Mappings
{
    public class ClientMapping : BaseMapping<Client>
    {
        public ClientMapping() : base()
        {
            Table("client");
            Map(x => x.Cpf).Column("cpf").Length(14).Not.Nullable();
            Map(x => x.Name).Column("name").Length(255).Not.Nullable();
            Map(x => x.BirthdayDate).Column("birthday_date").Not.Nullable();
            Map(x => x.DriverLicense).Column("driver_license").Not.Nullable();

            HasMany(x => x.Reservations)
                .KeyColumn("reservation_id")
                .LazyLoad().Inverse()
                .Fetch.Subselect()
                .Cascade.SaveUpdate();
        }
    }
}
