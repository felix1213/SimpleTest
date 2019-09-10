using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FGPay.Models;

namespace FGPay.Manager { 
    public class FGPayContext:DbContext
    {
        public FGPayContext(DbContextOptions<FGPayContext> options) : base(options)
        {
        }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<MerchantRate> MerchantRates { get; set; }
        public DbSet<AgentCreditLog> AgentCreditLogs { get; set; }
        public DbSet<AgentWdOrder> AgentWdOrders { get; set; }
        public DbSet<AgentRate> AgentRates { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<MerchantCreditLog> MerchantCreditLogs { get; set; }
        public DbSet<MerchantWdOrder> MerchantWdOrders { get; set; }
        public DbSet<PaymentChannel> PaymentChannels { get; set; }
        public DbSet<QRCode> QRCodes { get; set; }
        public DbSet<ReceiptOrder> ReceiptOrders { get; set; }
        public DbSet<RepAccount> RepAccounts { get; set; }
        public DbSet<RepAccountCredit> RepAccountCredits { get; set; }
        public DbSet<RepAccountDepositOrder> RepAccountDepositOrders { get; set; }
        public DbSet<RepAccountLog> RepAccountLogs { get; set; }
        public DbSet<RepAccountWdOrder> RepAccountWdOrders { get; set; }

        public DbSet<SystemMenu> SystemMenu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Merchant>().ToTable("Merchant");
            modelBuilder.Entity<Agent>().ToTable("Agent");
            modelBuilder.Entity<MerchantRate>().ToTable("MerchantRate");
            modelBuilder.Entity<AgentCreditLog>().ToTable("AgentCreditLog");
            modelBuilder.Entity<AgentWdOrder>().ToTable("AgentOrder");
            modelBuilder.Entity<AgentRate>().ToTable("AgentRate");
            modelBuilder.Entity<BankAccount>().ToTable("BankAccount");
            modelBuilder.Entity<MerchantCreditLog>().ToTable("MerchantCreditLog");
            modelBuilder.Entity<MerchantWdOrder>().ToTable("MerchantOrder");
            modelBuilder.Entity<PaymentChannel>().ToTable("PaymentChannel");
            modelBuilder.Entity<QRCode>().ToTable("QRCode");
            modelBuilder.Entity<ReceiptOrder>().ToTable("ReceiptOrder");
            modelBuilder.Entity<RepAccount>().ToTable("RepAccount");
            modelBuilder.Entity<RepAccountCredit>().ToTable("RepAccountCredit");
            modelBuilder.Entity<RepAccountDepositOrder>().ToTable("RepAccountDepositOrder");
            modelBuilder.Entity<RepAccountLog>().ToTable("RepAccountLog");
            modelBuilder.Entity<RepAccountWdOrder>().ToTable("RepAccountWithdrawalOrder");
            modelBuilder.Entity<SystemMenu>().ToTable("SystemMenu");

            //不启用MerchantRate表对Merchant的级联删除
            modelBuilder.Entity<MerchantRate>()
               .HasOne(d => d.Merchant)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AgentRate>()
                .HasOne(d => d.Agent)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RepAccountCredit>()
                .HasOne(d =>d.RepAccount)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
