using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuseumManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Main");

            migrationBuilder.CreateTable(
                name: "Materials",
                schema: "Main",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stowages",
                schema: "Main",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stowages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimePeriods",
                schema: "Main",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Safes",
                schema: "Main",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StowageId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Safes_Stowages_StowageId",
                        column: x => x.StowageId,
                        principalSchema: "Main",
                        principalTable: "Stowages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Artifacts",
                schema: "Main",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    OldMuseumNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewMuseumNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Biodegradability = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SafeId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    TimePeriodId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artifacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artifacts_Safes_SafeId",
                        column: x => x.SafeId,
                        principalSchema: "Main",
                        principalTable: "Safes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artifacts_TimePeriods_TimePeriodId",
                        column: x => x.TimePeriodId,
                        principalSchema: "Main",
                        principalTable: "TimePeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtifactImages",
                schema: "Main",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtifactId = table.Column<string>(type: "nvarchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtifactImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtifactImages_Artifacts_ArtifactId",
                        column: x => x.ArtifactId,
                        principalSchema: "Main",
                        principalTable: "Artifacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtifactMaterials",
                schema: "Main",
                columns: table => new
                {
                    ArtifactId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    MaterialId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    IsImportantMaterial = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtifactMaterials", x => new { x.ArtifactId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_ArtifactMaterials_Artifacts_ArtifactId",
                        column: x => x.ArtifactId,
                        principalSchema: "Main",
                        principalTable: "Artifacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtifactMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "Main",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtifactImages_ArtifactId",
                schema: "Main",
                table: "ArtifactImages",
                column: "ArtifactId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtifactMaterials_MaterialId",
                schema: "Main",
                table: "ArtifactMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Artifacts_SafeId",
                schema: "Main",
                table: "Artifacts",
                column: "SafeId");

            migrationBuilder.CreateIndex(
                name: "IX_Artifacts_TimePeriodId",
                schema: "Main",
                table: "Artifacts",
                column: "TimePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Safes_StowageId",
                schema: "Main",
                table: "Safes",
                column: "StowageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtifactImages",
                schema: "Main");

            migrationBuilder.DropTable(
                name: "ArtifactMaterials",
                schema: "Main");

            migrationBuilder.DropTable(
                name: "Artifacts",
                schema: "Main");

            migrationBuilder.DropTable(
                name: "Materials",
                schema: "Main");

            migrationBuilder.DropTable(
                name: "Safes",
                schema: "Main");

            migrationBuilder.DropTable(
                name: "TimePeriods",
                schema: "Main");

            migrationBuilder.DropTable(
                name: "Stowages",
                schema: "Main");
        }
    }
}
