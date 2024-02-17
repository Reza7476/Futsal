using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futsal.Migrations;
[Migration(202402171852)]
public class _202402171852_ModifedPlayer :Migration

{
    public override void Up()
    {
        Alter.Table("Players")
            .AddColumn("Role").AsInt32().NotNullable();
    }
    public override void Down()
    {
        Delete.Column("Role").FromTable("Players");

    }
}
