﻿// <auto-generated />
using System;
using API.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20220309013047_Start")]
    partial class Start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API.Model.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Cpf")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .IsRequired()
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

                    b.Property<string>("Permissao")
                        .HasColumnType("longtext")
                        .HasColumnName("permissao");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("senha");

                    b.Property<decimal?>("WhatsApp")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("whats-app");

                    b.HasKey("Id");

                    b.ToTable("person");
                });
#pragma warning restore 612, 618
        }
    }
}
