using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Data.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Domain.Models.Guitarrista> Guitarrista { get; set; }

        public DbSet<Domain.Models.Guitarras> Guitarras { get; set; }
    }
}
