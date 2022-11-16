using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheMusicRoomDB.Migrations
{
    /// <inheritdoc />
    public partial class addisavailabletoequipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRental_Rental_RentalsId",
                table: "CustomerRental");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rental",
                table: "Rental");

            migrationBuilder.RenameTable(
                name: "Rental",
                newName: "Rentals");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Equipment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomerListDTOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerListDTOs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeListDTOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeListDTOs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsAvailable",
                value: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRental_Rentals_RentalsId",
                table: "CustomerRental",
                column: "RentalsId",
                principalTable: "Rentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRental_Rentals_RentalsId",
                table: "CustomerRental");

            migrationBuilder.DropTable(
                name: "CustomerListDTOs");

            migrationBuilder.DropTable(
                name: "EmployeeListDTOs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Equipment");

            migrationBuilder.RenameTable(
                name: "Rentals",
                newName: "Rental");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rental",
                table: "Rental",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRental_Rental_RentalsId",
                table: "CustomerRental",
                column: "RentalsId",
                principalTable: "Rental",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
