using System.Web;
using System.Web.Mvc;

namespace ProgrammersTest_Bell
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
