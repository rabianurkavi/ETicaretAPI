using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    /* Sadece ICustomerWriteRepository eklediğimiz zaman oradaki fonksiyonları buraya uygulattıracak, bu da çok uzun bir yol olacak.
    WriteRepository diye zaten bir sınıfımız vardı bunun içine entity yazmamız yeterli. Peki niye interface i ekliyoruz?
    Bu interface de bu CustomerWriteRepository nin abstractionudur yani soyut yapılandırmasıdır. Yani ben depented injection dan CustomerWriteRepository bunu 
    talep ederken ICustomerWriteRepository bununla talep edeceğim 
    ICustomerWriteRepository bu CustomerWriteRepository bunun doğrulayıcısı yani imzası oluyor WriteRepository<Customer> bunla da uygulanmış oluyor.
    WriteRepository bizden constructor da parametre istiyor. Context e illaki değer vermemiz gerekiyor.
    */
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
