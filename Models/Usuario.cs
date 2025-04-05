// Descripción del proyecto: Este proyecto consiste en la creación de un sistema de gestión de tareas que permite a los usuarios administrar sus tareas pendientes, en progreso y finalizadas. El sistema cuenta con una interfaz web donde los usuarios pueden ver, crear, editar y eliminar tareas, así como filtrarlas por su estado. Además, se implementa un sistema de autenticación para permitir a los usuarios iniciar sesión y acceder a sus tareas de forma segura.
//
//  El desarrollo de este proyecto me permitió aprender sobre el uso de ASP.NET Web API para la creación de servicios RESTful que interactúan con una base de datos a través de Entity Framework. Pude comprender la importancia de separar la lógica de negocio de la capa de presentación para mantener un código limpio y modular. Además, la implementación de la autenticación de usuarios me ayudó a entender cómo se gestionan las credenciales de forma segura en una aplicación web.
//  El proyecto se ha estructurado siguiendo los principios de diseño RESTful, lo que facilita la comunicación entre el backend y posibles aplicaciones frontend o móviles. La utilización de ASP.NET Web API permite una gestión eficiente de recursos, asegurando que las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para usuarios y tareas sean simples, intuitivas y escalables.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Gestion_Tareas.Models
{
    public class Usuario
    {
        // Es el identificador único del usuario utilizado para distinguir cada usuario en la base de datos.
        public int Id { get; set; }
        // Es el nombre completo del usuario. 
        public string Nombre { get; set; }
        // Es la dirección de correo electrónico del usuario. Nos servirá para la autenticación.
        public string Email { get; set; }
        // Es la contraseña del usuario. También utilizada para autenticacion 
        public string Contrasena { get; set; }
        // Es el rol que define los permisos del usuario dentro del sistema. Puede ser "Admin" o "Miembro".
        public string Rol { get; set; } 
    }
}