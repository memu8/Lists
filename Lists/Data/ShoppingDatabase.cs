using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Lists.Models;

namespace Lists.Data
{
    public class ShoppingDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ShoppingDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetNotesAsync()
        {
            return _database.Table<Item>().ToListAsync();
        }

        public Task<Item> GetNoteAsync(int id)
        {
            return _database.Table<Item>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Item note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Item note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
