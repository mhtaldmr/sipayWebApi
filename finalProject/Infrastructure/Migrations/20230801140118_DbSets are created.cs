using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DbSetsarecreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_AspNetUsers_UserId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_FlatType_FlatTypeId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Apartment_ApartmentId",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartment",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "Apartment",
                newName: "Apartments");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_ApartmentId",
                table: "Invoices",
                newName: "IX_Invoices_ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Apartment_UserId",
                table: "Apartments",
                newName: "IX_Apartments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Apartment_FlatTypeId",
                table: "Apartments",
                newName: "IX_Apartments_FlatTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_AspNetUsers_UserId",
                table: "Apartments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_FlatType_FlatTypeId",
                table: "Apartments",
                column: "FlatTypeId",
                principalTable: "FlatType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Apartments_ApartmentId",
                table: "Invoices",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_AspNetUsers_UserId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_FlatType_FlatTypeId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Apartments_ApartmentId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameTable(
                name: "Apartments",
                newName: "Apartment");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ApartmentId",
                table: "Invoice",
                newName: "IX_Invoice_ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Apartments_UserId",
                table: "Apartment",
                newName: "IX_Apartment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Apartments_FlatTypeId",
                table: "Apartment",
                newName: "IX_Apartment_FlatTypeId");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartment",
                table: "Apartment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_AspNetUsers_UserId",
                table: "Apartment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_FlatType_FlatTypeId",
                table: "Apartment",
                column: "FlatTypeId",
                principalTable: "FlatType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Apartment_ApartmentId",
                table: "Invoice",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
