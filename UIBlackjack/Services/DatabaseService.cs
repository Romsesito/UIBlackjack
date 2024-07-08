// Services/DatabaseService.cs
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UIBlackjack.Models;

namespace UIBlackjack.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserData>().Wait();
        }

        public Task<List<UserData>> GetUserDataAsync()
        {
            return _database.Table<UserData>().ToListAsync();
        }

        public Task<int> SaveUserDataAsync(UserData userData)
        {
            if (userData.Id != 0)
            {
                return _database.UpdateAsync(userData);
            }
            else
            {
                return _database.InsertAsync(userData);
            }
        }

        public Task<int> DeleteUserDataAsync(UserData userData)
        {
            return _database.DeleteAsync(userData);
        }
    }
}