using Mysqlx.Expr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CountryHouse.DataBase
{
    public class VMBuildings
    {
        List<DateBuildings> buildings;

        public VMBuildings()
        {
            UpdateDate();
        }

        public List<DateBuildings> Get()
        {
            UpdateDate();
            return buildings;
        }

        public void Add(DateBuildings build)
        {
            if (build == null)
            {
                MessageBox.Show("Проверьте заполненние данных.");
                return;
            }
                
            using (DBCountryHouse db = new DBCountryHouse())
                {
                    db.Buildings.Add(build);
                    db.SaveChanges();
                    buildings = db.Buildings.ToList();
                }
        }
        public void Add(string Name=null, string Status = null, DateTime? DateBuild = null, string TypeBuild = null)
        {
            if (Name == null | Status == null | DateBuild == null | TypeBuild == null)
            {
                MessageBox.Show("Проверьте заполненние данных.");
                return;
            }
            using (DBCountryHouse db = new DBCountryHouse())
            {
                db.Buildings.Add(new DateBuildings { Name = Name, Status = Status, DateBuild = (DateTime)DateBuild, TypeBuild = TypeBuild });
                db.SaveChanges();
                buildings = db.Buildings.ToList();
            }
        }

        public void Edit(DateBuildings build, int? id = null)
        {
            if (id == null)
            {
                MessageBox.Show("Не удалось выполнить редактирование.");
                return;
            }

            build.IdBuilds = (int)id;
            using (DBCountryHouse db = new DBCountryHouse())
            {
                db.Buildings.Add (build);
                buildings = db.Buildings.ToList();
            }
        }
        
        public void Remove(DateBuildings build = null)
        {
            if(build==null)
            {
                MessageBox.Show("Не удалось найти объект который необходимо удалить.");
                return;
            }
            using (DBCountryHouse db = new DBCountryHouse())
            {
                db.Buildings.Remove(build);
                buildings = db.Buildings.ToList();
            }
        }
        public void Remove(int? id = null)
        {
            if (id == null)
            {
                MessageBox.Show("Не удалось найти объект который необходимо удалить.");
                return;
            }
            DateBuildings build;
            build = buildings.FirstOrDefault(s=> s.IdBuilds == id);
            if (build != null)
                using (DBCountryHouse db = new DBCountryHouse())
                {
                    db.Buildings.Remove(build);
                    buildings = db.Buildings.ToList();
                }
        }

        public void UpdateDate()
        {
            using (DBCountryHouse db = new DBCountryHouse())
            {
                buildings = db.Buildings.ToList();
            }
        }
    }
}
