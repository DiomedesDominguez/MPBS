using Listado.Helpers;
using Listado.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listado.Data
{
  public  class ListadoDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

        });
        static SQLiteAsyncConnection Database => lazyInitializer.Value; static bool initialized = false;
        public ListadoDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Tarea).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Tarea)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }
        public Task<List<T>> GetAllAsync<T>()
            where T : class, ITable, new()
        {

            return Database.Table<T>().ToListAsync();
        }

        public Task<int> SaveAsync<T>(T item)
            where T : class, ITable, new()
        {
            var exist = Database.Table<T>().CountAsync(x => x.Id == item.Id).Result == 1;
            if (exist)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteAsync<T>(T item)
            where T : class, ITable, new()
        {
            return Database.DeleteAsync<T>(item.Id);
        }
    }
}
