#pragma checksum "D:\GitHub\terziyski-clima\TerziyskiClima\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ad24c08f5637db69d9690ef36fc77b81364310f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\GitHub\terziyski-clima\TerziyskiClima\Views\_ViewImports.cshtml"
using TerziyskiClima;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\terziyski-clima\TerziyskiClima\Views\_ViewImports.cshtml"
using TerziyskiClima.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ad24c08f5637db69d9690ef36fc77b81364310f", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef0f5f34d7967cf5fd0341a8863f3d4b276f1b07", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\GitHub\terziyski-clima\TerziyskiClima\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center color-scheme\">\r\n    <p class=\"display-4\">Welcome, ");
#nullable restore
#line 6 "D:\GitHub\terziyski-clima\TerziyskiClima\Views\Home\Index.cshtml"
                                   if (User.Identity.IsAuthenticated) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p>");
#nullable restore
#line 6 "D:\GitHub\terziyski-clima\TerziyskiClima\Views\Home\Index.cshtml"
                                                                      Write(User.Claims.ToList()[1].Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p> ");
#nullable restore
#line 6 "D:\GitHub\terziyski-clima\TerziyskiClima\Views\Home\Index.cshtml"
                                                                                                              }

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
