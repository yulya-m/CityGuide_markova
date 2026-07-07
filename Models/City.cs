using Schema = System.ComponentModel.DataAnnotations.Schema;
using CityGuide29.Markova.Classes;
using System.Text.RegularExpressions;
using System.Windows;

namespace CityGuide29.Markova.Models
{
	public class City : Notification
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                Match match = Regex.Match(value, "^.{1,100}$");
                if (!match.Success)
                    MessageBox.Show("Название не должно быть пустым и не более 100 символов.", "Некорректный ввод значения.");
                else
                {
                    _name = value;
                    OnPropertyChanget("Name");
                }
            }
        }
        private string _country;
        public string Country
        {
			get => _country;
			set
			{
				Match match = Regex.Match(value, "^.{1,50}$");
				if (!match.Success)
					MessageBox.Show("Страна не должна быть пустым и не более 50 символов.", "Некорректный ввод значения.");
				else
				{
					_country = value;
					OnPropertyChanget("Country");
				}
			}
		}
		private string _description;
		public string Description
		{
			get => _description;
			set
			{
				Match match = Regex.Match(value, "^.{1,500}$");
				if (!match.Success)
					MessageBox.Show("Описание не должно быть пустым и не более 500 символов.", "Некорректный ввод значения.");
				else
				{
					_description = value;
					OnPropertyChanget("Description");
				}
			}
		}
		private string _imagePath;
		public string ImagePath
		{
			get => _imagePath;
			set
			{
				_imagePath = value;
				OnPropertyChanget("ImagePath");
			}
		}
		[Schema.NotMapped]
		private bool _isEditing;
		[Schema.NotMapped]
		public bool IsEditing
		{
			get => _isEditing;
			set
			{
				_isEditing = value;
				OnPropertyChanget("IsEditing");
				OnPropertyChanget("IsEditingText");
			}
		}
		[Schema.NotMapped]
		public string IsEditingText
		{
			get
			{
				if (IsEditing) return "Сохранить";
				else return "Изменить";
			}
		}
		[Schema.NotMapped]
		public RealyCommand OnEdit
		{
			get
			{
				return new RealyCommand(obj =>
				{
					IsEditing = !IsEditing;
					if (!IsEditing)
						(MainWindow.init.DataContext as ViewModels.VM_Pages).vm_cities.context.SaveChanges();
				});
			}
		}
		[Schema.NotMapped]
		public RealyCommand OnDelete
		{
			get
			{
				return new RealyCommand(obj =>
				{
					if(MessageBox.Show("Вы уверены, что хотите удалить город?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
					{
						(MainWindow.init.DataContext as ViewModels.VM_Pages).vm_cities.Cities.Remove(this);
						(MainWindow.init.DataContext as ViewModels.VM_Pages).vm_cities.context.Remove(this);
						(MainWindow.init.DataContext as ViewModels.VM_Pages).vm_cities.context.SaveChanges();
					}
				});
			}
		}
	}
}
