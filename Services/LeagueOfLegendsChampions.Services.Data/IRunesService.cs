namespace LeagueOfLegendsChampions.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IRunesService
    {
        IEnumerable<T> GetAll<T>(string id);
    }
}
