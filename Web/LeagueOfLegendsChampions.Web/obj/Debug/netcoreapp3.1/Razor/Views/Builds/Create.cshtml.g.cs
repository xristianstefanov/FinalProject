#pragma checksum "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d596c8a2c3b68181e72dad3cd22459d28d865e93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Builds_Create), @"mvc.1.0.view", @"/Views/Builds/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d596c8a2c3b68181e72dad3cd22459d28d865e93", @"/Views/Builds/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e0248e0a4407caccfad7dd88b26afb75dfa01bc", @"/Views/_ViewImports.cshtml")]
    public class Views_Builds_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LeagueOfLegendsChampions.Web.ViewModels.Builds.BuildInListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-md-6 offset-md-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
  
    ViewData["Title"] = "Create your build:";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d596c8a2c3b68181e72dad3cd22459d28d865e935872", async() => {
                WriteLiteral(@"
    <style>
        hr {
            border: none;
            border-top: 3px ridge floralwhite;
            color: floralwhite;
            overflow: visible;
            text-align: center;
            height: 5px;
        }

        h2 {
            color: floralwhite;
            text-align: center;
        }

        h1 {
            color: floralwhite;
            font-style: initial;
        }

        label {
            color: floralwhite;
        }

        .dropbtn {
            background-color: floralwhite;
            color: black;
            padding: 16px;
            font-size: 16px;
            border: none;
            cursor: pointer;
            width: 84px;
        }

        .dropdown {
            position: relative;
            display: inline-block;
        }

        .dropdown-content {
            display: none;
            position: absolute;
            padding: 5px 15px;
            background-color: floralwhite;
            box-sha");
                WriteLiteral(@"dow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
            width: 180px;
        }

        /*.dropdown-content a {
                color: black;
                padding: 12px 16px;
                text-decoration: none;
                display: block;
            }*/

        /*.dropdown-content a:hover {
                    background-color: floralwhite
                }*/

        .dropdown:hover .dropdown-content {
            display: inline-block;
        }

        .dropdown:hover .dropbtn {
            background-color: floralwhite;
        }


        .dropdown-content li {
            list-style-type: none;
            cursor: pointer;
        }

            .dropdown-content li img {
                width: 24px;
                display: inline-block;
            }

            .dropdown-content li p {
                display: inline-block;
            }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d596c8a2c3b68181e72dad3cd22459d28d865e938840", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d596c8a2c3b68181e72dad3cd22459d28d865e939106", async() => {
                    WriteLiteral("\r\n        <h2>");
#nullable restore
#line 94 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
       Write(this.ViewData["Title"]);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</h2>\r\n        <hr>\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d596c8a2c3b68181e72dad3cd22459d28d865e939689", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 96 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n        <div class=\"form-group\">\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d596c8a2c3b68181e72dad3cd22459d28d865e9311402", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 98 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d596c8a2c3b68181e72dad3cd22459d28d865e9312993", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 99 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d596c8a2c3b68181e72dad3cd22459d28d865e9314669", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 100 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n            <hr>\r\n");
#nullable restore
#line 114 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
              int counter = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
             foreach (var selectedItem in this.Model.SelectedItems)
            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                <div class=\"dropdown\">\r\n                    <div class=\"dropbtn\"");
                    BeginWriteAttribute("id", " id=\"", 3264, "\"", 3288, 2);
                    WriteAttributeValue("", 3269, "mainButton-", 3269, 11, true);
#nullable restore
#line 118 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
WriteAttributeValue("", 3280, counter, 3280, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">Item ");
#nullable restore
#line 118 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
                                                                  Write(selectedItem);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</div>\r\n                    <ul");
                    BeginWriteAttribute("id", " id=\"", 3339, "\"", 3363, 2);
                    WriteAttributeValue("", 3344, "items-", 3344, 6, true);
#nullable restore
#line 119 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
WriteAttributeValue("", 3350, selectedItem, 3350, 13, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    BeginWriteAttribute("name", " name=\"", 3364, "\"", 3389, 2);
                    WriteAttributeValue("", 3371, "Item-", 3371, 5, true);
#nullable restore
#line 119 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
WriteAttributeValue("", 3376, selectedItem, 3376, 13, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"dropdown-content\">\r\n");
#nullable restore
#line 120 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
                         foreach (var item in this.Model.Items)
                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                            <li class=\"dropdown-content-item\"");
                    BeginWriteAttribute("onclick", " onclick=\"", 3571, "\"", 3617, 5);
                    WriteAttributeValue("", 3581, "clickItemHandler(", 3581, 17, true);
#nullable restore
#line 122 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
WriteAttributeValue("", 3598, item.Id, 3598, 8, false);

#line default
#line hidden
#nullable disable
                    WriteAttributeValue("", 3606, ",", 3606, 1, true);
#nullable restore
#line 122 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
WriteAttributeValue(" ", 3607, counter, 3608, 8, false);

#line default
#line hidden
#nullable disable
                    WriteAttributeValue("", 3616, ")", 3616, 1, true);
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                                <p>");
#nullable restore
#line 123 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
                              Write(item.Name);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</p>\r\n                                <img src=\"http://ddragon.leagueoflegends.com/cdn/10.20.1/img/champion/Aatrox.png\" />\r\n                            </li>\r\n");
#nullable restore
#line 126 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"
                        }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                    </ul>\r\n                </div>\r\n");
#nullable restore
#line 129 "C:\Users\xrist\OneDrive\Desktop\MyFirstAspNetProject\Web\LeagueOfLegendsChampions.Web\Views\Builds\Create.cshtml"

                counter++;
            }

#line default
#line hidden
#nullable disable
                    WriteLiteral("            <hr>\r\n        </div>\r\n        <input type=\"submit\" class=\"btn btn-outline-white\" />\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script>
        //$(document).ready(function () {
        //    $("".dropdown-content-item"").click(function (event) {
        //        console.log(event)
        //    });
        //})
        function clickItemHandler(itemId, mainButtonId) {
            console.log(itemId)
            console.log(mainButtonId)
            debugger
            var newText = document.getElementById(itemId).innerHTML
            document.getElementById(mainButtonId).innerHTML=newText
        }
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LeagueOfLegendsChampions.Web.ViewModels.Builds.BuildInListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591