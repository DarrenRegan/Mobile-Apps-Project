using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using myApp.Models;
using System.Threading.Tasks;

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

        public Task<List<QuickNotes>> GetItemAsync() => database.Table<QuickNotes>().ToListAsync();

        public Task<List<QuickNotes>> GetItemsNotDoneAsync() => database.QueryAsync<QuickNotes>("SELECT * FROM [QuickNotes] WHERE [Done] = 0");

        public Task<QuickNotes> GetItemAsync(int id) => database.Table<QuickNotes>().Where(i => i.ID == id).FirstOrDefaultAsync();

        public Task<int> SaveItemAsync(QuickNotes item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(QuickNotes item)
        {
            return database.DeleteAsync(item);
        }
       
    }
}//myAPP
