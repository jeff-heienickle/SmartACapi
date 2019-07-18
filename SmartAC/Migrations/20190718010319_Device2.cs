﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartAC.Migrations
{
    public partial class Device2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReadingDate",
                table: "DataReading",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadingDate",
                table: "DataReading");
        }
    }
}
