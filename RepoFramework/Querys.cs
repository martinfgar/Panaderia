using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SQLite;
using modelos;

namespace Repo {
    public class Selects
    {

        SQLiteConnection conexion;

        public Selects(SQLiteConnection conexion)
        {
            this.conexion = conexion;
        }

        SQLiteDataReader sqlite_datareader;

        SQLiteCommand sqlite_cmd;

        //Obtener lista de clientes
        public List<Cliente> obtenerClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = "select * from cliente";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                lista.Add(new Cliente
                {
                    dni = sqlite_datareader.GetString(0),
                    nombre = sqlite_datareader.GetString(1),
                    direccion = sqlite_datareader.GetString(2)
                });
            }
            conexion.Close();
            return lista;
        }

        //Obtiene la lista de productos
        public List<Producto> obtenerProductos()
        {
            List<Producto> lista = new List<Producto>();
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = "select * from producto";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                lista.Add(new Producto
                {
                    id_producto = sqlite_datareader.GetInt32(0),
                    nombre = sqlite_datareader.GetString(1),
                    precio = sqlite_datareader.GetFloat(2),
                    kg_harina = sqlite_datareader.GetFloat(3)
                });
            }
            conexion.Close();
            return lista;
        }

        //Obtiene la lista de pedidos programados para la fecha especificada.
        public List<Pedido> obtenerPedidosFecha(System.DateTime fecha)
        {
            List<Pedido> lista = new List<Pedido>();
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"select * from pedido where fecha='{fecha.ToString("d", CultureInfo.GetCultureInfo("es-ES"))}'";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                int _id_pedido = sqlite_datareader.GetInt32(0);
                Pedido pedido = new Pedido
                {
                    id_pedido = _id_pedido,
                    fecha = System.DateTime.Parse(sqlite_datareader.GetString(1), CultureInfo.GetCultureInfo("es-ES")),
                    entregado = sqlite_datareader.GetBoolean(2),
                    pagado = sqlite_datareader.GetBoolean(3),
                    dni = sqlite_datareader.GetString(4),
                    id_prod_cantidad = new List<(int,int)>()
                };
                sqlite_cmd = conexion.CreateCommand();
                sqlite_cmd.CommandText = $"select * from pedido_producto where id_pedido={_id_pedido}";
                SQLiteDataReader reader2;
                reader2 = sqlite_cmd.ExecuteReader();

                while (reader2.Read())
                {
                    pedido.id_prod_cantidad.Add((reader2.GetInt32(1), reader2.GetInt32(2)));
                }
                lista.Add(pedido);
            }
            conexion.Close();
            return lista;
        }

        //Obtiene la lista de pedidos marcados como habituales
        public List<PedidoHabitual> pedidosHabituales()
        {
            List<PedidoHabitual> lista = new List<PedidoHabitual>();
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"select * from pedido_habitual";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                int _id_pedido = sqlite_datareader.GetInt32(0);
                PedidoHabitual pedido = new PedidoHabitual
                {
                    id_pedido_habitual = _id_pedido,
                    dni = sqlite_datareader.GetString(1),
                    id_prod_cantidad = new List<(int,int)>(),
                };
                sqlite_cmd = conexion.CreateCommand();
                sqlite_cmd.CommandText = $"select * from pedido_hab_producto where id_pedido_habitual={_id_pedido}";
                SQLiteDataReader reader2;
                reader2 = sqlite_cmd.ExecuteReader();

                while (reader2.Read())
                {
                    pedido.id_prod_cantidad.Add((reader2.GetInt32(1), reader2.GetInt32(2)));
                }
                lista.Add(pedido);
            }
            conexion.Close();
            return lista;
        }

        //Obtiene las excepciones a pedidos habituales para el dia de hoy
        public List<int> id_pedidos_excepcionesFecha(System.DateTime fecha)
        {
            List<int> lista = new List<int>();
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"select id_pedido_habitual from excepcion where fecha='{fecha.ToString("d", CultureInfo.GetCultureInfo("es-ES"))}'";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                lista.Add(sqlite_datareader.GetInt32(0));
            }
            conexion.Close();
            return lista;
        }

        //Obtiene lista de pedidos entregados no pagados por usuario
        public List<Pedido> pedidosUsuarioSinPagar(string dni)
        {
            List<Pedido> lista = new List<Pedido>();
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"select * from pedido where dni='{dni}' and pagado=0 and entregado=1";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                int _id_pedido = sqlite_datareader.GetInt32(0);
                Pedido pedido = new Pedido
                {
                    id_pedido = _id_pedido,
                    fecha = System.DateTime.Parse(sqlite_datareader.GetString(1), CultureInfo.GetCultureInfo("es-ES")),
                    entregado = sqlite_datareader.GetBoolean(2),
                    pagado = sqlite_datareader.GetBoolean(3),
                    dni = sqlite_datareader.GetString(4),
                    id_prod_cantidad = new List<(int,int)>()
                };
                sqlite_cmd = conexion.CreateCommand();
                sqlite_cmd.CommandText = $"select * from pedido_producto where id_pedido={_id_pedido}";
                SQLiteDataReader reader2;
                reader2 = sqlite_cmd.ExecuteReader();

                while (reader2.Read())
                {
                    pedido.id_prod_cantidad.Add((reader2.GetInt32(1), reader2.GetInt32(2)));
                }
                lista.Add(pedido);
            }
            conexion.Close();
            return lista;
        }

        //Obtiene lista de productos y cantidad vendidos en tienda en una fecha dada.
        public List<(int, int)> ventasIDProductosEnFecha(System.DateTime fecha)
        {
            List<(int, int)> lista = new List<(int, int)>();
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"select id_producto,cantidad from venta inner join venta_producto on venta.id_venta=venta_producto.id_venta where fecha='{fecha.ToString("d", CultureInfo.GetCultureInfo("es-ES"))}'";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                lista.Add((sqlite_datareader.GetInt32(0), sqlite_datareader.GetInt32(1)));
            }
            conexion.Close();
            return lista;
        }

        //Obtiene los id de productos producidos en la fecha aportada, y la cantidad
        public List<(int, int)> produccionEnFecha(System.DateTime fecha)
        {
            List<(int, int)> lista = new List<(int, int)>();
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"select id_producto,cantidad from producido_producto where fecha='{fecha.ToString("d", CultureInfo.GetCultureInfo("es-ES"))}'";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                lista.Add((sqlite_datareader.GetInt32(0), sqlite_datareader.GetInt32(1)));
            }
            conexion.Close();
            return lista;
        }

        //Obtiene lo gastado en luz en la fecha especificada
        public float gastoLuzFecha(System.DateTime fecha)
        {
            float gasto = 0;
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"select gasto_electrico from producido where fecha='{fecha.ToString("d", CultureInfo.GetCultureInfo("es-ES"))}'";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                gasto += sqlite_datareader.GetFloat(0);
            }
            conexion.Close();
            return gasto;
        }
    }

    public class Inserts
    {
        SQLiteConnection conexion;
        SQLiteCommand sqlite_cmd;

        public Inserts(SQLiteConnection conexion)
        {
            this.conexion = conexion;
        }

        //Registrar un nuevo cliente
        public void registrarCliente(Cliente cliente)
        {
            try
            {
                sqlite_cmd = conexion.CreateCommand();
                conexion.Open();
                sqlite_cmd.CommandText = $"insert into cliente values(@dni,@nombre,@direccion); select last_insert_rowid();";
                sqlite_cmd.Parameters.AddWithValue("@dni", cliente.dni);
                sqlite_cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                sqlite_cmd.Parameters.AddWithValue("@direccion", cliente.direccion);
                sqlite_cmd.ExecuteReader();
            }
            catch (SQLiteException ex)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }


        }

        //Registrar un nuevo pedido
        public void registrarPedido(Pedido pedido)
        {
            try
            {
                sqlite_cmd = conexion.CreateCommand();
                conexion.Open();
                sqlite_cmd.CommandText = $"insert into pedido(fecha,entregado,pagado,dni) values(@fecha,@entregado,@pagado,@dni)";
                sqlite_cmd.Parameters.AddWithValue("@fecha", pedido.fecha.ToString("d", CultureInfo.GetCultureInfo("es-ES")));
                sqlite_cmd.Parameters.AddWithValue("@entregado", pedido.entregado);
                sqlite_cmd.Parameters.AddWithValue("@pagado", pedido.pagado);
                sqlite_cmd.Parameters.AddWithValue("@dni", pedido.dni);
                sqlite_cmd.ExecuteReader();
                int _id_pedido = (int)conexion.LastInsertRowId;
                pedido.id_pedido = _id_pedido;
                pedido.productos.ForEach(tupla =>
                {
                    sqlite_cmd = conexion.CreateCommand();
                    sqlite_cmd.CommandText = $"insert into pedido_producto values(@id_pedido,@id_producto,@cantidad)";
                    sqlite_cmd.Parameters.AddWithValue("@id_pedido", _id_pedido);
                    sqlite_cmd.Parameters.AddWithValue("@id_producto", tupla.Item1.id_producto);
                    sqlite_cmd.Parameters.AddWithValue("@cantidad", tupla.Item2);
                    sqlite_cmd.ExecuteReader();
                });

            }
            catch (SQLiteException ex)
            {
                //Para cuando ese usuario ya tiene un pedido para ese dia
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Registrar nuevo pedido habitual
        public void registrarPedidoHabitual(PedidoHabitual pedido)
        {
            try
            {
                sqlite_cmd = conexion.CreateCommand();
                conexion.Open();
                sqlite_cmd.CommandText = $"insert into pedido_habitual(dni) values(@dni)";
                sqlite_cmd.Parameters.AddWithValue("@dni", pedido.dni);
                sqlite_cmd.ExecuteReader();
                int _id_pedido = (int)conexion.LastInsertRowId;
                pedido.productos.ForEach(tupla =>
                {
                    sqlite_cmd = conexion.CreateCommand();
                    sqlite_cmd.CommandText = $"insert into pedido_hab_producto values(@id_pedido,@id_producto,@cantidad)";
                    sqlite_cmd.Parameters.AddWithValue("@id_pedido", _id_pedido);
                    sqlite_cmd.Parameters.AddWithValue("@id_producto", tupla.Item1.id_producto);
                    sqlite_cmd.Parameters.AddWithValue("@cantidad", tupla.Item2);
                    sqlite_cmd.ExecuteReader();
                });

            }
            catch (SQLiteException ex)
            {
                //Para cuando ese usuario ya tiene un pedido para ese dia
                throw;
            }
            finally
            {
                conexion.Close();
            }

        }

        //Registrar venta fisica en local
        public void registrarVenta(Venta venta)
        {
            sqlite_cmd = conexion.CreateCommand();
            conexion.Open();
            sqlite_cmd.CommandText = $"insert into venta(fecha) values(@fecha)";
            sqlite_cmd.Parameters.AddWithValue("@fecha", System.DateTime.Now.ToString("d", CultureInfo.GetCultureInfo("es-ES")));
            sqlite_cmd.ExecuteReader();
            int _id_venta = (int)conexion.LastInsertRowId;
            venta.productos.ForEach(tupla =>
            {
                sqlite_cmd = conexion.CreateCommand();
                sqlite_cmd.CommandText = $"insert into venta_producto values(@id_venta,@id_producto,@cantidad)";
                sqlite_cmd.Parameters.AddWithValue("@id_venta", _id_venta);
                sqlite_cmd.Parameters.AddWithValue("@id_producto", tupla.Item1.id_producto);
                sqlite_cmd.Parameters.AddWithValue("@cantidad", tupla.Item2);
                sqlite_cmd.ExecuteReader();
            });
            conexion.Close();
        }

        //Registra excepcion para entrega de pedidos habituales
        public void registrarExcepcion(int id_pedido_habitual, System.DateTime fecha)
        {
            try
            {
                sqlite_cmd = conexion.CreateCommand();
                conexion.Open();
                sqlite_cmd.CommandText = $"insert into excepcion values(@id_pedido_hab,@fecha)";
                sqlite_cmd.Parameters.AddWithValue("@fecha", fecha.ToString("d", CultureInfo.GetCultureInfo("es-ES")));
                sqlite_cmd.Parameters.AddWithValue("@id_pedido_hab", id_pedido_habitual);
                sqlite_cmd.ExecuteReader();
            }
            catch (SQLiteException ex)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

        }

        //Registrar la produccion del dia
        public void registrarProduccion(List<(Producto, int)> productos, float horas_horno, float gasto_electrico)
        {
            try
            {
                sqlite_cmd = conexion.CreateCommand();
                conexion.Open();
                sqlite_cmd.CommandText = $"insert into producido values(@fecha,@horas,@consumo)";
                sqlite_cmd.Parameters.AddWithValue("@fecha", System.DateTime.Today.ToString("d", CultureInfo.GetCultureInfo("es-ES")));
                sqlite_cmd.Parameters.AddWithValue("@horas", horas_horno);
                sqlite_cmd.Parameters.AddWithValue("@consumo", gasto_electrico);
                sqlite_cmd.ExecuteReader();
                productos.ForEach(tupla =>
                {
                    sqlite_cmd = conexion.CreateCommand();
                    sqlite_cmd.CommandText = $"insert into producido_producto values(@fecha,@id_producto,@cantidad)";
                    sqlite_cmd.Parameters.AddWithValue("@fecha", System.DateTime.Today.ToString("d", CultureInfo.GetCultureInfo("es-ES")));
                    sqlite_cmd.Parameters.AddWithValue("@id_producto", tupla.Item1.id_producto);
                    sqlite_cmd.Parameters.AddWithValue("@cantidad", tupla.Item2);
                    sqlite_cmd.ExecuteReader();
                });
            }
            catch (SQLiteException ex)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }

    public class Deletes
    {
        SQLiteConnection conexion;

        public Deletes(SQLiteConnection conexion)
        {
            this.conexion = conexion;
        }

        SQLiteDataReader sqlite_datareader;

        SQLiteCommand sqlite_cmd;

        public void cancelarPedido(Pedido pedido)
        {
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"delete from pedido_producto where id_pedido={pedido.id_pedido}";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"delete from pedido where id_pedido={pedido.id_pedido}";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            conexion.Close();
        }

        public void eliminarPedidoHabitual(PedidoHabitual ped)
        {
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"delete from pedido_hab_producto where id_pedido_habitual={ped.id_pedido_habitual}";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"delete from pedido_habitual where id_pedido_habitual={ped.id_pedido_habitual}";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            conexion.Close();
        }
    }


    public class Updates
    {
        SQLiteConnection conexion;

        public Updates(SQLiteConnection conexion)
        {
            this.conexion = conexion;
        }

        SQLiteDataReader sqlite_datareader;

        SQLiteCommand sqlite_cmd;


        //Actualiza entrega pedido
        public void actualizarEntregaPedido(Pedido pedido)
        {
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"update pedido set entregado=1 where id_pedido={pedido.id_pedido}";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            conexion.Close();
        }

        //Actualiza a pagado el estado de los pedidos entregados de un cliente
        public void pagarPedidosEntregadosACliente(Cliente cliente)
        {
            conexion.Open();
            sqlite_cmd = conexion.CreateCommand();
            sqlite_cmd.CommandText = $"update pedido set pagado=1 where dni='{cliente.dni}' and entregado=1";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            conexion.Close();
        }
    }


}

