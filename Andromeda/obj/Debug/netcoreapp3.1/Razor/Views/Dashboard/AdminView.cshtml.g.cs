#pragma checksum "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\AdminView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94ca64da683b6b7865df680153cba65b443b80ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_AdminView), @"mvc.1.0.view", @"/Views/Dashboard/AdminView.cshtml")]
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
#line 1 "E:\PROJECTS\Andromeda\Andromeda\Views\_ViewImports.cshtml"
using Andromeda;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\PROJECTS\Andromeda\Andromeda\Views\_ViewImports.cshtml"
using Andromeda.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94ca64da683b6b7865df680153cba65b443b80ac", @"/Views/Dashboard/AdminView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4edbb7b79fb90b2bb189387ba32eb606b12d084", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_AdminView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Andromeda.Models.DashboardVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\AdminView.cshtml"
  
    ViewData["Title"] = "AdminView";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""text-center"">

        <h1>ADMIN DASHBOARD</h1>

        <div class=""form-group"">
            <input type=""submit"" id=""btnAddEmployee"" value=""ADD EMPLOYEE"" class=""btn btn-primary"" />
            <input type=""submit"" id=""btnDailyReport"" value=""CHECK DTR"" class=""btn btn-primary"" />
        </div>

");
#nullable restore
#line 14 "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\AdminView.cshtml"
          
            if (Model.LogType == Andromeda.Application.Employee.Queries.LogType.TimeIn)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group\">\r\n                    <input type=\"submit\" id=\"btnTimeIn\" value=\"<< TIME IN >>\" class=\"btn btn-primary\" />\r\n                </div>\r\n");
#nullable restore
#line 20 "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\AdminView.cshtml"

            }
            else if (Model.LogType == Andromeda.Application.Employee.Queries.LogType.TimeOut)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group\">\r\n                    <input type=\"submit\" id=\"btnTimeOut\" value=\"<< TIME OUT >>\" class=\"btn btn-primary\" />\r\n                </div>\r\n");
#nullable restore
#line 28 "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\AdminView.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>*****</p>\r\n");
#nullable restore
#line 32 "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\AdminView.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Andromeda.Models.DashboardVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
