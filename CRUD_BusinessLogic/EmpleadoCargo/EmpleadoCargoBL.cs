using CRUD_DataAccess.EmpleadoCargo;
using CRUD_DataAccess.EmpleadoCargo.Impl;
using CRUD_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_BusinessLogic.EmpleadoCargo
{
    public class EmpleadoCargoBL : BL<EmpleadoCargoBE>
    {
        EmpleadoCargoDAO empleadoCargoDAO;

        public EmpleadoCargoBL()
        {
            empleadoCargoDAO = new EmpleadoCargoDAOSql();
        }


        public bool Insert(EmpleadoCargoBE toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(EmpleadoCargoBE toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public EmpleadoCargoBE Find(object id)
        {
            throw new NotImplementedException();
        }

        public List<EmpleadoCargoBE> FindAll()
        {
            return empleadoCargoDAO.FindAll();
        }
    }
}
