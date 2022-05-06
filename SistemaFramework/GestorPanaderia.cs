using Repo;
using System.Linq;
using modelos;
using System.Data.SQLite;
using System.Collections.Generic;

namespace Sistema {
    public class GestorPanaderia
    {
        ConnectDB con;
        Selects sel;
        Inserts ins;
        Updates upd;
        Deletes del;

        private float precio_kg_harina = 1.29f;

        private int consumo_horno = 3000;

        private float precio_luz_kw_h;
        public List<Producto> listaProductos { get; set; }

        public GestorPanaderia(string urlDB) {
            con = new ConnectDB(urlDB);
            sel = new Selects(con.crearConexion());
            ins = new Inserts(con.crearConexion());
            upd = new Updates(con.crearConexion());
            del = new Deletes(con.crearConexion());
            listaProductos = sel.obtenerProductos();
            anadirHabitualesDeManana();
            precio_luz_kw_h = PrecioLuz.obtenerPrecioLuz() / 1000;
        }

        public GestorPanaderia()
        {
            con = new ConnectDB();
            sel = new Selects(con.crearConexion());
            ins = new Inserts(con.crearConexion());
            upd = new Updates(con.crearConexion());
            del = new Deletes(con.crearConexion());
            listaProductos = sel.obtenerProductos();
            anadirHabitualesDeManana();
            precio_luz_kw_h = PrecioLuz.obtenerPrecioLuz() / 1000;

        }

        //Este metodo se ejecuta al iniciar el programa, añade los pedidos habituales (que no tengan excepcion para hoy) a pedidos
        private void anadirHabitualesDeManana()
        {
            List<int> excepciones = sel.id_pedidos_excepcionesFecha(System.DateTime.Today.AddDays(1));
            List<PedidoHabitual> pedidosASumar = listaPedidosHabituales().FindAll(pedido => !excepciones.Contains(pedido.id_pedido_habitual));
            pedidosASumar.ForEach(pedido =>
            {
                try
                {
                    ins.registrarPedido(
                    new Pedido
                    {
                        productos = pedido.productos,
                        dni = pedido.dni,
                        fecha = System.DateTime.Today.AddDays(1),
                        entregado = false,
                        pagado = false
                    }
                );
                }
                catch
                {
                    //Puede ser que el metodo se haya ejecutado de antes y ya esten introducidos (SQLiteException)
                }
            });
        }

        //Devuelve la lista de los pedidos marcados como habituales y antes de ello añade todos los datos de los productos en el pedido
        public List<PedidoHabitual> listaPedidosHabituales()
        {
            List<PedidoHabitual> listaPedidosHab = sel.pedidosHabituales();
            List<Cliente> clientes = listaDeClientes();
            listaPedidosHab.ForEach(pedido =>
            {
                pedido.cliente = clientes.Find(client => pedido.dni == client.dni);
                pedido.productos = new List<(Producto, int)>();
                pedido.id_prod_cantidad.ForEach(producto =>
                {
                    pedido.productos.Add((listaProductos.Find(prod => prod.id_producto == producto.Item1), producto.Item2));
                });
            });
            return listaPedidosHab;
        }
        //Devuelve la lista de pedidos, y antes de ello añade todos los datos de los productos en el pedido
        public List<Pedido> pedidosDeFecha(System.DateTime fecha)
        {
            List<Pedido> listaPedidosHoy = sel.obtenerPedidosFecha(fecha);
            List<Cliente> clientes = listaDeClientes();
            listaPedidosHoy.ForEach(pedido =>
            {
                pedido.cliente = clientes.Find(client => pedido.dni == client.dni);
                pedido.productos = new List<(Producto, int)>();
                pedido.id_prod_cantidad.ForEach(producto =>
                {
                    pedido.productos.Add((listaProductos.Find(prod => prod.id_producto == producto.Item1), producto.Item2));
                });
            });
            return listaPedidosHoy;
        }


        //Pedidos de hoy sin entregar
        public List<Pedido> pedidosPorEntregarHoy()
        {
            return pedidosDeFecha(System.DateTime.Today).FindAll(pedido => !pedido.entregado);
        }

        //Devuelve un diccionario con los productos a producir el dia especificado y la cantidad
        public Dictionary<Producto, int> aProducirEnFecha(System.DateTime fecha)
        {
            Dictionary<Producto, int> produccion = new Dictionary<Producto, int>();
            pedidosDeFecha(fecha).ForEach(pedido =>
            {
                pedido.productos.ForEach(producto =>
                {
                    if (produccion.ContainsKey(producto.Item1))
                    {
                        produccion[producto.Item1] += producto.Item2;
                    }
                    else
                    {
                        produccion.Add(producto.Item1, producto.Item2);
                    }
                });
            });
            //En caso de consultar para dentro de 2 dias o más, sumar pedidos habituales
            if ((fecha - System.DateTime.Today).TotalDays > 1)
            {
                listaPedidosHabituales().ForEach(pedido =>
                {
                    pedido.productos.ForEach(producto =>
                    {
                        if (produccion.ContainsKey(producto.Item1))
                        {
                            produccion[producto.Item1] += producto.Item2;
                        }
                        else
                        {
                            produccion.Add(producto.Item1, producto.Item2);
                        }
                    });
                });
            }

            return produccion;
        }

        //Devuelve la lista de clientes
        public List<Cliente> listaDeClientes()
        {
            return sel.obtenerClientes();
        }

        //Registra un nuevo cliente en la BD
        public void registrarCliente(Cliente cliente)
        {
            try
            {
                ins.registrarCliente(cliente);
            }
            catch (SQLiteException ex)
            {
                throw;
            }

        }

