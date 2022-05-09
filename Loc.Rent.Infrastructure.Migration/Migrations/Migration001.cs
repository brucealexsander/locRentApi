using FluentMigrator;
using System;

namespace Loc.Rent.Infrastructure.Migration.Migrations
{
    [Migration(1)]
    public class Migration001 : FluentMigrator.Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            PerformCreateTables();
        }

        private void PerformCreateTables()
        {
            if (!Schema.Table("client").Exists())
            {
                Create.Table("client")
                    .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
                    .WithColumn("name").AsString(255).NotNullable()
                    .WithColumn("cpf").AsString(14).Unique().NotNullable()
                    .WithColumn("birthday_date").AsDateTime().NotNullable()
                    .WithColumn("driver_license").AsString(255).NotNullable()
                    .WithColumn("address_id").AsInt32().NotNullable();
            }
            if (!Schema.Table("manufacturer").Exists())
            {
                Create.Table("manufacturer")
                    .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
                    .WithColumn("name").AsString(255).NotNullable();
            }

            if (!Schema.Table("model").Exists())
            {
                Create.Table("model")
                    .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
                    .WithColumn("name").AsString(255).NotNullable()
                    .WithColumn("manufacturer_id").AsInt32().NotNullable();
            }

            if (!Schema.Table("reservation").Exists())
            {
                Create.Table("reservation")
                    .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
                    .WithColumn("date").AsDateTime().NotNullable()
                    .WithColumn("withdrawal_date").AsDateTime().Nullable()
                    .WithColumn("expected_date_return").AsDateTime().NotNullable()
                    .WithColumn("return_date").AsDateTime().Nullable()
                    .WithColumn("client_id").AsInt32().NotNullable()
                    .WithColumn("vehicle_id").AsInt32().NotNullable();
            }

            if (!Schema.Table("vehicle").Exists())
            {
                Create.Table("vehicle")
                    .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
                    .WithColumn("plate").AsString(255).NotNullable()
                    .WithColumn("description").AsString(255).NotNullable()
                    .WithColumn("manufacture_year").AsInt32().NotNullable()
                    .WithColumn("model_year").AsInt32().NotNullable()
                    .WithColumn("model_id").AsInt32().NotNullable();
            }

            if (!Schema.Table("address").Exists())
            {
                Create.Table("address")
                    .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
                    .WithColumn("street").AsString(255).NotNullable()
                    .WithColumn("number").AsString(255).NotNullable()
                    .WithColumn("neighborhood").AsString(255).NotNullable()
                    .WithColumn("complement").AsString().Nullable()
                    .WithColumn("zip_code").AsString().NotNullable()
                    .WithColumn("city_id").AsInt32().NotNullable();
            }

            if (!Schema.Table("city").Exists())
            {
                Create.Table("city")
                    .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
                    .WithColumn("name").AsString(255).NotNullable()
                    .WithColumn("state_id").AsInt32().NotNullable();
            }

            if (!Schema.Table("state").Exists())
            {
                Create.Table("state")
                    .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
                    .WithColumn("name").AsString(255).NotNullable()
                    .WithColumn("initials").AsString(255).Unique().NotNullable()
                    .WithColumn("country_id").AsInt32().NotNullable();
            }

            if (!Schema.Table("country").Exists())
            {
                Create.Table("country")
                    .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
                    .WithColumn("name").AsString(255).NotNullable();
            }
        }
    }
}
