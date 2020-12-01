namespace LeagueOfLegendsChampions.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LeagueOfLegendsChampions.Web.ViewModels.Champions;

    public interface IChampionsService
    {
        IEnumerable<T> GetAll<T>();
        T GetById<T>(string id);
    }
}
