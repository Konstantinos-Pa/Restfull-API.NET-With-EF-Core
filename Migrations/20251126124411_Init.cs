using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    NativeLanguage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AssessmentTestCode = table.Column<string>(type: "text", nullable: false),
                    ExaminationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ScoreReportDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CandidateScore = table.Column<int>(type: "integer", nullable: false),
                    MaximumScore = table.Column<int>(type: "integer", nullable: false),
                    PercentageScore = table.Column<int>(type: "integer", nullable: false),
                    AssessmentResultLabel = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<int>(type: "integer", maxLength: 5, nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    LandlineNumber = table.Column<int>(type: "integer", nullable: false),
                    CandidateNumber = table.Column<int>(type: "integer", nullable: false),
                    CandidateNumber1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Candidates_CandidateNumber1",
                        column: x => x.CandidateNumber1,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mobiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MobileNumber = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    MobileType = table.Column<string>(type: "text", nullable: false),
                    CandidateNumber = table.Column<int>(type: "integer", nullable: false),
                    CandidateNumber1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobiles_Candidates_CandidateNumber1",
                        column: x => x.CandidateNumber1,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "photo_Ids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhotoIdImage = table.Column<int>(type: "integer", nullable: false),
                    photoIdNumber = table.Column<int>(type: "integer", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    CandidateNumber = table.Column<int>(type: "integer", nullable: false),
                    CandidateNumber1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photo_Ids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photo_Ids_Candidates_CandidateNumber1",
                        column: x => x.CandidateNumber1,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateCertificate",
                columns: table => new
                {
                    CandidatesCandidateNumber = table.Column<int>(type: "integer", nullable: false),
                    CertificatesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCertificate", x => new { x.CandidatesCandidateNumber, x.CertificatesId });
                    table.ForeignKey(
                        name: "FK_CandidateCertificate_Candidates_CandidatesCandidateNumber",
                        column: x => x.CandidatesCandidateNumber,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateCertificate_Certificates_CertificatesId",
                        column: x => x.CertificatesId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidatesAnalytics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TopicDescription = table.Column<string>(type: "text", nullable: false),
                    AwardedMarks = table.Column<int>(type: "integer", nullable: false),
                    possibleMarks = table.Column<int>(type: "integer", nullable: false),
                    CertificateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesAnalytics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatesAnalytics_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CandidateNumber1",
                table: "Addresses",
                column: "CandidateNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificate_CertificatesId",
                table: "CandidateCertificate",
                column: "CertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesAnalytics_CertificateId",
                table: "CandidatesAnalytics",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_CandidateNumber1",
                table: "Mobiles",
                column: "CandidateNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_photo_Ids_CandidateNumber1",
                table: "photo_Ids",
                column: "CandidateNumber1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CandidateCertificate");

            migrationBuilder.DropTable(
                name: "CandidatesAnalytics");

            migrationBuilder.DropTable(
                name: "Mobiles");

            migrationBuilder.DropTable(
                name: "photo_Ids");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
