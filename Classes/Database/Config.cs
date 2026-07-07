using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuide29.Markova.Classes.Database
{
    public class Config
    {
		public static readonly string connection = "server=192.168.0.111;" +
			"uid=root;" +
			"pwd=root;" +
			"database=cityguide;";
		public static readonly MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 21));
	}
}
