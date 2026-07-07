using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CityGuide29.Markova.Classes
{
	public class Notification : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanget([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
