using System.Web.Mvc;

namespace WEBGIAY.Areas.Webmaster
{
    public class WebmasterAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Webmaster";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Webmaster_default",
                "Webmaster/{controller}/{action}/{id}",
                new { action = "login", id = UrlParameter.Optional },
                new string[] { "WEBGIAY.Areas.Webmaster.Controllers" }
            );
        }
    }
}