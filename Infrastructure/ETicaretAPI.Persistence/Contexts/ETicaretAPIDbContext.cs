using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext:DbContext
    {
        //bu constructor IOC container da doldurulacak
        public ETicaretAPIDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //bundan sonra her savechanges tetiklendiğinde ben insert ile update üzerlerinde istediğim değişikliği yapıp
        //ardından savechangesasync tekrardan devreye sokabiliriz.
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //DbContexten gelir entityler üzerinden yapılan değişiklikleri ya da yeni eklenen verinin yakalanmasını
            //sağlayan propertytidir. Track edilen verikeri yakalayıp elde etmemizi sağlar.Insertte track edilmez ortada veri yoktur.
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ =data.State switch //_ herhangi bir atama işlemi yapmıyoruz
                {
                    //eğerki ekleme işlemi ise 
                    EntityState.Added=> data.Entity.CreatedDate=DateTime.UtcNow,
                    EntityState.Modified=>data.Entity.UpdatedDate=DateTime.UtcNow
                };
            }
            //gelen isteklerde (insert,update) insertse createddate update ise uptadeddate i dolduracağız.
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
