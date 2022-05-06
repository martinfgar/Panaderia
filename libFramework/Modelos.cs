using System.Collections.Generic;

namespace modelos {
    public class Cliente
    {
        public string dni { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public override string ToString()
        {

            return $"DNI: {dni}, Nombre: {nombre}, Direccion: {direccion}";
        }
    }
    public class Producto
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public float kg_harina { get; set; }
        public override string ToString()
        {
            return $"Producto: {nombre}, Precio: {precio}€, Harina/ud: {kg_harina}kg";
        }
    }
    public class Pedido
    {
        public int id_pedido { get; set; }
        public System.DateTime fecha { get; set; }
        public bool entregado { get; set; }
        public bool pagado { get; set; }
        public string dni { get; set; }
        public Cliente cliente { get; set; }
        public List<(int, int)> id_prod_cantidad { get; set; }
        public List<(Producto, int)> productos { get; set; } 
        public float total
        {
            get
            {
                float precio = 0;
                productos.ForEach(tupla => { precio += tupla.Item1.precio * tupla.Item2; });
                return precio;
            }
        }
        public override string ToString()
        {
            string str = $"{cliente.ToString()}\n";
            float precio = 0;
            productos.ForEach(tupla => {
                precio += tupla.Item1.precio * tupla.Item2;
                str += $"{tupla.Item1.nombre}, Cantidad: {tupla.Item2}\n";
            });
            str += $"Total: {precio}€";
            return str;
        }
    }
    public class PedidoHabitual
    {
        public int id_pedido_habitual { get; set; }
        public string dni { get; set; }
        public Cliente cliente { get; set; }
        public List<(int, int)> id_prod_cantidad { get; set; }

        public List<(Producto, int)> productos { get; set; }

        public float total
        {
            get
            {
                float precio = 0;
                productos.ForEach(tupla => { precio += tupla.Item1.precio * tupla.Item2; });
                return precio;
            }
        }

        public override string ToString()
        {
            string str = $"\n{cliente.ToString()}\n";
            float precio = 0;
            productos.ForEach(tupla => {
                precio += tupla.Item1.precio * tupla.Item2;
                str += $"{tupla.Item1.nombre}, Cantidad: {tupla.Item2}\n";
            });
            str += $"Total: {precio}€";
            return str;
        }
    }
    public class Pago
    {
        public string dni { get; set; }
        public System.DateTime fecha { get; set; }

        public float cantidad { get; set; }
        public Cliente cliente { get; set; }
    }
    public class Producido
    {
        public System.DateTime fecha { get; set; }
        public float horas_horno { get; set; }
        public List<(Producto, int)> productos { get; set; }
    }
    public class Venta
    {
        public int id_venta { get; set; }
        public System.DateTime fecha { get; set; }
        public List<(Producto, int)> productos { get; set; }

        public float total
        {
            get
            {
                float precio = 0;
                productos.ForEach(tupla => { precio += tupla.Item1.precio * tupla.Item2; });
                return precio;
            }
        }
    }
}
