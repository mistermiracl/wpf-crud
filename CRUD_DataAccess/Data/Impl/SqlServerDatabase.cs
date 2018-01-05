using CRUD_DataAccess.Empleado;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DataAccess.Data.Impl
{
    public class SqlServerDatabase : Database
    {
        public IDbConnection GetOpenConnection()
        {
            IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.CONNECTION_STRING_NAME].ConnectionString);
            conn.Open();
            return conn;
        }

        public IDbCommand CreateCommand(IDbConnection conn, string sqlText)
        {
            IDbCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlText;
            return cmd;
            
        }

        public IDbCommand CreateStoredProcedureCommand(IDbConnection conn, string sqlText)
        {
            IDbCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlText;
            return cmd;
        }

        public IDataParameter CreateParameter(string name, object value)
        {
            IDataParameter param = new SqlParameter(name, value);
            return param;
        }
    }
}
