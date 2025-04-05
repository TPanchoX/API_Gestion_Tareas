// ESCUELA POLITÉCNICA NACIONAL
// Aplicaciones Distribuidas
// Integrantes: Francisco Imbaquinga, Patricio Sánchez
// Fecha: 01/02/2025
// PROYECTO 2 (Segundo Bimetres)
//
// Descripción del proyecto: Este proyecto consiste en la creación de un sistema de gestión de tareas que permite a los usuarios administrar sus tareas pendientes, en progreso y finalizadas. El sistema cuenta con una interfaz web donde los usuarios pueden ver, crear, editar y eliminar tareas, así como filtrarlas por su estado. Además, se implementa un sistema de autenticación para permitir a los usuarios iniciar sesión y acceder a sus tareas de forma segura.
//
// Conclusiones:
// Francisco Imbaquinga: El desarrollo de este proyecto me permitió aprender sobre el uso de ASP.NET Web API para la creación de servicios RESTful que interactúan con una base de datos a través de Entity Framework. Pude comprender la importancia de separar la lógica de negocio de la capa de presentación para mantener un código limpio y modular. Además, la implementación de la autenticación de usuarios me ayudó a entender cómo se gestionan las credenciales de forma segura en una aplicación web.
// Francisco Imbaquinga: El proyecto se ha estructurado siguiendo los principios de diseño RESTful, lo que facilita la comunicación entre el backend y posibles aplicaciones frontend o móviles. La utilización de ASP.NET Web API permite una gestión eficiente de recursos, asegurando que las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para usuarios y tareas sean simples, intuitivas y escalables.
// 
// Patricio Sánchez: La integración con Entity Framework (EF) simplifica el acceso y manipulación de la base de datos, eliminando la necesidad de escribir consultas SQL complejas. El enfoque Code First utilizado permite que la estructura de la base de datos evolucione junto con el código, facilitando la gestión de cambios mediante migraciones.
// Patricio Sánchez:La arquitectura del proyecto está bien organizada, separando claramente la lógica de datos (DAL), modelos y controladores. Esta modularidad facilita la mantenibilidad del código, permitiendo agregar nuevas funcionalidades o realizar modificaciones sin afectar significativamente la estructura existente. Además, la implementación de nuevas características como la gestión de permisos o la auditoría de tareas sería relativamente sencilla.
//
// Recomendaciones:
// Francisco Imbaquinga: Para futuras versiones del sistema, sería interesante implementar un sistema de notificaciones para recordar a los usuarios sobre tareas pendientes o fechas de vencimiento. También se podría agregar un sistema de etiquetas o categorías para organizar las tareas de forma más eficiente.
// Francisco Imbaquinga: Sería útil incorporar un sistema de búsqueda para permitir a los usuarios encontrar tareas específicas rápidamente. Además, se podría mejorar la interfaz de usuario con elementos interactivos como drag-and-drop para reorganizar las tareas o filtros avanzados para personalizar la visualización.
//
// Patricio Sánchez: Para mejorar la seguridad del sistema, se podría implementar un sistema de cifrado para proteger las contraseñas de los usuarios en la base de datos. También sería recomendable agregar validaciones de entrada para prevenir ataques de inyección de código y asegurar que los datos ingresados sean seguros y válidos.
// Patricio Sánchez: En futuras versiones, se podría extender la funcionalidad del sistema permitiendo a los usuarios compartir tareas con otros miembros, asignar responsables o establecer fechas límite para colaboraciones. Esto ampliaría las capacidades de gestión de proyectos y fomentaría la colaboración entre los usuarios.

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
    // Este controlador gestiona las operaciones relacionadas con los usuarios del sistema.
    // Permite crear, obtener, actualizar y eliminar usuarios a través de la API REST.
    public class UsuarioController : ApiController
    {
        // Instancia del contexto de la base de datos para interactuar con la tabla de usuarios.
        private GestorTareas db = new GestorTareas();

        // GET: api/usuarios
        // Este método devuelve la lista de todos los usuarios almacenados en la base de datos.
        // Se utiliza para obtener información general de los usuarios registrados.
        [HttpGet]
        [Route("api/usuarios")]
        public IEnumerable<Usuario> GetUsuarios() => db.Usuarios.ToList();

        // POST: api/usuarios
        // Este método permite crear un nuevo usuario en la base de datos.
        // Recibe un objeto Usuario desde el cuerpo de la solicitud HTTP (en formato JSON).
        [HttpPost]
        [Route("api/usuarios")]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            db.Usuarios.Add(usuario);// Se agrega el nuevo usuario al contexto de la base de datos.
            db.SaveChanges();// Se guardan los cambios en la base de datos.
            return Ok(usuario);// Devuelve una respuesta exitosa con el usuario creado.
        }

        // PUT: api/usuarios/{id}
        // Este método permite actualizar los datos de un usuario existente.
        // Busca al usuario por su ID y actualiza sus propiedades si se encuentra en la base de datos.
        [HttpPut]
        [Route("api/usuarios/{id}")]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            var existingUser = db.Usuarios.Find(id);// Busca al usuario en la base de datos por su ID.
            if (existingUser == null) return NotFound();// Si no se encuentra, devuelve un 404 Not Found.

            // Actualiza las propiedades del usuario encontrado.
            existingUser.Nombre = usuario.Nombre;
            existingUser.Email = usuario.Email;
            existingUser.Rol = usuario.Rol;

            db.SaveChanges();// Guarda los cambios realizados en la base de datos.
            return Ok(existingUser);// Devuelve el usuario actualizado.
        }

        // DELETE: api/usuarios/{id}
        // Este método permite eliminar un usuario de la base de datos según su ID.
        [HttpDelete]
        [Route("api/usuarios/{id}")]
        public IHttpActionResult DeleteUsuario(int id)
        {
            var usuario = db.Usuarios.Find(id);// Busca al usuario por su ID en la base de datos.
            if (usuario == null) return NotFound();// Si no se encuentra, devuelve un 404 Not Found.

            db.Usuarios.Remove(usuario);// Elimina al usuario del contexto de la base de datos.
            db.SaveChanges();// Guarda los cambios para reflejar la eliminación.
            return Ok();// Devuelve una respuesta exitosa.
        }
    }
}
