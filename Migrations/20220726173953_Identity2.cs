using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtistSite.Migrations
{
    public partial class Identity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "596ab769-76ef-41ef-9637-956ca16a9573");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedOn", "UserName" },
                values: new object[] { "f3417f68-5a50-44d5-9dba-2e69645a7164", 0, null, "f4364f9d-7863-47ca-97ff-ecc967cc4c88", "ana.martin1995@gmail.com", false, "Ana", "Martin Delgado", false, null, null, null, null, null, false, "105f25de-03ec-4851-9f4c-5945534e5296", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3417f68-5a50-44d5-9dba-2e69645a7164");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "FName", "LName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedOn", "UserName" },
                values: new object[] { "596ab769-76ef-41ef-9637-956ca16a9573", 0, null, "e8e0f563-4bcb-4898-8d28-7ea69940eb15", "ana.martin1995@gmail.com", false, "Ana", "Martin Delgado", false, null, null, null, null, null, false, "7649697a-9eea-4df6-ab55-a0af322c85b4", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }
    }
}
