using CRUD_BusinessLogic.Empleado;
using CRUD_BusinessLogic.EmpleadoCargo;
using CRUD_Entity;
using CRUD_UI.Model;
using CRUD_UI.ViewModel.Common;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CRUD_UI.ViewModel
{
    public class MainWindowViewModel
    {
        public EmpleadoModel EmpleadoActual { get; set; }// = new EmpleadoModel { NombreEmpleado = "Pepe", ApellidoEmpleado = "Gonzalez", CargoEmpleado = "Tecnico de Redes", EdadEmpleado = 22 };

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
            EmpleadoActual = new EmpleadoModel();
            InitializeEmpleadoActual();

            empleadoBL = new EmpleadoBL();
            empleadoCargoBL = new EmpleadoCargoBL();

            Empleados = new ObservableCollection<EmpleadoModel>();
            LoadEmpleados();
            Cargos = new ObservableCollection<string>();
            LoadCargos();

            //ATTACH METHOD TO COMMAND
            GuardarCambios = new BaseCommand(SaveChanges);

            Actualizar = new BaseCommand((args) =>
            {
                var emp = (EmpleadoModel)args;
                EmpleadoActual.IdEmpleado = emp.IdEmpleado;
                EmpleadoActual.NombreEmpleado = emp.NombreEmpleado;
                EmpleadoActual.ApellidoEmpleado = emp.ApellidoEmpleado;
                EmpleadoActual.CargoEmpleado = emp.CargoEmpleado;
                EmpleadoActual.EdadEmpleado = emp.EdadEmpleado;
                //MessageBox.Show($"Actualizando {args}");
            });

            Eliminar = new BaseCommand((args) =>
            {
                var rpta = MessageBox.Show("¿Esta seguro que desea eliminar este empleado?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rpta == MessageBoxResult.Yes)
                    empleadoBL.Delete(args);
                //MessageBox.Show($"Eliminando {args}");
                LoadEmpleados();
            });
        }

        public void LoadEmpleados()
        {
            //Empleados = new ObservableCollection<EmpleadoModel>
            //{
            //    new EmpleadoModel { NombreEmpleado = "Juan", ApellidoEmpleado = "Diaz", CargoEmpleado = "Analista Funcional", EdadEmpleado = 47 },
            //};

            //TO REFRESH THE LIST AND THE GRID VIEW RE ASSINGING THE PROPERTY (TYPEOF OBSCOLLECTION) WILL NOT WORK SINCE IT DOES NOT IMPLEMENT THE INOTIFYPROPERTY CHANGED INTERFACE
            //Empleados = new ObservableCollection<EmpleadoModel>(empleadoBL.FindAll().Select(e => new EmpleadoModel
            //{
            //    IdEmpleado = e.Id,
            //    NombreEmpleado = e.Nombre,
            //    ApellidoEmpleado = e.Apellido,
            //    CargoEmpleado = e.Cargo,
            //    EdadEmpleado = e.Edad
            //}));

            //SO THE BEST WAY TO ACHIEVE THE SAME RESULT IS TO CLEAR ALL ITEMS AND THE FILL THE ONES IN THE DATABASSE TO THE SAME COLLECTION
            Empleados.Clear();
            empleadoBL.FindAll().ForEach(e =>
            {
                Empleados.Add(new EmpleadoModel
                {
                    IdEmpleado = e.Id,
                    NombreEmpleado = e.Nombre,
                    ApellidoEmpleado = e.Apellido,
                    CargoEmpleado = e.Cargo,
                    EdadEmpleado = e.Edad
                });
            });
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

            //Cargos = new ObservableCollection<string>(empleadoCargoBL.FindAll().Select(e => { Console.WriteLine(e.Nombre); return e.Nombre; }));
            Cargos.Clear();
            empleadoCargoBL.FindAll().ForEach(c => Cargos.Add(c.Nombre));
        }

        public void SaveChanges(object args)
        {
            //EmpleadoActual.NombreEmpleado = "Pepe" + i;
            //i++;
            //if()
            //MessageBox.Show(EmpleadoActual.NombreEmpleado.ToString());

            //IF THE EMPLEADO ALREADY EXISTS UPDATE
            if (Empleados.Where(e => e.IdEmpleado == EmpleadoActual.IdEmpleado).Count() == 1)
            {
                empleadoBL.Update(new EmpleadoBE
                {
                    Id = EmpleadoActual.IdEmpleado,
                    Nombre = EmpleadoActual.NombreEmpleado,
                    Apellido = EmpleadoActual.ApellidoEmpleado,
                    Cargo = EmpleadoActual.CargoEmpleado,
                    Edad = EmpleadoActual.EdadEmpleado
                });
            }
            //OTHERWISE INSERT
            else
            {
                empleadoBL.Insert(new EmpleadoBE
                {
                    //Id = EmpleadoActual.IdEmpleado,
                    Nombre = EmpleadoActual.NombreEmpleado,
                    Apellido = EmpleadoActual.ApellidoEmpleado,
                    Cargo = EmpleadoActual.CargoEmpleado,
                    Edad = EmpleadoActual.EdadEmpleado
                });
                //MessageBox.Show(EmpleadoActual.NombreEmpleado);
            }
            InitializeEmpleadoActual();
            LoadEmpleados();
        }

        void InitializeEmpleadoActual()
        {
            EmpleadoActual.IdEmpleado = 0;
            EmpleadoActual.NombreEmpleado = "";
            EmpleadoActual.ApellidoEmpleado = "";
            EmpleadoActual.CargoEmpleado = "";
            EmpleadoActual.EdadEmpleado = 0;
        }
    }
}
