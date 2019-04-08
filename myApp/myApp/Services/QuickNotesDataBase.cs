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
        readonly SQLiteAsyncConnection database;

        public QuickNotesDataBase(string dbPath)
        {
            //Implements SQLiteInterface and calls GetConnection method
            //CreateTable creates a table called QuickNotes
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<QuickNotes>().Wait();

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
