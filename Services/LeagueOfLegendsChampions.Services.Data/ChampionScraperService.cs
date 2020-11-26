namespace LeagueOfLegendsChampions.Services.Data
{
    using System;
    using System.Text.RegularExpressions;
    public class ChampionScraperService : IChampionScraperService
    {
        //public void ImportChampionssAsync()
        //{
        //    HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
        //    HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://champion.gg/");
        //    int count = 0;

        //    foreach (var item in doc1.DocumentNode.SelectNodes("//div[@class='tsm-tooltip']"))
        //    {
        //        if (count > 19)
        //        {
        //            string url = item.InnerHtml.Trim().Replace(" ", string.Empty);
        //            int indexOfUrlFirst = url.IndexOf("('");
        //            int indexOfUrlSecond = url.IndexOf("')");
        //            string championIconImageUrl = url.Substring(indexOfUrlFirst, indexOfUrlSecond - indexOfUrlFirst).Replace("('", string.Empty);

        //            string championName = Regex.Replace(item.InnerText, @"\t|\n|\r", string.Empty);
        //            Console.WriteLine(championName.Replace("&#39;", "'").Trim().ToString().Replace("&amp;", "&"));
        //            Console.WriteLine(championIconImageUrl);
        //            count++;
        //        }
        //        else
        //        {
        //            count++;
        //        }
        //    }
        //}
    }
}
