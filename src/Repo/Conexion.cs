using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
namespace Repo;
public class ConnectDB
{   SQLiteConnection? sqlite_conn;
    static string url= "../../panaderia.sqlite";

    static string fichero_sql = "../../Panaderia.sql";
    private static bool comprobarExistenciaDB(){ return File.Exists(url);}


    public  SQLiteConnection crearConexion(){
         
         if(!comprobarExistenciaDB()){
             crearDB();
         } else{
             sqlite_conn = new SQLiteConnection($"Data Source={url};");
         }
         
         return sqlite_conn;
    }   
    private void crearDB(){
        try{
            string comandos_sql = File.ReadAllText(fichero_sql);
            SQLiteConnection.CreateFile(url);
            sqlite_conn = new SQLiteConnection($"Data Source={url};");
            sqlite_conn.Open();
            SQLiteCommand command = new SQLiteCommand(comandos_sql,sqlite_conn);
            command.ExecuteNonQuery();
            sqlite_conn.Close();
        }catch{
            Console.WriteLine("No hemos encontrado el fichero .sql ni la base de datos, ponganse en contacto con el desarrollador.");
        }
    }

}
