using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialControl.DAL.Data.Migrations.FinancialControlDb
{
    public partial class RemovedGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Groups_GroupId",
                table: "Operations");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Operations_GroupId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Operations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Categories",
                newName: "ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                newName: "IX_Categories_ParentCategoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "RootCategoryId",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RootCategoryId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "Categories",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                newName: "IX_Categories_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Operations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_GroupId",
                table: "Operations",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CategoryId",
                table: "Groups",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Groups_GroupId",
                table: "Operations",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
