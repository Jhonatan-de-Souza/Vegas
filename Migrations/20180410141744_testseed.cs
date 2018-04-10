using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vegas.Migrations
{
    public partial class testseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Makes\" (\"Name\") Values ('Honda')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
