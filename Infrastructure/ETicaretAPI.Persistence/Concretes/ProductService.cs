using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
         => new() 
         {
             new() { Id=Guid.NewGuid(),Name="Telefon", Price=4500, Stock=10},
             new() { Id=Guid.NewGuid(),Name="Tablet", Price=1200, Stock=10},
             new() { Id=Guid.NewGuid(),Name="Televizyon", Price=3400, Stock=10},
             new() { Id=Guid.NewGuid(),Name="Bilgisayar", Price=12000, Stock=10},
             new() { Id=Guid.NewGuid(),Name="Kalemlik", Price=55, Stock=10},
         };
    }
}
