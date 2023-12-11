﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zeta.BelajarBarengBSI.Infrastructure.Persistence.Migrations
{
    public partial class ApplicationDbContext_001_InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BelajarBarengBSI");

            migrationBuilder.CreateTable(
                name: "ToDoGroups",
                schema: "BelajarBarengBSI",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Modified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItems",
                schema: "BelajarBarengBSI",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToDoGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    PriorityLevel = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Modified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItems_ToDoGroups_ToDoGroupId",
                        column: x => x.ToDoGroupId,
                        principalSchema: "BelajarBarengBSI",
                        principalTable: "ToDoGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ToDoGroupId",
                schema: "BelajarBarengBSI",
                table: "ToDoItems",
                column: "ToDoGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems",
                schema: "BelajarBarengBSI");

            migrationBuilder.DropTable(
                name: "ToDoGroups",
                schema: "BelajarBarengBSI");
        }
    }
}
