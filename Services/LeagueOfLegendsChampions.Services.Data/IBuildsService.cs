namespace LeagueOfLegendsChampions.Services.Data
{
    using System.Collections.Generic;

    public interface IBuildsService
    {
        IEnumerable<T> GetAll<T>(string id);
    }
}
