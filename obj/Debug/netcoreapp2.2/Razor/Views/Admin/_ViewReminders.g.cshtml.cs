#pragma checksum "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewReminders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd2de0ceba71f89633a6381fa3ed1d3cce5c7023"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin__ViewReminders), @"mvc.1.0.view", @"/Views/Admin/_ViewReminders.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/_ViewReminders.cshtml", typeof(AspNetCore.Views_Admin__ViewReminders))]
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
#line 1 "C:\Users\hp\Desktop\Clinica\Views\_ViewImports.cshtml"
using Clinica;

#line default
#line hidden
#line 2 "C:\Users\hp\Desktop\Clinica\Views\_ViewImports.cshtml"
using Clinica.Models;

#line default
#line hidden
#line 1 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewReminders.cshtml"
using Clinica.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd2de0ceba71f89633a6381fa3ed1d3cce5c7023", @"/Views/Admin/_ViewReminders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71c71d13737d87dabd05f348d5a3136668d83fd4", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin__ViewReminders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteReminder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewReminders.cshtml"
  
    var reminders = context.Reminder.ToList();

#line default
#line hidden
            BeginContext(116, 344, true);
            WriteLiteral(@"<style>
    .fabutton {
        background: none;
        padding: 0px;
        border: none;
        align-content: flex-end;
    }
</style>
<div class=""container col-8 text-center"">
    <a href=""/Reminders/Create"">
        <i class=""fas fa-plus-circle fa-3x"" style="" color:cornflowerblue;""></i>
    </a>
    <br />
    <br />

");
            EndContext();
#line 22 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewReminders.cshtml"
     foreach (var item in reminders)
    {

#line default
#line hidden
            BeginContext(505, 44, true);
            WriteLiteral("        <div class=\"card\">\r\n            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 549, "\"", 593, 4);
            WriteAttributeValue("", 557, "card-header", 557, 11, true);
            WriteAttributeValue(" ", 568, "d-flex", 569, 7, true);
            WriteAttributeValue(" ", 575, "bg-", 576, 4, true);
#line 25 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewReminders.cshtml"
WriteAttributeValue("", 579, item.Priority, 579, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(594, 19, true);
            WriteLiteral(">\r\n                ");
            EndContext();
            BeginContext(614, 40, false);
#line 26 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewReminders.cshtml"
           Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
            EndContext();
            BeginContext(654, 78, true);
            WriteLiteral("\r\n                <div class=\"align-self-start mx-auto\">\r\n                    ");
            EndContext();
            BeginContext(732, 251, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd2de0ceba71f89633a6381fa3ed1d3cce5c70235519", async() => {
                BeginContext(787, 192, true);
                WriteLiteral("\r\n                        <button type=\"submit\" class=\"fabutton\">\r\n                            <i class=\"fas fa-trash-alt ml-auto\"></i>\r\n                        </button>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 28 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewReminders.cshtml"
                                                     WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(983, 131, true);
            WriteLiteral("\r\n\r\n                </div>\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <b><i>Due Date:</i></b> &nbsp;");
            EndContext();
            BeginContext(1115, 43, false);
#line 37 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewReminders.cshtml"
                                         Write(Html.DisplayFor(modelItem => item.DateTime));

#line default
#line hidden
            EndContext();
            BeginContext(1158, 71, true);
            WriteLiteral("\r\n                <hr />\r\n                <b><i>Content:</i></b> &nbsp;");
            EndContext();
            BeginContext(1230, 42, false);
#line 39 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewReminders.cshtml"
                                        Write(Html.DisplayFor(modelItem => item.Content));

#line default
#line hidden
            EndContext();
            BeginContext(1272, 54, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <br />\r\n");
            EndContext();
#line 43 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewReminders.cshtml"
    }

#line default
#line hidden
            BeginContext(1333, 6, true);
            WriteLiteral("</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ApplicationDbContext context { get; private set; }
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
