
// Descripción del proyecto: Este proyecto consiste en la creación de un sistema de gestión de tareas que permite a los usuarios administrar sus tareas pendientes, en progreso y finalizadas. El sistema cuenta con una interfaz web donde los usuarios pueden ver, crear, editar y eliminar tareas, así como filtrarlas por su estado. Además, se implementa un sistema de autenticación para permitir a los usuarios iniciar sesión y acceder a sus tareas de forma segura.
//

//  El desarrollo de este proyecto me permitió aprender sobre el uso de ASP.NET Web API para la creación de servicios RESTful que interactúan con una base de datos a través de Entity Framework. Pude comprender la importancia de separar la lógica de negocio de la capa de presentación para mantener un código limpio y modular. Además, la implementación de la autenticación de usuarios me ayudó a entender cómo se gestionan las credenciales de forma segura en una aplicación web.
//  El proyecto se ha estructurado siguiendo los principios de diseño RESTful, lo que facilita la comunicación entre el backend y posibles aplicaciones frontend o móviles. La utilización de ASP.NET Web API permite una gestión eficiente de recursos, asegurando que las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para usuarios y tareas sean simples, intuitivas y escalables.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Sistema_Gestion_Tareas.Models;
using Sistema_Gestion_Tareas.DAL;

namespace Sistema_Gestion_Tareas.Controllers
{
    // Este controlador gestiona la autenticación de los usuarios en el sistema.
    // Su función principal es verificar las credenciales de los usuarios para permitir el acceso.
    public class AutenticacionController : ApiController
    {
        // Instancia del contexto de la base de datos para interactuar con la tabla de usuarios.
        private GestorTareas db = new GestorTareas();

        // POST: api/autenticacion/login
        // Este método permite a los usuarios iniciar sesión en el sistema.
        // Recibe un objeto Usuario con el email y la contraseña para validar las credenciales.
        [HttpPost]
        [Route("api/autenticacion/login")]
        public IHttpActionResult Login(Usuario login)
        {
            // Se busca en la base de datos un usuario que coincida con el email y la contraseña proporcionados.
            var usuario = db.Usuarios.FirstOrDefault(u => u.Email == login.Email && u.Contrasena == login.Contrasena);
            // Si no se encuentra un usuario con las credenciales proporcionadas, se devuelve un error 401 (No autorizado).
            if (usuario == null) return Unauthorized();
            // Si las credenciales son correctas, se devuelve un mensaje de éxito junto con la información del usuario.
            return Ok(new { mensaje = "Login exitoso", usuario });
        }

    }
}
