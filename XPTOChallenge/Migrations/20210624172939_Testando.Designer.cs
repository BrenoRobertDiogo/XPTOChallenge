﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XPTOChallenge.Data;

namespace XPTOChallenge.Migrations
{
    [DbContext(typeof(XPTOChallengeContext))]
    [Migration("20210624172939_Testando")]
    partial class Testando
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("XPTOChallenge.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CEP");

                    b.Property<int>("CNPJClient")
                        .HasMaxLength(14);

                    b.Property<string>("nomeCliente");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("XPTOChallenge.Models.OrdemServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPFPrestador")
                        .HasMaxLength(11);

                    b.Property<int?>("clienteId");

                    b.Property<DateTime>("dataExecucao");

                    b.Property<string>("nomePrestador");

                    b.Property<string>("tituloServico");

                    b.Property<double>("valorServico");

                    b.HasKey("Id");

                    b.HasIndex("clienteId");

                    b.ToTable("OrdemServico");
                });

            modelBuilder.Entity("XPTOChallenge.Models.OrdemServico", b =>
                {
                    b.HasOne("XPTOChallenge.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("clienteId");
                });
#pragma warning restore 612, 618
        }
    }
}
