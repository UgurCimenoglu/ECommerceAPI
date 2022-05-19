using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistance.Contexts
{
    public class ECommerceAPIDbContext : DbContext
    {
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        {
            Console.WriteLine("Context nesnesi oluşturuldu.");
        }
        ~ECommerceAPIDbContext()
        {
            Console.WriteLine("Context dispose edildi.");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker ne işe yarar? : Entityler üzerinde yapılan değişiklikleri yada eklenen veya üzerinde değişiklik yapılan verinin yakalanmasını sağlayan propertydir.
            //Track edilen veriyi yakalayıp üzerinde değişiklik yapabilmemizi sağlar.
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added =>
                    data.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified =>
                    data.Entity.UpdatedDate = DateTime.UtcNow,
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
