using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meistrai_mvc_mano.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoWorker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nuotrauka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoWorker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoWorker_AutoService_AutoServiceId",
                        column: x => x.AutoServiceId,
                        principalTable: "AutoService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoWorkerSpecialization",
                columns: table => new
                {
                    AutoWorkersId = table.Column<int>(type: "int", nullable: false),
                    SpecializationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoWorkerSpecialization", x => new { x.AutoWorkersId, x.SpecializationsId });
                    table.ForeignKey(
                        name: "FK_AutoWorkerSpecialization_AutoWorker_AutoWorkersId",
                        column: x => x.AutoWorkersId,
                        principalTable: "AutoWorker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoWorkerSpecialization_Specialization_SpecializationsId",
                        column: x => x.SpecializationsId,
                        principalTable: "Specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AutoWorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerRating_AutoWorker_AutoWorkerId",
                        column: x => x.AutoWorkerId,
                        principalTable: "AutoWorker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerRating_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoWorker_AutoServiceId",
                table: "AutoWorker",
                column: "AutoServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoWorkerSpecialization_SpecializationsId",
                table: "AutoWorkerSpecialization",
                column: "SpecializationsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerRating_AutoWorkerId",
                table: "WorkerRating",
                column: "AutoWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerRating_UserId",
                table: "WorkerRating",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoWorkerSpecialization");

            migrationBuilder.DropTable(
                name: "WorkerRating");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "AutoWorker");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AutoService");
        }
    }
}
