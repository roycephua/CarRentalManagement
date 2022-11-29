using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalManagement.Server.Data.Migrations
{
    public partial class AddedMakeAndModelSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 41, 4, 277, DateTimeKind.Local).AddTicks(6545), new DateTime(2022, 11, 29, 15, 41, 4, 278, DateTimeKind.Local).AddTicks(6278) });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 41, 4, 278, DateTimeKind.Local).AddTicks(7145), new DateTime(2022, 11, 29, 15, 41, 4, 278, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 11, 29, 15, 41, 4, 279, DateTimeKind.Local).AddTicks(7375), new DateTime(2022, 11, 29, 15, 41, 4, 279, DateTimeKind.Local).AddTicks(7382), "BMW", "System" },
                    { 2, "System", new DateTime(2022, 11, 29, 15, 41, 4, 279, DateTimeKind.Local).AddTicks(7385), new DateTime(2022, 11, 29, 15, 41, 4, 279, DateTimeKind.Local).AddTicks(7386), "Toyota", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(638), new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(645), "3 Series    ", "System" },
                    { 2, "System", new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(648), new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(649), "X5", "System" },
                    { 3, "System", new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(650), new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(651), "Prius", "System" },
                    { 4, "System", new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(652), new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(653), "Rav4", "System" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 10, 50, 774, DateTimeKind.Local).AddTicks(3344), new DateTime(2022, 11, 29, 15, 10, 50, 775, DateTimeKind.Local).AddTicks(797) });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 10, 50, 775, DateTimeKind.Local).AddTicks(1549), new DateTime(2022, 11, 29, 15, 10, 50, 775, DateTimeKind.Local).AddTicks(1554) });
        }
    }
}
