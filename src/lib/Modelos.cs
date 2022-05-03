namespace modelos;
public class Cliente
{
    public string dni{get;set;}
    public string nombre{get;set;}
    public string direccion{get;set;}
}
public class Producto{
    public int id_producto{get;set;}
    public string nombre{get;set;}
    public float precio{get;set;}
    public float kg_harina{get;set;}
}
public class Pedido{
    public int id_pedido{get;set;}
    public DateTime fecha{get;set;}
    public bool entregado{get;set;}
    public bool pagado{get;set;}
    public string dni{get;set;}
    public Cliente cliente{get;set;}
     public List<(Producto, int)> productos{get;set;}
}
public class PedidoHabitual{
    public int id_pedido_habitual{get;set;}
    public string dni{get;set;}
    public Cliente cliente{get;set;}
    public List<(Producto, int)> productos{get;set;}
}
public class Excepcion{
    public int id_pedido_habitual{get;set;}
    public DateTime fecha{get;set;}
    public PedidoHabitual pedido{get;set;}
}
public class Pago{
    public string dni{get;set;}
    public DateTime fecha{get;set;}
    
    public float cantidad{get;set;}
    public Cliente cliente{get;set;}
}
public class Producido{
    public DateTime fecha{get;set;}
    public float horas_horno{get;set;}
    public List<(Producto, int)> productos{get;set;}
}
public class Venta{
    public int id_venta{get;set;}
    public DateTime fecha{get;set;}
    public List<(Producto, int)> productos{get;set;}
}