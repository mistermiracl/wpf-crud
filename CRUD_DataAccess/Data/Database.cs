using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DataAccess.Data
{
    public interface Database
    {
        IDbConnection GetOpenConnection();
        IDbCommand CreateCommand(IDbConnection conn, string sqlText);
        IDbCommand CreateStoredProcedureCommand(IDbConnection conn, string sqlText);
        IDataParameter CreateParameter(string name, object value);
    }
}
