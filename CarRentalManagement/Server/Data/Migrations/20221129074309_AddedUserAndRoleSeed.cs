using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalManagement.Server.Data.Migrations
{
    public partial class AddedUserAndRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "27122f28-fb8e-4fd4-a0ed-b0514c604091", "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "8a214a21-1591-4c0b-9211-3f652f676ca9", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "e1340898-da4c-4f6f-9382-053e2f09a0b4", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAELaVViz5CWdo2zyFTNWOu6BofA2R2gsQR4K2+kOuEZNbHmJm9YQdIB6l8dt1xp/Y2A==", null, false, "09dd1634-5581-448e-b580-726b5bd987f5", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 43, 8, 601, DateTimeKind.Local).AddTicks(2186), new DateTime(2022, 11, 29, 15, 43, 8, 601, DateTimeKind.Local).AddTicks(9681) });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 43, 8, 602, DateTimeKind.Local).AddTicks(720), new DateTime(2022, 11, 29, 15, 43, 8, 602, DateTimeKind.Local).AddTicks(725) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(307), new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(313) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(316), new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(317) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(3712), new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(3719), new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(3721), new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(3722) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(3723), new DateTime(2022, 11, 29, 15, 43, 8, 603, DateTimeKind.Local).AddTicks(3724) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");

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

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 41, 4, 279, DateTimeKind.Local).AddTicks(7375), new DateTime(2022, 11, 29, 15, 41, 4, 279, DateTimeKind.Local).AddTicks(7382) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 41, 4, 279, DateTimeKind.Local).AddTicks(7385), new DateTime(2022, 11, 29, 15, 41, 4, 279, DateTimeKind.Local).AddTicks(7386) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(638), new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(648), new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(649) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(650), new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(651) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(652), new DateTime(2022, 11, 29, 15, 41, 4, 280, DateTimeKind.Local).AddTicks(653) });
        }
    }
}
