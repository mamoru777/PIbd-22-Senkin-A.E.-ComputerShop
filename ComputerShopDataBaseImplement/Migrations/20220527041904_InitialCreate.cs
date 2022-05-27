using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerShopDataBaseImplement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolTechnics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePos = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostavkaId = table.Column<int>(type: "int", nullable: false),
                    PolTechnicName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolTechnics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postavkas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostavkaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostavkaCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZakupkaId = table.Column<int>(type: "int", nullable: false)
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
                name: "Zakupkas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateBuy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZakupkaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostavshikId = table.Column<int>(type: "int", nullable: false),
                    ComplectId = table.Column<int>(type: "int", nullable: false),
                    ZakupkaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zakupkas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zakupkas_Postavkas_ZakupkaId",
                        column: x => x.ZakupkaId,
                        principalTable: "Postavkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zakupkas_Postavshiks_PostavshikId",
                        column: x => x.PostavshikId,
                        principalTable: "Postavshiks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Complects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PostavshikId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Complects_Zakupkas_ComplectId",
                        column: x => x.ComplectId,
                        principalTable: "Zakupkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComplectPolTechnics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplectId = table.Column<int>(type: "int", nullable: false),
                    PolTechnicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplectPolTechnics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplectPolTechnics_Complects_ComplectId",
                        column: x => x.ComplectId,
                        principalTable: "Complects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ComplectPolTechnics_PolTechnics_PolTechnicId",
                        column: x => x.PolTechnicId,
                        principalTable: "PolTechnics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SborkaComplects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplectId = table.Column<int>(type: "int", nullable: false),
                    SborkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SborkaComplects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SborkaComplects_Complects_ComplectId",
                        column: x => x.ComplectId,
                        principalTable: "Complects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SborkaComplects_Sborkas_SborkaId",
                        column: x => x.SborkaId,
                        principalTable: "Sborkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplectPolTechnics_ComplectId",
                table: "ComplectPolTechnics",
                column: "ComplectId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplectPolTechnics_PolTechnicId",
                table: "ComplectPolTechnics",
                column: "PolTechnicId");

            migrationBuilder.CreateIndex(
                name: "IX_Complects_ComplectId",
                table: "Complects",
                column: "ComplectId",
                unique: true,
                filter: "[ComplectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Complects_PostavshikId",
                table: "Complects",
                column: "PostavshikId");

            migrationBuilder.CreateIndex(
                name: "IX_SborkaComplects_ComplectId",
                table: "SborkaComplects",
                column: "ComplectId");

            migrationBuilder.CreateIndex(
                name: "IX_SborkaComplects_SborkaId",
                table: "SborkaComplects",
                column: "SborkaId");

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
                name: "IX_Zakupkas_PostavshikId",
                table: "Zakupkas",
                column: "PostavshikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zakupkas_ZakupkaId",
                table: "Zakupkas",
                column: "ZakupkaId",
                unique: true,
                filter: "[ZakupkaId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplectPolTechnics");

            migrationBuilder.DropTable(
                name: "SborkaComplects");

            migrationBuilder.DropTable(
                name: "SborkaZaiavkas");

            migrationBuilder.DropTable(
                name: "PolTechnics");

            migrationBuilder.DropTable(
                name: "Complects");

            migrationBuilder.DropTable(
                name: "Sborkas");

            migrationBuilder.DropTable(
                name: "Zaiavkas");

            migrationBuilder.DropTable(
                name: "Zakupkas");

            migrationBuilder.DropTable(
                name: "Postavkas");

            migrationBuilder.DropTable(
                name: "Postavshiks");
        }
    }
}
