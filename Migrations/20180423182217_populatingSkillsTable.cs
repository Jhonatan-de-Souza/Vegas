using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vega.Migrations
{
    public partial class populatingSkillsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(50, 'hit the the enemy from a distance', 'Meteor Shower')");
            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(80, 'hit the the enemy from a distance', 'Thunder Bolt')");
            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(50, 'hit the the enemy from a distance', 'Coin Toss')");
            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(50, 'hit the the enemy from a distance', 'Summon Police')");
            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(50, 'hit the the enemy from a distance', 'Do Battime')");
            migrationBuilder.Sql("INSERT INTO \"Skills\"(\"AttackRange\", \"Description\", \"Name\") values(50, 'hit the the enemy from a distance', 'Cast Defense Shield')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
