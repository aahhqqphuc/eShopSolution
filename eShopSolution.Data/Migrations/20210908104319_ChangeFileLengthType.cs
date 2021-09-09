using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("38656d75-0611-4067-a546-b38e25a61e7d"),
                column: "ConcurrencyStamp",
                value: "18eb1668-088c-477e-80c4-a7ec8dea815d");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("f46133e9-22ee-46b0-890f-5c3e8cc5c258"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd4cc425-5b3b-4bf0-bd9a-6ffde8255d79", "AQAAAAEAACcQAAAAEHLJHSQRV71JpFtnBeMBO7x3Lm7BSVMOeh3FaMvzADOu0ZUjUqoNrY7KF3HXOs0uXA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 8, 17, 43, 18, 144, DateTimeKind.Local).AddTicks(2461));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("38656d75-0611-4067-a546-b38e25a61e7d"),
                column: "ConcurrencyStamp",
                value: "34fd4bcd-aaf7-43f5-a0d5-217c842553ca");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("f46133e9-22ee-46b0-890f-5c3e8cc5c258"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe75dcbb-78d9-4115-95da-f16856fdb3a5", "AQAAAAEAACcQAAAAEFoM4ecVSBjjUaePb2NqTKm13+4dNN+4muJNl0GoOO1U0FfQ86YF1EZBmMikwCActg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 8, 15, 57, 28, 61, DateTimeKind.Local).AddTicks(2000));
        }
    }
}
