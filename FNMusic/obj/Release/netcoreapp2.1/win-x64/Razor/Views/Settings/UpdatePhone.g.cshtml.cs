#pragma checksum "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdatePhone.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33142ebf2e147a1ea35ed66460cd29c0c074ad34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Settings_UpdatePhone), @"mvc.1.0.view", @"/Views/Settings/UpdatePhone.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Settings/UpdatePhone.cshtml", typeof(AspNetCore.Views_Settings_UpdatePhone))]
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
#line 2 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdatePhone.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33142ebf2e147a1ea35ed66460cd29c0c074ad34", @"/Views/Settings/UpdatePhone.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5459c0cf8603ab4dc6f79681afbdf1c2daee3acd", @"/Views/_ViewImports.cshtml")]
    public class Views_Settings_UpdatePhone : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserMgt.Models.Update>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Settings", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AccountSettings", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdatePhone.cshtml"
  
    ViewData["Title"] = "Update Phone";
    Layout = "~/Views/Shared/_SettingsLayout.cshtml";
    bool vcsent = Convert.ToBoolean(httpContextAccessor.HttpContext.Session.GetString("VCSent"));

#line default
#line hidden
            BeginContext(316, 118, true);
            WriteLiteral("<section class=\"vbox bg-white\">\r\n    <section class=\"scrollable\">\r\n        <header class=\"modal-header\">\r\n            ");
            EndContext();
            BeginContext(434, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d72639d58f54477ca4427645071f1690", async() => {
                BeginContext(492, 32, true);
                WriteLiteral("<i class=\"fa fa-arrow-left\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(528, 100, true);
            WriteLiteral("\r\n            <span class=\"h4 font-bold text-center padder\">Change Phone</span>\r\n        </header>\r\n");
            EndContext();
#line 15 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdatePhone.cshtml"
         using (Html.BeginForm("UpdatePhone", "Settings", FormMethod.Post, new { enctype = "multipart/form-data" }))
        {

#line default
#line hidden
            BeginContext(757, 274, true);
            WriteLiteral(@"            <section class=""wrapper"" style=""padding-left:30px; padding-right:30px;"">
                <div class=""form-horizontal"">
                    <div class=""form-group"">
                        <p>Phone</p>
                        <input id=""PhoneTbx"" name=""Phone""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1031, "\"", 1067, 1);
#line 21 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdatePhone.cshtml"
WriteAttributeValue("", 1039, Html.ValueFor(x => x.Phone), 1039, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1068, 429, true);
            WriteLiteral(@" class=""form-control"" style=""width:200px; border-right-style:hidden; border-left-style:hidden; border-top-style:hidden;"" />
                        <br />
                        <span class=""small"">
                            We will text a verification code to this number. Standard SMS free may apply. Others will be able to find you by email or phone number.
                        </span>
                    </div>
");
            EndContext();
#line 27 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdatePhone.cshtml"
                     if (vcsent)
                    {

#line default
#line hidden
            BeginContext(1554, 318, true);
            WriteLiteral(@"                        <div class=""form-group"">
                            <p>Verification Code</p>
                            <input id=""TokenTbx"" name=""Token"" required class=""form-control"" style=""border-right-style:hidden; border-left-style:hidden; border-top-style:hidden;"" />
                        </div>
");
            EndContext();
#line 33 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdatePhone.cshtml"
                    }

#line default
#line hidden
            BeginContext(1895, 91, true);
            WriteLiteral("                </div>\r\n            </section>\r\n            <footer class=\"modal-footer\">\r\n");
            EndContext();
#line 37 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdatePhone.cshtml"
                 if (vcsent)
                {

#line default
#line hidden
            BeginContext(2035, 156, true);
            WriteLiteral("                    <button class=\"btn btn-success btn-rounded pull-right\">\r\n                        <span>Add Phone</span>\r\n                    </button>\r\n");
            EndContext();
#line 42 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdatePhone.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(2251, 159, true);
            WriteLiteral("                    <button class=\"btn btn-success btn-rounded pull-right\">\r\n                        <span>Verify Phone</span>\r\n                    </button>\r\n");
            EndContext();
#line 48 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdatePhone.cshtml"
                }

#line default
#line hidden
            BeginContext(2429, 23, true);
            WriteLiteral("            </footer>\r\n");
            EndContext();
#line 50 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Settings\UpdatePhone.cshtml"
        }

#line default
#line hidden
            BeginContext(2463, 32, true);
            WriteLiteral("    </section>\r\n</section>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserMgt.Models.Update> Html { get; private set; }
    }
}
#pragma warning restore 1591
