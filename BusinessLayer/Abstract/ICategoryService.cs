using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService: IGenericService<Category>
    {
    }

    // Business Katmanında Abstract klasörü içinde ki İnterface'ler "Service" olarak adlandırılıyor.
    // Business Katmanında Concreate klasörü içinde ki Class'lar "Manager" olarak adlandırılıyor.
}
