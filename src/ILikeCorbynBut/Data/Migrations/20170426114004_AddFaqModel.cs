using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ILikeCorbynBut.Data.Migrations
{
    public partial class AddFaqModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaqViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    DivId = table.Column<string>(nullable: false),
                    Publish = table.Column<bool>(nullable: false),
                    Question = table.Column<string>(nullable: false),
                    ReviewerId = table.Column<string>(nullable: true),
                    SubmittedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaqViewModel_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaqViewModel_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaqViewModel_AuthorId",
                table: "FaqViewModel",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_FaqViewModel_ReviewerId",
                table: "FaqViewModel",
                column: "ReviewerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaqViewModel");
        }

        
    }
}
