using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        //Context nesnesmi Depented Injection  IOContainer a koymuştuk, buraya talep edip read işlemlerini gerçekleştireceğiz.
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();//Set işlemi T entity içindir biz bunda customer,product vs de diyebilirdik velakin generic yapılanma kullandık.
        public IQueryable<T> GetAll()
           => Table;//"=>", return ve {} olmadan tek başına kullanılabilir.
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
          => Table.Where(method);
        //await dediğimizde görev bekleniyor asenkron bir şekilde beklediği zaman T türünde dönecektir.
        public async Task<T> GetSingle(Expression<Func<T, bool>> method)
           => await Table.FirstOrDefaultAsync(method);

        //Bu fonksiyonda(GetById) verilen id parametresine uygun bir fonk getirilmesi lazım ama nasıl olacak? Çünkü generic bir yapılandırma söz konusu.
        //Bu tarz çalışmalarda yapılması gereken iki işlem vardır ya reflection ya da marker patterına uygun bir alt yapıda çalışma.
        //Şöyle olacak GetById de olduğu gibi değersel çalışmalar yapıyorsak bir arayüz ya da sınıf tasarlamamız gerekiyor.
        //class olarak BaseEntity olarak T yi tanımlarsak her entity bulunan propertyleri getirecektir.
        public async Task<T> GetByIdAsync(string id)
            //=> Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
            => await Table.FindAsync(Guid.Parse(id));


    }
}
