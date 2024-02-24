using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebBlogApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("b47b6b64-ed3e-433b-b25e-d8c4b4f57ba1"), "Admin Cat1", new DateTime(2024, 2, 24, 13, 38, 22, 904, DateTimeKind.Local).AddTicks(6487), null, null, false, null, null, "CategoryNameDeneme1" },
                    { new Guid("d8dbf00c-7769-4cf8-9756-2d72c96bc201"), "Admin Cat", new DateTime(2024, 2, 24, 13, 38, 22, 904, DateTimeKind.Local).AddTicks(6485), null, null, false, null, null, "CategoryNameDeneme" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("43c77e23-7230-45cb-9c3c-ecd240f0a90c"), "Adimn1", new DateTime(2024, 2, 24, 13, 38, 22, 904, DateTimeKind.Local).AddTicks(7040), null, null, "CategoryImage1", "jpg", false, null, null },
                    { new Guid("eff96bac-314d-4631-aed3-46961b5089d9"), "Adimn", new DateTime(2024, 2, 24, 13, 38, 22, 904, DateTimeKind.Local).AddTicks(7037), null, null, "CategoryImage", "jpg", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("91936bf1-5875-4775-9743-5e2373c2c9ab"), new Guid("d8dbf00c-7769-4cf8-9756-2d72c96bc201"), "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title", "Admin test", new DateTime(2024, 2, 24, 13, 38, 22, 904, DateTimeKind.Local).AddTicks(5570), null, null, new Guid("eff96bac-314d-4631-aed3-46961b5089d9"), false, null, null, "Asp.netCore deneme title", 15 },
                    { new Guid("f360898e-63d4-4a89-a66d-491e64f3c313"), new Guid("b47b6b64-ed3e-433b-b25e-d8c4b4f57ba1"), "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title1", "Admin test", new DateTime(2024, 2, 24, 13, 38, 22, 904, DateTimeKind.Local).AddTicks(5583), null, null, new Guid("43c77e23-7230-45cb-9c3c-ecd240f0a90c"), false, null, null, "Asp.netCore deneme title1", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("91936bf1-5875-4775-9743-5e2373c2c9ab"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f360898e-63d4-4a89-a66d-491e64f3c313"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b47b6b64-ed3e-433b-b25e-d8c4b4f57ba1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d8dbf00c-7769-4cf8-9756-2d72c96bc201"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("43c77e23-7230-45cb-9c3c-ecd240f0a90c"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("eff96bac-314d-4631-aed3-46961b5089d9"));
        }
    }
}
