#pragma checksum "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_MainHeaderOptionsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "611161c790c4bcccedb3879f02d85849284b1766"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MainHeaderOptionsPartial), @"mvc.1.0.view", @"/Views/Shared/_MainHeaderOptionsPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_MainHeaderOptionsPartial.cshtml", typeof(AspNetCore.Views_Shared__MainHeaderOptionsPartial))]
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
#line 1 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_MainHeaderOptionsPartial.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"611161c790c4bcccedb3879f02d85849284b1766", @"/Views/Shared/_MainHeaderOptionsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5459c0cf8603ab4dc6f79681afbdf1c2daee3acd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MainHeaderOptionsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/a0.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "settings", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "accountsettings", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "user", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_MainHeaderOptionsPartial.cshtml"
  

    bool emailConfirmed = Convert.ToBoolean(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "EmailConfirmed").Value);
    string email = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Email").Value;


#line default
#line hidden
            BeginContext(332, 724, true);
            WriteLiteral(@"<div class=""navbar-right "">
    <ul class=""nav navbar-nav m-n hidden-xs nav-user user"">
        <li class=""hidden-xs"">
            <a href=""#"" class=""dropdown-toggle lt"" data-toggle=""dropdown"">
                <i class=""icon-bell""></i>
                <span class=""badge badge-sm up bg-danger count"">2</span>
            </a>
            <section id=""#notifications"" class=""dropdown-menu aside-xl animated fadeInUp"">
                <section class=""panel bg-white"">
                    <div class=""panel-heading b-light bg-light"">
                        <strong>You have <span class=""count"">2</span> notifications</strong>
                    </div>
                    <div class=""list-group list-group-alt"">
");
            EndContext();
#line 22 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_MainHeaderOptionsPartial.cshtml"
                         if (!emailConfirmed)
                        {

#line default
#line hidden
            BeginContext(1130, 1312, true);
            WriteLiteral(@"                            <div class=""media list-group-item"">
                                <span class=""pull-left""><i class=""fa fa-laptop fa-2x""></i></span>
                                <span class=""media-body block m-b-none"">
                                    We noticed you haven't yet activated your account, this could restrict you from accessing some exciting
                                    features on our platform and we would love for you to be part of everything we have to offer.
                                </span>
                                <div class=""form-group"">
                                    <p class=""navbar-text"">
                                        Didn't get the activation link?

                                    </p>
                                    <a class=""btn btn-info navbar-btn"" onclick=""sendConfirmationEmail()"">
                                        <span>resend</span>
                                    </a>
                           ");
            WriteLiteral(@"     </div>
                                <script type=""text/javascript"">
                                    function sendConfirmationEmail() {
                                        const http = new XMLHttpRequest();
                                        const url = '/confirm/");
            EndContext();
            BeginContext(2443, 5, false);
#line 42 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_MainHeaderOptionsPartial.cshtml"
                                                         Write(email);

#line default
#line hidden
            EndContext();
            BeginContext(2448, 561, true);
            WriteLiteral(@"';
                                        http.open(""POST"", url);
                                        http.send();
                                        http.onreadystatechange = (e) => {
                                            if (http.readyState == 4) {
                                                document.location.reload(true);
                                            }
                                        }
                                    }
                                </script>
                            </div>
");
            EndContext();
#line 53 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_MainHeaderOptionsPartial.cshtml"
                        }

#line default
#line hidden
            BeginContext(3036, 1225, true);
            WriteLiteral(@"                        <a href=""#"" class=""media list-group-item"">
                            <span class=""pull-left thumb-sm""><img src=""images/a0.png"" alt=""..."" class=""img-circle""></span>
                            <span class=""media-body block m-b-none"">  Use awesome animate.css <br> <small class=""text-muted"">10 minutes ago</small> </span>
                        </a>
                        <a href=""#"" class=""media list-group-item"">
                            <span class=""media-body block m-b-none""> 1.0 initial released<br> <small class=""text-muted"">1 hour ago</small> </span>
                        </a>
                    </div>
                    <div class=""panel-footer text-sm"">
                        <a href=""#"" class=""pull-right""><i class=""fa fa-cog""></i></a>
                        <a href=""#notes"" data-toggle=""class:show animated fadeInRight"">See all the notifications</a>
                    </div>
                </section>
            </section>
        </li>
        <li clas");
            WriteLiteral("s=\"dropdown\">\r\n            <a href=\"#\" class=\"dropdown-toggle bg clear\" data-toggle=\"dropdown\">\r\n                <span class=\"thumb-sm avatar pull-right m-t-n-sm m-b-n-sm m-l-sm\">\r\n                    ");
            EndContext();
            BeginContext(4261, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8670123c54e84b8195277946ca31bec1", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4298, 43, true);
            WriteLiteral("\r\n                </span>\r\n                ");
            EndContext();
            BeginContext(4342, 82, false);
#line 74 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_MainHeaderOptionsPartial.cshtml"
           Write(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Username").Value);

#line default
#line hidden
            EndContext();
            BeginContext(4424, 140, true);
            WriteLiteral("\r\n                <b class=\"caret\"></b>\r\n            </a>\r\n            <ul class=\"dropdown-menu animated fadeInRight\">\r\n                <li>");
            EndContext();
            BeginContext(4564, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0146973239048a7a00f9125a6879474", async() => {
                BeginContext(4661, 7, true);
                WriteLiteral("Profile");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4573, "~/", 4573, 2, true);
#line 78 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_MainHeaderOptionsPartial.cshtml"
AddHtmlAttributeValue("", 4575, httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Username" ).Value, 4575, 84, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4672, 230, true);
            WriteLiteral("</li>\r\n                <li><a href=\"#\"> <span class=\"badge bg-danger pull-right\">3</span> Notifications </a></li>\r\n                <li><a href=\"#\">Bookmarks</a></li>\r\n                <li class=\"divider\"></li>\r\n                <li>");
            EndContext();
            BeginContext(4902, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e43b97f5d0a54828a20c187ac302dba4", async() => {
                BeginContext(4960, 8, true);
                WriteLiteral("Settings");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4972, 89, true);
            WriteLiteral("</li>\r\n                <li><a href=\"docs.html\">Help Center</a></li>\r\n                <li>");
            EndContext();
            BeginContext(5061, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0741441c68114e4a99554ef0c3919d34", async() => {
                BeginContext(5106, 7, true);
                WriteLiteral("Log Out");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5117, 64, true);
            WriteLiteral("</li>\r\n            </ul>\r\n        </li>\r\n    </ul>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
