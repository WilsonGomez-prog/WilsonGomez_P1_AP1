﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WilsonGomez_P1_AP1.DAL;

namespace WilsonGomez_P1_AP1.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("WilsonGomez_P1_AP1.Entidades.Ciudades", b =>
                {
                    b.Property<int>("CiudadID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("CiudadID");

                    b.ToTable("ciudades");
                });
#pragma warning restore 612, 618
        }
    }
}
