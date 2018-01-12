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
        public Action<object> ToExecute { get; set; }
        public Func<bool> ShouldExecute { get; set; }

        public BaseCommand(Action<object> toExecute)
        {
            this.ToExecute = toExecute;
            this.ShouldExecute = () => true;
        }

        public BaseCommand (Action<object> toExecute, Func<bool> shouldExecute)
        {
            this.ToExecute = toExecute;
            this.ShouldExecute = shouldExecute;
        }
        
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //EVENT IS INVOKED WHENEVER CAN EXECUTE IS CALLED SO NO NEED TO INVOKE IT AGAIN OTHERWISE A RECURSIVE LOOP IS CAUSED 
            //CanExecuteChanged?.Invoke(this, new EventArgs());
            //if (CanExecuteChanged != null)
                //CanExecuteChanged(this, new EventArgs());
            return this.ShouldExecute();
        }

        public void Execute(object parameter)
        {
            this.ToExecute(parameter);
        }
    }
}
