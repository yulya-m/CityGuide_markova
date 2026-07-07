using CityGuide29.Markova.Classes;
using CityGuide29.Markova.Context;
using CityGuide29.Markova.Models;
using System.Collections.ObjectModel;

namespace CityGuide29.Markova.ViewModels
{
	public class VM_Cities : Notification
    {
        public CityContext context = new CityContext();
        public ObservableCollection<City> Cities { get; set; }
        public VM_Cities()
        {
            Cities = new ObservableCollection<City>(context.Cities.OrderBy(x => x.Name));
        }
        public RealyCommand OnAddCity
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    City NewCity = new City()
                    {
                        Name = "Новый город",
                        Country = "Страна",
                        Description = "Описание",
                        ImagePath = "/Images/default.jpg"
                    };
					Cities.Add(NewCity);
                    context.Cities.Add(NewCity);
                    context.SaveChanges();
				});

            }
        }
    }
}
