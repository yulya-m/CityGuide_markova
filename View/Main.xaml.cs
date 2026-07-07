using System.Windows.Controls;

namespace CityGuide29.Markova.View
{
	/// <summary>
	/// Логика взаимодействия для Main.xaml
	/// </summary>
	public partial class Main : Page
	{
		public Main(object Context)
		{
			InitializeComponent();
			DataContext = Context;
		}
	}
}
