using ClinicSalamat.Presentation.Areas.Admin.ActionFilterAttributes;
using ClinicSalamat.Presentation.Filter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicSalamat.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[CheckUserHasAnyRole]
[CatchExceptionFilter]
public class AdminBaseController : Controller
{
    public static string SuccessMessage = "SuccessMessage";
    public static string ErrorMessage = "ErrorMessage";
    public static string InfoMessage = "InfoMessage";
    public static string WarningMessage = "WarningMessage";

    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}

