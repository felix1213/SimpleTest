using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FGPay.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FGPayContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
