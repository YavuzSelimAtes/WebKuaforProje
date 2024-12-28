﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebKuaforProje.Data;

#nullable disable

namespace WebKuaforProje.Migrations
{
    [DbContext(typeof(VeriTabani))]
    partial class VeriTabaniModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebKuaforProje.Data.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Kullanici_ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("KullaniciAdi");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Kimlik");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Sifre");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TelefonNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Kullanici", (string)null);
                });

            modelBuilder.Entity("WebKuaforProje.Data.Personel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Subesi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UzmanlikAlani")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Subesi");

                    b.ToTable("Personeller");
                });

            modelBuilder.Entity("WebKuaforProje.Data.Sube", b =>
                {
                    b.Property<string>("Sehir")
                        .HasColumnType("text")
                        .HasColumnName("Sehir");

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Isim");

                    b.Property<string>("TamAdres")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TamAdres");

                    b.HasKey("Sehir");

                    b.ToTable("Subeler", (string)null);
                });

            modelBuilder.Entity("WebKuaforProje.Data.Personel", b =>
                {
                    b.HasOne("WebKuaforProje.Data.Kullanici", "Kullanici")
                        .WithOne("Personel")
                        .HasForeignKey("WebKuaforProje.Data.Personel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebKuaforProje.Data.Sube", "Sube")
                        .WithMany("Personeller")
                        .HasForeignKey("Subesi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");

                    b.Navigation("Sube");
                });

            modelBuilder.Entity("WebKuaforProje.Data.Kullanici", b =>
                {
                    b.Navigation("Personel")
                        .IsRequired();
                });

            modelBuilder.Entity("WebKuaforProje.Data.Sube", b =>
                {
                    b.Navigation("Personeller");
                });
#pragma warning restore 612, 618
        }
    }
}
