using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CountryHouse.DataBase
{
    public class VMPlanting
    {
        List<DatePlanting> plantings;


        public List<DatePlanting> Get()
        {
            UpdateDate();
            return plantings;
        }

        public void Add(DatePlanting plant)
        {
            if (plant == null)
            {
                MessageBox.Show("Проверьте заполненние данных.");
                return;
            }

            using (DBCountryHouse db = new DBCountryHouse())
            {
                db.Plants.Add(plant);
                db.SaveChanges();
                plantings = db.Plants.ToList();
            }
        }
        public void Add(int? IdPlace = null, string Culture = null, int? NumberOfPlants = null, DateTime? DatePlanes = null )
        {
            if (IdPlace == null | Culture == null | NumberOfPlants == null | DatePlanes == null)
            {
                MessageBox.Show("Проверьте заполненние данных.");
                return;
            }
            using (DBCountryHouse db = new DBCountryHouse())
            {
                db.Plants.Add(new DatePlanting { IdPlace= (int)IdPlace, Culture = Culture, NumberOfPlants = (int)NumberOfPlants, DatePlanes = (DateTime) DatePlanes});
                db.SaveChanges();
                plantings = db.Plants.ToList();
            }
        }

        public void Edit(DatePlanting plant, int? id = null)
        {
            if (id == null)
            {
                MessageBox.Show("Не удалось выполнить редактирование.");
                return;
            }

            plant.IdPlants = (int)id;
            using (DBCountryHouse db = new DBCountryHouse())
            {
                db.Plants.Add(plant);
                plantings = db.Plants.ToList();
            }
        }

        public void Remove(DatePlanting plant = null)
        {
            if (plant == null)
            {
                MessageBox.Show("Не удалось найти объект который необходимо удалить.");
                return;
            }
            using (DBCountryHouse db = new DBCountryHouse())
            {
                db.Plants.Remove(plant);
                plantings = db.Plants.ToList();
            }
        }
        public void Remove(int? id = null)
        {
            if (id == null)
            {
                MessageBox.Show("Не удалось найти объект который необходимо удалить.");
                return;
            }
            DatePlanting plant;
            plant = plantings.FirstOrDefault(s => s.IdPlants == id);
            if (plant != null)
                using (DBCountryHouse db = new DBCountryHouse())
                {
                    db.Plants.Remove(plant);
                    plantings = db.Plants.ToList();
                }
        }

        public void UpdateDate()
        {
            using (DBCountryHouse db = new DBCountryHouse())
            {
                plantings = db.Plants.Include("Buildings").ToList();
            }
        }
    }
}
