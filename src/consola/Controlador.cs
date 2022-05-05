using Sistema;
using modelos;
namespace consola;
public class Controlador
{


    GestorPanaderia gestor;

    public Vista vista = new Vista();
    public Dictionary<string, Action> casosDeUso;
    public Controlador(GestorPanaderia gestor)
    {
        this.gestor = gestor;

        casosDeUso = new Dictionary<string, Action>(){
            {"Pedidos",controladorPedidos},
            {"Clientes", controladorClientes},
            {"Finanzas",controladorFinanzas},
            {"Producción",controladorProduccion},
            {"Venta en panaderia",venderProductos},

        };
    }

    public void Run()
    {   
        vista.LimpiarPantalla();
        while (true)
        {
            vista.Mostrar("Para ayudar con la estimación de gastos, al producir panes introduzca los datos en el apartado 'Producción'",ConsoleColor.Blue);
            try
            {
                string eleccion = vista.TryObtenerElementoDeLista("Operaciones disponibles", casosDeUso.Keys.ToList(), "Elija una operacion");
                casosDeUso[eleccion].Invoke();
                vista.MostrarYReturn("Pulsa <Return> para continuar");
                vista.LimpiarPantalla();
            }
            catch { return; }
        }
    }

    public void controladorPedidos(){
        ControladorPedidos controladorPedidos = new ControladorPedidos(gestor,vista);
        controladorPedidos.Run();
    }

    public void controladorProduccion(){
        ControladorProduccion controladorProduccion = new ControladorProduccion(gestor,vista);
        controladorProduccion.Run();
    }
    public void controladorClientes(){
        ControladorClientes controladorClientes = new ControladorClientes(gestor,vista);
        controladorClientes.Run();
    }

    public void controladorFinanzas(){
        ControladorFinanzas controladorFinanzas = new ControladorFinanzas(gestor,vista);
        controladorFinanzas.Run();
    }

    public void venderProductos(){
       List<(Producto,int)> _productos = new();
       try{
           while(true){
               Producto prod = vista.TryObtenerElementoDeLista<Producto>("Lista de productos:",gestor.listaProductos,"Elija producto");
               int cantidad = vista.TryObtenerValorEnRangoInt(1,999,"Elija la cantidad");
               _productos.Add((prod,cantidad));
               vista.LimpiarPantalla();
               vista.MostrarDiccionario<Producto,int>("Lista de la compra",_productos.ToDictionary(x => x.Item1, x => x.Item2));
               if (!vista.Confirmar("Desea añadir más productos?")){
                   break;
               } 
           } 
           if(_productos.Count>0){
               gestor.venderProductos(new Venta{productos=_productos});
               vista.Mostrar("Transaccion realizada con exito",ConsoleColor.Green);
           }
       }catch{
           vista.Mostrar("No puede añadir el mismo producto dos veces",ConsoleColor.Red);
       }
       
    }  
}