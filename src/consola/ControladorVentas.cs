using Sistema;
using modelos;
namespace consola;
public class ControladorVentas{
    GestorPanaderia gestor;

    public Vista vista = new Vista();
    public Dictionary<string, Action> casosDeUso;
    public ControladorVentas(GestorPanaderia gestor)
    {
        this.gestor = gestor;

        casosDeUso = new Dictionary<string, Action>(){
            {"Vender Productos",venderProductos},
            {"Volver atras",volver}
        };
    }

    public void Run()
    {
        vista.LimpiarPantalla();
        while (true)
        {
            try
            {
                string eleccion = vista.TryObtenerElementoDeLista("Operaciones tienda", casosDeUso.Keys.ToList(), "Elija una operacion");
                casosDeUso[eleccion].Invoke();
                vista.MostrarYReturn("Pulsa <Return> para continuar");
                vista.LimpiarPantalla();
            }
            catch { return; }
        }
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

  
    public void volver(){
        throw new Exception("Menu principal");
    }
}