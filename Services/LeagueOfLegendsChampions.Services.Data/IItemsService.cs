namespace LeagueOfLegendsChampions.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IItemsService
    {
        IEnumerable<T> GetAll<T>();
        T GetByName<T>(string itemName);
        T GetById<T>(string id);
    }
}
