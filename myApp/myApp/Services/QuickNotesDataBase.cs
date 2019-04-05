using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using myApp.Models;

namespace myApp.Services
{
    public class QuickNotesDataBase
    {
        private SQLiteConnection _connection;
        private DateTime CreatedTime;

        public QuickNotesDataBase()
        {
            //Implements SQLiteInterface and calls GetConnection method
            //CreateTable creates a table called QuickNotes
            _connection = DependencyService.Get<SQLiteInterface>().GetConnection();
            _connection.CreateTable<QuickNotes>();

        }

        public IEnumerable<QuickNotes> GetNotes()
        {
            return (from t in _connection.Table<QuickNotes>() select t).ToList();
        }

        public QuickNotes GetNote(int id)
        {
            return _connection.Table<QuickNotes>().FirstOrDefault(t => t.ID == id);
        }

        public void DeleteNote(int id)
        {
            _connection.Delete<QuickNotes>(id);
        }

        public void AddNote(string note) {
            var newNote = new QuickNotes{
                Note = note,
                CreatedTime = DateTime.Now
            };
            _connection.Insert(newNote);
        }//AddNote
       
    }
}//myAPP
