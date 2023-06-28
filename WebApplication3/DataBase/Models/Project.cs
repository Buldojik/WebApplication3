using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    /// <summary>
    /// Проект
    /// </summary>
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int WorkerID { get; set; }
        public Worker Worker { get; set; }
    }
}
