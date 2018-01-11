using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_BusinessLogic
{
    interface BL<T>
    {
        bool Insert(T toInsert);
        bool Update(T toUpdate);
        bool Delete(object id);
        T Find(object id);
        List<T> FindAll();
    }
}
