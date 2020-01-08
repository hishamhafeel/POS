#pragma checksum "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\RightSideBar\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4c1a7f9a5839013067b0c54b307ac87dcc68af8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_RightSideBar_Default), @"mvc.1.0.view", @"/Views/Shared/Components/RightSideBar/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/RightSideBar/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_RightSideBar_Default))]
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
#line 1 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\RightSideBar\Default.cshtml"
using Pos.Configuration.Ui;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4c1a7f9a5839013067b0c54b307ac87dcc68af8", @"/Views/Shared/Components/RightSideBar/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b330e1eb204d7d943e394df42c33964e609f73c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_RightSideBar_Default : Pos.Web.Views.PosRazorPage<Pos.Web.Views.Shared.Components.RightSideBar.RightSideBarViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(102, 189, true);
            WriteLiteral("<aside id=\"rightsidebar\" class=\"right-sidebar\">\n    <ul class=\"nav nav-tabs tab-nav-right\" role=\"tablist\">\n        <li role=\"presentation\" class=\"active\"><a href=\"#skins\" data-toggle=\"tab\">");
            EndContext();
            BeginContext(292, 10, false);
#line 5 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\RightSideBar\Default.cshtml"
                                                                             Write(L("Skins"));

#line default
#line hidden
            EndContext();
            BeginContext(302, 80, true);
            WriteLiteral("</a></li>\n        <li role=\"presentation\"><a href=\"#settings\" data-toggle=\"tab\">");
            EndContext();
            BeginContext(383, 13, false);
#line 6 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\RightSideBar\Default.cshtml"
                                                                 Write(L("Settings"));

#line default
#line hidden
            EndContext();
            BeginContext(396, 175, true);
            WriteLiteral("</a></li>\n    </ul>\n    <div class=\"tab-content\">\n        <div role=\"tabpanel\" class=\"tab-pane fade in active in active\" id=\"skins\">\n            <ul class=\"demo-choose-skin\">\n");
            EndContext();
#line 11 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\RightSideBar\Default.cshtml"
                 foreach (var theme in UiThemes.All)
                {

#line default
#line hidden
            BeginContext(642, 36, true);
            WriteLiteral("                    <li data-theme=\"");
            EndContext();
            BeginContext(679, 14, false);
#line 13 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\RightSideBar\Default.cshtml"
                               Write(theme.CssClass);

#line default
#line hidden
            EndContext();
            BeginContext(693, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 694, "\"", 766, 1);
#line 13 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\RightSideBar\Default.cshtml"
WriteAttributeValue("", 702, theme.CssClass == Model.CurrentTheme.CssClass ? "active" : "", 702, 64, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(767, 30, true);
            WriteLiteral(">\n                        <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 797, "\"", 820, 1);
#line 14 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\RightSideBar\Default.cshtml"
WriteAttributeValue("", 805, theme.CssClass, 805, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(821, 38, true);
            WriteLiteral("></div>\n                        <span>");
            EndContext();
            BeginContext(860, 10, false);
#line 15 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\RightSideBar\Default.cshtml"
                         Write(theme.Name);

#line default
#line hidden
            EndContext();
            BeginContext(870, 34, true);
            WriteLiteral("</span>\n                    </li>\n");
            EndContext();
#line 17 "D:\Training\Programs\Pos\4.8.0\aspnet-core\src\Pos.Web.Mvc\Views\Shared\Components\RightSideBar\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(922, 2275, true);
            WriteLiteral(@"            </ul>
        </div>
        <div role=""tabpanel"" class=""tab-pane fade"" id=""settings"">
            <div class=""demo-settings"">
                <p>GENERAL SETTINGS</p>
                <ul class=""setting-list"">
                    <li>
                        <span>Report Panel Usage</span>
                        <div class=""switch"">
                            <label><input type=""checkbox"" checked><span class=""lever""></span></label>
                        </div>
                    </li>
                    <li>
                        <span>Email Redirect</span>
                        <div class=""switch"">
                            <label><input type=""checkbox""><span class=""lever""></span></label>
                        </div>
                    </li>
                </ul>
                <p>SYSTEM SETTINGS</p>
                <ul class=""setting-list"">
                    <li>
                        <span>Notifications</span>
                        <div class=""switch"">
                     ");
            WriteLiteral(@"       <label><input type=""checkbox"" checked><span class=""lever""></span></label>
                        </div>
                    </li>
                    <li>
                        <span>Auto Updates</span>
                        <div class=""switch"">
                            <label><input type=""checkbox"" checked><span class=""lever""></span></label>
                        </div>
                    </li>
                </ul>
                <p>ACCOUNT SETTINGS</p>
                <ul class=""setting-list"">
                    <li>
                        <span>Offline</span>
                        <div class=""switch"">
                            <label><input type=""checkbox""><span class=""lever""></span></label>
                        </div>
                    </li>
                    <li>
                        <span>Location Permission</span>
                        <div class=""switch"">
                            <label><input type=""checkbox"" checked><span class=""lever""></span></label>
        ");
            WriteLiteral("                </div>\n                    </li>\n                </ul>\n                \n                <p style=\"color: red;\">This settings are just for demonstration!</p>\n            </div>\n        </div>\n    </div>\n</aside>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pos.Web.Views.Shared.Components.RightSideBar.RightSideBarViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
