using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DataAccess
{
    public interface EntityDAO<T>
    {
        bool Insert(T toInsert);
        bool Update(T toUpdate);
        bool Delete(object id);
        T Find(object id);
        List<T> FindAll();
    }
}
