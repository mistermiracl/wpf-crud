using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DataAccess
{
    public static class Constantes
    {
        public const string CONNECTION_STRING_NAME = "RecursosHumanosConnection";

        public static class Empleado
        {
            public const string USP_EMPLEADO_INSERT = "usp_EmpleadoInsert";
            public const string USP_EMPLEADO_UPDATE = "usp_EmpleadoUpdate";
            public const string USP_EMPLEADO_DELETE = "usp_EmpleadoDelete";
            public const string USP_EMPLEADO_FIND = "usp_EmpleadoFind";
            public const string USP_EMPLEADO_FIND_ALL = "usp_EmpleadoFindAll";
        }

        public static class EmpleadoCargo
        {
            public const string USP_EMPLEADO_CARGO_FIND_ALL = "usp_Empleado_CargoFindAll";
        }
    }
}
