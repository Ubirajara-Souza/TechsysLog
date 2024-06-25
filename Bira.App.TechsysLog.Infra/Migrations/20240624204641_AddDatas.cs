using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bira.App.TechsysLog.Infra.Migrations
{
    public partial class AddDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataUpdate",
                table: "Pedidos",
                type: "timestamp(7) without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeactivation",
                table: "Pedidos",
                type: "timestamp(7) without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelivery",
                table: "Pedidos",
                type: "timestamp(7) without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegister",
                table: "Pedidos",
                type: "timestamp(7) without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUpdate",
                table: "Enderecos",
                type: "timestamp(7) without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeactivation",
                table: "Enderecos",
                type: "timestamp(7) without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegister",
                table: "Enderecos",
                type: "timestamp(7) without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataUpdate",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DateDeactivation",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DateDelivery",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DateRegister",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DataUpdate",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DateDeactivation",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DateRegister",
                table: "Enderecos");
        }
    }
}
