using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheMusicRoomDB.Migrations
{
    /// <inheritdoc />
    public partial class createequipmentlistview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW [dbo].[vwEquipmentList]
AS
SELECT et.Type, m.Name AS ""Model"", b.Name AS ""Brand"", e.Condition
FROM Equipment e
JOIN EquipmentTypes et ON et.Id = e.EquipmentTypeId
JOIN Models m ON m.Id = e.ModelId
JOIN Brands b ON b.Id = m.BrandId
GO");
        }
    }
}
