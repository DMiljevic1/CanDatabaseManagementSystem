﻿// <auto-generated />
using CanDatabaseManagementSystem.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CanDatabaseManagementSystem.DAL.Migrations
{
    [DbContext(typeof(CanDatabaseContext))]
    [Migration("20240220210738_addedDbcFileTable")]
    partial class addedDbcFileTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CanDatabaseManagementSystem.Domain.Models.DbcFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DbcFiles");
                });

            modelBuilder.Entity("CanDatabaseManagementSystem.Domain.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DbcFileId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DbcFileId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CanDatabaseManagementSystem.Domain.Models.NetworkNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DbcFileId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DbcFileId");

                    b.ToTable("NetworkNodes");
                });

            modelBuilder.Entity("CanDatabaseManagementSystem.Domain.Models.Signal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Lenght")
                        .HasColumnType("int");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartBit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Signals");
                });

            modelBuilder.Entity("CanDatabaseManagementSystem.Domain.Models.Message", b =>
                {
                    b.HasOne("CanDatabaseManagementSystem.Domain.Models.DbcFile", "DbcFile")
                        .WithMany("Messages")
                        .HasForeignKey("DbcFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DbcFile");
                });

            modelBuilder.Entity("CanDatabaseManagementSystem.Domain.Models.NetworkNode", b =>
                {
                    b.HasOne("CanDatabaseManagementSystem.Domain.Models.DbcFile", "DbcFile")
                        .WithMany("NetworkNodes")
                        .HasForeignKey("DbcFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DbcFile");
                });

            modelBuilder.Entity("CanDatabaseManagementSystem.Domain.Models.Signal", b =>
                {
                    b.HasOne("CanDatabaseManagementSystem.Domain.Models.Message", "Message")
                        .WithMany("Signals")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("CanDatabaseManagementSystem.Domain.Models.DbcFile", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("NetworkNodes");
                });

            modelBuilder.Entity("CanDatabaseManagementSystem.Domain.Models.Message", b =>
                {
                    b.Navigation("Signals");
                });
#pragma warning restore 612, 618
        }
    }
}
