using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OSCManager.Persistence.Core.Entities;

namespace OSCManager.Persistence.Core
{
    public abstract class AbstractContext<TDbContext> : DbContext where TDbContext : DbContext
    {
        public const string Schema = "OSCM";

        public const int DefaultMaxStringLength = 4000;

        public AbstractContext(DbContextOptions<TDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!string.IsNullOrWhiteSpace(Schema))
                modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);
        }
    }
}
