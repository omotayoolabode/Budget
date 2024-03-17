﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.Services.Migrations
{
    /// <inheritdoc />
    public partial class updatedIncome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IncomeDate",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncomeDate",
                table: "Incomes");
        }
    }
}
