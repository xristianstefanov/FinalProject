#pragma checksum "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Skins\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f8cef1acf9566ab93d74100a4676128a584b983"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Skins_All), @"mvc.1.0.view", @"/Views/Skins/All.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\_ViewImports.cshtml"
using LeagueOfLegendsChampions.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\_ViewImports.cshtml"
using LeagueOfLegendsChampions.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f8cef1acf9566ab93d74100a4676128a584b983", @"/Views/Skins/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e0248e0a4407caccfad7dd88b26afb75dfa01bc", @"/Views/_ViewImports.cshtml")]
    public class Views_Skins_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LeagueOfLegendsChampions.Web.ViewModels.Skins.SkinsForSingleChampViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Skins\All.cshtml"
  
    ViewData["Title"] = "All";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 style=\"color:floralwhite\">");
#nullable restore
#line 6 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Skins\All.cshtml"
                         Write(this.Model.ChampionName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div id=\"carouselExampleControls\" class=\"carousel slide\" data-ride=\"carousel\">\r\n    <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 10 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Skins\All.cshtml"
         foreach (var skin in this.Model.Skins)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"carousel-item active\">\r\n                <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 451, "\"", 475, 1);
#nullable restore
#line 13 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Skins\All.cshtml"
WriteAttributeValue("", 457, skin.SkinImageUrl, 457, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"First slide\">\r\n            </div>\r\n");
#nullable restore
#line 15 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Skins\All.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    <a class=""carousel-control-prev"" href=""#carouselExampleControls"" role=""button"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Previous</span>
    </a>
    <a class=""carousel-control-next"" href=""#carouselExampleControls"" role=""button"" data-slide=""next"">
        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Next</span>
    </a>
</div>

");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LeagueOfLegendsChampions.Web.ViewModels.Skins.SkinsForSingleChampViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591