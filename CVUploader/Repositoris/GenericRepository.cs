using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVUploader.Repositoris
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
    }
}
