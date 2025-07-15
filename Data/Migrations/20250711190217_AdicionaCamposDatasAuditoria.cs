using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EADFirstProjectApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCamposDatasAuditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Livros",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "Livros",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Generos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "Generos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Autores",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "Autores",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "Autores");
        }
    }
}
