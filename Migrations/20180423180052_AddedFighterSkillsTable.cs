using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vega.Migrations
{
    public partial class AddedFighterSkillsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Fighters_FighterId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_FighterId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "FighterId",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "FighterSkills",
                columns: table => new
                {
                    FighterId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    SkillsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FighterSkills", x => new { x.FighterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_FighterSkills_Fighters_FighterId",
                        column: x => x.FighterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FighterSkills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FighterSkills_SkillsId",
                table: "FighterSkills",
                column: "SkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FighterSkills");

            migrationBuilder.AddColumn<int>(
                name: "FighterId",
                table: "Skills",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_FighterId",
                table: "Skills",
                column: "FighterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Fighters_FighterId",
                table: "Skills",
                column: "FighterId",
                principalTable: "Fighters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
