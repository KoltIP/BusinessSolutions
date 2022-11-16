using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessSolutions.Data.Context.Migrations;

/// <inheritdoc />
public partial class DateChangeV6 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<DateTime>(
            name: "Date",
            table: "orders",
            type: "timestamp with time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "date");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<DateTime>(
            name: "Date",
            table: "orders",
            type: "date",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");
    }
}
