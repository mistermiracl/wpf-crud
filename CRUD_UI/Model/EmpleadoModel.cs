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
        private string nombreEmpleado;
        private string apellidoEmpleado;
        private string cargoEmpleado;
        private int edadEmpleado;

        public string NombreEmpleado
        {
            get => nombreEmpleado;
            set
            {
                if (nombreEmpleado != value)
                {
                    nombreEmpleado = value;
                    RaisePropertyChanged(nameof(NombreEmpleado));
                }
            }
        }

        public string ApellidoEmpleado
        {
            get => apellidoEmpleado;
            set
            {
                if (apellidoEmpleado != value)
                {
                    apellidoEmpleado = value;
                    RaisePropertyChanged(nameof(ApellidoEmpleado));
                }
            }
        }

        public string CargoEmpleado
        {
            get => cargoEmpleado;
            set
            {
                if (cargoEmpleado != value)
                {
                    cargoEmpleado = value;
                    RaisePropertyChanged(nameof(CargoEmpleado));
                }
            }
        }

        public int EdadEmpleado
        {
            get => edadEmpleado;
            set
            {
                if(edadEmpleado != value)
                {
                    edadEmpleado = value;
                    RaisePropertyChanged(nameof(EdadEmpleado));
                    Console.WriteLine(edadEmpleado);
                }
            }
        }
    }
}
