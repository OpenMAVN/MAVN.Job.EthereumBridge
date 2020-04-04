﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MAVN.Job.EthereumBridge.MsSqlRepositories.Migrations
{
    [DbContext(typeof(EthereumBridgeContext))]
    partial class EthereumBridgeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ethereum_bridge")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lykke.Job.EthereumBridge.MsSqlRepositories.Entities.BlocksDataEntity", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnName("key");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("value");

                    b.HasKey("Key");

                    b.ToTable("blocks_data");
                });

            modelBuilder.Entity("Lykke.Job.EthereumBridge.MsSqlRepositories.Entities.NonceEntity", b =>
                {
                    b.Property<string>("MasterWalletAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("master_wallet_address");

                    b.Property<long>("Nonce")
                        .HasColumnName("nonce");

                    b.HasKey("MasterWalletAddress");

                    b.ToTable("nonces");
                });

            modelBuilder.Entity("Lykke.Job.EthereumBridge.MsSqlRepositories.Entities.OperationEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnName("last_updated");

                    b.Property<int>("OperationStatus")
                        .HasColumnName("operation_status");

                    b.Property<string>("TransactionData")
                        .HasColumnName("transaction_data");

                    b.Property<string>("TransactionHash")
                        .HasColumnName("transaction_hash");

                    b.HasKey("Id");

                    b.HasIndex("OperationStatus", "LastUpdated");

                    b.ToTable("operations");
                });
#pragma warning restore 612, 618
        }
    }
}