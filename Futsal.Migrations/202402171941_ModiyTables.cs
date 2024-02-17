using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futsal.Migrations;
[Migration(202402171941)]
public class _202402171941_ModiyTables :Migration
{
    public override void Up()
    {
        Alter.Table("Players")
            .AlterColumn("TeamId").AsInt32().Nullable();
    }

    public override void Down()
    {
        Alter.Table("Players")
            .AlterColumn("TeamId").AsInt32().NotNullable();
    }
}
