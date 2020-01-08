#pragma checksum "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37c40c9cd066e169c695861bfbe79407756cedc4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_SideBarNav_Default), @"mvc.1.0.view", @"/Views/Shared/Components/SideBarNav/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/SideBarNav/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_SideBarNav_Default))]
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
#line 1 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\_ViewImports.cshtml"
using Abp.Localization;

#line default
#line hidden
#line 1 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
using Abp.Collections.Extensions;

#line default
#line hidden
#line 2 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
using Pos.Web.Views;

#line default
#line hidden
#line 3 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
using Pos.Web.Views.Shared.Components.SideBarNav;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37c40c9cd066e169c695861bfbe79407756cedc4", @"/Views/Shared/Components/SideBarNav/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b330e1eb204d7d943e394df42c33964e609f73c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_SideBarNav_Default : Pos.Web.Views.PosRazorPage<SideBarNavViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 5 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
  
    var calculateMenuUrl = new Func<string, string>((url) =>
    {
        if (string.IsNullOrEmpty(url))
        {
            return ApplicationPath;
        }

        if (UrlChecker.IsRooted(url))
        {
            return url;
        }

        return ApplicationPath + url;
    });

#line default
#line hidden
            BeginContext(429, 41, true);
            WriteLiteral("<div class=\"menu\">\n    <ul class=\"list\">\n");
            EndContext();
