using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM2.Migrations
{
    public partial class v31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Carts_UserId",
                table: "CartDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CartDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Carts_UserId",
                table: "CartDetails",
                column: "UserId",
                principalTable: "Carts",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Carts_UserId",
                table: "CartDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CartDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Carts_UserId",
                table: "CartDetails",
                column: "UserId",
                principalTable: "Carts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
