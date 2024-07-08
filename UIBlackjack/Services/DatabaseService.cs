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
            _database.CreateTableAsync<Tarjeta>().Wait();
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

        public Task<List<Tarjeta>> GetTarjetaDataAsync()
        {
            return _database.Table<Tarjeta>().ToListAsync();
        }

        public Task<int> SaveTarjetaDataAsync(Tarjeta tarjetaData)
        {
            if (tarjetaData.Id != 0)
            {
                return _database.UpdateAsync(tarjetaData);
            }
            else
            {
                return _database.InsertAsync(tarjetaData);
            }
        }

        public Task<int> DeleteTarjetaDataAsync(Tarjeta tarjetaData)
        {
            return _database.DeleteAsync(tarjetaData);
        }
    }
}