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
        public ChampionScraperService(IDeletableEntityRepository<Champion> championsRepository)
        {
            this.championsRepository = championsRepository;
        }

        public async Task ImportChampionsNamesAndIconsAsync()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://champion.gg/");
            int count = 0;

            foreach (var item in doc1.DocumentNode.SelectNodes("//div[@class='tsm-tooltip']"))
            {
                if (count > 19)
                {
                    string url = item.InnerHtml.Trim().Replace(" ", string.Empty);
                    int indexOfUrlFirst = url.IndexOf("('");
                    int indexOfUrlSecond = url.IndexOf("')");
                    string championIconImageUrl = url.Substring(indexOfUrlFirst, indexOfUrlSecond - indexOfUrlFirst).Replace("('", string.Empty);
                    string championName = Regex.Replace(item.InnerText, @"\t|\n|\r", string.Empty);
                    string championNameFull = championName.Replace("&#39;", "'").Trim().ToString().Replace("&amp;", "&");

                    HtmlAgilityPack.HtmlWeb web1 = new HtmlAgilityPack.HtmlWeb();
                    string myUsedLink = string.Empty;

                    if (championNameFull == "Nunu & Willump")
                    {
                        myUsedLink = $"https://na.leagueoflegends.com/en-us/champions/Name/".Replace("Name", "nunu");
                    }
                    else
                    {
                        myUsedLink = $"https://na.leagueoflegends.com/en-us/champions/Name/".Replace("Name", $"{championNameFull.Replace(".", string.Empty).ToLower().Replace("'", "-").ToString().Replace(" ", "-").ToString()}");
                    }

                    HtmlAgilityPack.HtmlDocument doc2 = web1.Load(myUsedLink);

                    string championFullSizeImageUrl = string.Empty;
                    foreach (var item1 in doc2.DocumentNode.SelectNodes("//div[@class='style__ForegroundAsset-sc-1o884zt-4 cVdVkh']"))
                    {
                        string urlOne = item1.InnerHtml.Trim().Replace(" ", string.Empty);
                        int indexOfUrlFirstOne = urlOne.IndexOf("=\"");
                        int indexOfUrlSecondOne = urlOne.IndexOf("g\"");
                        championFullSizeImageUrl = urlOne.Substring(indexOfUrlFirstOne + 1, indexOfUrlSecondOne - indexOfUrlFirstOne).Replace("\"", string.Empty);
                    }

                    string nicknameForChamp = string.Empty;
                    foreach (var item2 in doc2.DocumentNode.SelectNodes("//span[@class='style__Intro-sc-14gxj1e-2 fmCNnE']"))
                    {
                        nicknameForChamp = item2.InnerText.Replace("&#x27;", "'");
                    }

                    var championToAdd = new Champion
                    {
                        Name = championNameFull,
                        ImageIconUrl = championIconImageUrl,
                        ImageFullSizeUrl = championFullSizeImageUrl,
                        Nickname = nicknameForChamp,
                    };

                    await this.championsRepository.AddAsync(championToAdd);
                    count++;
                }
                else
                {
                    count++;
                }
            }

            await this.championsRepository.SaveChangesAsync();

            //foreach (var championNamee in this.championsRepository.All())
            //{
            //    HtmlAgilityPack.HtmlWeb web1 = new HtmlAgilityPack.HtmlWeb();
            //    string myUsedLink = string.Empty;
            //    if (championNamee.Name == "Nunu & Willump")
            //    {
            //        myUsedLink = $"https://na.leagueoflegends.com/en-us/champions/Name/".Replace("Name", "nunu");
            //    }
            //    else
            //    {
            //        myUsedLink = $"https://na.leagueoflegends.com/en-us/champions/Name/".Replace("Name", $"{championNamee.Name.Replace(".", string.Empty).ToLower().Replace("'", "-").ToString().Replace(" ", "-").ToString()}");
            //    }

            //    HtmlAgilityPack.HtmlDocument doc2 = web1.Load(myUsedLink);

            //    foreach (var item in doc2.DocumentNode.SelectNodes("//div[@class='style__ForegroundAsset-sc-1o884zt-4 cVdVkh']"))
            //    {
            //        string url = item.InnerHtml.Trim().Replace(" ", string.Empty);
            //        int indexOfUrlFirst = url.IndexOf("=\"");
            //        int indexOfUrlSecond = url.IndexOf("g\"");
            //        string championFullSizeImageUrl = url.Substring(indexOfUrlFirst + 1, indexOfUrlSecond - indexOfUrlFirst);
            //        championNamee.ImageFullSizeUrl = championFullSizeImageUrl.Replace("\"", string.Empty);
            //        this.championsRepository.Update(championNamee);
            //    }

            //    foreach (var item in doc2.DocumentNode.SelectNodes("//span[@class='style__Intro-sc-14gxj1e-2 fmCNnE']"))
            //    {
            //        championNamee.Nickname = item.InnerText;
            //        this.championsRepository.Update(championNamee);
            //    }
            //}
        }
    }
}
