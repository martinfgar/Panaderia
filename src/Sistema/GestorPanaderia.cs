using Repo;
using System.Linq;
using modelos;
using System.Data.SQLite;
namespace Sistema;
public class GestorPanaderia
{
    static ConnectDB con = new ConnectDB();
    Selects sel = new Selects(con.crearConexion());
    Inserts ins = new Inserts(con.crearConexion());
    
    Updates upd = new Updates(con.crearConexion());
    Deletes del = new Deletes(con.crearConexion());
    public List<Producto> listaProductos{get;set;}
    
    public GestorPanaderia(){
        listaProductos = sel.obtenerProductos();
        anadirHabitualesDeManana();
        
    }

    //Este metodo se ejecuta al iniciar el programa, añade los pedidos habituales (que no tengan excepcion para hoy) a pedidos
    private void anadirHabitualesDeManana(){
        List<int> excepciones = sel.id_pedidos_excepcionesFecha(DateTime.Today.AddDays(1));
        List<PedidoHabitual> pedidosASumar = listaPedidosHabituales().FindAll(pedido => !excepciones.Contains(pedido.id_pedido_habitual));
        pedidosASumar.ForEach(pedido =>{
            try{
                
                ins.registrarPedido(
                new Pedido{
                    productos=pedido.productos,
                    dni = pedido.dni,
                    fecha = DateTime.Today.AddDays(1),
                    entregado = false,
                    pagado=false
                }
            );
            }catch{
                //Puede ser que el metodo se haya ejecutado de antes y ya esten introducidos (SQLiteException)
            }
        });
    }

    //Devuelve la lista de los pedidos marcados como habituales y antes de ello añade todos los datos de los productos en el pedido
    public List<PedidoHabitual> listaPedidosHabituales(){
        List<PedidoHabitual> listaPedidosHab = sel.pedidosHabituales();
        List<Cliente> clientes = listaDeClientes();
        listaPedidosHab.ForEach(pedido =>{
            pedido.cliente = clientes.Find(client => pedido.dni == client.dni);
            pedido.productos = new();
            pedido.id_prod_cantidad.ForEach(producto =>{
                pedido.productos.Add((listaProductos.Find(prod => prod.id_producto == producto.Item1),producto.Item2));
            });
        });
        return listaPedidosHab;
    }
    //Devuelve la lista de pedidos, y antes de ello añade todos los datos de los productos en el pedido
    public List<Pedido> pedidosDeFecha(DateTime fecha){
        List<Pedido> listaPedidosHoy = sel.obtenerPedidosFecha(fecha);
        List<Cliente> clientes = listaDeClientes();
        listaPedidosHoy.ForEach(pedido =>{
            pedido.cliente = clientes.Find(client => pedido.dni == client.dni);
            pedido.productos = new();
            pedido.id_prod_cantidad.ForEach(producto =>{
                pedido.productos.Add((listaProductos.Find(prod => prod.id_producto == producto.Item1),producto.Item2));
            });
        });
        return listaPedidosHoy;
    }

    
    //Pedidos de hoy sin entregar
    public List<Pedido> pedidosPorEntregarHoy(){
        return pedidosDeFecha(DateTime.Today).FindAll(pedido => !pedido.entregado);   
    }
    //Devuelve un diccionario con los productos a producir hoy y la cantidad
    public Dictionary<Producto,int> aProducirHoy(){
        Dictionary<Producto,int> produccion = new Dictionary<Producto, int>();
        pedidosDeFecha(DateTime.Today).ForEach(pedido =>{
            pedido.productos.ForEach(producto =>{
                if(produccion.ContainsKey(producto.Item1)){
                    produccion[producto.Item1]+=producto.Item2;
                }else{
                    produccion.Add(producto.Item1,producto.Item2);
                }
            });
        });
        return produccion;
    }

    //Devuelve la lista de clientes
    public List<Cliente> listaDeClientes(){
        return sel.obtenerClientes();
    }

    //Registra un nuevo cliente en la BD
    public void registrarCliente(Cliente cliente){
        try{
            ins.registrarCliente(cliente);
        }catch(SQLiteException ex){
            throw;
        }
        
    }
    
    //Registra un nuevo pedido en la BD
    public void registrarPedido(Pedido pedido){
        try{
            ins.registrarPedido(pedido);
        } catch(SQLiteException ex){
            throw;
        } 
    }

    //Este metodo elimina un pedido
    public void eliminarPedido(Pedido pedido){
        del.cancelarPedido(pedido);
    }

    //Dinero de ventas en rango de fechas
    public float dineroVentasRangoFechas(DateTime inicio, DateTime final){
        float dinero =0;
        while(inicio.CompareTo(final)<=0){
            List<(int,int)> ventas = sel.ventasIDProductosEnFecha(inicio);
            ventas.ForEach(tupla=>{
                dinero+=tupla.Item2*listaProductos.Find(x=>x.id_producto==tupla.Item1).precio;
            });
            inicio = inicio.AddDays(1);
        }
        return dinero;
    }

    //Dinero obtenido hoy gracias a pedidos
    public float dineroHoyPedidos(){
        float ventas =0;
        foreach (KeyValuePair<Producto, int> kvp in aProducirHoy()){
            ventas+=kvp.Key.precio*kvp.Value;
        }
        return ventas;
    }

    //Entregar pedido
    public void entregarPedido(Pedido pedido){
        upd.actualizarEntregaPedido(pedido);
    }
    //Dinero que debe un cliente
    public float dineroQueDebeCliente(Cliente cliente){
        List<Pedido> pedidosSinPagar = sel.pedidosUsuarioSinPagar(cliente.dni);
        float pufos=0;
        pedidosSinPagar.ForEach(pedido =>{
            pedido.id_prod_cantidad.ForEach(producto =>{
                pufos+=listaProductos.Find(prod => prod.id_producto == producto.Item1).precio*producto.Item2;
            });
        });
        return pufos;
    }

    //Cuando un cliente paga, los pedidos entregados se establecen  como pagados y se registra el pago
    public void saldarDeudas(Cliente cliente){
        ins.registrarPago(cliente,dineroQueDebeCliente(cliente));
        upd.pagarPedidosEntregadosACliente(cliente);
    }

    //Para vender productos en panaderia
    public void venderProductos(Venta venta){
        ins.registrarVenta(venta);
    }

    //Registra una excepcion a un pedido habitual
    public void registrarExcepcion(int id_pedido_hab, DateTime fecha){
        try{
            ins.registrarExcepcion(id_pedido_hab,fecha);
        } catch(SQLiteException ex){
            throw;
        } 
    }

    //Registra un nuevo pedido habitual
    public void registrarPedidoHabitual(PedidoHabitual pedido){
        try{
            ins.registrarPedidoHabitual(pedido);
            //Para que figure en los pedidos de mañana
            anadirHabitualesDeManana();
        }catch(SQLiteException ex){
            throw;
        }
    }

    //Elimina un pedido habitual
    public void eliminarPedidoHabitual(PedidoHabitual pedido){
        del.eliminarPedidoHabitual(pedido);
    }

    //Este metodo registra la produccion del dia 
    public void registrarProduccion(List<(Producto,int)> productos, float horas_horno){
        try{
            ins.registrarProduccion(productos,horas_horno);
        }catch(SQLiteException ex){
            throw;
        }
    }
}
