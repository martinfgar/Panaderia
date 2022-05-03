// See https://aka.ms/new-console-template for more information
using modelos;
using Repo;
ConnectDB con = new ConnectDB();
Selects sel = new Selects();
sel.obtenerClientes(con.crearConexion());

