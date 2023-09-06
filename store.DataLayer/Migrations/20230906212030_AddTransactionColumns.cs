using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUser",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModifiedUser",
                table: "Products");
        }
    }
}
