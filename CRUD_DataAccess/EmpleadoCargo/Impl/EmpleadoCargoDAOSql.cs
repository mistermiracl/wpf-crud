using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_DataAccess.Data;
using CRUD_DataAccess.Data.Impl;
using CRUD_Entity;

namespace CRUD_DataAccess.EmpleadoCargo.Impl
{
    public class EmpleadoCargoDAOSql : EmpleadoCargoDAO
    {
        private Database db;

        IDbConnection conn;
        IDbCommand cmd;
        IDataReader reader;

        public EmpleadoCargoDAOSql()
        {
            db = new SqlServerDatabase();
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
            using (conn = db.GetOpenConnection())
            using (cmd = db.CreateStoredProcedureCommand(conn, Constantes.EmpleadoCargo.USP_EMPLEADO_CARGO_FIND_ALL))
            using (reader = cmd.ExecuteReader())
            {
                List<EmpleadoCargoBE> list = new List<EmpleadoCargoBE>();
                EmpleadoCargoBE empleadoCargo;
                while (reader.Read())
                {
                    empleadoCargo = new EmpleadoCargoBE
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2)
                    };

                    //ADD THE EMPLEADO TO THE RETURN LIST
                    list.Add(empleadoCargo);
                }
                return list;
            }
        }
    }
}
