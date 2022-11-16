using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheMusicRoomDB.Migrations
{
    /// <inheritdoc />
    public partial class removedaddressesandphonestosimplify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerAddresses_AddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerPhones_PhoneId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeAddresses_EmployeeAddressId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeePhones_EmployeePhoneId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "CustomerPhones");

            migrationBuilder.DropTable(
                name: "EmployeePhones");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeAddressId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeePhoneId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PhoneId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmployeeAddresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "EmployeeAddressId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeePhoneId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "PhoneNumber", "State", "Street", "Zip" },
                values: new object[] { "Hope Mills", "123-456-7890", "North Carolina", "892 Some Road", "12345-0000" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "PhoneNumber", "State", "Street", "Zip" },
                values: new object[] { "Fayetteville", "234-567-8901", "North Carolina", "429 That Avenue", "67891-0000" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "PhoneNumber", "State", "Street", "Zip" },
                values: new object[] { "South Bend", "345-678-9012", "Indiana", "403 S. 29th Street", "89172-0000" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "City", "PhoneNumber", "State", "Street", "Zip" },
                values: new object[] { "Anchorage", "456-789-0123", "Alaska", "123 Fake Street", "68981-0000" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "City", "PhoneNumber", "State", "Street", "Zip" },
                values: new object[] { "Leesville", "567-890-1234", "Louisiana", "456 Another Street", "01597-0000" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "PhoneNumber", "State", "Street", "Zip" },
                values: new object[] { "Fayetteville", "123-456-7890", "North Carolina", "123 Sample Street", "46514-0000" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "PhoneNumber", "State", "Street", "Zip" },
                values: new object[] { "Fayetteville", "234-567-8901", "North Carolina", "249 MadeUp Road", "46514-0000" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "PhoneNumber", "State", "Street", "Zip" },
                values: new object[] { "Raeford", "345-678-9012", "North Carolina", "903 Imaginary Circle", "46514-0000" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "City", "PhoneNumber", "State", "Street", "Zip" },
                values: new object[] { "Sanford", "456-789-0123", "North Carolina", "191 Nonexistent Lane", "46514-0000" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "City", "PhoneNumber", "State", "Street", "Zip" },
                values: new object[] { "Southern Pines", "567-890-1234", "North Carolina", "902 Fake Street", "46514-0000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeAddressId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeePhoneId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhoneId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddressId", "PhoneId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddressId", "PhoneId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddressId", "PhoneId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddressId", "PhoneId" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddressId", "PhoneId" },
                values: new object[] { 5, 5 });

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

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmployeeAddressId", "EmployeePhoneId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EmployeeAddressId", "EmployeePhoneId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EmployeeAddressId", "EmployeePhoneId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EmployeeAddressId", "EmployeePhoneId" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EmployeeAddressId", "EmployeePhoneId" },
                values: new object[] { 5, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeAddressId",
                table: "Employees",
                column: "EmployeeAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeePhoneId",
                table: "Employees",
                column: "EmployeePhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PhoneId",
                table: "Customers",
                column: "PhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerAddresses_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "CustomerAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerPhones_PhoneId",
                table: "Customers",
                column: "PhoneId",
                principalTable: "CustomerPhones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeAddresses_EmployeeAddressId",
                table: "Employees",
                column: "EmployeeAddressId",
                principalTable: "EmployeeAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeePhones_EmployeePhoneId",
                table: "Employees",
                column: "EmployeePhoneId",
                principalTable: "EmployeePhones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
