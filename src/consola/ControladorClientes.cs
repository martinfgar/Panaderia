using Sistema;
using modelos;
using System.Data.SQLite;
namespace consola;
public class ControladorClientes{
    GestorPanaderia gestor;

    public Vista vista = new Vista();
    public Dictionary<string, Action> casosDeUso;
    public ControladorClientes(GestorPanaderia gestor)
    {
        this.gestor = gestor;

        casosDeUso = new Dictionary<string, Action>(){
            {"Registrar Nuevo Cliente",registrarCliente},
            {"Ver deudas de clientes", verDeudasCliente},
            {"Saldar deudas de cliente",saldarDeudasCliente},
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
                string eleccion = vista.TryObtenerElementoDeLista("Operaciones con clientes", casosDeUso.Keys.ToList(), "Elija una operacion");
                casosDeUso[eleccion].Invoke();
                vista.MostrarYReturn("Pulsa <Return> para continuar");
                vista.LimpiarPantalla();
            }
            catch { return; }
        }
    }
    public void registrarCliente(){
        try{
            string _dni = vista.TryObtenerDatoDeTipo<string>("Introduzca el DNI");
            string _nombre = vista.TryObtenerDatoDeTipo<string>("Introduzca el nombre");
            string _direccion = vista.TryObtenerDatoDeTipo<string>("Introduzca la direccion");
            Cliente cliente = new Cliente{
                dni=_dni,
                nombre=_nombre,
                direccion=_direccion
            };
            gestor.registrarCliente(cliente);
            vista.Mostrar("Cliente registrado correctamente",ConsoleColor.Green);
        } catch(SQLiteException ex){
            vista.Mostrar("Ya hay un cliente con ese DNI",ConsoleColor.Red);
        }
        
        
    }

    public void verDeudasCliente(){
        Cliente cliente = vista.TryObtenerElementoDeLista<Cliente>("Lista de clientes",gestor.listaDeClientes(),"Elija el cliente");
        float deuda =gestor.dineroQueDebeCliente(cliente);
        if (deuda>0){
            vista.Mostrar(cliente);
            vista.Mostrar($"Deuda: {deuda}€",ConsoleColor.Red);
        }else{
            vista.Mostrar("El cliente no tiene deudas",ConsoleColor.Green);
        }
    }

    public void saldarDeudasCliente(){
        Cliente cliente = vista.TryObtenerElementoDeLista<Cliente>("Lista de clientes",gestor.listaDeClientes(),"Elija el cliente");
        float deuda =gestor.dineroQueDebeCliente(cliente);
        if (deuda>0){
            vista.Mostrar(cliente);
            vista.Mostrar($"Deuda: {deuda}€",ConsoleColor.Red);
            if (vista.Confirmar("Confirmar pago?")){
                gestor.saldarDeudas(cliente);
                vista.Mostrar("Deudas del cliente canceladas.",ConsoleColor.Green);
            }
        }else{
            vista.Mostrar("El cliente no tiene deudas",ConsoleColor.Green);
        }
    }

    public void volver(){
        throw new Exception("Menu principal");
    }
}