#pragma checksum "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\LoginVerification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15e82263a644cf9247a1e77b1699c1f69800df4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_LoginVerification), @"mvc.1.0.view", @"/Views/Auth/LoginVerification.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Auth/LoginVerification.cshtml", typeof(AspNetCore.Views_Auth_LoginVerification))]
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
#line 2 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\LoginVerification.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 3 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\LoginVerification.cshtml"
using System.Security.Claims;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15e82263a644cf9247a1e77b1699c1f69800df4d", @"/Views/Auth/LoginVerification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5459c0cf8603ab4dc6f79681afbdf1c2daee3acd", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_LoginVerification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FNMusic.Models.TwoFactorVerification>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/a0.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded center-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(111, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\LoginVerification.cshtml"
  
    ViewData["Title"] = "LoginVerification";
    Layout = "~/Views/Shared/_AuthLayout.cshtml";
    

#line default
#line hidden
            BeginContext(273, 261, true);
            WriteLiteral(@"
<section class=""m-t-lg wrapper-md animated fadeInUp"">
    <div class=""container aside-xl bg-white"" style=""box-shadow:0px 10px 10px; border-radius:10px;"">
        <header class=""wrapper text-center"">
            <h2>Login Verification</h2>
            <p>(");
            EndContext();
            BeginContext(535, 11, false);
#line 16 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\LoginVerification.cshtml"
           Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(546, 34, true);
            WriteLiteral(")</p>\r\n        </header>\r\n        ");
            EndContext();
            BeginContext(580, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "83820bb8576c4b65b7c456047bd286c1", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(650, 211, true);
            WriteLiteral("\r\n        <h5 class=\"text-center\">A verification code was sent to your mobile number, kindly input the code in the box below</h5>\r\n        <section class=\"form-horizontal\" style=\"padding:0px 30px 0px 30px;\">\r\n\r\n");
            EndContext();
#line 22 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\LoginVerification.cshtml"
             using (Html.BeginForm("login/verification", "Auth", FormMethod.Post, new { enctype = "multipart/form-data" }))
            {
                

#line default
#line hidden
            BeginContext(1018, 65, false);
#line 24 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\LoginVerification.cshtml"
           Write(Html.ValidationSummary(true, "", new { @class = "text-danger}" }));

#line default
#line hidden
            EndContext();
            BeginContext(1085, 24, true);
            WriteLiteral("                <hr />\r\n");
            EndContext();
            BeginContext(1111, 62, true);
            WriteLiteral("                <div class=\"form-group\">\r\n                    ");
            EndContext();
            BeginContext(1174, 113, false);
#line 28 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\LoginVerification.cshtml"
               Write(Html.PasswordFor(x => x.Token, new { placeholder = "_ _ _ _ _ _", @class = "form-control input-lg text-center" }));

#line default
#line hidden
            EndContext();
            BeginContext(1287, 194, true);
            WriteLiteral("\r\n                </div>\r\n                <button type=\"submit\" class=\"btn  btn-warning b-white btn-block\">\r\n                    <span class=\"m-r-n-lg\">Verify</span>\r\n                </button>\r\n");
            EndContext();
#line 33 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Auth\LoginVerification.cshtml"
            }

#line default
#line hidden
            BeginContext(1496, 925, true);
            WriteLiteral(@"            <p class=""text-center m-t-lg"">
                Didn't get the code?
                <a class=""btn btn-success"" onclick=""sendLoginVerificationToken()"">
                    <span>resend</span>
                </a>
            </p>
            <script type=""text/javascript"">
                function sendLoginVerificationToken() {
                    const http = new XMLHttpRequest();
                    const url = '/sendloginverificationtoken';
                    http.open(""POST"", url);
                    http.send();

                    http.onreadystatechange = (e) => {
                        if (http.readyState == 4) {
                            document.location.reload(true);
                            alert('Token was sent successfully');
                        }
                    }
                }
            </script>
        </section>
    </div>
</section>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FNMusic.Models.TwoFactorVerification> Html { get; private set; }
    }
}
#pragma warning restore 1591
