using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHouse.DataBase
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class DBCountryHouse : DbContext
    {
        public DbSet<DateBuildings> Buildings {  get; set; }
        public DbSet<DatePlanting> Plants { get; set; }
        public DbSet<DateTaskLog> TaskLog { get; set; }

        public DBCountryHouse() : base("server=localhost; port=3306; user=root; password=0000; database=CountryHouse")
        {
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Database.CreateIfNotExists();
        }
    }

}
