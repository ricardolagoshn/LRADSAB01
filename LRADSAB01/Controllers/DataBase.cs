using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace LRADSAB01.Controllers
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection _connection;

        public DataBase() { }

        public DataBase(string path) 
        { 
            _connection = new SQLiteAsyncConnection(path); 
            // Creacion de objetos de base de datos
            _connection.CreateTableAsync<Models.Personas>().Wait();
        }

        // Crear metodos CREATE - READ - UPDATE - DELETE

        public Task<int> AddPersona(Models.Personas persona)
        {
            if (persona.Id == 0)
            {
                return _connection.InsertAsync(persona);
            }
            else
            {
                return _connection.UpdateAsync(persona);
            }
        } 

        public Task<List<Models.Personas>> GetAllPersonas() 
        {
            return _connection.Table<Models.Personas>().ToListAsync();
        }

        public Task<Models.Personas> GetPersona(int pid) 
        {
            return _connection.Table<Models.Personas>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        public Task<int> DeletePersona(Models.Personas personas) 
        {
            return _connection.DeleteAsync(personas);
        }

    }
}
