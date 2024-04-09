using System;
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsPorted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeviceLimit = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataLimit = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyBills_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PlanInfoId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPlans_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPlans_PlanInfo_PlanInfoId",
                        column: x => x.PlanInfoId,
                        principalTable: "PlanInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanBills_MonthlyBills_BillId",
                        column: x => x.BillId,
                        principalTable: "MonthlyBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false),
                    UserPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedNumbers_PhoneNumbers_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedNumbers_UserPlans_UserPlanId",
                        column: x => x.UserPlanId,
                        principalTable: "UserPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AssignedNumberId = table.Column<int>(type: "int", nullable: false),
                    DeviceInfoId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_AssignedNumbers_AssignedNumberId",
                        column: x => x.AssignedNumberId,
                        principalTable: "AssignedNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devices_DeviceInfo_Id",
                        column: x => x.Id,
                        principalTable: "DeviceInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "d336125e-579b-4143-9847-8a689a4b3560", "emma.johnson@example.com", false, "Emma", "Johnson", false, null, null, null, null, null, false, null, false, null },
                    { 2, 0, "551c3124-167d-437f-8c37-be25f8bf2b66", "liam.williams@example.com", false, "Liam", "Williams", false, null, null, null, null, null, false, null, false, null },
                    { 3, 0, "91068afa-ba91-4937-a962-a3a732b01138", "olivia.brown@example.com", false, "Olivia", "Brown", false, null, null, null, null, null, false, null, false, null },
                    { 4, 0, "b39cfd14-d136-447c-9a79-343c171e2d64", "noah.jones@example.com", false, "Noah", "Jones", false, null, null, null, null, null, false, null, false, null },
                    { 5, 0, "f8f92b31-8cd3-40d1-bbe7-2a68f7b3cf04", "ava.garcia@example.com", false, "Ava", "Garcia", false, null, null, null, null, null, false, null, false, null },
                    { 6, 0, "0c79d3f6-b9e5-4dca-bc5c-6a2a0e41e7a3", "oliver.miller@example.com", false, "Oliver", "Miller", false, null, null, null, null, null, false, null, false, null },
                    { 7, 0, "41ae8c56-2696-4ef1-970d-c5b0fa0059e1", "isabella.davis@example.com", false, "Isabella", "Davis", false, null, null, null, null, null, false, null, false, null },
                    { 8, 0, "48bcbb34-a76f-4dbd-ae2c-55c868186db6", "ethan.martinez@example.com", false, "Ethan", "Martinez", false, null, null, null, null, null, false, null, false, null },
                    { 9, 0, "f33f5549-d22d-421d-8eeb-8a618c273173", "sophia.rodriguez@example.com", false, "Sophia", "Rodriguez", false, null, null, null, null, null, false, null, false, null },
                    { 10, 0, "2ff0a0ad-db8a-436b-b000-408c420b3aec", "jacob.wilson@example.com", false, "Jacob", "Wilson", false, null, null, null, null, null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "DeviceInfo",
                columns: new[] { "Id", "ImgUrl", "Manufacturer", "Model" },
                values: new object[,]
                {
                    { 1, null, "Apple", "iPhone 13" },
                    { 2, null, "Apple", "iPhone 13 Pro" },
                    { 3, null, "Apple", "iPhone 13 Mini" },
                    { 4, null, "Apple", "iPhone SE" },
                    { 5, null, "Apple", "iPhone 12" },
                    { 6, null, "Samsung", "Galaxy S21" },
                    { 7, null, "Samsung", "Galaxy Note 20" },
                    { 8, null, "Samsung", "Galaxy A52" },
                    { 9, null, "Samsung", "Galaxy Z Fold 3" },
                    { 10, null, "Samsung", "Galaxy S20 FE" },
                    { 11, null, "Google", "Pixel 6" },
                    { 12, null, "Google", "Pixel 5a" },
                    { 13, null, "Google", "Pixel 4a 5G" },
                    { 14, null, "Google", "Pixel 4 XL" },
                    { 15, null, "Google", "Pixel 3a" },
                    { 16, null, "OnePlus", "OnePlus 9 Pro" },
                    { 17, null, "OnePlus", "OnePlus 9" },
                    { 18, null, "OnePlus", "OnePlus Nord 2" },
                    { 19, null, "OnePlus", "OnePlus 8T" },
                    { 20, null, "OnePlus", "OnePlus 8 Pro" },
                    { 21, null, "Xiaomi", "Xiaomi 11T Pro" },
                    { 22, null, "Xiaomi", "Xiaomi Redmi Note 11" },
                    { 23, null, "Xiaomi", "Xiaomi Mi 11 Lite" },
                    { 24, null, "Xiaomi", "Xiaomi Poco X4 Pro" },
                    { 25, null, "Xiaomi", "Xiaomi Mi Mix 4" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "IsPorted", "Number" },
                values: new object[,]
                {
                    { 1, false, "6035550100" },
                    { 2, false, "6035550101" },
                    { 3, false, "6035550102" },
                    { 4, false, "6035550103" },
                    { 5, false, "6035550104" },
                    { 6, false, "2025550100" },
                    { 7, false, "2025550101" },
                    { 8, false, "2025550102" },
                    { 9, false, "2025550103" },
                    { 10, false, "2025550104" },
                    { 11, false, "3055550100" },
                    { 12, false, "3055550101" },
                    { 13, false, "3055550102" },
                    { 14, false, "3055550103" },
                    { 15, false, "3055550104" },
                    { 16, false, "4155550100" },
                    { 17, false, "4155550101" },
                    { 18, false, "4155550102" },
                    { 19, false, "4155550103" },
                    { 20, false, "4155550104" },
                    { 21, false, "7025550100" },
                    { 22, false, "7025550101" },
                    { 23, false, "7025550102" },
                    { 24, false, "7025550103" },
                    { 25, false, "7025550104" }
                });

            migrationBuilder.InsertData(
                table: "PlanInfo",
                columns: new[] { "Id", "DataLimit", "Description", "DeviceLimit", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 5, "Stay connected with our Basic Plan, perfect for calls, messages, and browsing with a generous 5GB data limit.", 1, "Basic Plan", 30m },
                    { 2, 10, "Upgrade to our Standard Plan for more data and the flexibility to connect two devices. Enjoy browsing, streaming, and sharing with 10GB of data.", 2, "Standard Plan", 40m },
                    { 3, 0, "Get the ultimate experience with our Premium Plan. Stream, game, and connect with multiple devices effortlessly with unlimited data.", 5, "Premium Plan", 60m }
                });

            migrationBuilder.InsertData(
                table: "MonthlyBills",
                columns: new[] { "Id", "BillingDate", "IsPaid", "Total", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 30m, 1 },
                    { 2, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 60m, 2 },
                    { 3, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 120m, 3 },
                    { 4, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 40m, 4 },
                    { 5, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 70m, 5 },
                    { 6, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 110m, 6 },
                    { 7, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 60m, 7 },
                    { 8, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 30m, 8 },
                    { 9, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 100m, 9 },
                    { 10, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 60m, 10 }
                });

            migrationBuilder.InsertData(
                table: "UserPlans",
                columns: new[] { "Id", "EnrollmentDate", "PlanInfoId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 5, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 6, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 7, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 8, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 9, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6 },
                    { 11, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 12, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 13, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7 },
                    { 14, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8 },
                    { 16, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9 },
                    { 17, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 9 },
                    { 18, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "AssignedNumbers",
                columns: new[] { "Id", "PhoneNumberId", "UserPlanId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 6, 3 },
                    { 3, 7, 3 },
                    { 4, 8, 3 },
                    { 5, 9, 3 },
                    { 6, 10, 3 },
                    { 7, 11, 4 },
                    { 8, 12, 5 },
                    { 9, 13, 5 },
                    { 10, 14, 6 },
                    { 11, 15, 6 },
                    { 12, 16, 7 },
                    { 13, 17, 7 },
                    { 14, 18, 8 },
                    { 15, 19, 9 },
                    { 16, 20, 9 },
                    { 18, 22, 11 },
                    { 19, 23, 11 },
                    { 20, 24, 12 },
                    { 21, 25, 13 },
                    { 22, 2, 14 },
                    { 23, 3, 16 },
                    { 24, 4, 17 },
                    { 25, 5, 17 },
                    { 26, 21, 18 }
                });

            migrationBuilder.InsertData(
                table: "PlanBills",
                columns: new[] { "Id", "Amount", "BillId", "BillingDate" },
                values: new object[,]
                {
                    { 1, 30m, 1, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 60m, 2, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 30m, 3, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 30m, 3, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 60m, 3, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 40m, 4, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 30m, 5, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 40m, 5, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 30m, 6, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 40m, 6, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 40m, 6, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 60m, 7, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 30m, 8, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 40m, 9, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 60m, 9, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 60m, 10, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "AssignedNumberId", "DeviceInfoId", "Name", "Serial" },
                values: new object[,]
                {
                    { 1, 1, 3, "My iPhone 13 Mini", "EM12345" },
                    { 2, 2, 9, "Jake's Galaxy Z Fold 3", "LM54321" },
                    { 3, 3, 15, "Dad's Pixel 3a", "LM98765" },
                    { 4, 4, 22, "Mom's Xiaomi Redmi Note 11", "LM13579" },
                    { 5, 5, 6, "My Samsung Galaxy S21", "LM24680" },
                    { 6, 6, 2, "Sara's iPhone 13 Pro", "LM11223" },
                    { 7, 7, 14, "Brother's Pixel 4 XL", "OV44444" },
                    { 8, 8, 18, "Sister's OnePlus Nord 2", "OV55555" },
                    { 9, 9, 12, "Grandpa's Pixel 5a", "OV66666" },
                    { 10, 10, 20, "Grandma's OnePlus 8 Pro", "OV77777" },
                    { 11, 11, 7, "Uncle's Galaxy Note 20", "OV88888" },
                    { 12, 12, 4, "Aunt's iPhone SE", "NH12121" },
                    { 13, 13, 10, "Cousin's Galaxy S20 FE", "NH23232" },
                    { 14, 14, 17, "My OnePlus 9", "AV99999" },
                    { 15, 15, 25, "Xiaomi Mi Mix 4", "AV88888" },
                    { 16, 16, 13, "Pixel 4a 5G", "AV77777" },
                    { 18, 18, 23, "Xiaomi Mi 11 Lite", "OL54321" },
                    { 19, 19, 11, "Google Pixel 6", "OL98765" },
                    { 20, 21, 19, "OnePlus 8T", "IS24680" },
                    { 21, 22, 8, "Samsung Galaxy A52", "ET56789" },
                    { 22, 23, 16, "OnePlus 9 Pro", "SP98765" },
                    { 23, 24, 1, "iPhone 13", "SP54321" },
                    { 24, 26, 8, "Jacob's Phone", "JC13579" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedNumbers_PhoneNumberId",
                table: "AssignedNumbers",
                column: "PhoneNumberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignedNumbers_UserPlanId",
                table: "AssignedNumbers",
                column: "UserPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_AssignedNumberId",
                table: "Devices",
                column: "AssignedNumberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyBills_UserId",
                table: "MonthlyBills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_Number",
                table: "PhoneNumbers",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanBills_BillId",
                table: "PlanBills",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlans_PlanInfoId",
                table: "UserPlans",
                column: "PlanInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlans_UserId",
                table: "UserPlans",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "PlanBills");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AssignedNumbers");

            migrationBuilder.DropTable(
                name: "DeviceInfo");

            migrationBuilder.DropTable(
                name: "MonthlyBills");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "UserPlans");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PlanInfo");
        }
    }
}
