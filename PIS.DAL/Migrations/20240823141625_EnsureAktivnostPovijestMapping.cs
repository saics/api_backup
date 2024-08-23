using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIS.DAL.Migrations
{
    public partial class EnsureAktivnostPovijestMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OriginalAktivnostId",
                table: "AktivnostPovijest",
                newName: "OriginalAktivnostID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AktivnostPovijest",
                newName: "ID");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProsjecnaOcjena",
                table: "AktivnostPovijest",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "AktivnostPovijest",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "AktivnostPovijest",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MedijanOcjena",
                table: "AktivnostPovijest",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "AktivnostPovijest",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_AktivnostPovijest_EventPovijestId",
                table: "AktivnostPovijest",
                column: "EventPovijestId");

            migrationBuilder.CreateIndex(
                name: "IX_AktivnostPovijest_OriginalAktivnostID",
                table: "AktivnostPovijest",
                column: "OriginalAktivnostID");

            migrationBuilder.AddForeignKey(
                name: "FK__Aktivnost__Event__05D8E0BE",
                table: "AktivnostPovijest",
                column: "EventPovijestId",
                principalTable: "EventPovijest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Aktivnost__Origi__06CD04F7",
                table: "AktivnostPovijest",
                column: "OriginalAktivnostID",
                principalTable: "Aktivnosti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Aktivnost__Event__05D8E0BE",
                table: "AktivnostPovijest");

            migrationBuilder.DropForeignKey(
                name: "FK__Aktivnost__Origi__06CD04F7",
                table: "AktivnostPovijest");

            migrationBuilder.DropIndex(
                name: "IX_AktivnostPovijest_EventPovijestId",
                table: "AktivnostPovijest");

            migrationBuilder.DropIndex(
                name: "IX_AktivnostPovijest_OriginalAktivnostID",
                table: "AktivnostPovijest");

            migrationBuilder.RenameColumn(
                name: "OriginalAktivnostID",
                table: "AktivnostPovijest",
                newName: "OriginalAktivnostId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "AktivnostPovijest",
                newName: "Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProsjecnaOcjena",
                table: "AktivnostPovijest",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "AktivnostPovijest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "AktivnostPovijest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MedijanOcjena",
                table: "AktivnostPovijest",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "AktivnostPovijest",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
