using FGPay.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGPay.Domain.DbContexts
{
    public class FGPayContext:DbContext
    {
        public FGPayContext(DbContextOptions<FGPayContext> options):base(options)
        {
        }
        public DbSet<UserEntity> tbUser { get; set; }
        public DbSet<MenuEntity> tbMenu { get; set; }
        public DbSet<RoleEntity> tbRole { get; set; }

        public DbSet<LibraryEntity> tbLibrary { get; set; }
    }

}
