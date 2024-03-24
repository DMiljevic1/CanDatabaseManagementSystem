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
    [Migration("20240324090940_AddedCanMessageIdCoulumn")]
    partial class AddedCanMessageIdCoulumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainModels.Models.DbcFile", b =>
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

            modelBuilder.Entity("DomainModels.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("CanMessageId")
                        .HasColumnType("bigint");

                    b.Property<int>("DbcFileId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DbcFileId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("DomainModels.Models.NetworkNode", b =>
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

            modelBuilder.Entity("DomainModels.Models.Signal", b =>
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

            modelBuilder.Entity("DomainModels.Models.Message", b =>
                {
                    b.HasOne("DomainModels.Models.DbcFile", "DbcFile")
                        .WithMany("Messages")
                        .HasForeignKey("DbcFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DbcFile");
                });

            modelBuilder.Entity("DomainModels.Models.NetworkNode", b =>
                {
                    b.HasOne("DomainModels.Models.DbcFile", "DbcFile")
                        .WithMany("NetworkNodes")
                        .HasForeignKey("DbcFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DbcFile");
                });

            modelBuilder.Entity("DomainModels.Models.Signal", b =>
                {
                    b.HasOne("DomainModels.Models.Message", "Message")
                        .WithMany("Signals")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("DomainModels.Models.DbcFile", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("NetworkNodes");
                });

            modelBuilder.Entity("DomainModels.Models.Message", b =>
                {
                    b.Navigation("Signals");
                });
#pragma warning restore 612, 618
        }
    }
}
