using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vega.Migrations
{
    public partial class Re_SeedingDatabaseAfterNuke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Makes\" (\"Name\") Values ('Honda')");

            migrationBuilder.Sql("INSERT INTO \"Features\"(\"Name\") Values('Feature1')");
            migrationBuilder.Sql("INSERT INTO \"Features\"(\"Name\") Values('Feature2')");
            migrationBuilder.Sql("INSERT INTO \"Features\"(\"Name\") Values('Feature3')");

            migrationBuilder.Sql("INSERT INTO \"Fighters\" (\"Name\",\"Power\",\"Speed\",\"DateOfBirth\",\"IsFinalForm\") Values ('Jet Lee','9000','1000','05/05/1998 23:59:59.995',true)");
            migrationBuilder.Sql("INSERT INTO \"Fighters\" (\"Name\",\"Power\",\"Speed\",\"DateOfBirth\",\"IsFinalForm\") Values ('Vegeta','9000','1000','05/05/1998 23:59:59.995',true)");
            migrationBuilder.Sql("INSERT INTO \"Fighters\" (\"Name\",\"Power\",\"Speed\",\"DateOfBirth\",\"IsFinalForm\") Values ('Picollo','9000','1000','05/05/1998 23:59:59.995',true)");

            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(50, 'hit the the enemy from a distance', 'Meteor Shower')");
            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(80, 'hit the the enemy from a distance', 'Thunder Bolt')");
            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(50, 'hit the the enemy from a distance', 'Coin Toss')");
            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(50, 'hit the the enemy from a distance', 'Summon Police')");
            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(50, 'hit the the enemy from a distance', 'Do Battime')");
            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(50, 'hit the the enemy from a distance', 'Cast Defense Shield')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Features\" where \"Name\" in ('Feature1','Feature2','Feature3')");
        }
    }
}
