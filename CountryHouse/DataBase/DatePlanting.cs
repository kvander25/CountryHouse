using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHouse.DataBase
{
    [Table("Planting")]
    public class DatePlanting
    {
        [Key, Required] 
        public int IdPlants {  get; set; }

        [ForeignKey("Buildings")]
        public int IdPlace { get; set; }
        public virtual DateBuildings Buildings { get; set; }

        [Required] 
        public string Culture { get; set; }

        [Required] 
        public DateTime DatePlanes { get; set; }

        [Required] 
        public int NumberOfPlants { get; set; }
    }
}
