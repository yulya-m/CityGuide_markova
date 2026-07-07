using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityGuide29.Markova.Classes
{
    public class RealyCommand : ICommand
    {
        private readonly Action<object> _execute;
        public RealyCommand(Action<object> execute)
        {
            _execute = execute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
