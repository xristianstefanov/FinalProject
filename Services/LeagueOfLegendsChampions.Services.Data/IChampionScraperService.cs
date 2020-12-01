namespace LeagueOfLegendsChampions.Services.Data
{
    using System.Threading.Tasks;
    public interface IChampionScraperService
    {
        Task ImportChampionsNamesAndIconsAsync();
    }
}
