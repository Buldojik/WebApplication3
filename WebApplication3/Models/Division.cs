using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    /// <summary>
    /// Подразделение
    /// </summary>
    public class Division
    {
        /// <summary>
        /// И
        /// </summary>
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int WorkerID { get; set; }
        public Worker Worker {get; set; }
    }
}