        //Registra un nuevo pedido en la BD
        public void registrarPedido(Pedido pedido)
        {
            try
            {
                ins.registrarPedido(pedido);
            }
            catch (SQLiteException ex)
            {
                throw;
            }
        }

        //Este metodo elimina un pedido
        public void eliminarPedido(Pedido pedido)
        {
            del.cancelarPedido(pedido);
        }

        //Estima el gasto en luz, en base a lo anotado en la tabla produccion
        public float gastoEnLuzRangoFechas(System.DateTime inicio, System.DateTime final)
        {
            float gasto = 0;
            while (inicio.CompareTo(final) <= 0)
            {
                //Utilizar produccion apuntada
                gasto += sel.gastoLuzFecha(inicio);
                inicio = inicio.AddDays(1);
            }
            return gasto;
        }

        //Estima el gasto en harina de la produccion en un rango de fechas
        public float gastoEnHarinaEstimadoRangoFechas(System.DateTime inicio, System.DateTime final)
        {
            float gasto = 0;

            while (inicio.CompareTo(final) <= 0)
            {
                //Utilizar produccion apuntada
                List<(int, int)> listaID_Prod_Cantidad = sel.produccionEnFecha(inicio);
                listaID_Prod_Cantidad.ForEach(tupla => {
                    gasto += listaProductos.Find(x => x.id_producto == tupla.Item1).kg_harina * tupla.Item2;
                });
                //En caso de no haber apuntado produccion, utilizar los pedidos
                if (listaID_Prod_Cantidad.Count == 0)
                {
                    foreach (KeyValuePair<Producto, int> kvp in aProducirEnFecha(inicio))
                    {
                        gasto += kvp.Key.kg_harina * kvp.Value;
                    }
                }
                inicio = inicio.AddDays(1);
            }
            return gasto;
        }

        //Dinero de ventas en rango de fechas
        public float dineroVentasRangoFechas(System.DateTime inicio, System.DateTime final)
        {
            float dinero = 0;
            while (inicio.CompareTo(final) <= 0)
            {
                List<(int, int)> ventas = sel.ventasIDProductosEnFecha(inicio);
                ventas.ForEach(tupla =>
                {
                    dinero += tupla.Item2 * listaProductos.Find(x => x.id_producto == tupla.Item1).precio;
                });
                inicio = inicio.AddDays(1);
            }
            return dinero;
        }


        //Aproximacion dinero pedidos en x rango de dias. No tiene en cuenta excepciones de pedidos habituales.
        public float dineroPedidosRangoFechas(System.DateTime inicio, System.DateTime final)
        {
            float total = 0;
            while (inicio.CompareTo(final) <= 0)
            {
                List<Pedido> pedidos = pedidosDeFecha(inicio);
                pedidos.ForEach(pedido => { total += pedido.total; });
                //En este caso añadimos los pedidos habituales
                if ((inicio - System.DateTime.Today).TotalDays > 1)
                {
                    List<PedidoHabitual> pedidosHabituales = listaPedidosHabituales();
                    pedidosHabituales.ForEach(pedido => { total += pedido.total; });
                }
                inicio = inicio.AddDays(1);
            }

            return total;
        }

        //Entregar pedido
        public void entregarPedido(Pedido pedido)
        {
            upd.actualizarEntregaPedido(pedido);
        }
        //Dinero que debe un cliente
        public float dineroQueDebeCliente(Cliente cliente)
        {
            List<Pedido> pedidosSinPagar = sel.pedidosUsuarioSinPagar(cliente.dni);
            float pufos = 0;
            pedidosSinPagar.ForEach(pedido =>
            {
                pedido.id_prod_cantidad.ForEach(producto =>
                {
                    pufos += listaProductos.Find(prod => prod.id_producto == producto.Item1).precio * producto.Item2;
                });
            });
            return pufos;
        }

        //Cuando un cliente paga, los pedidos entregados se establecen  como pagados y se registra el pago
        public void saldarDeudas(Cliente cliente)
        {
            ins.registrarPago(cliente, dineroQueDebeCliente(cliente));
            upd.pagarPedidosEntregadosACliente(cliente);
        }

        //Para vender productos en panaderia
        public void venderProductos(Venta venta)
        {
            ins.registrarVenta(venta);
        }

        //Registra una excepcion a un pedido habitual
        public void registrarExcepcion(int id_pedido_hab, System.DateTime fecha)
        {
            try
            {
                ins.registrarExcepcion(id_pedido_hab, fecha);
            }
            catch (SQLiteException ex)
            {
                throw;
            }
        }

        //Registra un nuevo pedido habitual
        public void registrarPedidoHabitual(PedidoHabitual pedido)
        {
            try
            {
                ins.registrarPedidoHabitual(pedido);
                //Para que figure en los pedidos de mañana
                anadirHabitualesDeManana();
            }
            catch (SQLiteException ex)
            {
                throw;
            }
        }

        //Elimina un pedido habitual
        public void eliminarPedidoHabitual(PedidoHabitual pedido)
        {
            del.eliminarPedidoHabitual(pedido);
        }

        //Este metodo registra la produccion del dia 
        public void registrarProduccion(List<(Producto, int)> productos, float horas_horno)
        {
            float gasto_electrico = consumo_horno / 1000 * horas_horno * precio_luz_kw_h;
            try
            {
                ins.registrarProduccion(productos, horas_horno, gasto_electrico);
            }
            catch (SQLiteException ex)
            {
                throw;
            }
        }
    }


}
