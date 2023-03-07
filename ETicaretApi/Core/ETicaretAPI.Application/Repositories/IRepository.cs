using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    //Kendi içerisinde temel(base) şeyleri tutsun.Yani bütün repository de olması gereken şeyleri tutarız.
    public interface IRepository<T> where T:BaseEntity
    {
        //DbSet illaki bir entity olması gerekiyor.Bundan olayı hata verir bu hatayı önlemek için yukarıda where koşuluyla sınırlandırıyoruz.
        DbSet<T> Table { get; }
    }
}
