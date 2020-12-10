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
        public ChampionScraperService(IDeletableEntityRepository<Champion> championsRepository, IDeletableEntityRepository<Item> itemsRepository, IDeletableEntityRepository<Skill> skillsRepository)
        {
            this.championsRepository = championsRepository;
            this.itemsRepository = itemsRepository;
            this.skillsRepository = skillsRepository;
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

            //HtmlAgilityPack.HtmlWeb web10 = new HtmlAgilityPack.HtmlWeb();
            //HtmlAgilityPack.HtmlDocument doc10 = web10.Load("https://rankedboost.com/league-of-legends/items-update-2020/");
            //int count1 = 0;

            //foreach (var item10 in doc10.DocumentNode.SelectNodes("//a[@class='sim-champ-a']"))
            //{
            //    if (count1 > 171)
            //    {
            //        break;
            //    }

            //    string textForNames = item10.InnerHtml.Trim();
            //    int indexOfTextForNamesFirst = textForNames.IndexOf("title=");
            //    int indexOfTextForNamesSecond = textForNames.IndexOf("class");
            //    string namesOfItems = textForNames.Substring(indexOfTextForNamesFirst, indexOfTextForNamesSecond - indexOfTextForNamesFirst);
            //    string name = namesOfItems.Replace("title=", string.Empty).ToString().Replace("\"", string.Empty).Trim();
            //    string urlForImages = item10.InnerHtml;
            //    int indexOfUrlForImagesFirst = urlForImages.IndexOf("data-lazy-src=");
            //    int indexOfUrlForImagesSecond = urlForImages.IndexOf(".png");
            //    string imageUrlForItems = urlForImages.Substring(indexOfUrlForImagesFirst, indexOfUrlForImagesSecond + 4 - indexOfUrlForImagesFirst);
            //    string finalUrl = imageUrlForItems.Replace("data-lazy-src=\"", string.Empty).Trim();

            //    var itemToAdd = new Item
            //    {
            //        Name = name,
            //        ImageUrl = finalUrl,
            //    };

            //    await this.itemsRepository.AddAsync(itemToAdd);
            //    count1++;
            //}

            //await this.itemsRepository.SaveChangesAsync();

            foreach (var champion in this.championsRepository.AllAsNoTracking().OrderBy(c => c.Name))
            {
                string champNameToUseForSkillLevels = string.Empty;

                if (champion.Name == "Nunu & Willump")
                {
                    champNameToUseForSkillLevels = "nunu";
                }
                else if (champion.Name == "Kai'Sa")
                {
                    champNameToUseForSkillLevels = "kaisa";
                }
                else
                {
                    champNameToUseForSkillLevels = champion.Name.Replace(".", string.Empty).ToLower().Replace("'", "-").ToString().Replace(" ", "-").ToString();
                }

                List<int> qLevels = new List<int>();
                List<int> wLevels = new List<int>();
                List<int> eLevels = new List<int>();
                List<int> rLevels = new List<int>();

                if (champNameToUseForSkillLevels == "aphelios" || champNameToUseForSkillLevels == "jayce" || champNameToUseForSkillLevels == "udyr")
                {
                    qLevels = new List<int> { 1, 2, 3, 5, 7 };
                    wLevels = new List<int> { 4, 6, 8, 10, 11 };
                    eLevels = new List<int> { 13, 14, 15, 16, 17 };
                    rLevels = new List<int> { 9, 12, 18 };
                }
                else
                {
                    HtmlAgilityPack.HtmlWeb web11 = new HtmlAgilityPack.HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc11 = web11.Load("https://rankedboost.com/league-of-legends/build/Name/".Replace("Name", champNameToUseForSkillLevels));

                    int counterForLevels = 1;

                    foreach (var skillLevel in doc11.DocumentNode.SelectNodes("//td[@class='rb-build-skill-seq-td']"))
                    {
                        if (skillLevel.InnerText == "Q")
                        {
                            qLevels.Add(counterForLevels);
                            counterForLevels++;
                        }
                        else if (skillLevel.InnerText == "W")
                        {
                            wLevels.Add(counterForLevels);
                            counterForLevels++;
                        }
                        else if (skillLevel.InnerText == "E")
                        {
                            eLevels.Add(counterForLevels);
                            counterForLevels++;
                        }
                        else if (skillLevel.InnerText == "R")
                        {
                            rLevels.Add(counterForLevels);
                            counterForLevels++;
                        }
                    }
                }


                string champNameToUseForSkill = string.Empty;

                if (champion.Name == "Nunu & Willump")
                {
                    champNameToUseForSkill = "nunu";
                }
                else
                {
                    champNameToUseForSkill = champion.Name.Replace(".", string.Empty).ToLower().Replace("'", string.Empty).ToString().Replace(" ", string.Empty).ToString();
                }

                HtmlAgilityPack.HtmlWeb web10 = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc10 = web10.Load("https://u.gg/lol/champions/Name/build".Replace("Name", champNameToUseForSkill));
                int countToUseForSkills = 0;

                foreach (var item10 in doc10.DocumentNode.SelectNodes("//div[@class='skill-order-row']"))
                {
                    string text = item10.InnerHtml;
                    string textForNames = item10.InnerText;
                    int indexOfTextForNamesFirst = text.IndexOf("src=");
                    int indexOfTextForNamesSecond = text.IndexOf(".png");

                    string skillImageUrl = text.Substring(indexOfTextForNamesFirst + 5, indexOfTextForNamesSecond - indexOfTextForNamesFirst).Replace("\"", string.Empty);
                    string skillName = Regex.Replace(textForNames, "[0-9]{2,}", string.Empty).Remove(0, 1).ToString();

                    if (countToUseForSkills == 0)
                    {
                        var skillToAdd = new Skill
                        {
                            ChampionId = champion.Id,
                            Name = skillName.Replace("&#x;", "'"),
                            SkillImageUrl = skillImageUrl,
                            FirstLevelToUpgrade = qLevels[0],
                            SecondLevelToUpgrade = qLevels[1],
                            ThirdLevelToUpgrade = qLevels[2],
                            FourthLevelToUpgrade = qLevels[3],
                            FifthLevelToUpgrade = qLevels[4],
                        };

                        await this.skillsRepository.AddAsync(skillToAdd);
                    }
                    else if (countToUseForSkills == 1)
                    {
                        var skillToAdd = new Skill
                        {
                            ChampionId = champion.Id,
                            Name = skillName.Replace("&#x;", "'"),
                            SkillImageUrl = skillImageUrl,
                            FirstLevelToUpgrade = wLevels[0],
                            SecondLevelToUpgrade = wLevels[1],
                            ThirdLevelToUpgrade = wLevels[2],
                            FourthLevelToUpgrade = wLevels[3],
                            FifthLevelToUpgrade = wLevels[4],
                        };

                        await this.skillsRepository.AddAsync(skillToAdd);
                    }
                    else if (countToUseForSkills == 2)
                    {
                        var skillToAdd = new Skill
                        {
                            ChampionId = champion.Id,
                            Name = skillName.Replace("&#x;", "'"),
                            SkillImageUrl = skillImageUrl,
                            FirstLevelToUpgrade = eLevels[0],
                            SecondLevelToUpgrade = eLevels[1],
                            ThirdLevelToUpgrade = eLevels[2],
                            FourthLevelToUpgrade = eLevels[3],
                            FifthLevelToUpgrade = eLevels[4],
                        };

                        await this.skillsRepository.AddAsync(skillToAdd);
                    }
                    else if (countToUseForSkills == 3)
                    {
                        if (rLevels.Count > 2)
                        {
                            var skillToAdd = new Skill
                            {
                                ChampionId = champion.Id,
                                Name = skillName.Replace("&#x;", "'"),
                                SkillImageUrl = skillImageUrl,
                                FirstLevelToUpgrade = rLevels[0],
                                SecondLevelToUpgrade = rLevels[1],
                                ThirdLevelToUpgrade = rLevels[2],
                                FourthLevelToUpgrade = 0,
                                FifthLevelToUpgrade = 0,
                            };

                            await this.skillsRepository.AddAsync(skillToAdd);
                        }
                        else
                        {
                            var skillToAdd = new Skill
                            {
                                ChampionId = champion.Id,
                                Name = skillName.Replace("&#x;", "'"),
                                SkillImageUrl = skillImageUrl,
                                FirstLevelToUpgrade = 25,
                                SecondLevelToUpgrade = 25,
                                ThirdLevelToUpgrade = 25,
                                FourthLevelToUpgrade = 0,
                                FifthLevelToUpgrade = 0,
                            };

                            await this.skillsRepository.AddAsync(skillToAdd);
                        }
                    }
                    else
                    {
                        var skillToAdd = new Skill
                        {
                            ChampionId = champion.Id,
                            Name = skillName.Replace("&#x;", "'"),
                            SkillImageUrl = skillImageUrl,
                            FirstLevelToUpgrade = 0,
                            SecondLevelToUpgrade = 0,
                            ThirdLevelToUpgrade = 0,
                            FourthLevelToUpgrade = 0,
                            FifthLevelToUpgrade = 0,
                        };

                        await this.skillsRepository.AddAsync(skillToAdd);
                    }

                    countToUseForSkills++;
                }

                countToUseForSkills = 0;
            }

            await this.skillsRepository.SaveChangesAsync();
        }
    }
}
