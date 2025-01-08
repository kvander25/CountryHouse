using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHouse.DataBase
{
    [Table("Buildings")]
    public class DateBuildings
    {
        [Key, Required] 
        public int IdBuilds { get; set; }

        [Required] 
        public string Name { get; set; }

        [Required] 
        public string Status { get; set; }

        [Required] 
        public DateTime DateBuild { get; set; }

        [Required] 
        public string TypeBuild { get; set; }

        public virtual ICollection<DatePlanting> DatePlants { get; } = new List<DatePlanting>();

        public virtual ICollection<DateTaskLog> DateTaskLogs { get; } = new List<DateTaskLog>();
    }
}
