using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vega.Migrations
{
    public partial class RenamedSkillColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FighterSkills_Skills_SkillId",
                table: "FighterSkills");

            migrationBuilder.DropIndex(
                name: "IX_FighterSkills_SkillId",
                table: "FighterSkills");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "FighterSkills");

            migrationBuilder.CreateIndex(
                name: "IX_FighterSkills_SkillId",
                table: "FighterSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_FighterSkills_Skill_SkillId",
                table: "FighterSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FighterSkills_Skills_SkillId",
                table: "FighterSkills");

            migrationBuilder.DropIndex(
                name: "IX_FighterSkills_SkillId",
                table: "FighterSkills");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "FighterSkills",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FighterSkills_SkillId",
                table: "FighterSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_FighterSkills_Skills_SkillId",
                table: "FighterSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
