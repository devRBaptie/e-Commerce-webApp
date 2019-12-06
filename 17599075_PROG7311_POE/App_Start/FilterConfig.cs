using System.Web;
using System.Web.Mvc;

namespace _17599075_PROG7311_POE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
