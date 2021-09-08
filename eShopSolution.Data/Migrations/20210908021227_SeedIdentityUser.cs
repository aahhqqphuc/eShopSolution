using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 8, 9, 12, 26, 471, DateTimeKind.Local).AddTicks(4643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 8, 9, 3, 27, 861, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("38656d75-0611-4067-a546-b38e25a61e7d"), "d8db763d-d54f-461d-bf4c-6db014a42b1b", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("38656d75-0611-4067-a546-b38e25a61e7d"), new Guid("f46133e9-22ee-46b0-890f-5c3e8cc5c258") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("f46133e9-22ee-46b0-890f-5c3e8cc5c258"), 0, "545d6d34-4bb9-4480-a0a1-c427bbb1dae2", new DateTime(2021, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "ffqphuc@gmail.com", true, "Phuc", "Nguyen", false, null, "ffqphuc@gmail.com", "admin", "AQAAAAEAACcQAAAAEAMTnMAyAs79adnX30a/zDXviT5a1INTc4/hpNDKzjYn36GPEJQXCBT3fgg4aYdIdg==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 8, 9, 12, 26, 484, DateTimeKind.Local).AddTicks(7326));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("38656d75-0611-4067-a546-b38e25a61e7d"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("38656d75-0611-4067-a546-b38e25a61e7d"), new Guid("f46133e9-22ee-46b0-890f-5c3e8cc5c258") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f46133e9-22ee-46b0-890f-5c3e8cc5c258"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 8, 9, 3, 27, 861, DateTimeKind.Local).AddTicks(8625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 8, 9, 12, 26, 471, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 8, 9, 3, 27, 875, DateTimeKind.Local).AddTicks(3425));
        }
    }
}
