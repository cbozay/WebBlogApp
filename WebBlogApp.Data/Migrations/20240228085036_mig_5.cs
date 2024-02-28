using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebBlogApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("57cfe179-9409-409c-a556-4919da9e07ba"), new Guid("b47b6b64-ed3e-433b-b25e-d8c4b4f57ba1"), "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title1", "Admin test", new DateTime(2024, 2, 28, 11, 50, 35, 686, DateTimeKind.Local).AddTicks(1327), null, null, new Guid("43c77e23-7230-45cb-9c3c-ecd240f0a90c"), false, null, null, "Asp.netCore deneme title1", 10 },
                    { new Guid("efe7cc45-49b5-4e93-99d7-bae43f88464c"), new Guid("d8dbf00c-7769-4cf8-9756-2d72c96bc201"), "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title", "Admin test", new DateTime(2024, 2, 28, 11, 50, 35, 686, DateTimeKind.Local).AddTicks(1322), null, null, new Guid("eff96bac-314d-4631-aed3-46961b5089d9"), false, null, null, "Asp.netCore deneme title", 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("275133c8-3ba4-41a9-a651-b7c07c4a14a9"),
                column: "ConcurrencyStamp",
                value: "b07d7343-b5a8-490b-a001-39195fd55edb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("56e31c4f-ea61-4f29-8811-d3553477634d"),
                column: "ConcurrencyStamp",
                value: "346804ed-5392-4f49-920c-f04dae6ddf78");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("965c9f1a-3110-43cb-bc4e-9a3e63923b06"),
                column: "ConcurrencyStamp",
                value: "5a2b03c5-64f6-46fe-814a-2c1fe1eef822");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("641f781c-95f0-49ec-90e6-414cf8ad4f96"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d4d2b7d-73a8-4f23-b0ee-9b433e8a4bf5", "AQAAAAIAAYagAAAAENN3RKXKhiu59ytqxZvxc9IU9kOJbAzNGeRQka/usVrzqcTD2NBZoCn8LnKjrG8Ltg==", "6cfa2434-4034-45df-9546-07a437be9fcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b31b2bd9-0d08-4f2b-99c7-e6bc062c5175"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "766c5e6f-91f8-40d3-a2cb-9514a76718db", "AQAAAAIAAYagAAAAEEzKdKb/H7WliJZf6WEI8nRQ5lpjrToed+dqldq3PwYY6D/I4hz7dRmN89Zxhy5vlg==", "9dec85e7-fad4-42d4-9fdc-18db3ef217e8" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b47b6b64-ed3e-433b-b25e-d8c4b4f57ba1"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 11, 50, 35, 686, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d8dbf00c-7769-4cf8-9756-2d72c96bc201"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 11, 50, 35, 686, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("43c77e23-7230-45cb-9c3c-ecd240f0a90c"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 11, 50, 35, 686, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("eff96bac-314d-4631-aed3-46961b5089d9"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 11, 50, 35, 686, DateTimeKind.Local).AddTicks(2767));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("57cfe179-9409-409c-a556-4919da9e07ba"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("efe7cc45-49b5-4e93-99d7-bae43f88464c"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("58aabbdb-736e-46c1-a779-9d8ab8bd3633"), new Guid("b47b6b64-ed3e-433b-b25e-d8c4b4f57ba1"), "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title1", "Admin test", new DateTime(2024, 2, 28, 11, 47, 28, 948, DateTimeKind.Local).AddTicks(6595), null, null, new Guid("43c77e23-7230-45cb-9c3c-ecd240f0a90c"), false, null, null, "Asp.netCore deneme title1", 10 },
                    { new Guid("d9523636-2198-42e0-bdd2-d6d5ee7e161a"), new Guid("d8dbf00c-7769-4cf8-9756-2d72c96bc201"), "Asp.netCore deneme titleAsp.netCore deneme titleAsp.netCore deneme title", "Admin test", new DateTime(2024, 2, 28, 11, 47, 28, 948, DateTimeKind.Local).AddTicks(6582), null, null, new Guid("eff96bac-314d-4631-aed3-46961b5089d9"), false, null, null, "Asp.netCore deneme title", 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("275133c8-3ba4-41a9-a651-b7c07c4a14a9"),
                column: "ConcurrencyStamp",
                value: "4fdf0070-dd36-4df8-90a3-57b5d22b1bda");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("56e31c4f-ea61-4f29-8811-d3553477634d"),
                column: "ConcurrencyStamp",
                value: "86754db2-37be-43a8-b0f7-257d05aa1ccf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("965c9f1a-3110-43cb-bc4e-9a3e63923b06"),
                column: "ConcurrencyStamp",
                value: "5ab0dcb8-fc08-4980-9688-5de932b65935");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("641f781c-95f0-49ec-90e6-414cf8ad4f96"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43a31121-b439-4381-8616-bfe6df694c24", null, "5d0b9411-89d2-4dcf-96cd-a400d2999d90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b31b2bd9-0d08-4f2b-99c7-e6bc062c5175"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40647a7e-876e-4727-b1ff-bb4fd5a63ea5", "AQAAAAIAAYagAAAAENkKngZouW4UogYIxZyqqpsUDpt0Yy6mDYyqTlSg3HWcHVCvj6CWkx+EvYYJHYpbqg==", "a025f958-efcb-41b2-95c4-2d26d281cc94" });

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
        }
    }
}
