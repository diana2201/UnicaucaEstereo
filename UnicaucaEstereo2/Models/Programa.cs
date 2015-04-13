using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace UnicaucaEstereo2.Models
{
    public class Programa
    {
        [AutoIncrement, PrimaryKey]
        public int ID {get ; set;}
        public String name { get; set; }
        public int startTime { get; set; }
        public int startMin { get; set; }
        public int endTime { get; set; }
        public int endMin { get; set; }
        public String description { get; set; }
        public String announcer { get; set; }
        public String director { get; set; }
        public String day { get; set; }
        public String typep { get; set; }

        public Programa()
        { }

        //public Programa(String name, String starTime, String endTime, String description, String announcer, String director, String day, String typep)
        //{

        //    this.name = name;
        //    this.startTime = startTime;
        //    this.endTime = endTime;
        //    this.description = description;
        //    this.announcer = announcer;
        //    this.director = director;
        //    this.day = day;
        //    this.typep = typep;
        //}
    }
}
