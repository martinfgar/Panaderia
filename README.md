# PANADERÍA  

## Contexto  

Manolo tiene una panadería, en la que produce **4 tipos de panes**. A la madrugada produce el pan en su horno, y cada día produce lo que entregará en los **pedidos a domicilio** y lo que tendrá en la tienda.  

Hay clientes que tienen **pedidos habituales**, es decir, que se entregan todos los días salvo **excepciones** que los clientes especifican.  

Manolo quiere llevar las cuentas de lo que gasta en luz y en materias primas, y compararlo con lo que saca con los pedidos y **ventas**.  

Al tratarse de un valle en el que todos se conocen, Manolo tiene la confianza suficiente con los vecinos como para **no cobrar por adelantado**, sino que **cobra los pedidos entregados** a los clientes cuando se acercan a la tienda.  

Por temas de organización, Manolo pide una **antelación de 2 días para realizar un pedido**, así puede organizarse mejor. De la mísma manera, para **cancelar un pedido pide que le avisen con 2 días de adelanto**.  

## Automatización  

El programa automatizará y ofrecerá ayuda con los siguientes procesos:  
- Dirá que productos tiene que producir para los pedidos de ese mismo día.
- Se estimarán gastos cuando Manolo especifique lo que ha producido en el horno.
- Calculará los gastos y beneficios con los pedidos y ventas anotadas en el programa.
- Permitirá añadir nuevos clientes.
- Permitirá anotar pedidos, pedidos habituales, excepciones a estos...
- Permitirá anotar que pedido se ha entregado.
- Permitirá conocer la deuda de los clientes.
  
El programa no automatizará lo relacionado con los gastos del reparto ni empleados en caso de que los hubiese.  

## Diagramas  

### Casos de uso  

![](Imagenes/Casos%20de%20uso%20panaderia.png)

### Diagrama de actividad  

### Diagrama de estado   

### Diagrama de secuencia   

### Diagrama de clases   

- Modelos de Negocio (namespace modelos):  
  
![](Imagenes/DiagramaClasesNegocio.png)

- Arquitectura : En este caso todos los namespace hacen uso de los modelos de negocio anteriormente mostrados.  


