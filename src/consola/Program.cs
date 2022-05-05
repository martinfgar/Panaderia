// See https://aka.ms/new-console-template for more information
using consola;
using Sistema;
using modelos;
using System.Globalization;
/*
ConnectDB con = new ConnectDB();


Inserts ins = new Inserts(con.crearConexion());

Pedido ped = new Pedido{
    dni = "12345678A",
    fecha = DateTime.Parse("4/5/2022", CultureInfo.GetCultureInfo("es-ES")),
    entregado=false,
    pagado=false,
    productos = new List<(Producto, int)>{
        (new Producto{
            id_producto=1
        },10)
    }
};
ins.registrarPedido(ped);
*/
GestorPanaderia gestor = new GestorPanaderia();
Controlador controlador = new Controlador(gestor);
controlador.Run();
/*
vista.MostrarListaEnumerada<Pedido>("Lista de pedidos para hoy:",gestor.pedidosDeHoy());
vista.MostrarDiccionario<Producto,int>("Produccion de pedidos para hoy:",gestor.aProducirHoy());
vista.MostrarListaEnumerada<Cliente>("Lista de clientes:",gestor.listaDeClientes());
Console.WriteLine($"Total en pedidos: {gestor.dineroHoyPedidos()}€");

*/
//Entregar pedido
/*
Pedido ped = vista.TryObtenerElementoDeLista<Pedido>("Pedidos",gestor.pedidosPorEntregarHoy(),"Pedido entregado");
gestor.entregarPedido(ped);
*/


