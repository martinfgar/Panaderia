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
Vista vista = new Vista();
GestorPanaderia gestor = new GestorPanaderia();
vista.MostrarListaEnumerada<Pedido>("Lista de pedidos para hoy:",gestor.pedidosDeHoy());
vista.MostrarDiccionario<Producto,int>("Produccion de pedidos para hoy:",gestor.aProducirHoy());
vista.MostrarListaEnumerada<Cliente>("Lista de clientes:",gestor.listaDeClientes());
Console.WriteLine($"Total en pedidos: {gestor.dineroHoyPedidos()}€");
//Entregar pedido
Pedido ped = vista.TryObtenerElementoDeLista<Pedido>("Pedidos",gestor.pedidosPorEntregarHoy(),"Pedido entregado");
gestor.entregarPedido(ped);

//Pago de cliente
Cliente cli = vista.TryObtenerElementoDeLista<Cliente>("Clientes",gestor.listaDeClientes(),"Elija un cliente");
if (gestor.dineroQueDebeCliente(cli)==0){
    vista.Mostrar("Este cliente no debe dinero");
}else{
    Console.WriteLine($"Deudas de {cli.ToString()}\nTotal: {gestor.dineroQueDebeCliente(cli)}€");
    if (vista.Confirmar("Desea confirmar el pago?")){
        gestor.saldarDeudas(cli);
    }
}