#line 23 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
         foreach (var menuItem in Model.MainMenu.Items)
        {

#line default
#line hidden
            BeginContext(536, 15, true);
            WriteLiteral("            <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 551, "\"", 619, 1);
#line 25 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
WriteAttributeValue("", 559, Model.ActiveMenuItemName == menuItem.Name ? "active" : "", 559, 60, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(620, 2, true);
            WriteLiteral(">\n");
            EndContext();
#line 26 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                 if (menuItem.Items.IsNullOrEmpty())
                {

#line default
#line hidden
            BeginContext(693, 22, true);
            WriteLiteral("                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 715, "\"", 753, 1);
#line 28 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
WriteAttributeValue("", 722, calculateMenuUrl(menuItem.Url), 722, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(754, 2, true);
            WriteLiteral(">\n");
            EndContext();
#line 29 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                         if (!string.IsNullOrWhiteSpace(menuItem.Icon))
                        {

#line default
#line hidden
            BeginContext(854, 54, true);
            WriteLiteral("                            <i class=\"material-icons\">");
            EndContext();
            BeginContext(909, 13, false);
#line 31 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                                 Write(menuItem.Icon);

#line default
#line hidden
            EndContext();
            BeginContext(922, 5, true);
            WriteLiteral("</i>\n");
            EndContext();
#line 32 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                        }

#line default
#line hidden
            BeginContext(953, 30, true);
            WriteLiteral("                        <span>");
            EndContext();
            BeginContext(984, 20, false);
#line 33 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                         Write(menuItem.DisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(1004, 33, true);
            WriteLiteral("</span>\n                    </a>\n");
            EndContext();
#line 35 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1094, 71, true);
            WriteLiteral("                    <a href=\"javascript:void(0);\" class=\"menu-toggle\">\n");
            EndContext();
#line 39 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                         if (!string.IsNullOrWhiteSpace(menuItem.Icon))
                        {

#line default
#line hidden
            BeginContext(1263, 54, true);
            WriteLiteral("                            <i class=\"material-icons\">");
            EndContext();
            BeginContext(1318, 13, false);
#line 41 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                                 Write(menuItem.Icon);

#line default
#line hidden
            EndContext();
            BeginContext(1331, 5, true);
            WriteLiteral("</i>\n");
            EndContext();
#line 42 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                        }

#line default
#line hidden
            BeginContext(1362, 30, true);
            WriteLiteral("                        <span>");
            EndContext();
            BeginContext(1393, 20, false);
#line 43 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                         Write(menuItem.DisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(1413, 74, true);
            WriteLiteral("</span>\n                    </a>\n                    <ul class=\"ml-menu\">\n");
            EndContext();
#line 46 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                         foreach (var subMenuItem in menuItem.Items)
                        {

#line default
#line hidden
            BeginContext(1582, 31, true);
            WriteLiteral("                            <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1613, "\"", 1684, 1);
#line 48 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
WriteAttributeValue("", 1621, Model.ActiveMenuItemName == subMenuItem.Name ? "active" : "", 1621, 63, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1685, 2, true);
            WriteLiteral(">\n");
            EndContext();
#line 49 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                 if (subMenuItem.Items.IsNullOrEmpty())
                                {

#line default
#line hidden
            BeginContext(1793, 38, true);
            WriteLiteral("                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1831, "\"", 1872, 1);
#line 51 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
WriteAttributeValue("", 1838, calculateMenuUrl(subMenuItem.Url), 1838, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1873, 2, true);
            WriteLiteral(">\n");
            EndContext();
#line 52 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                         if (!string.IsNullOrWhiteSpace(subMenuItem.Icon))
                                        {

#line default
#line hidden
            BeginContext(2008, 70, true);
            WriteLiteral("                                            <i class=\"material-icons\">");
            EndContext();
            BeginContext(2079, 16, false);
#line 54 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                                                 Write(subMenuItem.Icon);

#line default
#line hidden
            EndContext();
            BeginContext(2095, 5, true);
            WriteLiteral("</i>\n");
            EndContext();
#line 55 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                        }

#line default
#line hidden
            BeginContext(2142, 46, true);
            WriteLiteral("                                        <span>");
            EndContext();
            BeginContext(2189, 23, false);
#line 56 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                         Write(subMenuItem.DisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(2212, 49, true);
            WriteLiteral("</span>\n                                    </a>\n");
            EndContext();
#line 58 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(2366, 87, true);
            WriteLiteral("                                    <a href=\"javascript:void(0);\" class=\"menu-toggle\">\n");
            EndContext();
#line 62 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                         if (!string.IsNullOrWhiteSpace(subMenuItem.Icon))
                                        {

#line default
#line hidden
            BeginContext(2586, 70, true);
            WriteLiteral("                                            <i class=\"material-icons\">");
            EndContext();
            BeginContext(2657, 16, false);
#line 64 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                                                 Write(subMenuItem.Icon);

#line default
#line hidden
            EndContext();
            BeginContext(2673, 5, true);
            WriteLiteral("</i>\n");
            EndContext();
#line 65 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                        }

#line default
#line hidden
            BeginContext(2720, 46, true);
            WriteLiteral("                                        <span>");
            EndContext();
            BeginContext(2767, 23, false);
#line 66 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                         Write(subMenuItem.DisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(2790, 106, true);
            WriteLiteral("</span>\n                                    </a>\n                                    <ul class=\"ml-menu\">\n");
            EndContext();
#line 69 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                         foreach (var subSubMenuItem in subMenuItem.Items)
                                        {

#line default
#line hidden
            BeginContext(3029, 47, true);
            WriteLiteral("                                            <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 3076, "\"", 3150, 1);
#line 71 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
WriteAttributeValue("", 3084, Model.ActiveMenuItemName == subSubMenuItem.Name ? "active" : "", 3084, 66, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3151, 52, true);
            WriteLiteral(">\n                                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3203, "\"", 3247, 1);
#line 72 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
WriteAttributeValue("", 3210, calculateMenuUrl(subSubMenuItem.Url), 3210, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3248, 54, true);
            WriteLiteral(">\n                                                    ");
            EndContext();
            BeginContext(3303, 26, false);
#line 73 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                               Write(subSubMenuItem.DisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(3329, 104, true);
            WriteLiteral("\n                                                </a>\n                                            </li>\n");
            EndContext();
#line 76 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                        }

#line default
#line hidden
            BeginContext(3475, 42, true);
            WriteLiteral("                                    </ul>\n");
            EndContext();
#line 78 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                                }

#line default
#line hidden
            BeginContext(3551, 34, true);
            WriteLiteral("                            </li>\n");
            EndContext();
#line 80 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                        }

#line default
#line hidden
            BeginContext(3611, 26, true);
            WriteLiteral("                    </ul>\n");
            EndContext();
#line 82 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(3655, 18, true);
            WriteLiteral("            </li>\n");
            EndContext();
#line 84 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\SideBarNav\Default.cshtml"
        }

#line default
#line hidden
            BeginContext(3683, 17, true);
            WriteLiteral("    </ul>\n</div>\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SideBarNavViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
