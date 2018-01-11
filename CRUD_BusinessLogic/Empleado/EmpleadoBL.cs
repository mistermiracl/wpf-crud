using CRUD_DataAccess;
using CRUD_DataAccess.Empleado.Impl;
using CRUD_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_BusinessLogic.Empleado
{
    public class EmpleadoBL : BL<EmpleadoBE>
    {
        private EmpleadoDAO empleadoDAO;
        public EmpleadoBL()
        {
            empleadoDAO = new EmpleadoDAOSql();
        }

        public bool Insert(EmpleadoBE toInsert)
        {
            return empleadoDAO.Insert(toInsert);
        }

        public bool Update(EmpleadoBE toUpdate)
        {
            return empleadoDAO.Update(toUpdate);
        }

        public bool Delete(object id)
        {
            return empleadoDAO.Delete(id);
        }

        public EmpleadoBE Find(object id)
        {
            return empleadoDAO.Find(id);
        }

        public List<EmpleadoBE> FindAll()
        {
            return empleadoDAO.FindAll();
        }
    }
}
