﻿// <auto-generated />
using BeleskeBlazor.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeleskeBlazor.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240407210519_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeleskeBlazor.Client.Data.Model.Beleska", b =>
                {
                    b.Property<int>("IdBeleska")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBeleska"));

                    b.Property<byte[]>("dokument")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("idCas")
                        .HasColumnType("int");

                    b.Property<int>("idStudent")
                        .HasColumnType("int");

                    b.Property<string>("naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("redniBroj")
                        .HasColumnType("int");

                    b.HasKey("IdBeleska");

                    b.ToTable("Beleske");
                });
#pragma warning restore 612, 618
        }
    }
}