using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TandemTechAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhonePlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeviceLimit = table.Column<int>(type: "int", nullable: false),
                    DataLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhonePlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PhonePlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPlans_PhonePlans_PhonePlanId",
                        column: x => x.PhonePlanId,
                        principalTable: "PhonePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanPhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPlanId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanPhoneNumbers_PhoneNumbers_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanPhoneNumbers_UserPlans_UserPlanId",
                        column: x => x.UserPlanId,
                        principalTable: "UserPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlanPhoneNumberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_PlanPhoneNumbers_PlanPhoneNumberId",
                        column: x => x.PlanPhoneNumberId,
                        principalTable: "PlanPhoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, "2125551234" },
                    { 2, "2125551235" },
                    { 3, "2125551236" },
                    { 4, "2125551237" },
                    { 5, "4155551234" },
                    { 6, "4155551235" },
                    { 7, "4155551236" },
                    { 8, "4155551237" },
                    { 9, "3125551234" },
                    { 10, "3125551235" },
                    { 11, "3125551236" },
                    { 12, "3125551237" },
                    { 13, "2135551234" },
                    { 14, "2135551235" },
                    { 15, "2135551236" },
                    { 16, "2135551237" },
                    { 17, "2125551238" },
                    { 18, "2125551239" },
                    { 19, "2125551240" },
                    { 20, "2125551241" }
                });

            migrationBuilder.InsertData(
                table: "PhonePlans",
                columns: new[] { "Id", "DataLimit", "Description", "DeviceLimit", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 5, "Stay connected with our Basic Plan, perfect for calls, messages, and browsing with a generous 5GB data limit.", 1, "Basic Plan", 30m },
                    { 2, 10, "Upgrade to our Standard Plan for more data and the flexibility to connect two devices. Enjoy browsing, streaming, and sharing with 10GB of data.", 2, "Standard Plan", 40m },
                    { 3, 0, "Get the ultimate experience with our Premium Plan. Stream, game, and connect with multiple devices effortlessly with unlimited data.", 5, "Premium Plan", 60m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "calexander@contosouniversity.edu", "Carson", "Alexander" },
                    { 2, "malonso@contosouniversity.edu", "Meredith", "Alonso" },
                    { 3, "aanand@contosouniversity.edu", "Arturo", "Anand" },
                    { 4, "gbarzdukas@contosouniversity.edu", "Gytis", "Barzdukas" },
                    { 5, "yli@contosouniversity.edu", "Yan", "Li" },
                    { 6, "pjustice@contosouniversity.edu", "Bob", "Justice" },
                    { 7, "lnorman@contosouniversity.edu", "Laura", "Norman" },
                    { 8, "nolivetto@contosouniversity.edu", "Nino", "Olivetto" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_PlanPhoneNumberId",
                table: "Devices",
                column: "PlanPhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPhoneNumbers_PhoneNumberId",
                table: "PlanPhoneNumbers",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPhoneNumbers_UserPlanId",
                table: "PlanPhoneNumbers",
                column: "UserPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlans_PhonePlanId",
                table: "UserPlans",
                column: "PhonePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlans_UserId",
                table: "UserPlans",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "PlanPhoneNumbers");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "UserPlans");

            migrationBuilder.DropTable(
                name: "PhonePlans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
