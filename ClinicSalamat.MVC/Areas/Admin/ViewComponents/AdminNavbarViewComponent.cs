using ClinicSalamat.Domain.IRepositories.User;
using Microsoft.AspNetCore.Mvc;
using ClinicSalamat.Application.Extensions;
using System.Threading.Tasks;
using System.Threading;

namespace ClinicSalamat.Presentation.Areas.Admin.ViewComponents;

public class AdminNavbarViewComponent : ViewComponent
{
    #region Ctor

    private readonly IUserQueryRepository _userQueryRepository;

    public AdminNavbarViewComponent(IUserQueryRepository userQueryRepository)
    {
        _userQueryRepository  = userQueryRepository;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken = default)
    {
        var user = await _userQueryRepository.GetByIdAsync(cancellationToken , User.GetUserId());

        return View("AdminNavbar", user);
    }
}
