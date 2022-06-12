
using Microsoft.AspNetCore.Mvc.Filters;

namespace admin_cms.Models.Infraestrutura.Autenticacao
{
    public class LogadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(filterContext.HttpContext.Request.Cookies["alunos"]))
            {
                //  if(string.IsNullOrEmpty(filterContext.HttpContext.Session.GetString("alunos")))
                filterContext.HttpContext.Response.Redirect("/");


                base.OnActionExecuting(filterContext);

                return;
            }
        }

    }
}


//public class LogadoAttribute : ActionFilterAttribute
//{
 //   public override void OnActionExecuting(ActionExecutingContext filterContext)
  //  {
   //     if (string.IsNullOrEmpty(filterContext.HttpContext.Request.Cookies["adm_cms"]))
    //    {
     //       filterContext.HttpContext.Response.Redirect("/login");
      //      return;
       // }
        //base.OnActionExecuting(filterContext);
    //}
//}