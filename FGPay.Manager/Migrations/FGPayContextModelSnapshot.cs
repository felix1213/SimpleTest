﻿// <auto-generated />
using System;
using FGPay.Manager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FGPay.Manager.Migrations
{
    [DbContext(typeof(FGPayContext))]
    partial class FGPayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FGPay.Models.Agent", b =>
                {
                    b.Property<int>("AgentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountCardNumber")
                        .HasMaxLength(20);

                    b.Property<string>("AccountName")
                        .HasMaxLength(50);

                    b.Property<string>("AgentFullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte>("AgentState")
                        .HasColumnType("tinyint");

                    b.Property<string>("AgentUserID")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.Property<string>("BankFullName")
                        .HasMaxLength(50);

                    b.Property<string>("ClientIP")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("LastLoginTime");

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("Operator")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(100);

                    b.HasKey("AgentID");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("FGPay.Models.AgentCreditLog", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AgentUserID")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<decimal>("BeforeCredit")
                        .HasColumnType("money");

                    b.Property<DateTime>("CreateTime");

                    b.Property<byte>("CreditLogType")
                        .HasColumnType("tinyint");

                    b.Property<string>("MerchantUserID")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("OrderNumber")
                        .HasMaxLength(20);

                    b.Property<string>("Remark")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("AgentCreditLog");
                });

            modelBuilder.Entity("FGPay.Models.AgentRate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgentID");

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("Operator")
                        .HasMaxLength(50);

                    b.Property<int>("PaymentType");

                    b.Property<decimal>("Rate")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("numeric(4, 2)");

                    b.Property<byte>("State")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.HasIndex("AgentID");

                    b.ToTable("AgentRate");
                });

            modelBuilder.Entity("FGPay.Models.AgentWdOrder", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AccountCardNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("AgentFullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("AgentUserID")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("BankFullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ClientIP")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("ExtraRemark")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("Operator")
                        .HasMaxLength(50);

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(50);

                    b.Property<byte>("State")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("WithdrawalFee")
                        .HasColumnType("money");

                    b.HasKey("ID");

                    b.ToTable("AgentOrder");
                });

            modelBuilder.Entity("FGPay.Models.BankAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountCardNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("BankFullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("Operator")
                        .HasMaxLength(50);

                    b.Property<byte>("State")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.ToTable("BankAccount");
                });

            modelBuilder.Entity("FGPay.Models.Merchant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgentID");

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.Property<string>("ClientIP")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("LastLoginTime");

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("Md5key")
                        .HasMaxLength(50);

                    b.Property<string>("MerchantFullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte>("MerchantState")
                        .HasColumnType("tinyint");

                    b.Property<string>("MerchantUserID")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Operator")
                        .HasMaxLength(50);

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20);

                    b.Property<decimal>("PrepaidRate")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("numeric(4, 2)");

                    b.Property<string>("Remark")
                        .HasMaxLength(100);

                    b.Property<byte>("Role")
                        .HasColumnType("tinyint");

                    b.Property<byte>("SettleType")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("WithdrawalRate")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("numeric(4, 2)");

                    b.HasKey("ID");

                    b.HasIndex("AgentID");

                    b.ToTable("Merchant");
                });

            modelBuilder.Entity("FGPay.Models.MerchantCreditLog", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<decimal>("BeforeCredit")
                        .HasColumnType("money");

                    b.Property<DateTime>("CreateTime");

                    b.Property<byte>("CreditLogType")
                        .HasColumnType("tinyint");

                    b.Property<string>("MerchantUserID")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("OrderNumber")
                        .HasMaxLength(20);

                    b.Property<string>("Remark")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("MerchantCreditLog");
                });

            modelBuilder.Entity("FGPay.Models.MerchantRate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<int>("MerchantID");

                    b.Property<string>("Operator")
                        .HasMaxLength(50);

                    b.Property<int>("PaymentType");

                    b.Property<decimal>("Rate")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("numeric(4, 2)");

                    b.Property<byte>("State")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.HasIndex("MerchantID");

                    b.ToTable("MerchantRate");
                });

            modelBuilder.Entity("FGPay.Models.MerchantWdOrder", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AccountCardNumber")
                        .HasMaxLength(20);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("AgentFullName")
                        .HasMaxLength(50);

                    b.Property<string>("AgentUserID")
                        .HasMaxLength(20);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("AyncCallbackUrl")
                        .HasMaxLength(50);

                    b.Property<string>("BankFullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ClientIP")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("ExtraRemark")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("MerchantFullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MerchantOrderNo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MerchantUserID")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Operator")
                        .HasMaxLength(50);

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(50);

                    b.Property<byte>("State")
                        .HasColumnType("tinyint");

                    b.Property<string>("SyncCallbackUrl")
                        .HasMaxLength(50);

                    b.Property<decimal>("WithdrawalFee")
                        .HasColumnType("money");

                    b.HasKey("ID");

                    b.ToTable("MerchantOrder");
                });

            modelBuilder.Entity("FGPay.Models.PaymentChannel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChannelName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte>("ChannelState")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<decimal>("MaxLimitDaily")
                        .HasColumnType("money");

                    b.Property<decimal>("MaxLimitSingle")
                        .HasColumnType("money");

                    b.Property<decimal>("MinLimitSingle")
                        .HasColumnType("money");

                    b.Property<string>("Operator")
                        .HasMaxLength(50);

                    b.Property<byte>("PaymentType")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.ToTable("PaymentChannel");
                });

            modelBuilder.Entity("FGPay.Models.QRCode", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientIP")
                        .HasMaxLength(30);

                    b.Property<string>("CodeInformation")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("Operator")
                        .HasMaxLength(50);

                    b.Property<int>("PaymentType");

                    b.Property<byte>("State")
                        .HasColumnType("tinyint");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("QRCode");
                });

            modelBuilder.Entity("FGPay.Models.ReceiptOrder", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AccountName")
                        .HasMaxLength(20);

                    b.Property<string>("AccountUserID")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("AgentFullName")
                        .HasMaxLength(50);

                    b.Property<string>("AgentUserID")
                        .HasMaxLength(20);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("AyncCallbackUrl")
                        .HasMaxLength(50);

                    b.Property<string>("ClientIP")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("ExtraRemark")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("MerchantFullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MerchantOrderNo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MerchantUserID")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Operator")
                        .HasMaxLength(50);

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PaymentType");

                    b.Property<string>("QRAccountUserID")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(50);

                    b.Property<byte>("State")
                        .HasColumnType("tinyint");

                    b.Property<string>("SyncCallbackUrl")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("ReceiptOrder");
                });

            modelBuilder.Entity("FGPay.Models.RepAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountCardNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("BankFullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ClientIP")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("LoginPwd")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Operator")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UpperLevel")
                        .HasMaxLength(50);

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("WithdrawalPwd")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("RepAccount");
                });

            modelBuilder.Entity("FGPay.Models.RepAccountCredit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Alipay")
                        .HasColumnType("money");

                    b.Property<decimal>("BonusAmount")
                        .HasColumnType("money");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<decimal>("FrozenAmount");

                    b.Property<decimal>("MarketingFee")
                        .HasColumnType("money");

                    b.Property<decimal>("ReceiptAmount")
                        .HasColumnType("money");

                    b.Property<int>("RepAccountID");

                    b.Property<decimal>("UnionPay")
                        .HasColumnType("money");

                    b.Property<decimal>("Wechat")
                        .HasColumnType("money");

                    b.HasKey("ID");

                    b.HasIndex("RepAccountID");

                    b.ToTable("RepAccountCredit");
                });

            modelBuilder.Entity("FGPay.Models.RepAccountDepositOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountCardNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("BankFullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("ExtraRemark")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(50);

                    b.Property<byte>("State")
                        .HasColumnType("tinyint");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("RepAccountDepositOrder");
                });

            modelBuilder.Entity("FGPay.Models.RepAccountLog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientIP");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("LogTitle")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<byte>("LogType")
                        .HasColumnType("tinyint");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("RepAccountLog");
                });

            modelBuilder.Entity("FGPay.Models.RepAccountWdOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountCardNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("BankFullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("ExtraRemark")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdateTime");

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(50);

                    b.Property<byte>("State")
                        .HasColumnType("tinyint");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("WithdrawalFee")
                        .HasColumnType("money");

                    b.HasKey("ID");

                    b.ToTable("RepAccountWithdrawalOrder");
                });

            modelBuilder.Entity("FGPay.Models.AgentRate", b =>
                {
                    b.HasOne("FGPay.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FGPay.Models.Merchant", b =>
                {
                    b.HasOne("FGPay.Models.Agent", "MerchantAgent")
                        .WithMany()
                        .HasForeignKey("AgentID");
                });

            modelBuilder.Entity("FGPay.Models.MerchantRate", b =>
                {
                    b.HasOne("FGPay.Models.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FGPay.Models.RepAccountCredit", b =>
                {
                    b.HasOne("FGPay.Models.RepAccount", "RepAccount")
                        .WithMany()
                        .HasForeignKey("RepAccountID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
