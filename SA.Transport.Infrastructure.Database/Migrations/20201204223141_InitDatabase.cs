using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SA.Transport.Infrastructure.Database.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PN = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MakeGE = table.Column<string>(maxLength: 50, nullable: false),
                    MakeEN = table.Column<string>(maxLength: 50, nullable: false),
                    ModelGE = table.Column<string>(maxLength: 50, nullable: false),
                    ModelEN = table.Column<string>(maxLength: 50, nullable: false),
                    VinCode = table.Column<string>(maxLength: 100, nullable: false),
                    Number = table.Column<string>(maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ColorId = table.Column<Guid>(nullable: false),
                    PhotoName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transports_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportFuelType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FuelTypeId = table.Column<Guid>(nullable: false),
                    TransportId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportFuelType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportFuelType_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportFuelType_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TransportId = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportOwners_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportOwners_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("011f6864-ebc0-4b90-b086-171338138128"), "თეთრი" },
                    { new Guid("5dd1f2cf-4be3-4e35-9de8-94517d20b430"), "ვერცხლისფერი" },
                    { new Guid("abdf990e-4c5c-4da6-bf9d-74acf211389b"), "შავი" },
                    { new Guid("1d8df33e-b122-40d7-81fa-96bd9f6fe28c"), "ლურჯი" },
                    { new Guid("37510c12-15e1-43ff-a698-ae13fab578cb"), "წითელი" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("7de331c8-a8f0-4ecd-9391-a3eabff2ac4e"), "ბენზინი" },
                    { new Guid("545721d4-3e3d-4f28-9980-aaf97f4f86bd"), "ელექტრო" },
                    { new Guid("0de7c688-10bb-4ae2-98ff-363126680486"), "გაზი" },
                    { new Guid("1c37af91-a690-43ef-89c0-9ff4e0ba9198"), "დიზელი" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName", "PN" },
                values: new object[,]
                {
                    { new Guid("f8df66c6-4efa-460e-951e-993ceb79e5f2"), "გიორგი", "გიორგაძე", "00000000000" },
                    { new Guid("11181dfb-55c9-4333-9be6-d1c25afc654c"), "ნინო", "ნინიძე", "11111111111" },
                    { new Guid("1a58910b-7436-4757-b77d-eed5e584af8b"), "ხატია", "ხატიაშვილი", "22222222222" }
                });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "Id", "ColorId", "CreateDate", "MakeEN", "MakeGE", "ModelEN", "ModelGE", "Number", "PhotoName", "VinCode" },
                values: new object[] { new Guid("03a8858c-c3c8-470c-bd6c-92219fe000c3"), new Guid("011f6864-ebc0-4b90-b086-171338138128"), new DateTime(2017, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), "Ford", "ფორდი", "Fusion", "ფუჯნ", "TE-111-ST", null, "1111" });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "Id", "ColorId", "CreateDate", "MakeEN", "MakeGE", "ModelEN", "ModelGE", "Number", "PhotoName", "VinCode" },
                values: new object[] { new Guid("3c4a2fe1-ab0d-495f-943c-42fbe65c295b"), new Guid("abdf990e-4c5c-4da6-bf9d-74acf211389b"), new DateTime(2015, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), "Mercedes", "მერსედესი", "A-Klasse", "ა-კლასი", "TE-222-ST", null, "2222" });

            migrationBuilder.InsertData(
                table: "TransportFuelType",
                columns: new[] { "Id", "EndDate", "FuelTypeId", "StartDate", "TransportId" },
                values: new object[,]
                {
                    { new Guid("05eba01b-a3ce-45b1-b7db-1ddedbd0ff69"), null, new Guid("7de331c8-a8f0-4ecd-9391-a3eabff2ac4e"), new DateTime(2017, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), new Guid("03a8858c-c3c8-470c-bd6c-92219fe000c3") },
                    { new Guid("4d8978b4-2f11-4b4e-87a5-df0e2bda0c7a"), null, new Guid("545721d4-3e3d-4f28-9980-aaf97f4f86bd"), new DateTime(2017, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), new Guid("03a8858c-c3c8-470c-bd6c-92219fe000c3") },
                    { new Guid("2d5b8bd1-c0e0-48c6-9999-a9b5552a140f"), null, new Guid("7de331c8-a8f0-4ecd-9391-a3eabff2ac4e"), new DateTime(2015, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), new Guid("3c4a2fe1-ab0d-495f-943c-42fbe65c295b") }
                });

            migrationBuilder.InsertData(
                table: "TransportOwners",
                columns: new[] { "Id", "EndDate", "PersonId", "StartDate", "TransportId" },
                values: new object[,]
                {
                    { new Guid("1a14a1c8-c253-4ba0-af77-1f4dc42b8ece"), null, new Guid("f8df66c6-4efa-460e-951e-993ceb79e5f2"), new DateTime(2020, 5, 5, 2, 31, 41, 287, DateTimeKind.Local).AddTicks(1867), new Guid("03a8858c-c3c8-470c-bd6c-92219fe000c3") },
                    { new Guid("fb1b0ac6-1e10-4e7d-9400-9d1ead8d6383"), null, new Guid("11181dfb-55c9-4333-9be6-d1c25afc654c"), new DateTime(2019, 12, 5, 2, 31, 41, 287, DateTimeKind.Local).AddTicks(2509), new Guid("3c4a2fe1-ab0d-495f-943c-42fbe65c295b") },
                    { new Guid("5a02ea75-dcd6-4148-bfcd-a9548b103753"), null, new Guid("1a58910b-7436-4757-b77d-eed5e584af8b"), new DateTime(2020, 9, 5, 2, 31, 41, 287, DateTimeKind.Local).AddTicks(2531), new Guid("3c4a2fe1-ab0d-495f-943c-42fbe65c295b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_PN",
                table: "People",
                column: "PN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportFuelType_FuelTypeId",
                table: "TransportFuelType",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportFuelType_TransportId",
                table: "TransportFuelType",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportOwners_PersonId",
                table: "TransportOwners",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportOwners_TransportId",
                table: "TransportOwners",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_ColorId",
                table: "Transports",
                column: "ColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportFuelType");

            migrationBuilder.DropTable(
                name: "TransportOwners");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
