﻿// <auto-generated />
using System;
using CoralSafe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoralSafe.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240531203428_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoralSafe.Models.Campanha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("data_publicacao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("Data_Campanha");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Descricao_Camapanha");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Name_Campanha");

                    b.Property<int>("ongId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<float>("valorMeta")
                        .HasColumnType("BINARY_FLOAT")
                        .HasColumnName("Valor_Campanha");

                    b.HasKey("Id");

                    b.HasIndex("ongId");

                    b.ToTable("T_CORALSAFE_CAMPANHA");
                });

            modelBuilder.Entity("CoralSafe.Models.Donate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDonate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("Data_Doacao");

                    b.Property<int>("Userid")
                        .HasColumnType("NUMBER(10)");

                    b.Property<float>("Valor")
                        .HasColumnType("BINARY_FLOAT")
                        .HasColumnName("Valor_Doado");

                    b.Property<int>("idUserDonate")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Id_Doador");

                    b.HasKey("Id");

                    b.HasIndex("Userid");

                    b.ToTable("T_CORALSAFE_APOIO");
                });

            modelBuilder.Entity("CoralSafe.Models.Ong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOng")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATA_CRIACAO");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NOME_ONG");

                    b.Property<int>("cnpj")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("EMAIL_ONG");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ENDERECO");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ESTADO");

                    b.Property<int>("telefone")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("TELEFONE_ONG");

                    b.HasKey("Id");

                    b.ToTable("T_CORALSAFE_ONG");
                });

            modelBuilder.Entity("CoralSafe.Models.Produto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("NOME");

                    b.Property<int>("QntPontos")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("QUANTIDADE_PONTOS");

                    b.HasKey("ID");

                    b.ToTable("T_CORALSAFE_PRODUTOS");
                });

            modelBuilder.Entity("CoralSafe.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("IsActive")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Status_Usuario");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Email_Usuario");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("Name_Usuario");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Senha_Do_Usuario");

                    b.Property<int>("pontos")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Pontos");

                    b.Property<DateTime>("timeRegister")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("Data_Cadastro");

                    b.HasKey("id");

                    b.ToTable("T_CORALSAFE_USUARIO");
                });

            modelBuilder.Entity("CoralSafe.Models.Campanha", b =>
                {
                    b.HasOne("CoralSafe.Models.Ong", "ong")
                        .WithMany()
                        .HasForeignKey("ongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ong");
                });

            modelBuilder.Entity("CoralSafe.Models.Donate", b =>
                {
                    b.HasOne("CoralSafe.Models.User", "User")
                        .WithMany("donates")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoralSafe.Models.User", b =>
                {
                    b.Navigation("donates");
                });
#pragma warning restore 612, 618
        }
    }
}
