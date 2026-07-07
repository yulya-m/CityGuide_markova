using CityGuide29.Markova.Classes;
using CityGuide29.Markova.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuide29.Markova.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Cities vm_cities = new VM_Cities();
        public VM_Pages()
        {
            MainWindow.init.frame.Navigate(new Main(vm_cities));
        }
        public RealyCommand OnClose
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    MainWindow.init.Close();
                });
            }
        }
    }
}
