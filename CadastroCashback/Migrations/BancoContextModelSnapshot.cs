﻿// <auto-generated />
using System;
using CadastroCashback.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroCashback.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("CadastroCashback.Models.Cashback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCredito")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransacaoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ValorCashback")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TransacaoId");

                    b.ToTable("Cashbacks", (string)null);
                });

            modelBuilder.Entity("CadastroCashback.Models.ContatoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Limite")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Quant")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contatos", (string)null);
                });

            modelBuilder.Entity("CadastroCashback.Models.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataTransacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TransacaoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Valor")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TransacaoId");

                    b.ToTable("Transacoes", (string)null);
                });

            modelBuilder.Entity("CadastroCashback.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("CadastroCashback.Models.Cashback", b =>
                {
                    b.HasOne("CadastroCashback.Models.Transacao", "Transacao")
                        .WithMany("Cashbacks")
                        .HasForeignKey("TransacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transacao");
                });

            modelBuilder.Entity("CadastroCashback.Models.Transacao", b =>
                {
                    b.HasOne("CadastroCashback.Models.Usuario", "Usuario")
                        .WithMany("Transacoes")
                        .HasForeignKey("TransacaoId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CadastroCashback.Models.Transacao", b =>
                {
                    b.Navigation("Cashbacks");
                });

            modelBuilder.Entity("CadastroCashback.Models.Usuario", b =>
                {
                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
