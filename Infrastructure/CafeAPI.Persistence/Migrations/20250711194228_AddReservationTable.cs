using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "BEKLİYOR"),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    CafeId = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumberOfPeople = table.Column<byte>(type: "tinyint", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_CafeInfos_CafeId",
                        column: x => x.CafeId,
                        principalTable: "CafeInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CafeId",
                table: "Reservations",
                column: "CafeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Id",
                table: "Reservations",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
