<h1>EvertecTest  WEBSHOP</h1>

Lo primero que se debe de tener en cuenta es que al descragar el proyecto se debe de limpiar y recompilar la solucion para evitar posibles errores.
<b>El poryecto esta compilado en .NET Frameworks 4.7.2   y usa Entity Framework 6.0.0 ademas de Unity 5.11.1 para la inyeccion de dependencias </b>
Dentro del proyecto ya va una base de datos con usuario grabado el cual es elkin683@gmail.com con clave 1093219235 sin embargo la solucion ofrece una opcion para crear usarios adicionales en la seccion crear login, para efectos del ejercisio se puede seleccionar si es un usuario administrador o no (el Administrador ademas de las funciones normales puede ver todas las ordenes de la tienda)

<h2>Estrucura del proyecto</h2>
La solucion esta compuesta por 3 capas:
1 La capa de persistencia donde se encuentran los entity y el repositorio con las consultas a la base de datos.
2 La capa del negocio donde se encuentran los DOmain service y los DTO sirviendo como capa intermedia a los datos
3 La capa de interfaz de usuario en donde se interactua con el usuario final ademas de contener la clase encargada de interactuar con Place to Pay <b>Se debe de garantizar que este proyecto sea el proyecto de inicio de la solucion, en caso de que no lo sea se hace clic derecho en el proyecto y se le da establecer como proyecto de inicio</b>
<h2>Flujo del proyecto</h2>
1 Se debe iniciar session o crear un usuario y posteriormente iniciar session
2 Despues de iniciar session se cargaran la vista de ordenes del usuario con un menu superior, si el usuario es Administrador tendra la opcion de ver todas las ordenes de la tienda, en listado de ordenes el usuario tendra la opcion de reintentar el proceso de pago o consultar el estado de una orden( actualizar si la transaccion ha cambiado)
3 dentro de la vista de las ordenes del usuario, el podra crear una nueva orden y posteriormente inciar el proceso de pago finalmente retomando a la pantalla de resumen de la transaccion(esta panta actualiza la transaccion, en caso de que quede pendiinete al ir a esta pantalla se actualizara la orden si hay un cambio en la transaccion)
