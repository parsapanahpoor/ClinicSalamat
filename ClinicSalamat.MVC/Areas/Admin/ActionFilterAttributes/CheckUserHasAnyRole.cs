using Microsoft.AspNetCore.Mvc.Filters;
namespace ClinicSalamat.Presentation.Areas.Admin.ActionFilterAttributes;
using ClinicSalamat.Application.Extensions;
using ClinicSalamat.Domain.IRepositories.Role;

public class CheckUserHasAnyRole : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var service = (IRoleQueryRepository)context.HttpContext.RequestServices.GetService(typeof(IRoleQueryRepository))!;

        base.OnActionExecuting(context);

        var hasUserAnyRole = service.IsUser_Admin(context.HttpContext.User.GetUserId() , default).Result;

        if (!hasUserAnyRole)
        {
            context.HttpContext.Response.Redirect("/");
        }
    }
}
