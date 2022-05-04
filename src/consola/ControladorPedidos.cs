using Sistema;
using modelos;
using System.Globalization;
namespace consola;
public class ControladorPedidos
{
    GestorPanaderia gestor;

    public Vista vista = new Vista();
    public Dictionary<string, Action> casosDeUso;
    public ControladorPedidos(GestorPanaderia gestor)
    {
        this.gestor = gestor;

        casosDeUso = new Dictionary<string, Action>(){
            {"Entregar Pedido",entregarPedido},
            {"Crear nuevo pedido",crearPedido},
            {"Cancelar pedido habitual para dia concreto (mínimo 2 dias de antelación)", crearExcepcion},
            {"Crear pedido habitual",crearPedidoHabitual},
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
                string eleccion = vista.TryObtenerElementoDeLista("Operaciones con pedidos", casosDeUso.Keys.ToList(), "Elija una operacion");
                casosDeUso[eleccion].Invoke();
                vista.MostrarYReturn("Pulsa <Return> para continuar");
                vista.LimpiarPantalla();
            }
            catch { return; }
        }
    }

    public void entregarPedido()
    {
        List<Pedido> pedidos = gestor.pedidosPorEntregarHoy();
        if (pedidos.Count > 0)
        {
            Pedido pedido = vista.TryObtenerElementoDeLista<Pedido>("Lista de pedidos por entregar", pedidos, "Elija el pedido");
            gestor.entregarPedido(pedido);
            vista.Mostrar("Pedido entregado", ConsoleColor.Green);
        }
        else
        {
            vista.Mostrar("No hay pedidos por entregar", ConsoleColor.Green);
        }

    }

    //Minimo dos dias de antelacion para cancelar
    public void crearExcepcion()
    {
        try
        {   vista.Mostrar("Puede cancelar el proceso escribiendo 'fin'",ConsoleColor.Yellow);
            PedidoHabitual pedidoHab = vista.TryObtenerElementoDeLista<PedidoHabitual>("Lista de pedidos habituales", gestor.listaPedidosHabituales(), "Elija el pedido");
            DateTime fechaMinima = DateTime.Today.AddDays(2);
            DateTime fecha;
            while (true)
            {
                fecha = vista.TryObtenerFecha("Elija fecha");
                if (fecha.CompareTo(fechaMinima) >= 0)
                {
                    break;
                }
                vista.Mostrar($"No se pueden cancelar pedidos antes de {fechaMinima.ToString("d", CultureInfo.GetCultureInfo("es-ES"))}");
            }
            gestor.registrarExcepcion(pedidoHab.id_pedido_habitual,fecha);
            vista.Mostrar($"Pedido {pedidoHab} cancelado con exito para el {fecha.ToString("d",CultureInfo.GetCultureInfo("es-ES"))}",ConsoleColor.Green);
        }
        catch
        {
            //En caso de que el usuario quiera cancelar
        }

    }

    public void crearPedidoHabitual() { }

    public void crearPedido(){

    }
    public void volver()
    {
        throw new Exception("Menu principal");
    }
}