namespace LeagueOfLegendsChampions.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using LeagueOfLegendsChampions.Data.Common.Repositories;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Data;
    public class ChampionScraperService : IChampionScraperService
    {
        private readonly IDeletableEntityRepository<Champion> championsRepository;
        private readonly IDeletableEntityRepository<Item> itemsRepository;
        private readonly IDeletableEntityRepository<Skill> skillsRepository;
        private readonly IDeletableEntityRepository<Skin> skinsRepository;
        private readonly IDeletableEntityRepository<Rune> runesRepository;
        public ChampionScraperService(IDeletableEntityRepository<Champion> championsRepository, IDeletableEntityRepository<Item> itemsRepository, IDeletableEntityRepository<Skill> skillsRepository, IDeletableEntityRepository<Skin> skinsRepository, IDeletableEntityRepository<Rune> runesRepository)
        {
            this.championsRepository = championsRepository;
            this.itemsRepository = itemsRepository;
            this.skillsRepository = skillsRepository;
            this.skinsRepository = skinsRepository;
            this.runesRepository = runesRepository;
        }

        public async Task ImportChampionsNamesAndIconsAsync()
        {
            HtmlAgilityPack.HtmlWeb webForItems = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument docForItems = webForItems.Load("https://rankedboost.com/league-of-legends/items-update-2020/");
            int countForItems = 0;

            foreach (var currentItem in docForItems.DocumentNode.SelectNodes("//a[@class='sim-champ-a']"))
            {
                if (countForItems > 171)
                {
                    break;
                }

                string textForItems = currentItem.InnerHtml.Trim();
                int startingIndexOfTextForItems = textForItems.IndexOf("title=");
                int indexOfTextForItems = textForItems.IndexOf("class");
                string namesOfItems = textForItems.Substring(startingIndexOfTextForItems, indexOfTextForItems - startingIndexOfTextForItems);
                string name = namesOfItems.Replace("title=", string.Empty).ToString().Replace("\"", string.Empty).Trim();
                string urlForImages = currentItem.InnerHtml;
                int indexOfUrlForImagesFirst = urlForImages.IndexOf("data-lazy-src=");
                int indexOfUrlForImagesSecond = urlForImages.IndexOf(".png");
                string imageUrlForItems = urlForImages.Substring(indexOfUrlForImagesFirst, indexOfUrlForImagesSecond + 4 - indexOfUrlForImagesFirst);
                string finalUrl = imageUrlForItems.Replace("data-lazy-src=\"", string.Empty).Trim();

                var itemToAdd = new Item
                {
                    Name = name,
                    ImageUrl = finalUrl,
                };

                await this.itemsRepository.AddAsync(itemToAdd);
                countForItems++;
            }

            await this.itemsRepository.SaveChangesAsync();
        }
    }
}
