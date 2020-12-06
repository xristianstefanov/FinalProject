namespace LeagueOfLegendsChampions.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using LeagueOfLegendsChampions.Data.Common.Repositories;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Data;
    public class ChampionScraperService : IChampionScraperService
    {
        private readonly IDeletableEntityRepository<Champion> championsRepository;
        private readonly IDeletableEntityRepository<Item> itemsRepository;
        public ChampionScraperService(IDeletableEntityRepository<Champion> championsRepository, IDeletableEntityRepository<Item> itemsRepository)
        {
            this.championsRepository = championsRepository;
            this.itemsRepository = itemsRepository;
        }

        public async Task ImportChampionsNamesAndIconsAsync()
        {
            //HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            //HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://champion.gg/");
            //int count = 0;

            //foreach (var item in doc1.DocumentNode.SelectNodes("//div[@class='tsm-tooltip']"))
            //{
            //    if (count > 19)
            //    {
            //        string url = item.InnerHtml.Trim().Replace(" ", string.Empty);
            //        int indexOfUrlFirst = url.IndexOf("('");
            //        int indexOfUrlSecond = url.IndexOf("')");
            //        string championIconImageUrl = url.Substring(indexOfUrlFirst, indexOfUrlSecond - indexOfUrlFirst).Replace("('", string.Empty);
            //        string championName = Regex.Replace(item.InnerText, @"\t|\n|\r", string.Empty);
            //        string championNameFull = championName.Replace("&#39;", "'").Trim().ToString().Replace("&amp;", "&");

            //        HtmlAgilityPack.HtmlWeb web1 = new HtmlAgilityPack.HtmlWeb();
            //        string myUsedLink = string.Empty;

            //        if (championNameFull == "Nunu & Willump")
            //        {
            //            myUsedLink = $"https://na.leagueoflegends.com/en-us/champions/Name/".Replace("Name", "nunu");
            //        }
            //        else
            //        {
            //            myUsedLink = $"https://na.leagueoflegends.com/en-us/champions/Name/".Replace("Name", $"{championNameFull.Replace(".", string.Empty).ToLower().Replace("'", "-").ToString().Replace(" ", "-").ToString()}");
            //        }

            //        HtmlAgilityPack.HtmlDocument doc2 = web1.Load(myUsedLink);

            //        string championFullSizeImageUrl = string.Empty;
            //        foreach (var item1 in doc2.DocumentNode.SelectNodes("//div[@class='style__ForegroundAsset-sc-1o884zt-4 cVdVkh']"))
            //        {
            //            string urlOne = item1.InnerHtml.Trim().Replace(" ", string.Empty);
            //            int indexOfUrlFirstOne = urlOne.IndexOf("=\"");
            //            int indexOfUrlSecondOne = urlOne.IndexOf("g\"");
            //            championFullSizeImageUrl = urlOne.Substring(indexOfUrlFirstOne + 1, indexOfUrlSecondOne - indexOfUrlFirstOne).Replace("\"", string.Empty);
            //        }

            //        string nicknameForChamp = string.Empty;
            //        foreach (var item2 in doc2.DocumentNode.SelectNodes("//span[@class='style__Intro-sc-14gxj1e-2 fmCNnE']"))
            //        {
            //            nicknameForChamp = item2.InnerText.Replace("&#x27;", "'");
            //        }

            //        var championToAdd = new Champion
            //        {
            //            Name = championNameFull,
            //            ImageIconUrl = championIconImageUrl,
            //            ImageFullSizeUrl = championFullSizeImageUrl,
            //            Nickname = nicknameForChamp,
            //        };

            //        await this.championsRepository.AddAsync(championToAdd);
            //        count++;
            //    }
            //    else
            //    {
            //        count++;
            //    }
            //}

            //await this.championsRepository.SaveChangesAsync();

            HtmlAgilityPack.HtmlWeb web10 = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc10 = web10.Load("https://rankedboost.com/league-of-legends/items-update-2020/");
            int count1 = 0;

            foreach (var item10 in doc10.DocumentNode.SelectNodes("//a[@class='sim-champ-a']"))
            {
                if (count1 > 171)
                {
                    break;
                }

                string textForNames = item10.InnerHtml.Trim();
                int indexOfTextForNamesFirst = textForNames.IndexOf("title=");
                int indexOfTextForNamesSecond = textForNames.IndexOf("class");
                string namesOfItems = textForNames.Substring(indexOfTextForNamesFirst, indexOfTextForNamesSecond - indexOfTextForNamesFirst);
                string name = namesOfItems.Replace("title=", string.Empty).ToString().Replace("\"", string.Empty).Trim();
                string urlForImages = item10.InnerHtml;
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
                count1++;
            }

            await this.itemsRepository.SaveChangesAsync();
        }
    }
}
