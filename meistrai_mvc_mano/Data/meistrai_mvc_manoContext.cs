using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using meistrai_mvc_mano.Models;

namespace meistrai_mvc_mano.Data
{
    public class meistrai_mvc_manoContext : DbContext
    {
        public meistrai_mvc_manoContext (DbContextOptions<meistrai_mvc_manoContext> options)
            : base(options)
        {
        }

        public DbSet<meistrai_mvc_mano.Models.Specialization> Specialization { get; set; } = default!;

        public DbSet<meistrai_mvc_mano.Models.AutoService>? AutoService { get; set; }
    }
}
