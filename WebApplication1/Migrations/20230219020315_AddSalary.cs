﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearch.App.Migrations
{
    public partial class AddSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Jobs",
                newName: "InitalSalary");

            migrationBuilder.AddColumn<double>(
                name: "FinalSalary",
                table: "Jobs",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalSalary",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "InitalSalary",
                table: "Jobs",
                newName: "Salary");

        }
    }
}
