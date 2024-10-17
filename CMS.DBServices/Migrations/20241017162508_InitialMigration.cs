using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DBServices.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courier",
                columns: table => new
                {
                    CourierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    RouteID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courier", x => x.CourierID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteID);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ShipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentPrice = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    ShipmentWeight = table.Column<double>(type: "float", nullable: false),
                    ShipmentAddress = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CustomerPhone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ShipmentID);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentsBooked",
                columns: table => new
                {
                    ShipmentBookedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentID = table.Column<int>(type: "int", nullable: false),
                    CourierID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shipment__D2CB3F41C3C0A7C1", x => x.ShipmentBookedID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    FullName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    VendorEmail = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    VendorAddress = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorID);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Vendors__1788CC4D656BF494",
                table: "Vendors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Vendors__F0E72A773491B1DB",
                table: "Vendors",
                column: "VendorEmail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courier");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "ShipmentsBooked");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
