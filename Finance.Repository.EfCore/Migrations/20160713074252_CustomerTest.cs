using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Finance.Repository.EfCore.Migrations
{
    public partial class CustomerTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "CustomerTest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTest", x => x.Id);
                });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customers",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "CustomerTest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customer",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");
        }
    }
}
