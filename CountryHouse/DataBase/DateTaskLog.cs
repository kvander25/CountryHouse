using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryHouse.DataBase
{
    [Table("TaskLog")]
    public class DateTaskLog
    {
        [Key, Required]
        public int IdTaskLog { get; set; }

        [ForeignKey("Buildings")]
        public int IdBuilds { get; set; }
        public virtual DateBuildings Buildings { get; set; }

        [Required]
        public string TypeOfWork { get; set; }

        [Required]
        public string RequiredMaterial { get; set; }

        [Required]
        public DateTime DateOfCompletion { get; set; }
    }
}
