using Microsoft.AspNetCore.Mvc;

namespace ClinicSalamat.Presentation.Areas.Admin.Controllers;

public class HomeController : AdminBaseController
{
    #region Admin Dashboard

    public IActionResult Index() => View();

    #endregion
}
