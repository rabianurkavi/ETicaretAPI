using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T: BaseEntity
    {
        //Ekleme, silme, güncelleme
        //Niye boolean verdik eklediysek sonucu true ya da false veriyoruz.İstiyorsak entity döndürebilirsin.
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);//overload birden fazla ekleme işleminde kullanılacak
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        Task<int> SaveAsync();//yapılan işlemler neticesinde SaveChanges'i çağırabilmek için bu fonksiyonu kullanacağız.
      

    }
}
