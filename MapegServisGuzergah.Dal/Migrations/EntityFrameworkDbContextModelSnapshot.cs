﻿// <auto-generated />
using System;
using MapegServisGuzergah.Dal.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MapegServisGuzergah.Dal.Migrations
{
    [DbContext(typeof(EntityFrameworkDbContext))]
    partial class EntityFrameworkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("LocationId"));

                    b.Property<int?>("CountyId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Geometry>("Geometry")
                        .HasColumnType("geometry");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UserCreatedId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserModifiedId")
                        .HasColumnType("bigint");

                    b.HasKey("LocationId");

                    b.ToTable("Locations", "public");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("RouteId"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Geometry>("Geometry")
                        .HasColumnType("geometry");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RouteName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("UserCreatedId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserModifiedId")
                        .HasColumnType("bigint");

                    b.HasKey("RouteId");

                    b.ToTable("Routes", "public");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("StationId"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StationName")
                        .HasColumnType("text");

                    b.Property<long?>("UserCreatedId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserModifiedId")
                        .HasColumnType("bigint");

                    b.HasKey("StationId");

                    b.ToTable("Stations", "public");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("UserId"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UserCreatedId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserModifiedId")
                        .HasColumnType("bigint");

                    b.Property<int>("VoyageId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("VoyageId");

                    b.ToTable("Users", "public");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("VehicleId"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("integer");

                    b.Property<string>("Plate")
                        .HasColumnType("text");

                    b.Property<long?>("UserCreatedId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserModifiedId")
                        .HasColumnType("bigint");

                    b.Property<int>("VoyageId")
                        .HasColumnType("integer");

                    b.HasKey("VehicleId");

                    b.HasIndex("VoyageId");

                    b.ToTable("Vehicles", "public");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.Voyage", b =>
                {
                    b.Property<int>("VoyageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("VoyageId"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.Property<long?>("UserCreatedId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("VoyageName")
                        .HasColumnType("text");

                    b.HasKey("VoyageId");

                    b.HasIndex("RouteId");

                    b.ToTable("Voyages", "public");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.VoyageStations", b =>
                {
                    b.Property<int>("VoyageStationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("VoyageStationId"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StationId")
                        .HasColumnType("integer");

                    b.Property<long?>("UserCreatedId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserModifiedId")
                        .HasColumnType("bigint");

                    b.Property<int>("VoyageId")
                        .HasColumnType("integer");

                    b.HasKey("VoyageStationId");

                    b.HasIndex("StationId");

                    b.HasIndex("VoyageId");

                    b.ToTable("VoyageStations", "public");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.Location", b =>
                {
                    b.HasOne("MapegServisGuzergah.Entity.Entities.Station", "Station")
                        .WithOne("Location")
                        .HasForeignKey("MapegServisGuzergah.Entity.Entities.Location", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.User", b =>
                {
                    b.HasOne("MapegServisGuzergah.Entity.Entities.Voyage", "Voyage")
                        .WithMany("Users")
                        .HasForeignKey("VoyageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voyage");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.Vehicle", b =>
                {
                    b.HasOne("MapegServisGuzergah.Entity.Entities.Voyage", "Voyage")
                        .WithMany("Vehicles")
                        .HasForeignKey("VoyageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voyage");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.Voyage", b =>
                {
                    b.HasOne("MapegServisGuzergah.Entity.Entities.Route", "Route")
                        .WithMany("Voyages")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.VoyageStations", b =>
                {
                    b.HasOne("MapegServisGuzergah.Entity.Entities.Station", "Station")
                        .WithMany("VoyageStations")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MapegServisGuzergah.Entity.Entities.Voyage", "Voyage")
                        .WithMany("VoyageStations")
                        .HasForeignKey("VoyageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");

                    b.Navigation("Voyage");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.Route", b =>
                {
                    b.Navigation("Voyages");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.Station", b =>
                {
                    b.Navigation("Location");

                    b.Navigation("VoyageStations");
                });

            modelBuilder.Entity("MapegServisGuzergah.Entity.Entities.Voyage", b =>
                {
                    b.Navigation("Users");

                    b.Navigation("Vehicles");

                    b.Navigation("VoyageStations");
                });
#pragma warning restore 612, 618
        }
    }
}
