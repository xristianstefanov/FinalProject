using System;
using LeagueOfLegendsChampions.Data;
using LeagueOfLegendsChampions.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LeagueOfLegendsChampions.Web.Areas.Identity.IdentityHostingStartup))]
namespace LeagueOfLegendsChampions.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}