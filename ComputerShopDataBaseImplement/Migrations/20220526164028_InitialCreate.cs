using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerShopDataBaseImplement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postavkas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostavkaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostavkaCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postavkas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postavshiks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postavshiks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zaiavkas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZaiavkaName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaiavkas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolTechnics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePos = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostavkaId = table.Column<int>(type: "int", nullable: false),
                    PolTechnicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostavlaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolTechnics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolTechnics_Postavkas_PostavlaId",
                        column: x => x.PostavlaId,
                        principalTable: "Postavkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sborkas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SborkaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PostavshikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sborkas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sborkas_Postavshiks_PostavshikId",
                        column: x => x.PostavshikId,
                        principalTable: "Postavshiks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostavkaZaiavkas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostavkaId = table.Column<int>(type: "int", nullable: false),
                    ZaiavkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostavkaZaiavkas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostavkaZaiavkas_Postavkas_PostavkaId",
                        column: x => x.PostavkaId,
                        principalTable: "Postavkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PostavkaZaiavkas_Zaiavkas_ZaiavkaId",
                        column: x => x.ZaiavkaId,
                        principalTable: "Zaiavkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SborkaZaiavkas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SborkaId = table.Column<int>(type: "int", nullable: false),
                    ZaiavkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SborkaZaiavkas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SborkaZaiavkas_Sborkas_SborkaId",
                        column: x => x.SborkaId,
                        principalTable: "Sborkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SborkaZaiavkas_Zaiavkas_ZaiavkaId",
                        column: x => x.ZaiavkaId,
                        principalTable: "Zaiavkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Zakupkas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateBuy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZakupkaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplectId = table.Column<int>(type: "int", nullable: false),
                    ZakupkaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zakupkas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Complects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PostavshikId = table.Column<int>(type: "int", nullable: false),
                    SborkaId = table.Column<int>(type: "int", nullable: false),
                    ZakupkaId = table.Column<int>(type: "int", nullable: false),
                    ComplectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complects_Postavshiks_PostavshikId",
                        column: x => x.PostavshikId,
                        principalTable: "Postavshiks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Complects_Sborkas_SborkaId",
                        column: x => x.SborkaId,
                        principalTable: "Sborkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Complects_Zakupkas_ComplectId",
                        column: x => x.ComplectId,
                        principalTable: "Zakupkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complects_ComplectId",
                table: "Complects",
                column: "ComplectId");

            migrationBuilder.CreateIndex(
                name: "IX_Complects_PostavshikId",
                table: "Complects",
                column: "PostavshikId");

            migrationBuilder.CreateIndex(
                name: "IX_Complects_SborkaId",
                table: "Complects",
                column: "SborkaId");

            migrationBuilder.CreateIndex(
                name: "IX_PolTechnics_PostavlaId",
                table: "PolTechnics",
                column: "PostavlaId");

            migrationBuilder.CreateIndex(
                name: "IX_PostavkaZaiavkas_PostavkaId",
                table: "PostavkaZaiavkas",
                column: "PostavkaId");

            migrationBuilder.CreateIndex(
                name: "IX_PostavkaZaiavkas_ZaiavkaId",
                table: "PostavkaZaiavkas",
                column: "ZaiavkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sborkas_PostavshikId",
                table: "Sborkas",
                column: "PostavshikId");

            migrationBuilder.CreateIndex(
                name: "IX_SborkaZaiavkas_SborkaId",
                table: "SborkaZaiavkas",
                column: "SborkaId");

            migrationBuilder.CreateIndex(
                name: "IX_SborkaZaiavkas_ZaiavkaId",
                table: "SborkaZaiavkas",
                column: "ZaiavkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zakupkas_ZakupkaId",
                table: "Zakupkas",
                column: "ZakupkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zakupkas_Complects_ZakupkaId",
                table: "Zakupkas",
                column: "ZakupkaId",
                principalTable: "Complects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complects_Postavshiks_PostavshikId",
                table: "Complects");

            migrationBuilder.DropForeignKey(
                name: "FK_Sborkas_Postavshiks_PostavshikId",
                table: "Sborkas");

            migrationBuilder.DropForeignKey(
                name: "FK_Complects_Sborkas_SborkaId",
                table: "Complects");

            migrationBuilder.DropForeignKey(
                name: "FK_Complects_Zakupkas_ComplectId",
                table: "Complects");

            migrationBuilder.DropTable(
                name: "PolTechnics");

            migrationBuilder.DropTable(
                name: "PostavkaZaiavkas");

            migrationBuilder.DropTable(
                name: "SborkaZaiavkas");

            migrationBuilder.DropTable(
                name: "Postavkas");

            migrationBuilder.DropTable(
                name: "Zaiavkas");

            migrationBuilder.DropTable(
                name: "Postavshiks");

            migrationBuilder.DropTable(
                name: "Sborkas");

            migrationBuilder.DropTable(
                name: "Zakupkas");

            migrationBuilder.DropTable(
                name: "Complects");
        }
    }
}
