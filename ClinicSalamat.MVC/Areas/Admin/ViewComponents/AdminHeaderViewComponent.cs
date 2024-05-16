using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicSalamat.Presentation.Areas.Admin.ViewComponents;

public class AdminHeaderViewComponent : ViewComponent
{
    #region Ctor



    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {

        return View("AdminHeader");
    }
}
