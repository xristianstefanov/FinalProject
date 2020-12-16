namespace LeagueOfLegendsChampions.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LeagueOfLegendsChampions.Data.Common.Repositories;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;

    public class ItemsService : IItemsService
    {
        private readonly IRepository<BuildItem> buildItemsRepository;
        private readonly IDeletableEntityRepository<Item> itemsRepository;

        public ItemsService(IRepository<BuildItem> buildItemsRepository, IDeletableEntityRepository<Item> itemsRepository)
        {
            this.buildItemsRepository = buildItemsRepository;
            this.itemsRepository = itemsRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var items = this.buildItemsRepository.AllAsNoTracking()
                .To<T>()
                .ToList();

            return items;
        }

        public T GetById<T>(string id)
        {
            var item = this.itemsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return item;
        }

        public T GetByName<T>(string itemName)
        {
            var item = this.itemsRepository.AllAsNoTracking()
                .Where(x => x.Name == itemName)
                .To<T>().FirstOrDefault();

            return item;
        }
    }
}
