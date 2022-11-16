using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessSolutions.Data.Context.Migrations;

/// <inheritdoc />
public partial class DateChangeV2 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "Date",
            table: "orders",
            type: "timestamp with time zone",
            nullable: false,
            oldClrType: typeof(DateOnly),
            oldType: "date");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<DateOnly>(
            name: "Date",
            table: "orders",
            type: "date",
            nullable: false,
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone");
    }
}
