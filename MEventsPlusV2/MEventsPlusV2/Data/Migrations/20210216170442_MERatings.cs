using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MEventsPlusV2.Data.Migrations
{
    public partial class MERatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Availability = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MERatings = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telno = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Jobrole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Staffs_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingsEvents",
                columns: table => new
                {
                    BookingsID = table.Column<int>(type: "int", nullable: false),
                    EventsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsEvents", x => new { x.BookingsID, x.EventsID });
                    table.ForeignKey(
                        name: "FK_BookingsEvents_Bookings_BookingsID",
                        column: x => x.BookingsID,
                        principalTable: "Bookings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingsEvents_Events_EventsID",
                        column: x => x.EventsID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EAddresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EAddressID = table.Column<int>(type: "int", nullable: true),
                    EventsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EAddresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EAddresses_EAddresses_EAddressID",
                        column: x => x.EAddressID,
                        principalTable: "EAddresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EAddresses_Events_EventsID",
                        column: x => x.EventsID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Availability = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EInfoID = table.Column<int>(type: "int", nullable: true),
                    EventsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EInfo_EInfo_EInfoID",
                        column: x => x.EInfoID,
                        principalTable: "EInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EInfo_Events_EventsID",
                        column: x => x.EventsID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SAddress",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SAddressID = table.Column<int>(type: "int", nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAddress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SAddress_SAddress_SAddressID",
                        column: x => x.SAddressID,
                        principalTable: "SAddress",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SAddress_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telno = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Jobrole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SInfoID = table.Column<int>(type: "int", nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SInfo_SInfo_SInfoID",
                        column: x => x.SInfoID,
                        principalTable: "SInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SInfo_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CAddress",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CAddressID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAddress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CAddress_CAddress_CAddressID",
                        column: x => x.CAddressID,
                        principalTable: "CAddress",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dateofbirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telno = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CInfoID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CInfo_CInfo_CInfoID",
                        column: x => x.CInfoID,
                        principalTable: "CInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ID1 = table.Column<int>(type: "int", nullable: false),
                    Dateofbirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telno = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_User_ID",
                        column: x => x.ID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingsEvents_EventsID",
                table: "BookingsEvents",
                column: "EventsID");

            migrationBuilder.CreateIndex(
                name: "IX_CAddress_CAddressID",
                table: "CAddress",
                column: "CAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_CAddress_CustomerID",
                table: "CAddress",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CInfo_CInfoID",
                table: "CInfo",
                column: "CInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_CInfo_CustomerID",
                table: "CInfo",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_EAddresses_EAddressID",
                table: "EAddresses",
                column: "EAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_EAddresses_EventsID",
                table: "EAddresses",
                column: "EventsID");

            migrationBuilder.CreateIndex(
                name: "IX_EInfo_EInfoID",
                table: "EInfo",
                column: "EInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_EInfo_EventsID",
                table: "EInfo",
                column: "EventsID");

            migrationBuilder.CreateIndex(
                name: "IX_SAddress_SAddressID",
                table: "SAddress",
                column: "SAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_SAddress_StaffID",
                table: "SAddress",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_SInfo_SInfoID",
                table: "SInfo",
                column: "SInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_SInfo_StaffID",
                table: "SInfo",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffID",
                table: "Staffs",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CustomerID",
                table: "User",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_CAddress_Customers_CustomerID",
                table: "CAddress",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CInfo_Customers_CustomerID",
                table: "CInfo",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Customers_CustomerID",
                table: "User",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Customers_CustomerID",
                table: "User");

            migrationBuilder.DropTable(
                name: "BookingsEvents");

            migrationBuilder.DropTable(
                name: "CAddress");

            migrationBuilder.DropTable(
                name: "CInfo");

            migrationBuilder.DropTable(
                name: "EAddresses");

            migrationBuilder.DropTable(
                name: "EInfo");

            migrationBuilder.DropTable(
                name: "SAddress");

            migrationBuilder.DropTable(
                name: "SInfo");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
