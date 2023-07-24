using Domain.BaseEntity;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBaseContext
{
    public class ProductsContext : DbContext
    {
        private readonly DateTime _dateTimeService;

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual DbSet<Product> Products { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "Admin";
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = "Admin";
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}