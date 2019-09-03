#pragma checksum "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5abf9ad6da1eb475005a249a07c37880b8cde694"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_ResetPassword), @"mvc.1.0.view", @"/Views/Auth/ResetPassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Auth/ResetPassword.cshtml", typeof(AspNetCore.Views_Auth_ResetPassword))]
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
#line 2 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5abf9ad6da1eb475005a249a07c37880b8cde694", @"/Views/Auth/ResetPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5459c0cf8603ab4dc6f79681afbdf1c2daee3acd", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_ResetPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FNMusic.Models.ResetPassword>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auth", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
  
    ViewData["Title"] = "Reset Password";
    Layout = "~/Views/Shared/_AuthLayout.cshtml";

    bool reset = Convert.ToBoolean(httpContextAccessor.HttpContext.Session.GetString("RESET"));
    bool emailExists = Convert.ToBoolean(httpContextAccessor.HttpContext.Session.GetString("EMAILEXISTS"));

#line default
#line hidden
            BeginContext(433, 333, true);
            WriteLiteral(@"
<section id=""content"" class=""m-t-lg wrapper-md animated fadeInUp"">
    <div class=""container aside-xl bg-white"" style=""box-shadow:0px 10px 10px; border-radius:5px;"">
        <header class=""wrapper text-center"">
            <h2>Reset your password</h2>
            <h5>Fill in all necessary information</h5>
        </header>
");
            EndContext();
#line 19 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
         if (!reset)
        {

#line default
#line hidden
            BeginContext(799, 79, true);
            WriteLiteral("        <section class=\"form-horizontal\" style=\"padding: 0px 30px 30px 30px\">\r\n");
            EndContext();
#line 22 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
             using (Html.BeginForm("PasswordReset", "Auth", FormMethod.Post, new { enctype = "multipart/form-data" }))
            {
                

#line default
#line hidden
            BeginContext(1030, 64, false);
#line 24 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
           Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1096, 86, true);
            WriteLiteral("                <hr />\r\n                <div class=\"form-group\">\r\n                    ");
            EndContext();
            BeginContext(1183, 81, false);
#line 27 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
               Write(Html.ValidationMessageFor(x => x.Email, "", new { @class = "text-danger small" }));

#line default
#line hidden
            EndContext();
            BeginContext(1264, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1287, 119, false);
#line 28 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
               Write(Html.TextBoxFor(x => x.Email, new { @class = "form-control input text-center", placeholder = "Email", type = "email" }));

#line default
#line hidden
            EndContext();
            BeginContext(1406, 26, true);
            WriteLiteral("\r\n                </div>\r\n");
            EndContext();
#line 30 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
                 if (emailExists)
                {

#line default
#line hidden
            BeginContext(1486, 70, true);
            WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
            EndContext();
            BeginContext(1557, 114, false);
#line 33 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
                   Write(Html.PasswordFor(x => x.Password, new { @class = "form-control input text-center", placeholder = "New Password" }));

#line default
#line hidden
            EndContext();
            BeginContext(1671, 100, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        ");
            EndContext();
            BeginContext(1772, 125, false);
#line 36 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
                   Write(Html.PasswordFor(x => x.ConfirmPassword, new { @class = "form-control input text-center", placeholder = "Confirm Password" }));

#line default
#line hidden
            EndContext();
            BeginContext(1897, 30, true);
            WriteLiteral("\r\n                    </div>\r\n");
            EndContext();
#line 38 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
                }

#line default
#line hidden
            BeginContext(1948, 150, true);
            WriteLiteral("                <button type=\"submit\" class=\"btn btn-warning btn-block\">\r\n                    <span>Reset Password</span>\r\n                </button>\r\n");
            EndContext();
#line 43 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
            }

#line default
#line hidden
            BeginContext(2113, 20, true);
            WriteLiteral("        </section>\r\n");
            EndContext();
#line 45 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(2169, 105, true);
            WriteLiteral("            <section style=\"padding:0px 30px 30px 30px;\">\r\n                <h4 class=\"text-center\">Dear, ");
            EndContext();
            BeginContext(2275, 11, false);
#line 49 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
                                         Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(2286, 135, true);
            WriteLiteral("</h4>\r\n                <h5 class=\"text-center\">You have successfully reset your password</h5>\r\n                <br />\r\n                ");
            EndContext();
            BeginContext(2421, 149, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b3677a3fce14ebbbdb1a9a9fe558993", async() => {
                BeginContext(2499, 67, true);
                WriteLiteral("\r\n                    <span>Click to Login</span>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2570, 26, true);
            WriteLiteral("\r\n            </section>\r\n");
            EndContext();
#line 56 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\ResetPassword.cshtml"
            

        }

#line default
#line hidden
            BeginContext(2623, 28, true);
            WriteLiteral("\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FNMusic.Models.ResetPassword> Html { get; private set; }
    }
}
#pragma warning restore 1591
