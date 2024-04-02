using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TandemTechAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("06917677-cdd6-4523-91b8-88d6d0a912d2"), "calexander@contosouniversity.edu", "Carson", "Alexander" },
                    { new Guid("2a36409f-6732-459b-b7d1-a561c521a3cb"), "aanand@contosouniversity.edu", "Arturo", "Anand" },
                    { new Guid("53cea385-aa61-4e81-ba7a-38d7ed60ce4f"), "lnorman@contosouniversity.edu", "Laura", "Norman" },
                    { new Guid("554039c7-cba1-4404-9fbe-21918a9190f7"), "nolivetto@contosouniversity.edu", "Nino", "Olivetto" },
                    { new Guid("5e9c10d4-3b0a-4ccb-8a77-fb2d7e702c6b"), "pjustice@contosouniversity.edu", "Peggy", "Justice" },
                    { new Guid("798acf1b-7339-44bd-8367-7132a978d7b1"), "malonso@contosouniversity.edu", "Meredith", "Alonso" },
                    { new Guid("7a1be69a-38ac-4cde-a105-615de38c2d12"), "yli@contosouniversity.edu", "Yan", "Li" },
                    { new Guid("7d84360e-4967-4c7b-8e4c-0f085de7ca4d"), "gbarzdukas@contosouniversity.edu", "Gytis", "Barzdukas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
