using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockBikes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frames",
                columns: table => new
                {
                    FrameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frames", x => x.FrameID);
                });

            migrationBuilder.CreateTable(
                name: "Pedals",
                columns: table => new
                {
                    PedalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedals", x => x.PedalID);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatID);
                });

            migrationBuilder.CreateTable(
                name: "Tubes",
                columns: table => new
                {
                    TubeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tubes", x => x.TubeID);
                });

            migrationBuilder.CreateTable(
                name: "Wheels",
                columns: table => new
                {
                    WheelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrameID = table.Column<int>(type: "int", nullable: false),
                    TubeID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wheels", x => x.WheelID);
                    table.ForeignKey(
                        name: "FK_Wheels_Frames_FrameID",
                        column: x => x.FrameID,
                        principalTable: "Frames",
                        principalColumn: "FrameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wheels_Tubes_TubeID",
                        column: x => x.TubeID,
                        principalTable: "Tubes",
                        principalColumn: "TubeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    BikeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatID = table.Column<int>(type: "int", nullable: false),
                    LeftPedalID = table.Column<int>(type: "int", nullable: false),
                    RightPedalID = table.Column<int>(type: "int", nullable: false),
                    LeftWheelID = table.Column<int>(type: "int", nullable: false),
                    RightWheelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.BikeID);
                    table.ForeignKey(
                        name: "FK_Bikes_Pedals_LeftPedalID",
                        column: x => x.LeftPedalID,
                        principalTable: "Pedals",
                        principalColumn: "PedalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bikes_Pedals_RightPedalID",
                        column: x => x.RightPedalID,
                        principalTable: "Pedals",
                        principalColumn: "PedalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bikes_Seats_SeatID",
                        column: x => x.SeatID,
                        principalTable: "Seats",
                        principalColumn: "SeatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bikes_Wheels_LeftWheelID",
                        column: x => x.LeftWheelID,
                        principalTable: "Wheels",
                        principalColumn: "WheelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bikes_Wheels_RightWheelID",
                        column: x => x.RightWheelID,
                        principalTable: "Wheels",
                        principalColumn: "WheelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_LeftPedalID",
                table: "Bikes",
                column: "LeftPedalID");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_LeftWheelID",
                table: "Bikes",
                column: "LeftWheelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_RightPedalID",
                table: "Bikes",
                column: "RightPedalID");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_RightWheelID",
                table: "Bikes",
                column: "RightWheelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_SeatID",
                table: "Bikes",
                column: "SeatID");

            migrationBuilder.CreateIndex(
                name: "IX_Wheels_FrameID",
                table: "Wheels",
                column: "FrameID");

            migrationBuilder.CreateIndex(
                name: "IX_Wheels_TubeID",
                table: "Wheels",
                column: "TubeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Pedals");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Wheels");

            migrationBuilder.DropTable(
                name: "Frames");

            migrationBuilder.DropTable(
                name: "Tubes");
        }
    }
}
