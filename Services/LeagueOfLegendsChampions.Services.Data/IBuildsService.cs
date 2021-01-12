namespace LeagueOfLegendsChampions.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LeagueOfLegendsChampions.Web.ViewModels.Builds;

    public interface IBuildsService
    {
        IEnumerable<T> GetAll<T>(string id);
        Task CreateAsync(BuildInListViewModel input, string championId);
        Task DeleteBuildAsync(string championId, string userId);
    }
}
