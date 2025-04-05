using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Sistema_Gestion_Tareas.Models;

namespace Sistema_Gestion_Tareas.DAL
{
    // Esta clase representa el contexto de la base de datos para el sistema de gestión de tareas.
    // Está heredada de DbContext, lo que permite a Entity Framework manejar las operaciones de la base de datos.
    public class GestorTareas: DbContext
    {
        // DbSet<Tarea> representa la tabla de Tareas en la base de datos.
        // Entity Framework usa esta propiedad para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar).
        public DbSet<Tarea> Tareas { get; set; }

        // DbSet<Usuario> representa la tabla de Usuarios en la base de datos.
        // También permite realizar operaciones CRUD para gestionar los usuarios del sistema.
        public DbSet<Usuario> Usuarios { get; set; }
    }
}