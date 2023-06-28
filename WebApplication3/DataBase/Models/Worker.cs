using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication3.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Worker
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Cod1C { get; set; }
        public string Post { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Division? Division { get; set; }
    }
}
