create table cliente(
    DNI TEXT NOT NULL PRIMARY KEY,
    NOMBRE TEXT NOT NULL,
    DIRECCION TEXT NOT NULL
);
create table pago(
    DNI text not null,
    fecha text not null,
    cantidad real not null,
    foreign key (dni) references cliente(dni)
);
create table pedido(
    id_pedido integer primary key autoincrement,
    fecha text not null,
    entregado integer not null,
    pagado integer not null,
    dni text not null,
    foreign key (dni) references cliente(dni)
);

create table pedido_habitual(
    id_pedido_habitual integer primary key autoincrement,
    dni text not null,
    foreign key (dni) references cliente(dni)
);
create table producto(
    id_producto integer primary key autoincrement,
    nombre text not null,
    precio real not null,
    kg_harina_ud real not null
);

create table pedido_producto(
    id_pedido integer not null,
    id_producto integer not null,
    cantidad integer not null,
    primary key (id_pedido,id_producto),
    foreign key (id_pedido) REFERENCES pedido(id_pedido),
    foreign key (id_producto) REFERENCES producto(id_producto)
);
create table pedido_hab_producto(
    id_pedido_habitual integer not null,
    id_producto integer not null,
    cantidad integer not null,
    primary key (id_pedido_habitual,id_producto),
    foreign key (id_pedido_habitual) references pedido_habitual(id_pedido_habitual),
    foreign key (id_producto) REFERENCES producto(id_producto)
);
create table excepcion(
    id_pedido_habitual integer not null,
    fecha text not null,
    primary key (id_pedido_habitual,fecha),
    foreign key (id_pedido_habitual) REFERENCES pedido_habitual(id_pedido_habitual)
);
create table venta(
    id_venta integer primary key autoincrement,
    fecha text not null
);
create table venta_producto(
    id_venta integer not null,
    id_producto integer not null,
    cantidad integer not null,
    primary key (id_venta,id_producto),
    foreign key (id_producto) REFERENCES producto(id_producto),
    foreign key (id_venta) REFERENCES venta(id_venta)
);
create table producido(
    fecha text primary key,
    horas_horno real not null
);
create table producido_producto(
    fecha text not null,
    id_producto integer not null,
    cantidad integer not null,
    primary key (fecha,id_producto),
    foreign key (id_producto) REFERENCES producto(id_producto),
    foreign key (fecha) REFERENCES producido(fecha)
);



insert into cliente values('12345678A','Miguel Gutierrez', 'Calle Azul 30, Pueblo Paleta');
insert into cliente values('12345678B','Jaime Gutierrez', 'Calle Roja 20, Pueblo Paleto');
insert into cliente values('12345678C','Ana Alvarez', 'Calle Verde 10, Pueblo Muela');
insert into cliente values('12345678D','Marcos Prego', 'Calle Negra 40, Pueblo Molar');
insert into cliente values('12345678E','Yolanda Yoli', 'Calle Gris 30, Irun');

insert into producto (nombre,precio,kg_harina_ud) values('Baguette',0.7,0.2);
insert into producto (nombre,precio,kg_harina_ud) values('Chapata',1.2,0.3);
insert into producto (nombre,precio,kg_harina_ud) values('Rustico',1.5,0.5);
insert into producto (nombre,precio,kg_harina_ud) values('Hogaza',2,0.7);

