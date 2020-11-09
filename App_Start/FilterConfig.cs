using System.Web;
using System.Web.Mvc;

namespace FDMSWeb
{
    /* Filter Configuration*/
    public class FilterConfig
    {
        /// <summary>
        /// Register global filters for the project to use
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); // add default Handle Error Attribute to handle errors
        }
    }
}
