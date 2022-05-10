using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Reflection;
namespace Repo {
    public class ConnectDB
    {
        SQLiteConnection sqlite_conn;
        string directorio = Path.GetFullPath(@"C:\PanaderiaManolo");
        string url = Path.GetFullPath(@"C:\PanaderiaManolo\panaderia.sqlite");

        public SQLiteConnection crearConexion()
        {

            if (!File.Exists(url))
            {
                var str = Directory.GetCurrentDirectory();
                crearDB();
            }
            else
            {
                sqlite_conn = new SQLiteConnection($"Data Source={url};");
            }

            return sqlite_conn;
        }
        private void crearDB()
        {
            try
            {

                Assembly thisAssembly = Assembly.GetExecutingAssembly();
                Stream s = thisAssembly.GetManifestResourceStream("RepoFramework.Panaderia.sql");
                StreamReader sr = new StreamReader(s);
                string comandos_sql = sr.ReadToEnd();
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }
                SQLiteConnection.CreateFile(url);
                sqlite_conn = new SQLiteConnection($"Data Source={url};");
                sqlite_conn.Open();
                SQLiteCommand command = new SQLiteCommand(comandos_sql, sqlite_conn);
                command.ExecuteNonQuery();
                sqlite_conn.Close();
            }
            catch
            {
                //Error
            }
        }

    }

}
