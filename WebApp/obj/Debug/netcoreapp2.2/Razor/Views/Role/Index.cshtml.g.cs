#pragma checksum "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "847b1e4e8dd5a60576051b8c951ace0fd332263e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Index), @"mvc.1.0.view", @"/Views/Role/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Role/Index.cshtml", typeof(AspNetCore.Views_Role_Index))]
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
#line 1 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#line 2 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"847b1e4e8dd5a60576051b8c951ace0fd332263e", @"/Views/Role/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Aplication.DTO.RoleDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(134, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(163, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "847b1e4e8dd5a60576051b8c951ace0fd332263e3918", async() => {
                BeginContext(186, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(200, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(310, 16, true);
            WriteLiteral("    <br />\r\n    ");
            EndContext();
            BeginContext(327, 66, false);
#line 14 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
Write(Html.ActionLink("Anly Active", "Index", new { onlyActive = true }));

#line default
#line hidden
            EndContext();
            BeginContext(393, 18, true);
            WriteLiteral("\r\n    <br />\r\n    ");
            EndContext();
            BeginContext(412, 64, false);
#line 16 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
Write(Html.ActionLink("Width trash", "Index", new { Deleted = false }));

#line default
#line hidden
            EndContext();
            BeginContext(476, 18, true);
            WriteLiteral("\r\n    <br />\r\n    ");
            EndContext();
            BeginContext(495, 62, false);
#line 18 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
Write(Html.ActionLink("Anly trash", "Index", new { Deleted = true }));

#line default
#line hidden
            EndContext();
            BeginContext(557, 104, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(662, 44, false);
#line 30 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.RoleName));

#line default
#line hidden
            EndContext();
            BeginContext(706, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(762, 38, false);
#line 33 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(800, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(856, 44, false);
#line 36 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
            EndContext();
            BeginContext(900, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(956, 45, false);
#line 39 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsDeleted));

#line default
#line hidden
            EndContext();
            BeginContext(1001, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 45 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(1119, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1168, 43, false);
#line 48 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.RoleName));

#line default
#line hidden
            EndContext();
            BeginContext(1211, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1267, 37, false);
#line 51 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1304, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1360, 43, false);
#line 54 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsActive));

#line default
#line hidden
            EndContext();
            BeginContext(1403, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1459, 44, false);
#line 57 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsDeleted));

#line default
#line hidden
            EndContext();
            BeginContext(1503, 57, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n\r\n                ");
            EndContext();
            BeginContext(1561, 52, false);
#line 61 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new {  id=item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1613, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1634, 57, false);
#line 62 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id=item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1691, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1712, 55, false);
#line 63 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1767, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 66 "C:\Users\Milica\Desktop\nekiProjektiBitniFax\diplomski\c#\VrticZaPse\WebApp\Views\Role\Index.cshtml"
}   

#line default
#line hidden
            BeginContext(1809, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Aplication.DTO.RoleDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591