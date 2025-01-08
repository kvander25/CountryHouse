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
    public class VMTaskLog
    {
        List<DateTaskLog> taskLogs;


        public List<DateTaskLog> Get()
        {
            UpdateDate();
            return taskLogs;
        }

        public void Add(DateTaskLog taskLog)
        {
            if (taskLog == null)
            {
                MessageBox.Show("Проверьте заполненние данных.");
                return;
            }

            using (DBCountryHouse db = new DBCountryHouse())
            {
                db.TaskLog.Add(taskLog);
                db.SaveChanges();
                taskLogs = db.TaskLog.ToList();
            }
        }
        public void Add(int? IdBuilds = null, string TypeOfWork = null, string RequiredMaterial = null, DateTime? DateOfCompletion = null)
        {
            if (IdBuilds == null | TypeOfWork == null | RequiredMaterial == null | DateOfCompletion == null)
            {
                MessageBox.Show("Проверьте заполненние данных.");
                return;
            }
            using (DBCountryHouse db = new DBCountryHouse())
            {
                db.TaskLog.Add(new DateTaskLog { IdBuilds = (int)IdBuilds, TypeOfWork = TypeOfWork, RequiredMaterial = RequiredMaterial, DateOfCompletion = (DateTime)DateOfCompletion });
                db.SaveChanges();
                taskLogs = db.TaskLog.ToList();
            }
        }

        public void Edit(DateTaskLog taskLog, int? id = null)
        {
            if (id == null)
            {
                MessageBox.Show("Не удалось выполнить редактирование.");
                return;
            }

            taskLog.IdTaskLog = (int)id;
            using (DBCountryHouse db = new DBCountryHouse())
            {
                db.TaskLog.Add(taskLog);
                taskLogs = db.TaskLog.ToList();
            }
        }

        public void Remove(DateTaskLog taskLog = null)
        {
            if (taskLog == null)
            {
                MessageBox.Show("Не удалось найти объект который необходимо удалить.");
                return;
            }
            using (DBCountryHouse db = new DBCountryHouse())
            {
                db.TaskLog.Remove(taskLog);
                taskLogs = db.TaskLog.ToList();
            }
        }
        public void Remove(int? id = null)
        {
            if (id == null)
            {
                MessageBox.Show("Не удалось найти объект который необходимо удалить.");
                return;
            }
            DateTaskLog taskLog;
            taskLog = taskLogs.FirstOrDefault(s => s.IdTaskLog == id);
            if (taskLog != null)
                using (DBCountryHouse db = new DBCountryHouse())
                {
                    db.TaskLog.Remove(taskLog);
                    taskLogs = db.TaskLog.ToList();
                }
        }

        public void UpdateDate()
        {
            using (DBCountryHouse db = new DBCountryHouse())
            {
                taskLogs = db.TaskLog.Include("Buildings").ToList();
            }
        }
    }
}
