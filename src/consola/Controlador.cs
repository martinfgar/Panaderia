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
            {"Venta en panaderia",controladorVentas}
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

    public void controladorPedidos(){
        ControladorPedidos controladorPedidos = new ControladorPedidos(gestor);
        controladorPedidos.Run();
    }

    public void controladorProduccion(){}
    public void controladorClientes(){
        ControladorClientes controladorClientes = new ControladorClientes(gestor);
        controladorClientes.Run();
    }

    public void controladorFinanzas(){

    }

    public void controladorVentas(){
        ControladorVentas controladorVentas = new ControladorVentas(gestor);
        controladorVentas.Run();
    }

    
}