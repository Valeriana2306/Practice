using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RESTpr.Models
{
    public class VendersContext : DbContext
    {
        public VendersContext(DbContextOptions<VendersContext> options)
            : base(options)
        {
        }

        public DbSet<Venders> Venders { get; set; }
    }
}