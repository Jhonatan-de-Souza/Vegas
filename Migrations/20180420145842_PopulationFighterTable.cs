using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vega.Migrations
{
    public partial class PopulationFighterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.Sql("INSERT INTO \"Fighters\" (\"Name\",\"Power\",\"Speed\") Values ('Jet Lee','9000','1000')");
                migrationBuilder.Sql("INSERT INTO \"Fighters\" (\"Name\",\"Power\",\"Speed\") Values ('Bruce','9500','1500')");
                migrationBuilder.Sql("INSERT INTO \"Fighters\" (\"Name\",\"Power\",\"Speed\") Values ('Jon','15000','2000')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}

