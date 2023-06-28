using System;

namespace WebApplication3.Models
{
    /// <summary>
    /// Трудозатраты
    /// </summary>
    public class LaborCosts
    {
        public int ID { get; set; }
        public int QuestID { get; set; }
        public Quest Quest { get; set; }
        public int WorkerID { get; set; }
        public Worker Worker { get; set; }
        public DateOnly Date {get; set; }
        public float Hour { get; set; }
    }
}
