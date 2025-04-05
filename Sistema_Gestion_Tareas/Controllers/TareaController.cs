
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
    // Este controlador gestiona las operaciones relacionadas con las tareas. Colocamos los endpoints de la API para que otros sistemas puedan interactuar con las tareas.
    public class TareaController : ApiController
    {
        // Se instancia el contexto de la base de datos para interactuar con la tabla de tareas.
        private GestorTareas db = new GestorTareas();

        // GET: api/tareas
        // Este método devuelve todas las tareas almacenadas en la base de datos.
        // Se utiliza para obtener una lista completa de tareas.
        [HttpGet]
        [Route("api/tareas")]
        public IEnumerable<Tarea> GetTareas() => db.Tareas.ToList();

        // POST: api/tareas
        // Este método permite crear una nueva tarea en la base de datos.
        // Recibe un objeto Tarea desde el cuerpo de la solicitud HTTP.
        [HttpPost]
        [Route("api/tareas")]
        public IHttpActionResult PostTarea(Tarea tarea)
        {
            db.Tareas.Add(tarea);// Se agrega la nueva tarea al contexto de la base de datos.
            db.SaveChanges();// Se guardan los cambios en la base de datos.
            return Ok(tarea);// Se devuelve una respuesta exitosa con la tarea creada.
        }

        // PUT: api/tareas/{id}
        // Este método permite actualizar una tarea existente.
        // Busca la tarea por su ID y actualiza sus propiedades si se encuentra en la base de datos.
        [HttpPut]
        [Route("api/tareas/{id}")]
        public IHttpActionResult PutTarea(int id, Tarea tarea)
        {
            var existingTarea = db.Tareas.Find(id);// Busca la tarea en la base de datos por su ID.
            if (existingTarea == null) return NotFound();// Si no se encuentra, devuelve un 404.

            // Actualiza las propiedades de la tarea encontrada.
            existingTarea.Titulo = tarea.Titulo;
            existingTarea.Descripcion = tarea.Descripcion;
            existingTarea.Estado = tarea.Estado;

            db.SaveChanges();// Guarda los cambios en la base de datos.
            return Ok(existingTarea);// Devuelve la tarea actualizada.
        }

        // DELETE: api/tareas/{id}
        // Este método elimina una tarea de la base de datos según su ID.
        [HttpDelete]
        [Route("api/tareas/{id}")]
        public IHttpActionResult DeleteTarea(int id)
        {
            var tarea = db.Tareas.Find(id);// Busca la tarea por su ID.
            if (tarea == null) return NotFound();// Si no se encuentra, devuelve un 404.

            db.Tareas.Remove(tarea);// Elimina la tarea del contexto de la base de datos.
            db.SaveChanges();// Guarda los cambios para reflejar la eliminación.
            return Ok();// Devuelve una respuesta exitosa.
        }

        // GET: api/tareas/filter?estado=Pendiente
        // Este método devuelve una lista de tareas filtradas por su estado (Pendiente, En Progreso, Finalizada).
        [HttpGet]
        [Route("api/tareas/filter")]
        public IEnumerable<Tarea> GetTareasPorEstado(string estado)
        {
            // Filtra las tareas en la base de datos que coincidan con el estado proporcionado.
            return db.Tareas.Where(t => t.Estado == estado).ToList();
        }
    }
}
