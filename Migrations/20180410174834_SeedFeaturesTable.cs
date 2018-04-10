using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vegas.Migrations
{
    public partial class SeedFeaturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Features\"(\"Name\") Values('Feature1')");
            migrationBuilder.Sql("INSERT INTO \"Features\"(\"Name\") Values('Feature2')");
            migrationBuilder.Sql("INSERT INTO \"Features\"(\"Name\") Values('Feature3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Features\" where \"Name\" in ('Feature1','Feature2','Feature3')");
        }
    }
}
