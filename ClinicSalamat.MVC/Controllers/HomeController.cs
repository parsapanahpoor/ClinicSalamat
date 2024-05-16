using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSalamat.MVC.Controllers;

public class HomeController : Controller
{
    #region Index
 
    public IActionResult Index() => View();

    #endregion
}
