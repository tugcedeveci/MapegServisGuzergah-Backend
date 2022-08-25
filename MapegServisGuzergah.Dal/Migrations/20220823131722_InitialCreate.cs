using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MapegServisGuzergah.Dal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "Routes",
                schema: "public",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    RouteName = table.Column<string>(type: "text", nullable: false),
                    Geometry = table.Column<Geometry>(type: "geometry", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: true),
                    UserModifiedId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                schema: "public",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: true),
                    UserModifiedId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "Voyages",
                schema: "public",
                columns: table => new
                {
                    VoyageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    VoyageName = table.Column<string>(type: "text", nullable: true),
                    RouteId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: true),
                    UserModifiedId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyages", x => x.VoyageId);
                    table.ForeignKey(
                        name: "FK_Voyages_Routes_RouteId",
                        column: x => x.RouteId,
                        principalSchema: "public",
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "public",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CountyId = table.Column<int>(type: "integer", nullable: true),
                    Geometry = table.Column<Geometry>(type: "geometry", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: true),
                    UserModifiedId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Stations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "public",
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "public",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    VoyageId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: true),
                    UserModifiedId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Voyages_VoyageId",
                        column: x => x.VoyageId,
                        principalSchema: "public",
                        principalTable: "Voyages",
                        principalColumn: "VoyageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                schema: "public",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Plate = table.Column<string>(type: "text", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "integer", nullable: false),
                    VoyageId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: true),
                    UserModifiedId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Voyages_VoyageId",
                        column: x => x.VoyageId,
                        principalSchema: "public",
                        principalTable: "Voyages",
                        principalColumn: "VoyageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoyageStations",
                schema: "public",
                columns: table => new
                {
                    VoyageStationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    VoyageId = table.Column<int>(type: "integer", nullable: false),
                    StationId = table.Column<int>(type: "integer", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: true),
                    UserModifiedId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoyageStations", x => x.VoyageStationId);
                    table.ForeignKey(
                        name: "FK_VoyageStations_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "public",
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoyageStations_Voyages_VoyageId",
                        column: x => x.VoyageId,
                        principalSchema: "public",
                        principalTable: "Voyages",
                        principalColumn: "VoyageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_VoyageId",
                schema: "public",
                table: "Users",
                column: "VoyageId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VoyageId",
                schema: "public",
                table: "Vehicles",
                column: "VoyageId");

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_RouteId",
                schema: "public",
                table: "Voyages",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_VoyageStations_StationId",
                schema: "public",
                table: "VoyageStations",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_VoyageStations_VoyageId",
                schema: "public",
                table: "VoyageStations",
                column: "VoyageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "VoyageStations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Stations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Voyages",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Routes",
                schema: "public");
        }
    }
}
