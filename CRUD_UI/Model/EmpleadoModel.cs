using CRUD_Entity;
using CRUD_UI.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_UI.Model
{
    public class EmpleadoModel : BaseModel
    {
        private EmpleadoBE empleado;
        //private string nombreEmpleado;
        //private string apellidoEmpleado;
        //private string cargoEmpleado;
        //private int edadEmpleado;

        public EmpleadoModel()
        {
            this.empleado = new EmpleadoBE();
        }

        public int IdEmpleado
        {
            get => empleado.Id;
            set
            {
                if(empleado.Id != value)
                {
                    empleado.Id = value;
                    RaisePropertyChanged(nameof(IdEmpleado));
                }
            }
        }

        public string NombreEmpleado
        {
            get => empleado.Nombre;
            set
            {
                if (empleado.Nombre != value)
                {
                    empleado.Nombre = value;
                    RaisePropertyChanged(nameof(NombreEmpleado));
                }
            }
        }

        public string ApellidoEmpleado
        {
            get => empleado.Apellido;
            set
            {
                if (empleado.Apellido != value)
                {
                    empleado.Apellido = value;
                    RaisePropertyChanged(nameof(ApellidoEmpleado));
                }
            }
        }

        public string CargoEmpleado
        {
            get => empleado.Cargo;
            set
            {
                if (empleado.Cargo != value)
                {
                    empleado.Cargo = value;
                    RaisePropertyChanged(nameof(CargoEmpleado));
                }
            }
        }

        public int EdadEmpleado
        {
            get => empleado.Edad;
            set
            {
                if(empleado.Edad != value)
                {
                    empleado.Edad = value;
                    RaisePropertyChanged(nameof(EdadEmpleado));
                    //Console.WriteLine(edadEmpleado);
                }
            }
        }
    }
}
