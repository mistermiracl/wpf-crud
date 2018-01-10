using CRUD_Entity;
using CRUD_UI.Model;
using CRUD_UI.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUD_UI.ViewModel
{
    public class MainWindowViewModel
    {
        int i = 1;

        public EmpleadoModel EmpleadoActual { get; set; } = new EmpleadoModel { NombreEmpleado = "Pepe", ApellidoEmpleado = "Gonzalez", CargoEmpleado = "Tecnico de Redes", EdadEmpleado = 22 };

        public MainWindowViewModel()
        {
            LoadEmpleados();
            LoadCargos();

            GuardarCambios = new BaseCommand(() =>
            {
                EmpleadoActual.NombreEmpleado = "Pepe" + i;
                i++;
            });
        }

        public ICommand GuardarCambios { get; set; }

        public ObservableCollection<EmpleadoModel> Empleados { get; set; }

        public ObservableCollection<string> Cargos { get; set; }

        public void LoadEmpleados()
        {
            Empleados = new ObservableCollection<EmpleadoModel>
            {
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
                new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 }

                //new EmpleadoModel { },
                //new EmpleadoModel {},
            };
        }

        public void LoadCargos()
        {
            Cargos = new ObservableCollection<string>
            {
                "Analista Funcional",
                "Developer .NET",
                "Jefe de Proyectos",
                "DBA",
                "Consultor SAP",
                "Developer ABAP",
                "Tecnico de Redes"
            };
        }
    }
}
