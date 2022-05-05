using Sistema;
using modelos;
using System.Data.SQLite;
namespace consola;
public class ControladorFinanzas{
    GestorPanaderia gestor;

    public Vista vista;
    public Dictionary<string, Action> casosDeUso;
    public ControladorFinanzas(GestorPanaderia gestor, Vista vista)
    {
        this.gestor = gestor;
        this.vista = vista;

        casosDeUso = new Dictionary<string, Action>(){
            {"Ingresos ventas en un rango de fecha",dineroVentas},
            {"Ingresos estimado de pedidos en un rango de fecha",dineroPedidoFecha},
            {"Gasto en harina en rango de fechas",gastoHarinaFechas},
            {"Gasto en luz en rango de fechas",gastoLuzFechas},
            {"Resumen rango de fechas",resumenRangoFechas}
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
                string eleccion = vista.TryObtenerElementoDeLista("Consultas financieras", casosDeUso.Keys.ToList(), "Elija una operacion");
                casosDeUso[eleccion].Invoke();
                vista.MostrarYReturn("Pulsa <Return> para continuar");
                vista.LimpiarPantalla();
            }
            catch { return; }
        }
    }
    public void dineroVentas(){
        DateTime inicio = vista.TryObtenerFecha("Fecha 1:");
        DateTime fin = vista.TryObtenerFecha("Fecha 2:");
        vista.Mostrar($"{gestor.dineroVentasRangoFechas(inicio,fin)}\u20AC");
    }

    public void dineroPedidoFecha(){
        DateTime inicio = vista.TryObtenerFecha("Fecha 1:");
        DateTime final = vista.TryObtenerFecha("Fecha 2:");
        vista.Mostrar($"{gestor.dineroPedidosRangoFechas(inicio,final)}\u20AC");
    }

    public void gastoHarinaFechas(){
        DateTime inicio = vista.TryObtenerFecha("Fecha 1:");
        DateTime final = vista.TryObtenerFecha("Fecha 2:");
        vista.Mostrar($"{gestor.gastoEnHarinaEstimadoRangoFechas(inicio,final)}\u20AC");
    }

    public void gastoLuzFechas(){
        DateTime inicio = vista.TryObtenerFecha("Fecha 1:");
        DateTime final = vista.TryObtenerFecha("Fecha 2:");
        vista.Mostrar($"{gestor.gastoEnLuzRangoFechas(inicio,final)}\u20AC");
    }

    public void resumenRangoFechas(){
        DateTime inicio = vista.TryObtenerFecha("Fecha 1:");
        DateTime final = vista.TryObtenerFecha("Fecha 2:");
        float dinero1 = gestor.dineroPedidosRangoFechas(inicio,final);
        vista.Mostrar($"Ingresos pedidos: {dinero1}\u20AC",ConsoleColor.Green);
        float dinero2  = gestor.dineroVentasRangoFechas(inicio,final);
        vista.Mostrar($"Ingreso por ventas: {dinero2}\u20AC",ConsoleColor.Green);
        float dinero3 = gestor.gastoEnHarinaEstimadoRangoFechas(inicio,final);
        vista.Mostrar($"Gasto en harina: {dinero3}\u20AC",ConsoleColor.Red);
        float dinero4 = gestor.gastoEnLuzRangoFechas(inicio,final);
        vista.Mostrar($"Gasto en luz horno: {dinero4}\u20AC",ConsoleColor.Red);
        float total = dinero1+dinero2-dinero3-dinero4;
        vista.Mostrar($"Total: {total}€",ConsoleColor.DarkYellow);
    }
}