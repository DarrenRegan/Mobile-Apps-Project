using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace myApp.Models
{
    public class QuickNotes
    {
        //Note and CreatedTImep represent columns in SQLite database, which are in table QuickNotes 
        //ID is a unique ID with Primary key and an auto-increment
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Note { get; set; }
        public DateTime CreatedTime { get; set; }

        public QuickNotes()
        {
            //default constructor
        }
    }
}
