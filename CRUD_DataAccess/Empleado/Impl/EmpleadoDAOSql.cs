using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Entity;
using System.Data;
using CRUD_DataAccess.Data;
using CRUD_DataAccess.Data.Impl;

namespace CRUD_DataAccess.Empleado.Impl
{
    public class EmpleadoDAOSql : EmpleadoDAO
    {
        const string ID_PARAM = "@id";
        const string NOMBRE_PARAM = "@nom";
        const string APELLIDO_PARAM = "@ape";
        const string CARGO_PARAM = "@car";
        const string EDAD_PARAM = "@eda";

        IDbConnection conn;
        IDbCommand cmd;
        IDataReader reader;

        Database db;
        public EmpleadoDAOSql()
        {
            db = new SqlServerDatabase();
        }

        public bool Insert(EmpleadoBE toInsert)
        {
            using (conn = db.GetOpenConnection())
            using (cmd = db.CreateStoredProcedureCommand(conn, Constantes.Empleado.USP_EMPLEADO_INSERT))
            {
                cmd.Parameters.Add(db.CreateParameter(NOMBRE_PARAM, toInsert.Nombre));
                cmd.Parameters.Add(db.CreateParameter(APELLIDO_PARAM, toInsert.Apellido));
                cmd.Parameters.Add(db.CreateParameter(CARGO_PARAM, toInsert.Cargo));
                cmd.Parameters.Add(db.CreateParameter(EDAD_PARAM, toInsert.Edad));

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(EmpleadoBE toUpdate)
        {
            using (conn = db.GetOpenConnection())
            using (cmd = db.CreateStoredProcedureCommand(conn, Constantes.Empleado.USP_EMPLEADO_UPDATE))
            {
                cmd.Parameters.Add(db.CreateParameter(ID_PARAM, toUpdate.Id));
                cmd.Parameters.Add(db.CreateParameter(NOMBRE_PARAM, toUpdate.Nombre));
                cmd.Parameters.Add(db.CreateParameter(APELLIDO_PARAM, toUpdate.Apellido));
                cmd.Parameters.Add(db.CreateParameter(CARGO_PARAM, toUpdate.Cargo));
                cmd.Parameters.Add(db.CreateParameter(EDAD_PARAM, toUpdate.Edad));

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(object id)
        {
            using (conn = db.GetOpenConnection())
            using (cmd = db.CreateStoredProcedureCommand(conn, Constantes.Empleado.USP_EMPLEADO_DELETE))
            {
                cmd.Parameters.Add(db.CreateParameter(ID_PARAM, id));

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public EmpleadoBE Find(object id)
        {
            using (conn = db.GetOpenConnection())
            using (cmd = db.CreateStoredProcedureCommand(conn, Constantes.Empleado.USP_EMPLEADO_FIND))
            {
                cmd.Parameters.Add(db.CreateParameter(ID_PARAM, id));

                using (reader = cmd.ExecuteReader())
                {
                    EmpleadoBE empleado = null;
                    if (reader.Read())
                    {
                        empleado = new EmpleadoBE();
                        empleado.Id = Convert.ToInt32(id);
                        empleado.Nombre = reader.GetString(1);
                        empleado.Apellido = reader.GetString(2);
                        empleado.Cargo = reader.GetString(3);
                        empleado.Edad = reader.GetInt32(4);
                    }

                    return empleado;
                }
            }
        }

        public List<EmpleadoBE> FindAll()
        {
            using (conn = db.GetOpenConnection())
            using (cmd = db.CreateStoredProcedureCommand(conn, Constantes.Empleado.USP_EMPLEADO_FIND_ALL))
            using (reader = cmd.ExecuteReader())
            {
                List<EmpleadoBE> lEmpleado = new List<EmpleadoBE>();
                EmpleadoBE emp;
                while (reader.Read())
                {
                    emp = new EmpleadoBE
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        Cargo = reader.GetString(3),
                        Edad = reader.GetInt32(4)
                    };
                }
                return lEmpleado;
            }
        }
        
    }
}
