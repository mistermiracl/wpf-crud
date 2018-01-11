using CRUD_BusinessLogic.Empleado;
using CRUD_BusinessLogic.EmpleadoCargo;
using CRUD_Entity;
using CRUD_UI.Model;
using CRUD_UI.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CRUD_UI.ViewModel
{
    public class MainWindowViewModel
    {
        public EmpleadoModel EmpleadoActual { get; set; } = new EmpleadoModel { NombreEmpleado = "Pepe", ApellidoEmpleado = "Gonzalez", CargoEmpleado = "Tecnico de Redes", EdadEmpleado = 22 };

        public ICommand GuardarCambios { get; set; }

        public ICommand Actualizar { get; set; }

        public ICommand Eliminar { get; set; }

        public ObservableCollection<EmpleadoModel> Empleados { get; set; }

        public ObservableCollection<string> Cargos { get; set; }

        EmpleadoBL empleadoBL;
        EmpleadoCargoBL empleadoCargoBL;

        int i = 1;

        public MainWindowViewModel()
        {
            empleadoBL = new EmpleadoBL();
            empleadoCargoBL = new EmpleadoCargoBL();

            LoadEmpleados();
            LoadCargos();

            GuardarCambios = new BaseCommand((args) =>
            {
                EmpleadoActual.NombreEmpleado = "Pepe" + i;
                i++;
            });

            Actualizar = new BaseCommand((args) =>
            {
                MessageBox.Show($"Actualizando {args}");
            });

            Eliminar = new BaseCommand((args) =>
            {
                MessageBox.Show($"Eliminando {args}");
            });
        }

        public void LoadEmpleados()
        {
            //Empleados = new ObservableCollection<EmpleadoModel>
            //{
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 }
            //};

            Empleados = new ObservableCollection<EmpleadoModel>(empleadoBL.FindAll().Select(e => new EmpleadoModel
            {
                IdEmpleado = e.Id,
                NombreEmpleado = e.Nombre,
                ApellidoEmpleado = e.Apellido,
                CargoEmpleado = e.Cargo,
                EdadEmpleado = e.Edad
            }));
        }

        public void LoadCargos()
        {
            //Cargos = new ObservableCollection<string>
            //{
            //    "Analista Funcional",
            //    "Developer .NET",
            //    "Jefe de Proyectos",
            //    "DBA",
            //    "Consultor SAP",
            //    "Developer ABAP",
            //    "Tecnico de Redes"
            //};

            Cargos = new ObservableCollection<string>(empleadoCargoBL.FindAll().Select(e => { Console.WriteLine(e.Nombre); return e.Nombre; }));
        }
    }
}
