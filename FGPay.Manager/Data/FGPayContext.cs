using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FGPay.Manager.Models;

namespace FGPay.Manager { 
    public class FGPayContext:DbContext
    {
        public FGPayContext(DbContextOptions<FGPayContext> options) : base(options)
        {
        }

        /// <summary>
        /// 商户
        /// </summary>
        public DbSet<Merchant> Merchants { get; set; }
        /// <summary>
        /// 代理
        /// </summary>
        public DbSet<Agent> Agents { get; set; }
        /// <summary>
        /// 费率设置
        /// </summary>
        public DbSet<MerchantRate> MerchantRates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Merchant>().ToTable("Merchant");

            //不启用MerchantRate表对Merchant的级联删除
            modelBuilder.Entity<MerchantRate>()
               .HasOne(d => d.Merchant)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
