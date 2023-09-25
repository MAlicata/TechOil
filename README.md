# Softtek Challenge TechOil C#
El reto consistió en desarrollar una aplicacion en .Net Core 6, el objetivo es proporcionar una solución para digitalizar y 
automatizar su proceso de control de horas y servicios de la empresa líder en el sector Oil & Gas en latinoamerica.

## Gestión del trabajo
Con fines de realizar una correcta gestión del trabajo, 
utilicé metodologías ágiles (Scrum) para desarrollar de manera ordenada cada etapa de iteración del proyecto.

​
## **Especificación de la Arquitectura**
​
### **Capa Controller**
Es esencial para la implementación de la lógica de manejo de solicitudes y respuestas en una aplicación web o API, 
asegurando una separación adecuada de las preocupaciones y una experiencia de usuario efectiva.
​
### **Capa DataAccess**
 Es fundamental para gestionar la interacción con la fuente de datos, 
 proporcionando un nivel de abstracción que facilita el acceso y la manipulación de datos de manera eficiente y segura en la aplicación.
​
### **Capa Entities**
En este nivel de la arquitectura se encarga de definir y modelar los objetos de datos y las estructuras que se utilizan en la aplicación, 
proporcionando una representación coherente y abstraída de los conceptos de negocio que son esenciales para el 
funcionamiento de la aplicación.
​
### **Capa Repositories**
Se utiliza en conjunto con un enfoque Unit of Work, proporciona una abstracción eficaz para gestionar la interacción con la base de datos y 
asegura la coherencia de los datos en una aplicación. 
Esto promueve la separación de preocupaciones y facilita el desarrollo y el mantenimiento de aplicaciones robustas y escalables.

**	Interfaces: Se definirán las interfaces que utilizaremos en los servicios.

### **Capa Services**
Se utiliza en conjunto con el patrón Unit of Work, es responsable de implementar la lógica de negocio de la aplicación, 
coordinar operaciones de acceso a datos y garantizar la coherencia de los datos a través de transacciones. 
Esto promueve una arquitectura organizada y facilita el desarrollo de aplicaciones robustas y mantenibles.​

### **Helper**​
*	Helper: Definiremos lógica que pueda ser de utilidad para todo el proyecto. Por ejemplo, algún método para encriptar/desencriptar contraseñas


## Created & Maintained By

[Matías Alicata](https://github.com/MAlicata/TechOil) - [LinkedIn](https://www.linkedin.com/in/matiasjesusalicata)