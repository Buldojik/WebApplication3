using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using System.Numerics;

namespace WebApplication3.Models
{
   /// <summary>
   /// Задача
   /// </summary>
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public List<int> WorkersID { get; set; }
        public List<Worker> Workers { get; set; }
    }
}
