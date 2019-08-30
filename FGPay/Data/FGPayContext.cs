using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FGPay.Models;

namespace FGPay.Data
{
    public class FGPayContext:DbContext
    {
        public FGPayContext(DbContextOptions<FGPayContext> options) : base(options)
        {
        }

        /// <summary>
        /// 商户
        /// </summary>
        public DbSet<Merchant> Merchants { get; set; }
    }
}
