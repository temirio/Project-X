#pragma checksum "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22717f891904be05228bd4a35396537ded8c6bb0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Settings_UpdateEmail), @"mvc.1.0.view", @"/Views/Settings/UpdateEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Settings/UpdateEmail.cshtml", typeof(AspNetCore.Views_Settings_UpdateEmail))]
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
#line 1 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\_ViewImports.cshtml"
using FNMusic;

#line default
#line hidden
#line 2 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\_ViewImports.cshtml"
using FNMusic.Models;

#line default
#line hidden
#line 2 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22717f891904be05228bd4a35396537ded8c6bb0", @"/Views/Settings/UpdateEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5459c0cf8603ab4dc6f79681afbdf1c2daee3acd", @"/Views/_ViewImports.cshtml")]
    public class Views_Settings_UpdateEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FNMusic.Models.Update>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml"
  
    ViewData["Title"] = "Update Email";
    Layout = "~/Views/Shared/_SettingsLayout.cshtml";
    bool vcsent = Convert.ToBoolean(httpContextAccessor.HttpContext.Session.GetString("VCSent"));

#line default
#line hidden
            BeginContext(316, 275, true);
            WriteLiteral(@"
<section class=""vbox"">
    <section class=""scrollable"">
        <header class=""modal-header"">
            <a href=""/settings/account""><i class=""fa fa-arrow-left""></i></a>
            <span class=""h4 font-bold text-center padder"">Change Email</span>
        </header>
");
            EndContext();
#line 16 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml"
         using (Html.BeginForm("UpdateEmail", "Settings", FormMethod.Post, new { enctype = "multipart/form-data" }))
        {

#line default
#line hidden
            BeginContext(720, 299, true);
            WriteLiteral(@"            <section class=""wrapper"" style=""padding-left:30px; padding-right:30px;"">
                <div class=""form-horizontal"">
                    <div class=""form-group"" style="""">
                        <p>Current</p>
                        <input disabled=""disabled"" class=""form-control""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1019, "\"", 1107, 1);
#line 22 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml"
WriteAttributeValue("", 1027, httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Email").Value, 1027, 80, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1108, 286, true);
            WriteLiteral(@" style=""width:200px; border-right-style:hidden; border-left-style:hidden; border-top-style:hidden;"" />
                    </div>
                    <div class=""form-group"">
                        <p>Email</p>
                        <input id=""EmailTbx"" name=""Email"" type=""email""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1394, "\"", 1430, 1);
#line 26 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml"
WriteAttributeValue("", 1402, Html.ValueFor(x => x.Email), 1402, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1431, 372, true);
            WriteLiteral(@" class=""form-control"" style=""width:200px; border-right-style:hidden; border-left-style:hidden; border-top-style:hidden;"" />
                    </div>
                    <p class=""small"">
                        Your email address is not displayed in your public profile on Twitter. Others will be able to find you by email or phone number.
                    </p>
");
            EndContext();
#line 31 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml"
                     if (vcsent)
                    {

#line default
#line hidden
            BeginContext(1860, 310, true);
            WriteLiteral(@"                        <div class=""form-group"">
                            <p>Token</p>
                            <input id=""TokenTbx"" name=""Token"" class=""form-control"" style=""width:200px; border-right-style:hidden; border-left-style:hidden; border-top-style:hidden;"" />
                        </div>
");
            EndContext();
#line 37 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml"
                    }

#line default
#line hidden
            BeginContext(2193, 182, true);
            WriteLiteral("                </div>\r\n            </section>\r\n            <footer class=\"modal-footer\">\r\n                <button id=\"submitBtn\" type=\"submit\" class=\"btn btn-success btn-rounded\">\r\n");
            EndContext();
#line 42 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml"
                     if (vcsent)
                    {

#line default
#line hidden
            BeginContext(2432, 43, true);
            WriteLiteral("                        <span>Done</span>\r\n");
            EndContext();
#line 45 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(2547, 51, true);
            WriteLiteral("                        <span>Verify Email</span>\r\n");
            EndContext();
#line 49 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml"
                    }

#line default
#line hidden
            BeginContext(2621, 50, true);
            WriteLiteral("                </button>\r\n            </footer>\r\n");
            EndContext();
#line 52 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdateEmail.cshtml"
        }

#line default
#line hidden
            BeginContext(2682, 30, true);
            WriteLiteral("    </section>\r\n</section>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor httpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FNMusic.Models.Update> Html { get; private set; }
    }
}
#pragma warning restore 1591