﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OralHealthManagement.Data;

namespace OralHealthManagement.Migrations
{
    [DbContext(typeof(OralHealthManagementContext))]
    [Migration("20200119154748_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OralHealthManagement.Models.Demography", b =>
                {
                    b.Property<string>("ChartNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("BeenICU")
                        .HasColumnType("bit");

                    b.Property<bool>("Comorbidity_COPD")
                        .HasColumnType("bit");

                    b.Property<bool>("Comorbidity_CRF")
                        .HasColumnType("bit");

                    b.Property<bool>("Comorbidity_CVD")
                        .HasColumnType("bit");

                    b.Property<bool>("Comorbidity_Cancer")
                        .HasColumnType("bit");

                    b.Property<bool>("Comorbidity_DM")
                        .HasColumnType("bit");

                    b.Property<bool>("Comorbidity_Dementia")
                        .HasColumnType("bit");

                    b.Property<bool>("Comorbidity_HF")
                        .HasColumnType("bit");

                    b.Property<bool>("Comorbidity_HTN")
                        .HasColumnType("bit");

                    b.Property<bool>("Comorbidity_Imune")
                        .HasColumnType("bit");

                    b.Property<bool>("Comorbidity_Liver")
                        .HasColumnType("bit");

                    b.Property<string>("Conscious")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dx")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Edu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromWhere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChartNo");

                    b.ToTable("Demography");
                });
#pragma warning restore 612, 618
        }
    }
}
