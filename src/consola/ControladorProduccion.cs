using System;
using Sistema;
using modelos;
namespace consola;
public class ControladorProduccion{

     
    GestorPanaderia gestor;
    public Vista vista = new Vista();
    public Dictionary<string, Action> casosDeUso;
    public ControladorProduccion(GestorPanaderia gestor){
        this.gestor=gestor;
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
                string eleccion = vista.TryObtenerElementoDeLista("Operaciones disponibles", casosDeUso.Keys.ToList(), "Elija una operacion");
                casosDeUso[eleccion].Invoke();
                vista.MostrarYReturn("Pulsa <Return> para continuar");
                vista.LimpiarPantalla();
            }
            catch { return; }
        }
    }

    public void mostrarPanesAProducir(){
        vista.MostrarDiccionario<Producto,int>("Productos : Cantidad",gestor.aProducirHoy());
    }
    public void especificarProduccion(){
        
    }
}