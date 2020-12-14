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
            HtmlAgilityPack.HtmlWeb webForChampions = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument docForChampions = webForChampions.Load("https://champion.gg/");
            int countForChampions = 0;

            foreach (var currentChampion in docForChampions.DocumentNode.SelectNodes("//div[@class='tsm-tooltip']"))
            {
                if (countForChampions > 19)
                {
                    string url = currentChampion.InnerHtml.Trim().Replace(" ", string.Empty);
                    int indexOfUrlFirst = url.IndexOf("('");
                    int indexOfUrlSecond = url.IndexOf("')");
                    string championIconImageUrl = url.Substring(indexOfUrlFirst, indexOfUrlSecond - indexOfUrlFirst).Replace("('", string.Empty);
                    string championName = Regex.Replace(currentChampion.InnerText, @"\t|\n|\r", string.Empty);
                    string championNameFull = championName.Replace("&#39;", "'").Trim().ToString().Replace("&amp;", "&");

                    HtmlAgilityPack.HtmlWeb webForChampionsNicknames = new HtmlAgilityPack.HtmlWeb();
                    string myUsedLink = string.Empty;

                    if (championNameFull == "Nunu & Willump")
                    {
                        myUsedLink = $"https://na.leagueoflegends.com/en-us/champions/Name/".Replace("Name", "nunu");
                    }
                    else
                    {
                        myUsedLink = $"https://na.leagueoflegends.com/en-us/champions/Name/".Replace("Name", $"{championNameFull.Replace(".", string.Empty).ToLower().Replace("'", "-").ToString().Replace(" ", "-").ToString()}");
                    }

                    HtmlAgilityPack.HtmlDocument docForChampionsNicknames = webForChampionsNicknames.Load(myUsedLink);

                    string championFullSizeImageUrl = string.Empty;
                    foreach (var itemUsedForChampPage in docForChampionsNicknames.DocumentNode.SelectNodes("//div[@class='style__ForegroundAsset-sc-1o884zt-4 cVdVkh']"))
                    {
                        string urlOne = itemUsedForChampPage.InnerHtml.Trim().Replace(" ", string.Empty);
                        int indexOfUrlFirstOne = urlOne.IndexOf("=\"");
                        int indexOfUrlSecondOne = urlOne.IndexOf("g\"");
                        championFullSizeImageUrl = urlOne.Substring(indexOfUrlFirstOne + 1, indexOfUrlSecondOne - indexOfUrlFirstOne).Replace("\"", string.Empty);
                    }

                    string nicknameForChamp = string.Empty;
                    foreach (var itemForNicknames in docForChampionsNicknames.DocumentNode.SelectNodes("//span[@class='style__Intro-sc-14gxj1e-2 fmCNnE']"))
                    {
                        nicknameForChamp = itemForNicknames.InnerText.Replace("&#x27;", "'");
                    }

                    var championToAdd = new Champion
                    {
                        Name = championNameFull,
                        ImageIconUrl = championIconImageUrl,
                        ImageFullSizeUrl = championFullSizeImageUrl,
                        Nickname = nicknameForChamp,
                    };

                    await this.championsRepository.AddAsync(championToAdd);

                    countForChampions++;
                }
                else
                {
                    countForChampions++;
                }
            }

            await this.championsRepository.SaveChangesAsync();

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
                    HtmlAgilityPack.HtmlWeb webForSkillLevels = new HtmlAgilityPack.HtmlWeb();
                    HtmlAgilityPack.HtmlDocument docForSkillLevels = webForSkillLevels.Load("https://rankedboost.com/league-of-legends/build/Name/".Replace("Name", champNameToUseForSkillLevels));

                    int counterForLevels = 1;

                    foreach (var skillLevel in docForSkillLevels.DocumentNode.SelectNodes("//td[@class='rb-build-skill-seq-td']"))
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

                HtmlAgilityPack.HtmlWeb webForSkills = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument docForSkills = webForSkills.Load("https://u.gg/lol/champions/Name/build".Replace("Name", champNameToUseForSkill));
                int countToUseForSkills = 0;

                foreach (var item10 in docForSkills.DocumentNode.SelectNodes("//div[@class='skill-order-row']"))
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
                        if (eLevels.Count > 4)
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
                        else
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
                                FifthLevelToUpgrade = 26,
                            };

                            await this.skillsRepository.AddAsync(skillToAdd);
                        }
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
                                FirstLevelToUpgrade = rLevels[0],
                                SecondLevelToUpgrade = rLevels[1],
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

            foreach (var neededChampForSkins in this.championsRepository.AllAsNoTracking())
            {
                HtmlAgilityPack.HtmlWeb webForSkins = new HtmlAgilityPack.HtmlWeb();

                string myUsedLinkForSkins = string.Empty;
                if (neededChampForSkins.Name == "Nunu & Willump")
                {
                    myUsedLinkForSkins = $"https://na.leagueoflegends.com/en-us/champions/Name/".Replace("Name", "nunu");
                }
                else
                {
                    myUsedLinkForSkins = $"https://na.leagueoflegends.com/en-us/champions/Name/".Replace("Name", $"{neededChampForSkins.Name.Replace(".", string.Empty).ToLower().Replace("'", "-").ToString().Replace(" ", "-").ToString()}");
                }

                HtmlAgilityPack.HtmlDocument docForSkins = webForSkins.Load(myUsedLinkForSkins);
                var textForSkinsList = docForSkins.DocumentNode.SelectNodes("//div[@class='style__CarouselItemThumb-sc-1tlyqoa-15 csknpA']");
                var textForSkinsNames = docForSkins.DocumentNode.SelectNodes("//label[@class='style__CarouselItemText-sc-1tlyqoa-16 oOgWZ']");

                for (int i = 0; i < textForSkinsList.Count; i++)
                {
                    string skinText = textForSkinsList[i].InnerHtml;
                    int indexOfTextForSkin = skinText.IndexOf("src=\"");
                    int indexOfTextForSkinSecond = skinText.IndexOf(".jpg");
                    string skinImgUrls = skinText.Substring(indexOfTextForSkin + 4, indexOfTextForSkinSecond - indexOfTextForSkin).Replace("\"", string.Empty);

                    string skinName = string.Empty;
                    for (int t = 0; t < textForSkinsNames.Count; t++)
                    {
                        if (i == t)
                        {
                            skinName = textForSkinsNames[t].InnerText;
                        }
                    }

                    var skinToAdd = new Skin
                    {
                        ChampionId = neededChampForSkins.Id,
                        SkinName = skinName,
                        SkinImageUrl = skinImgUrls,
                    };

                    await this.skinsRepository.AddAsync(skinToAdd);
                }
            }

            await this.skinsRepository.SaveChangesAsync();

            foreach (var championWithRunes in this.championsRepository.AllAsNoTracking().OrderBy(c => c.Name))
            {
                string champNameToUseForRunes = string.Empty;

                if (championWithRunes.Name == "Nunu & Willump")
                {
                    champNameToUseForRunes = "nunu";
                }
                else if (championWithRunes.Name == "Kai'Sa")
                {
                    champNameToUseForRunes = "kaisa";
                }
                else
                {
                    champNameToUseForRunes = championWithRunes.Name.Replace(".", string.Empty).ToLower().Replace("'", "-").ToString().Replace(" ", "-").ToString();
                }

                HtmlAgilityPack.HtmlWeb webForRunes = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument docForRunes = webForRunes.Load("https://rankedboost.com/league-of-legends/build/Name/".Replace("Name", champNameToUseForRunes));

                foreach (var rune in docForRunes.DocumentNode.SelectNodes("//div[@class='rb-build-runes-keystone-slot']"))
                {
                    string textForRune = rune.InnerHtml;
                    int indexOfTextForRunesFirst = textForRune.IndexOf("-src=");
                    int indexOfTextForRunesSecond = textForRune.IndexOf(".png");
                    string runeImageUrl = textForRune.Substring(indexOfTextForRunesFirst + 5, indexOfTextForRunesSecond - indexOfTextForRunesFirst).Replace("\"", string.Empty);
                    string runeName = rune.InnerText;

                    var runeToAdd = new Rune
                    {
                        ChampionId = championWithRunes.Id,
                        Name = runeName,
                        RuneImgUrl = runeImageUrl,
                    };

                    await this.runesRepository.AddAsync(runeToAdd);
                }
            }

            await this.runesRepository.SaveChangesAsync();
        }
    }
}
