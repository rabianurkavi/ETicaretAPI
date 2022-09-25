using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> :IRepository<T> where T: BaseEntity
    {
        //Sadece select işlemleri. Get, GetByID, List

        //Niye IQueryable: sorgu üzerinden çalışmak istiyorsak IQueryable.Inmemory de çalışmak istiyorsak IEnumarable
        // IQueryable ise senin yazmış olduğun şartlar ilgili veri tabanı sorgusuna eklenecektir.
        //List IEnumarable dir Inmemorye çeker o şekilde işlem yapar.
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);// bir şart vereceğim şarta uygun birden fazla veriyi getir
        Task<T> GetSingle(Expression<Func<T, bool>> method);//FirstOrDefaultun async versiyonunu kullanacak bundan dolayı T GetSingle(Expression<Func<T, bool>> method)'dan
        //Task e dönüştürüyoruz.
        Task<T> GetById(string id);//Bu da Async kullanacak
    }
}
