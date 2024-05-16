using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicSalamat.Presentation.Areas.Admin.ViewComponents;

public class AdminSideBarViewComponent : ViewComponent
{
    #region Ctor

    public AdminSideBarViewComponent()
    {

    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("AdminSideBar");
    }
}
