#pragma checksum "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\Auth\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f23650fc5f88688e0a86b10f80773312cf2e8355"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_Register), @"mvc.1.0.view", @"/Views/Auth/Register.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Auth/Register.cshtml", typeof(AspNetCore.Views_Auth_Register))]
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
#line 1 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\_ViewImports.cshtml"
using FNMusic;

#line default
#line hidden
#line 2 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\_ViewImports.cshtml"
using FNMusic.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f23650fc5f88688e0a86b10f80773312cf2e8355", @"/Views/Auth/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5459c0cf8603ab4dc6f79681afbdf1c2daee3acd", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FNMusic.Models.Auth.Register>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auth", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-lg btn-info btn-block btn-rounded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\Auth\Register.cshtml"
  
    ViewData["Title"] = "Register";
    Layout = "~/Views/Shared/_AuthLayout.cshtml";

#line default
#line hidden
            BeginContext(132, 406, true);
            WriteLiteral(@"
<section id=""content"" class=""m-t-lg wrapper-md animated fadeInDown"">
    <div class=""container aside-xl"">
        <a class=""navbar-brand block"" href=""index.html""><span class=""h1 font-bold"">FNMusic</span></a>
        <section class=""m-b-lg"">
            <header class=""wrapper text-center"">
                <strong>Sign up to listen to the latest</strong>
            </header>
            <hr />
");
            EndContext();
#line 15 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\Auth\Register.cshtml"
             using (Html.BeginForm("Register", "Auth", FormMethod.Post, new { enctype = "multipart/form-data" }))
            {

#line default
#line hidden
            BeginContext(668, 62, true);
            WriteLiteral("                <div class=\"form-group\">\r\n                    ");
            EndContext();
            BeginContext(731, 130, false);
#line 18 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\Auth\Register.cshtml"
               Write(Html.TextBoxFor(x => x.username, new { placeholder = "Username", @class = "form-control rounded input-lg text-center no-border" }));

#line default
#line hidden
            EndContext();
            BeginContext(861, 88, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
            EndContext();
            BeginContext(950, 148, false);
#line 21 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\Auth\Register.cshtml"
               Write(Html.TextBoxFor(x => x.email, new { type = "email", placeholder = "Email Address", @class = "form-control rounded input-lg text-center no-border" }));

#line default
#line hidden
            EndContext();
            BeginContext(1098, 88, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
            EndContext();
            BeginContext(1187, 149, false);
#line 24 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\Auth\Register.cshtml"
               Write(Html.TextBoxFor(x => x.password, new { type = "password", placeholder = "Password", @class = "form-control rounded input-lg text-center no-border" }));

#line default
#line hidden
            EndContext();
            BeginContext(1336, 88, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
            EndContext();
            BeginContext(1425, 133, false);
#line 27 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\Auth\Register.cshtml"
               Write(Html.TextBoxFor(x => x.firstname, new { placeholder = "First Name", @class = "form-control rounded input-lg text-center no-border" }));

#line default
#line hidden
            EndContext();
            BeginContext(1558, 88, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
            EndContext();
            BeginContext(1647, 131, false);
#line 30 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\Auth\Register.cshtml"
               Write(Html.TextBoxFor(x => x.lastname, new { placeholder = "Last Name", @class = "form-control rounded input-lg text-center no-border" }));

#line default
#line hidden
            EndContext();
            BeginContext(1778, 88, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
            EndContext();
            BeginContext(1867, 153, false);
#line 33 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\Auth\Register.cshtml"
               Write(Html.TextBoxFor(x => x.dateOfBirth, new { placeholder = "Date of Birth", type = "date", @class = "form-control rounded input-lg text-center no-border" }));

#line default
#line hidden
            EndContext();
            BeginContext(2020, 88, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
            EndContext();
            BeginContext(2109, 695, false);
#line 36 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\Auth\Register.cshtml"
               Write(Html.DropDownListFor(x => x.gender, new List<SelectListItem>() {
                                                            new SelectListItem{ Text = "Select Gender", Value = null, Selected = true },
                                                            new SelectListItem{ Text = "Male", Value = "M" },
                                                            new SelectListItem{ Text = "Female", Value = "F" }
                                                            //new SelectListItem(){ Text = "Unspecified", Value = "U", Disabled = true }
                                                        }, new { @class = "form-control rounded input-lg text-center no-border" }));

#line default
#line hidden
            EndContext();
            BeginContext(2804, 322, true);
            WriteLiteral(@"
                </div>
                <div class=""checkbox i-checks m-b"">
                    <label class=""m-l"">
                        <input id=""tac"" type=""checkbox"" style=""text-align:center;"" checked=""""><i></i> Agree the <a href=""#"">terms and policy</a>

                    </label>
                </div>
");
            EndContext();
            BeginContext(3128, 481, true);
            WriteLiteral(@"                <button id=""submit_btn"" type=""submit"" class=""btn btn-lg btn-warning lt b-white b-2x btn-block btn-rounded"">
                    <i class=""icon-arrow-right pull-right""></i>
                    <span class=""m-r-n-lg"">Sign up</span>
                </button>
                <div class=""line line-dashed""></div>
                <p class=""text-muted text-center"">
                    <small>Already have an account?</small>
                </p>
                ");
            EndContext();
            BeginContext(3609, 105, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98a42164438545abbf073d06ffddbea5", async() => {
                BeginContext(3703, 7, true);
                WriteLiteral("Sign in");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
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
            BeginContext(3714, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 59 "C:\Users\stephen.enunwah\Documents\Visual Studio 2017\Projects\Project X\FNMusic\Views\Auth\Register.cshtml"
            }

#line default
#line hidden
            BeginContext(3731, 46, true);
            WriteLiteral("        </section>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FNMusic.Models.Auth.Register> Html { get; private set; }
    }
}
#pragma warning restore 1591
