﻿// <auto-generated />
using System;
using API.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(MySQLContext))]
    partial class MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API.Model.Events", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Category")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("category");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.Property<int?>("PersonId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDay")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("state");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("API.Model.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("descricao");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Usuário"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Convidado"
                        });
                });

            modelBuilder.Entity("API.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Cpf")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("email");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.Property<int?>("PermissaoId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("senha");

                    b.Property<decimal?>("WhatsApp")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("whats-app");

                    b.HasKey("Id");

                    b.HasIndex("PermissaoId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "11122233344",
                            Email = "admin@admin.com.br",
                            ImageUrl = "http://google.com.br",
                            Name = "admin",
                            PermissaoId = 1,
                            Senha = "admin",
                            WhatsApp = 11233445566m
                        });
                });

            modelBuilder.Entity("API.Model.Events", b =>
                {
                    b.HasOne("API.Model.Person", "id")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("id");
                });

            modelBuilder.Entity("API.Model.Person", b =>
                {
                    b.HasOne("API.Model.Permission", "id")
                        .WithMany()
                        .HasForeignKey("PermissaoId");

                    b.Navigation("id");
                });
#pragma warning restore 612, 618
        }
    }
}
