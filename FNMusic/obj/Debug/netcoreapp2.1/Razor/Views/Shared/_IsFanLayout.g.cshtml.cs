#pragma checksum "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b04832cd0f8b806da448713e00cf2d493523b8f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__IsFanLayout), @"mvc.1.0.view", @"/Views/Shared/_IsFanLayout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_IsFanLayout.cshtml", typeof(AspNetCore.Views_Shared__IsFanLayout))]
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
#line 2 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 3 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
using BaseLib.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b04832cd0f8b806da448713e00cf2d493523b8f3", @"/Views/Shared/_IsFanLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5459c0cf8603ab4dc6f79681afbdf1c2daee3acd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__IsFanLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
  

    long profileUserId = Model.Id;
    long loggedInUserId = Convert.ToInt64(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id").Value);

    bool following = false;

#line default
#line hidden
            BeginContext(307, 29, true);
            WriteLiteral("\r\n<div class=\"pull-right\" >\r\n");
            EndContext();
#line 14 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
     if (profileUserId == loggedInUserId)
    {

#line default
#line hidden
            BeginContext(386, 46, true);
            WriteLiteral("        <a class=\"btn btn-default btn-rounded\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 432, "\"", 537, 3);
            WriteAttributeValue("", 439, "/", 439, 1, true);
#line 16 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
WriteAttributeValue("", 440, httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Username").Value, 440, 83, false);

#line default
#line hidden
            WriteAttributeValue("", 523, "/updateprofile", 523, 14, true);
            EndWriteAttribute();
            BeginContext(538, 93, true);
            WriteLiteral(" data-toggle=\"ajaxModal\">\r\n            <span class=\"text\">Edit Profile</span>\r\n        </a>\r\n");
            EndContext();
#line 19 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
    }
    else
    {
        if (following)
        {

#line default
#line hidden
            BeginContext(690, 145, true);
            WriteLiteral("            <a class=\"btn btn-default btn-rounded\" onclick=\"unfollow()\">\r\n                <span class=\"text\">Unfollow </span>\r\n            </a>\r\n");
            EndContext();
            BeginContext(849, 190, true);
            WriteLiteral("            <script type=\"text/javascript\">\r\n                function unfollow() {\r\n                    const Http = new XMLHttpRequest();\r\n                    const url = \'/unfollow?userId=");
            EndContext();
            BeginContext(1040, 13, false);
#line 31 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
                                             Write(profileUserId);

#line default
#line hidden
            EndContext();
            BeginContext(1053, 7, true);
            WriteLiteral("&fanId=");
            EndContext();
            BeginContext(1061, 14, false);
#line 31 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
                                                                  Write(loggedInUserId);

#line default
#line hidden
            EndContext();
            BeginContext(1075, 406, true);
            WriteLiteral(@"';
                    Http.open(""POST"", url);
                    Http.send();

                    Http.onreadystatechange = (e) => {
                        console.log(Http.responseText);

                        if (Http.readyState == 4) {
                            document.location.reload(true);
                        }
                    }
                }
            </script>
");
            EndContext();
#line 44 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(1517, 142, true);
            WriteLiteral("            <a class=\"btn btn-default btn-rounded\" onclick=\"follow()\">\r\n                <span class=\"text\"> Follow </span>\r\n            </a>\r\n");
            EndContext();
            BeginContext(1661, 186, true);
            WriteLiteral("            <script type=\"text/javascript\">\r\n                function follow() {\r\n                    const Http = new XMLHttpRequest();\r\n                    const url = \'/follow?userId=");
            EndContext();
            BeginContext(1848, 13, false);
#line 54 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
                                           Write(profileUserId);

#line default
#line hidden
            EndContext();
            BeginContext(1861, 7, true);
            WriteLiteral("&fanId=");
            EndContext();
            BeginContext(1869, 14, false);
#line 54 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
                                                                Write(loggedInUserId);

#line default
#line hidden
            EndContext();
            BeginContext(1883, 406, true);
            WriteLiteral(@"';
                    Http.open(""POST"", url);
                    Http.send();

                    Http.onreadystatechange = (e) => {
                        console.log(Http.responseText);

                        if (Http.readyState == 4) {
                            document.location.reload(true);
                        }
                    }
                }
            </script>
");
            EndContext();
#line 67 "C:\Users\Stephen\Documents\Visual Studio 2017\Projects\Project-X\FNMusic\Views\Shared\_IsFanLayout.cshtml"
        }
    }

#line default
#line hidden
            BeginContext(2307, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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