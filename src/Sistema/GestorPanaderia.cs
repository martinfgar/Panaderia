using Repo;
using System.Linq;
using modelos;
namespace Sistema;
public class GestorPanaderia
{
    static ConnectDB con = new ConnectDB();
    Selects sel = new Selects(con.crearConexion());
    Inserts ins = new Inserts(con.crearConexion());
    
    Updates upd = new Updates(con.crearConexion());
    public List<Producto> listaProductos{get;set;}
    
    public GestorPanaderia(){
        anadirHabitualesDeHoy();
        listaProductos = sel.obtenerProductos();
    }

    //Este metodo se ejecuta al iniciar el programa, añade los pedidos diarios cuando no tienen excepcion.
    private void anadirHabitualesDeHoy(){
        List<int> excepciones = sel.id_pedidos__habituales_excepcionesHoy();
        List<PedidoHabitual> pedidosASumar = sel.pedidosHabituales().FindAll(pedido => !excepciones.Contains(pedido.id_pedido_habitual));
        pedidosASumar.ForEach(pedido =>{
            ins.registrarPedido(
                new Pedido{
                    productos=pedido.productos,
                    dni = pedido.dni,
                    fecha = DateTime.Today,
                    entregado = false,
                    pagado=false
                }
            );
        });
    }

    //Devuelve la lista de los pedidos marcados como habituales
    public List<PedidoHabitual> listaPedidosHabituales(){
        return sel.pedidosHabituales();
    }
    //Devuelve la lista de pedidos, y antes de ello añade todos los datos de los productos en el pedido
    public List<Pedido> pedidosDeHoy(){
        List<Pedido> listaPedidosHoy = sel.obtenerPedidosHoy();
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

    //Lista de dnis de clientes 
    public List<string> dnisClientes(){
        return listaDeClientes().Select(o => o.dni).ToList();
    }

     //Pedidos de hoy sin entregar
    public List<Pedido> pedidosPorEntregarHoy(){
        return pedidosDeHoy().FindAll(pedido => !pedido.entregado);   
    }
    //Devuelve un diccionario con los productos a producir hoy y la cantidad
    public Dictionary<Producto,int> aProducirHoy(){
        Dictionary<Producto,int> produccion = new Dictionary<Producto, int>();
        pedidosDeHoy().ForEach(pedido =>{
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
        ins.registrarCliente(cliente);
    }
    
    //Registra un nuevo pedido en la BD
    public void registrarPedido(Pedido pedido){
        ins.registrarPedido(pedido);
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
        ins.registrarExcepcion(id_pedido_hab,fecha);
    }
}
