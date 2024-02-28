using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebBlogApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("b91f94eb-b9af-4a37-a0d3-b18b24c3eabe"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c914983e-e9fd-44de-a7ae-a842e65fec04"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("58aabbdb-736e-46c1-a779-9d8ab8bd3633"), new Guid("b47b6b64-ed3e-433b-b25e-d8c4b4f57ba1"), "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title1", "Admin test", new DateTime(2024, 2, 28, 11, 47, 28, 948, DateTimeKind.Local).AddTicks(6595), null, null, new Guid("43c77e23-7230-45cb-9c3c-ecd240f0a90c"), false, null, null, "Asp.netCore deneme title1", 10 },
                    { new Guid("d9523636-2198-42e0-bdd2-d6d5ee7e161a"), new Guid("d8dbf00c-7769-4cf8-9756-2d72c96bc201"), "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title", "Admin test", new DateTime(2024, 2, 28, 11, 47, 28, 948, DateTimeKind.Local).AddTicks(6582), null, null, new Guid("eff96bac-314d-4631-aed3-46961b5089d9"), false, null, null, "Asp.netCore deneme title", 15 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("275133c8-3ba4-41a9-a651-b7c07c4a14a9"), "4fdf0070-dd36-4df8-90a3-57b5d22b1bda", "User", "USER" },
                    { new Guid("56e31c4f-ea61-4f29-8811-d3553477634d"), "86754db2-37be-43a8-b0f7-257d05aa1ccf", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("965c9f1a-3110-43cb-bc4e-9a3e63923b06"), "5ab0dcb8-fc08-4980-9688-5de932b65935", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("641f781c-95f0-49ec-90e6-414cf8ad4f96"), 0, "43a31121-b439-4381-8616-bfe6df694c24", "admin@gmail.com", false, "Ali", "Candan", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", null, "+905555555544", false, "5d0b9411-89d2-4dcf-96cd-a400d2999d90", false, "admin@gmail.com" },
                    { new Guid("b31b2bd9-0d08-4f2b-99c7-e6bc062c5175"), 0, "40647a7e-876e-4727-b1ff-bb4fd5a63ea5", "superadmin@gmail.com", true, "Kenan", "Kahraman", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENkKngZouW4UogYIxZyqqpsUDpt0Yy6mDYyqTlSg3HWcHVCvj6CWkx+EvYYJHYpbqg==", "+905555555555", true, "a025f958-efcb-41b2-95c4-2d26d281cc94", false, "superadmin@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b47b6b64-ed3e-433b-b25e-d8c4b4f57ba1"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 11, 47, 28, 948, DateTimeKind.Local).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d8dbf00c-7769-4cf8-9756-2d72c96bc201"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 11, 47, 28, 948, DateTimeKind.Local).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("43c77e23-7230-45cb-9c3c-ecd240f0a90c"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 11, 47, 28, 948, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("eff96bac-314d-4631-aed3-46961b5089d9"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 11, 47, 28, 948, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("965c9f1a-3110-43cb-bc4e-9a3e63923b06"), new Guid("641f781c-95f0-49ec-90e6-414cf8ad4f96") },
                    { new Guid("56e31c4f-ea61-4f29-8811-d3553477634d"), new Guid("b31b2bd9-0d08-4f2b-99c7-e6bc062c5175") }
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("58aabbdb-736e-46c1-a779-9d8ab8bd3633"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d9523636-2198-42e0-bdd2-d6d5ee7e161a"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("b91f94eb-b9af-4a37-a0d3-b18b24c3eabe"), new Guid("d8dbf00c-7769-4cf8-9756-2d72c96bc201"), "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title", "Admin test", new DateTime(2024, 2, 25, 14, 38, 43, 366, DateTimeKind.Local).AddTicks(1466), null, null, new Guid("eff96bac-314d-4631-aed3-46961b5089d9"), false, null, null, "Asp.netCore deneme title", 15 },
                    { new Guid("c914983e-e9fd-44de-a7ae-a842e65fec04"), new Guid("b47b6b64-ed3e-433b-b25e-d8c4b4f57ba1"), "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title1", "Admin test", new DateTime(2024, 2, 25, 14, 38, 43, 366, DateTimeKind.Local).AddTicks(1485), null, null, new Guid("43c77e23-7230-45cb-9c3c-ecd240f0a90c"), false, null, null, "Asp.netCore deneme title1", 10 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b47b6b64-ed3e-433b-b25e-d8c4b4f57ba1"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 14, 38, 43, 366, DateTimeKind.Local).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d8dbf00c-7769-4cf8-9756-2d72c96bc201"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 14, 38, 43, 366, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("43c77e23-7230-45cb-9c3c-ecd240f0a90c"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 14, 38, 43, 366, DateTimeKind.Local).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("eff96bac-314d-4631-aed3-46961b5089d9"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 14, 38, 43, 366, DateTimeKind.Local).AddTicks(3368));
        }
    }
}
