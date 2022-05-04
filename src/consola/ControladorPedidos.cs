using Sistema;
using modelos;
using System.Globalization;
using System.Data.SQLite;
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
            {"Cancelar pedido (mínimo 2 días de antelación)",cancelarPedido},
            {"Ver pedidos para una fecha especifica",verPedidosFecha},
            {"Crear pedido habitual",crearPedidoHabitual},
            {"Eliminar pedido habitual",eliminarPedidoHabitual},
            {"Cancelar pedido habitual para dia concreto (mínimo 2 dias de antelación)", crearExcepcion}
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
        {
            vista.Mostrar("Puede cancelar el proceso escribiendo 'fin'", ConsoleColor.Cyan);
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
            gestor.registrarExcepcion(pedidoHab.id_pedido_habitual, fecha);
            vista.Mostrar($"Pedido {pedidoHab} cancelado con exito para el {fecha.ToString("d", CultureInfo.GetCultureInfo("es-ES"))}", ConsoleColor.Green);
        }
        catch (SQLiteException ex)
        {
            vista.Mostrar("El cliente ya tiene creada una excepcion para ese dia", ConsoleColor.Red);
        }

    }

    public void crearPedidoHabitual()
    {
        vista.Mostrar("Puede cancelar el proceso escribiendo 'fin'", ConsoleColor.Cyan);
        try
        {
            Cliente cliente = vista.TryObtenerElementoDeLista<Cliente>("Lista de clientes", gestor.listaDeClientes(), "Elija el cliente que realiza el pedido");
            List<(Producto, int)> _productos = new();
            while (true)
            {
                Producto prod = vista.TryObtenerElementoDeLista<Producto>("Lista de productos:", gestor.listaProductos, "Elija producto");
                int cantidad = vista.TryObtenerValorEnRangoInt(1, 999, "Elija la cantidad");
                _productos.Add((prod, cantidad));
                vista.LimpiarPantalla();
                vista.MostrarDiccionario<Producto, int>("Lista de la compra", _productos.ToDictionary(x => x.Item1, x => x.Item2));
                if (!vista.Confirmar("Desea añadir más productos?"))
                {
                    break;
                }
            }
            if (_productos.Count > 0)
            {
                gestor.registrarPedidoHabitual(new PedidoHabitual
                {
                    dni = cliente.dni,
                    productos = _productos
                });
                vista.Mostrar("Pedido habitual registrado con exito", ConsoleColor.Green);
            }

        }
        catch (SQLiteException ex)
        {
            vista.Mostrar("El cliente ya tiene un pedido habitual registrado. Cancele el que tiene antes de realizar otro.", ConsoleColor.Red);
        }
        catch
        {
            vista.Mostrar("No puede añadir el mismo producto dos veces", ConsoleColor.Red);
        }
    }

    public void crearPedido()
    {
        vista.Mostrar("Puede cancelar el proceso escribiendo 'fin'", ConsoleColor.Cyan);
        try
        {
            Cliente cliente = vista.TryObtenerElementoDeLista<Cliente>("Lista de clientes", gestor.listaDeClientes(), "Elija el cliente que realiza el pedido");
            List<(Producto, int)> _productos = new();
            while (true)
            {
                Producto prod = vista.TryObtenerElementoDeLista<Producto>("Lista de productos:", gestor.listaProductos, "Elija producto");
                int cantidad = vista.TryObtenerValorEnRangoInt(1, 999, "Elija la cantidad");
                _productos.Add((prod, cantidad));
                vista.LimpiarPantalla();
                vista.MostrarDiccionario<Producto, int>("Lista de la compra", _productos.ToDictionary(x => x.Item1, x => x.Item2));
                if (!vista.Confirmar("Desea añadir más productos?"))
                {
                    break;
                }
            }
            DateTime fechaMinima = DateTime.Today.AddDays(2);
            DateTime _fecha;
            while (true)
            {
                _fecha = vista.TryObtenerFecha("Elija fecha");
                if (_fecha.CompareTo(fechaMinima) >= 0)
                {
                    break;
                }
                vista.Mostrar($"No se pueden realizar pedidos para antes de {fechaMinima.ToString("d", CultureInfo.GetCultureInfo("es-ES"))}");
            }
            if (_productos.Count > 0)
            {
                gestor.registrarPedido(new Pedido
                {
                    dni = cliente.dni,
                    productos = _productos,
                    fecha = _fecha,
                    pagado = false,
                    entregado = false
                });
                vista.Mostrar("Pedido realizado con exito", ConsoleColor.Green);
            }

        }
        catch (SQLiteException ex)
        {
            vista.Mostrar("El cliente ya tiene un pedido para ese día, cancelelo antes de realizar otro", ConsoleColor.Red);
        }
        catch
        {
            vista.Mostrar("No puede añadir el mismo producto dos veces", ConsoleColor.Red);
        }
    }

    public void verPedidosFecha()
    {
        DateTime fecha = vista.TryObtenerFecha("Introduce la fecha");
        vista.MostrarListaEnumerada<Pedido>($"Lista de pedidos para el {fecha.ToString("d", CultureInfo.GetCultureInfo("es-ES"))}", gestor.pedidosDeFecha(fecha));
    }


    public void eliminarPedidoHabitual()
    {
        PedidoHabitual pedido = vista.TryObtenerElementoDeLista<PedidoHabitual>("Lista de pedidos habituales", gestor.listaPedidosHabituales(), "Introduzca el pedido habitual a eliminar");
        gestor.eliminarPedidoHabitual(pedido);
        vista.Mostrar("Pedido habitual eliminado con exito", ConsoleColor.Green);
    }
    public void cancelarPedido()
    {
        vista.Mostrar("Puede cancelar el proceso escribiendo 'fin'", ConsoleColor.Cyan);
        DateTime _fecha;
        DateTime fechaMinima = DateTime.Today.AddDays(2);
        while (true)
        {
            _fecha = vista.TryObtenerFecha("Elija fecha");
            if (_fecha.CompareTo(fechaMinima) >= 0)
            {
                break;
            }
            vista.Mostrar($"No se pueden cancelar pedidos antes de {fechaMinima.ToString("d", CultureInfo.GetCultureInfo("es-ES"))}");
        }
        Pedido ped = vista.TryObtenerElementoDeLista<Pedido>($"Lista de pedidos para el {_fecha.ToString("d", CultureInfo.GetCultureInfo("es-ES"))}", gestor.pedidosDeFecha(_fecha), "Elija el pedido a cancelar");
        gestor.eliminarPedido(ped);
        vista.Mostrar("Pedido cancelado", ConsoleColor.Green);
    }

}