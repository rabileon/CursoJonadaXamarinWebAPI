using JornadaXamarin.MobileApp.AppBase.Storage.Interfaces;
using JornadaXamarin.MobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace JornadaXamarin.MobileApp.AppBase.Storage
{
    public class SQLiteAsyncManager
    {
        private static SQLiteAsyncManager instance;

        public static SQLiteAsyncManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new();
                }
                return instance;
            }
        }

        private readonly SQLiteAsyncConnection connection;

        public SQLiteAsyncManager()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.db3");

            connection = new(path);

            connection.CreateTableAsync<BookDTO>().Wait();
        }

        public async Task SaveValueAsync<T>(T value, bool overrideIfExists = true) where T : Interfaces.IKeyObject, new()
        {
            if (overrideIfExists)
            {
                await connection.InsertOrReplaceAsync(value);
            }
            else
            {
                var item = await connection.FindAsync<T>(value.Id);
                if (item is null)
                {
                    await connection.InsertAsync(value);
                }
                else
                {
                    throw new Exception($"Id {value.Id} already exists in DB");
                }
            }
        }

        public async Task<T> FindByIdASync<T>(string id)
            where T : IKeyObject, new()
            => await connection.FindAsync<T>(id);

        public async Task InsertAllASync<T>(IEnumerable<T> values)
            where T : IKeyObject, new()
        {
            await connection.DropTableAsync<T>();
            await connection.CreateTableAsync<T>();
            await connection.InsertAllAsync(values);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            where T : IKeyObject, new()
            => await connection.Table<T>().ToListAsync();
    }
}