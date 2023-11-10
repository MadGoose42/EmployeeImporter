using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProject.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personnel_Records_Payroll_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personnel_Records_Forenames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personnel_Records_Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personnel_Records_Date_of_Birth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Personnel_Records_Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personnel_Records_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personnel_Records_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personnel_Records_Address_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personnel_Records_Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personnel_Records_EMail_Home = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personnel_Records_Start_Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
