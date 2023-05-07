using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialize_07052023134706 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanPurpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditScore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditAmount = table.Column<float>(type: "real", nullable: false),
                    LoanRate = table.Column<float>(type: "real", nullable: false),
                    CreditStatus = table.Column<int>(type: "int", nullable: false),
                    LoanPercentage = table.Column<float>(type: "real", nullable: false),
                    PaymentHistory = table.Column<int>(type: "int", nullable: true),
                    CreditHistoryLength = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credits");
        }
    }
}
