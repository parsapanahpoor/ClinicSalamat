﻿using ClinicSalamat.Presentation.Filter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace ClinicSalamat.Presentation.Controllers;

[CatchExceptionFilter]
public abstract class SiteBaseController : Controller
{
    public static string SuccessMessage = "SuccessMessage";
    public static string ErrorMessage = "ErrorMessage";
    public static string InfoMessage = "InfoMessage";
    public static string WarningMessage = "WarningMessage";

    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
