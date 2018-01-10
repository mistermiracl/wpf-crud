using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUD_UI.ViewModel.Common
{
    public class BaseCommand : ICommand
    {
        public Action ToExecute { get; set; }
        public Func<bool> ShouldExecute { get; set; }

        public BaseCommand (Action toExecute, Func<bool> shouldExecute)
        {
            this.ToExecute = toExecute;
            this.ShouldExecute = shouldExecute;
        }

        public BaseCommand (Action toExecute)
        {
            this.ToExecute = toExecute;
            this.ShouldExecute = () => true;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.ShouldExecute();
        }

        public void Execute(object parameter)
        {
            this.ToExecute();
        }
    }
}
