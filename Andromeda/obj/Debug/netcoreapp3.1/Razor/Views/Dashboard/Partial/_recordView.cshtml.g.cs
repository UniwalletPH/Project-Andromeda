#pragma checksum "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\Partial\_recordView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2101d136a010ba2c4f90f1bec9f82118229a441"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Partial__recordView), @"mvc.1.0.view", @"/Views/Dashboard/Partial/_recordView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2101d136a010ba2c4f90f1bec9f82118229a441", @"/Views/Dashboard/Partial/_recordView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4edbb7b79fb90b2bb189387ba32eb606b12d084", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Partial__recordView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Andromeda.Models.TimeRecordVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\Partial\_recordView.cshtml"
  
    ViewData["Title"] = "_recordView";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n    <br /><h3>Employee\'s Time Records</h3>\r\n\r\n\r\n<table class=\"record\" style=\"width:100%\">\r\n    <tr>\r\n        <th>DATE</th>\r\n        <th>TIME IN</th>\r\n        <th>TIME OUT</th>\r\n    </tr>\r\n");
#nullable restore
#line 17 "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\Partial\_recordView.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 20 "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\Partial\_recordView.cshtml"
           Write(item.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 21 "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\Partial\_recordView.cshtml"
           Write(item.TimeIn.Value.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\Partial\_recordView.cshtml"
           Write(item.TimeOut.Value.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 24 "E:\PROJECTS\Andromeda\Andromeda\Views\Dashboard\Partial\_recordView.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</table>



<style>
   

    .record tr {
        background-color: #eee;
        border-top: 1px solid #fff;
    }

    .record td {
        padding: 8px 2px 10px 20px;
    }

    .record tr:hover {
        background-color: #ccc;
    }

    .record th {
        background-color: #fff;
    }

    .record th, #example td {
        padding: 8px 2px 10px 20px;
    }

    .record td:hover {
        cursor: pointer;
    }
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Andromeda.Models.TimeRecordVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
