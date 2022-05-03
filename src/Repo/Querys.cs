using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using modelos;

namespace Repo;

public class Selects{
    SQLiteConnection conexion;
    
    SQLiteDataReader sqlite_datareader;

    SQLiteCommand sqlite_cmd;
    
    public List<Cliente> obtenerClientes(SQLiteConnection conexion){
        List<Cliente> lista = new();
        this.conexion=conexion;
        conexion.Open();
        sqlite_cmd = conexion.CreateCommand();
        string query = "select * from cliente";
        sqlite_cmd.CommandText = query;
        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while(sqlite_datareader.Read()){
            string _dni = sqlite_datareader.GetString(0);
            string _nombre = sqlite_datareader.GetString(1);
            string _direccion = sqlite_datareader.GetString(2);
            lista.Add(new Cliente{
                dni = _dni,
                nombre = _nombre,
                direccion = _direccion
            });
            Console.WriteLine($"{_dni}, {_nombre}, {_direccion}");
        
        }
        return lista;
    }

}

