using FluentMigrator;

namespace Futsal.Migrations;
[Migration(202402171700)]
public class _202402171700_CreatedTables : Migration
{
    public override void Up()
    {
        Create.Table("Teams")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("Name").AsString().NotNullable()
             .WithColumn("ColorDressOrigin").AsInt32().NotNullable()
             .WithColumn("ColorDressNormal").AsInt32().NotNullable();
        Create.Table("Players")
         .WithColumn("Id").AsInt32().PrimaryKey().Identity()
         .WithColumn("Name").AsString().NotNullable()
         .WithColumn("BirthDate").AsDateTime2().NotNullable()
         .WithColumn("TeamId").AsInt32().NotNullable()
         .ForeignKey("FK_Players_Teams", "Teams", "Id");


    }
    public override void Down()
    {
        Delete.Table("Player");
        Delete.Table("Teams");
    }

}
