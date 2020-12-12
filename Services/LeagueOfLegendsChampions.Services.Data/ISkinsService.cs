namespace LeagueOfLegendsChampions.Services.Data
{
    using System.Collections.Generic;

    public interface ISkinsService
    {
        IEnumerable<T> GetAll<T>(string id);
    }
}
