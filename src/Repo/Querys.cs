using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SQLite;
using modelos;

namespace Repo;

public class Selects{

    SQLiteConnection conexion;

    public Selects(SQLiteConnection conexion){
        this.conexion=conexion;
    }
    
    SQLiteDataReader sqlite_datareader;

    SQLiteCommand sqlite_cmd;
    
    public List<Cliente> obtenerClientes(){
        List<Cliente> lista = new();
        conexion.Open();
        sqlite_cmd = conexion.CreateCommand();
        sqlite_cmd.CommandText = "select * from cliente";
        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while(sqlite_datareader.Read()){
            lista.Add(new Cliente{
                dni = sqlite_datareader.GetString(0),
                nombre = sqlite_datareader.GetString(1),
                direccion = sqlite_datareader.GetString(2)
            });           
        }
        conexion.Close();
        return lista;
    }
    public List<Producto> obtenerProductos(){
        List<Producto> lista = new();
        conexion.Open();
        sqlite_cmd = conexion.CreateCommand();
        sqlite_cmd.CommandText = "select * from producto";
        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while(sqlite_datareader.Read()){
            lista.Add(new Producto{
                id_producto = sqlite_datareader.GetInt32(0),
                nombre = sqlite_datareader.GetString(1),
                precio = sqlite_datareader.GetFloat(2),
                kg_harina = sqlite_datareader.GetFloat(3)
            });           
        }
        conexion.Close();
        return lista;
    }

    public List<Pedido> obtenerPedidosHoy(){
        List<Pedido> lista = new();
        conexion.Open();
        sqlite_cmd = conexion.CreateCommand();
        sqlite_cmd.CommandText = $"select * from pedido where fecha='{DateTime.Now.ToString("d",CultureInfo.GetCultureInfo("es-ES"))}'";
        sqlite_datareader = sqlite_cmd.ExecuteReader();
        while(sqlite_datareader.Read()){
            int _id_pedido = sqlite_datareader.GetInt32(0);
            Pedido pedido = new Pedido{
                id_pedido=_id_pedido,
                fecha = DateTime.Parse(sqlite_datareader.GetString(1),CultureInfo.GetCultureInfo("es-ES")),
                entregado = sqlite_datareader.GetBoolean(2),
                pagado  = sqlite_datareader.GetBoolean(3),
                dni = sqlite_datareader.GetString(4),
                productos = new()
            };
            sqlite_cmd.CommandText=$"select * from pedido_producto inner join producto on pedido_producto.id_producto=producto.id_producto where id_pedido={_id_pedido}";
            SQLiteDataReader reader2;
            reader2 = sqlite_cmd.ExecuteReader();
           
            while(reader2.Read()){
                (Producto,int) tup = (
                    new Producto{
                        id_producto=reader2.GetInt32(1),
                        nombre = reader2.GetString(4),
                        precio = reader2.GetFloat(5),
                        kg_harina = reader2.GetFloat(6)
                    },
                    reader2.GetInt32(2)
                );
                pedido.productos.Add(tup);
            }
            lista.Add(pedido);           
        }
        conexion.Close();
        return lista;
    }

}

