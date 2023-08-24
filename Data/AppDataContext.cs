using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeOwnersApp.Models;

namespace HomeOwnersApp.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext (DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }

        public DbSet<HomeOwnersApp.Models.HomeOwners> HomeOwners { get; set; } = default!;
    }
}
