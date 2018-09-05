using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsApp.Models
{
    public class AnalyticsAppContext : IdentityDbContext<User>
    {
        public AnalyticsAppContext (DbContextOptions<AnalyticsAppContext> options)
            : base(options)
        {
        }

        public DbSet<AnalyticsApp.Models.Website> Website { get; set; }
        public DbSet<AnalyticsApp.Models.User> User { get; set; }
    }
}
