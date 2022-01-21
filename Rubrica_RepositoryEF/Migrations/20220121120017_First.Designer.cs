﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryEF;

#nullable disable

namespace Rubrica_RepositoryEF.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220121120017_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Rubrica_Core.Models.Contatto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Contatto", (string)null);
                });

            modelBuilder.Entity("Rubrica_Core.Models.Indirizzo", b =>
                {
                    b.Property<int>("IndirizzoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IndirizzoId"), 1L, 1);

                    b.Property<string>("Cap")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength();

                    b.Property<string>("Città")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ContattoId")
                        .HasColumnType("int");

                    b.Property<string>("Nazione")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Tipologia")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Via")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IndirizzoId");

                    b.HasIndex("ContattoId");

                    b.ToTable("Indirizzo", (string)null);
                });

            modelBuilder.Entity("Rubrica_Core.Models.Indirizzo", b =>
                {
                    b.HasOne("Rubrica_Core.Models.Contatto", "Contatto")
                        .WithMany("Indirizzi")
                        .HasForeignKey("ContattoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FKContatto");

                    b.Navigation("Contatto");
                });

            modelBuilder.Entity("Rubrica_Core.Models.Contatto", b =>
                {
                    b.Navigation("Indirizzi");
                });
#pragma warning restore 612, 618
        }
    }
}