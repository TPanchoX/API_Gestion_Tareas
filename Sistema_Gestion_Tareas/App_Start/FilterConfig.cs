using System.Web;
using System.Web.Mvc;

namespace Sistema_Gestion_Tareas
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
