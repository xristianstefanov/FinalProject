namespace LeagueOfLegendsChampions.Web.Areas.Administration.Controllers
{
    using LeagueOfLegendsChampions.Common;
    using LeagueOfLegendsChampions.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
