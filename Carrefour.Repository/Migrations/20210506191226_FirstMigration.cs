using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrefour.Repository.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XFactor = table.Column<int>(type: "int", nullable: false),
                    YFactor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalXPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    SpentAmount = table.Column<int>(type: "int", nullable: false),
                    XPoints = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransactionTypes_Transactions_ID",
                        column: x => x.ID,
                        principalTable: "Transactions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "ID", "XFactor", "YFactor" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "TotalXPoints" },
                values: new object[,]
                {
                    { 1, 200 },
                    { 2, 400 },
                    { 3, 600 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "ID", "CreatedDate", "CustomerID", "Expired", "SpentAmount", "XPoints" },
                values: new object[] { 1, new DateTime(2021, 5, 6, 21, 12, 26, 308, DateTimeKind.Local).AddTicks(2327), 1, false, 500, 500 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "ID", "CreatedDate", "CustomerID", "Expired", "SpentAmount", "XPoints" },
                values: new object[] { 2, new DateTime(2021, 5, 6, 21, 12, 26, 308, DateTimeKind.Local).AddTicks(8380), 1, false, 300, 300 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "ID", "CreatedDate", "CustomerID", "Expired", "SpentAmount", "XPoints" },
                values: new object[] { 3, new DateTime(2021, 5, 6, 21, 12, 26, 308, DateTimeKind.Local).AddTicks(8395), 2, false, 600, 600 });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "ID", "Type" },
                values: new object[] { 1, "Purchase" });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "ID", "Type" },
                values: new object[] { 2, "Redeem" });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerID",
                table: "Transactions",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
