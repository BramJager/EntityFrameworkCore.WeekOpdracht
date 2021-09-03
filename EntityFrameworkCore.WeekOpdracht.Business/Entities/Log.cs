using System;

namespace EntityFrameworkCore.WeekOpdracht.Business.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
    }
}
