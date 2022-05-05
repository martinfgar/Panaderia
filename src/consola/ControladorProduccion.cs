using System;
using Sistema;
using modelos;
using System.Data.SQLite;
namespace consola;
public class ControladorProduccion{

     
    GestorPanaderia gestor;
    public Vista vista;
    public Dictionary<string, Action> casosDeUso;
    public ControladorProduccion(GestorPanaderia gestor, Vista vista){
        this.gestor=gestor;
        this.vista = vista;
        casosDeUso = new Dictionary<string, Action>(){
            {"Ver Panes a producir hoy",mostrarPanesAProducir},
            {"Especificar producción de hoy",especificarProduccion}
        };
    }
    public void Run()
    {   
        vista.LimpiarPantalla();
        while (true)
        {
            try
            {
                vista.Mostrar("Puede ir atras escribiendo 'fin'", ConsoleColor.Cyan);
                string eleccion = vista.TryObtenerElementoDeLista("Operaciones disponibles", casosDeUso.Keys.ToList(), "Elija una operacion");
                casosDeUso[eleccion].Invoke();
                vista.MostrarYReturn("Pulsa <Return> para continuar");
                vista.LimpiarPantalla();
            }
            catch { return; }
        }
    }

    public void mostrarPanesAProducir(){
        vista.MostrarDiccionario<Producto,int>("Productos : Cantidad",gestor.aProducirEnFecha(DateTime.Today));
    }
    public void especificarProduccion(){
        try{
            List<(Producto, int)> _productos = new();
            while (true)
            {
                Producto prod = vista.TryObtenerElementoDeLista<Producto>("Lista de productos:", gestor.listaProductos, "Elija producto");
                int cantidad = vista.TryObtenerValorEnRangoInt(1, 999, "Elija la cantidad");
                _productos.Add((prod, cantidad));
                vista.LimpiarPantalla();
                vista.MostrarDiccionario<Producto, int>("Produccion:", _productos.ToDictionary(x => x.Item1, x => x.Item2));
                if (!vista.Confirmar("Desea añadir más productos?"))
                {
                    break;
                }
            }
            float horas_horno = vista.TryObtenerDatoDeTipo<float>("Introduzca las horas de horno");
            if (_productos.Count>0){
                gestor.registrarProduccion(_productos,horas_horno);
                vista.Mostrar("Producción registrada con exito",ConsoleColor.Green);
            }
            
        }catch(SQLiteException ex){
            vista.Mostrar("Ya has especificado la producción de hoy.",ConsoleColor.Red);
        }catch{
            vista.Mostrar("No puede añadir el mismo producto dos veces", ConsoleColor.Red);
        }
    }
}