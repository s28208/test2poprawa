using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectTypes",
                columns: table => new
                {
                    ObjectTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectTypes", x => x.ObjectTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerID);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseID);
                });

            migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseID = table.Column<int>(type: "int", nullable: false),
                    ObjectTypeID = table.Column<int>(type: "int", nullable: false),
                    Wigth = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objects", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_Objects_ObjectTypes_ObjectTypeID",
                        column: x => x.ObjectTypeID,
                        principalTable: "ObjectTypes",
                        principalColumn: "ObjectTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objects_Warehouses_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Object_Owner",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Object_Owner", x => new { x.ObjectID, x.OwnerID });
                    table.ForeignKey(
                        name: "FK_Object_Owner_Objects_ObjectID",
                        column: x => x.ObjectID,
                        principalTable: "Objects",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Object_Owner_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "OwnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ObjectTypes",
                columns: new[] { "ObjectTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "ot1" },
                    { 2, "ot2" },
                    { 3, "ot3" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerID", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski", "111111111" },
                    { 2, "Anna", "Nowak", "222222222" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseID", "Name" },
                values: new object[,]
                {
                    { 1, "h1" },
                    { 2, "h2" },
                    { 3, "h3" }
                });

            migrationBuilder.InsertData(
                table: "Objects",
                columns: new[] { "ObjectID", "Height", "ObjectTypeID", "WarehouseID", "Wigth" },
                values: new object[,]
                {
                    { 1, 5, 1, 1, 4 },
                    { 2, 1, 2, 2, 9 }
                });

            migrationBuilder.InsertData(
                table: "Object_Owner",
                columns: new[] { "ObjectID", "OwnerID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Object_Owner_OwnerID",
                table: "Object_Owner",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_ObjectTypeID",
                table: "Objects",
                column: "ObjectTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_WarehouseID",
                table: "Objects",
                column: "WarehouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Object_Owner");

            migrationBuilder.DropTable(
                name: "Objects");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "ObjectTypes");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
