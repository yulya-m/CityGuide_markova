using CityGuide29.Markova.Classes;
using System.Text.RegularExpressions;
using System.Windows;

namespace CityGuide29.Markova.Models
{
	public class Attraction : Notification
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
		private int _cityId;
		public int CityId
		{
			get => _cityId;
			set
			{
				_cityId = value;
				OnPropertyChanget("CityId");
			}
		}
		public virtual City City { get; set; }
	}
}
