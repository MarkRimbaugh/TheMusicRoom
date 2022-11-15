using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheMusicRoomDB.Migrations
{
    /// <inheritdoc />
    public partial class createandloaddatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPhones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePhones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Middle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Last = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "CustomerAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerPhones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "CustomerPhones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Middle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Last = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    EmployeeAddressId = table.Column<int>(type: "int", nullable: false),
                    EmployeePhoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeAddresses_EmployeeAddressId",
                        column: x => x.EmployeeAddressId,
                        principalTable: "EmployeeAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeePhones_EmployeePhoneId",
                        column: x => x.EmployeePhoneId,
                        principalTable: "EmployeePhones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentTypeId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentRental",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentRental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentRental_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentRental_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentRental_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fender" },
                    { 2, "Gibson" },
                    { 3, "Line 6" },
                    { 4, "Taylor" },
                    { 5, "Yamaha" },
                    { 6, "Korg" },
                    { 7, "Casio" },
                    { 8, "Tama" }
                });

            migrationBuilder.InsertData(
                table: "CustomerAddresses",
                columns: new[] { "Id", "City", "State", "Street", "Zip" },
                values: new object[,]
                {
                    { 1, "Hope Mills", "North Carolina", "892 Some Road", "12345-0000" },
                    { 2, "Fayetteville", "North Carolina", "429 That Avenue", "67891-0000" },
                    { 3, "South Bend", "Indiana", "403 S. 29th Street", "89172-0000" },
                    { 4, "Anchorage", "Alaska", "123 Fake Street", "68981-0000" },
                    { 5, "Leesville", "Louisiana", "456 Another Street", "01597-0000" }
                });

            migrationBuilder.InsertData(
                table: "CustomerPhones",
                columns: new[] { "Id", "Number", "Type" },
                values: new object[,]
                {
                    { 1, "123-456-7890", 2 },
                    { 2, "234-567-8901", 1 },
                    { 3, "345-678-9012", 0 },
                    { 4, "456-789-0123", 2 },
                    { 5, "567-890-1234", 2 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeAddresses",
                columns: new[] { "Id", "City", "State", "Street", "Zip" },
                values: new object[,]
                {
                    { 1, "Fayetteville", "North Carolina", "123 Sample Street", "46514-0000" },
                    { 2, "Fayetteville", "North Carolina", "249 MadeUp Road", "46514-0000" },
                    { 3, "Raeford", "North Carolina", "903 Imaginary Circle", "46514-0000" },
                    { 4, "Sanford", "North Carolina", "191 Nonexistent Lane", "46514-0000" },
                    { 5, "Southern Pines", "North Carolina", "902 Fake Street", "46514-0000" }
                });

            migrationBuilder.InsertData(
                table: "EmployeePhones",
                columns: new[] { "Id", "Number", "Type" },
                values: new object[,]
                {
                    { 1, "123-456-7890", 1 },
                    { 2, "234-567-8901", 1 },
                    { 3, "345-678-9012", 1 },
                    { 4, "456-789-0123", 1 },
                    { 5, "567-890-1234", 1 }
                });

            migrationBuilder.InsertData(
                table: "EquipmentTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Guitar" },
                    { 2, "Keyboard" },
                    { 3, "Drums" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Stratocaster" },
                    { 2, 1, "Telecaster" },
                    { 3, 1, "Acoustasonic" },
                    { 4, 2, "Les Paul" },
                    { 5, 2, "SG" },
                    { 6, 3, "JTV-89F" },
                    { 7, 4, "214ce" },
                    { 8, 5, "DGX670B" },
                    { 9, 6, "i3 Arranger" },
                    { 10, 7, "WK-7600" },
                    { 11, 8, "Superstar Classic" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "First", "Last", "Middle", "PhoneId" },
                values: new object[,]
                {
                    { 1, 1, "Mark", "Rimbaugh", "Evan", 1 },
                    { 2, 2, "Joshua", "Benson", "", 2 },
                    { 3, 3, "Drew", "Nelson", "Buddy", 3 },
                    { 4, 4, "Rico", "Rodriguez", "", 4 },
                    { 5, 5, "Jackson", "Freiburg", "", 5 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeAddressId", "EmployeePhoneId", "First", "Last", "Middle", "Position" },
                values: new object[,]
                {
                    { 1, 1, 1, "Brian", "Gorman", "", 0 },
                    { 2, 2, 2, "Patrick", "Larson", "", 1 },
                    { 3, 3, 3, "Ahmad", "Qaderyan", "Rohin", 1 },
                    { 4, 4, 4, "Mursal", "Qaderyan", "", 1 },
                    { 5, 5, 5, "Alex", "Robinson", "", 1 }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BrandId", "Condition", "EquipmentTypeId", "ModelId" },
                values: new object[,]
                {
                    { 1, 0, 0, 1, 1 },
                    { 2, 0, 1, 1, 1 },
                    { 3, 0, 1, 2, 7 },
                    { 4, 0, 2, 3, 8 },
                    { 5, 0, 4, 2, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PhoneId",
                table: "Customers",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeAddressId",
                table: "Employees",
                column: "EmployeeAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeePhoneId",
                table: "Employees",
                column: "EmployeePhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentTypeId",
                table: "Equipment",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ModelId",
                table: "Equipment",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRental_CustomerId",
                table: "EquipmentRental",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRental_EmployeeId",
                table: "EquipmentRental",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRental_EquipmentId",
                table: "EquipmentRental",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "EquipmentRental");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "CustomerPhones");

            migrationBuilder.DropTable(
                name: "EmployeeAddresses");

            migrationBuilder.DropTable(
                name: "EmployeePhones");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
