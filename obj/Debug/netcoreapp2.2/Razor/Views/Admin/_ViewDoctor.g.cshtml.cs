#pragma checksum "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26208b7b393c0d66ffcb5e15ab93b50057eb0abe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin__ViewDoctor), @"mvc.1.0.view", @"/Views/Admin/_ViewDoctor.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/_ViewDoctor.cshtml", typeof(AspNetCore.Views_Admin__ViewDoctor))]
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
#line 2 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
using Clinica.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26208b7b393c0d66ffcb5e15ab93b50057eb0abe", @"/Views/Admin/_ViewDoctor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71c71d13737d87dabd05f348d5a3136668d83fd4", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin__ViewDoctor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Users>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "_EditDoctor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(73, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
  
    var doctors = context.Doctor.ToList();

#line default
#line hidden
            BeginContext(126, 1514, true);
            WriteLiteral(@"<div class=""card shadow mb-4"">
    <div class=""card-header py-3"">
        <h6 class=""m-0 font-weight-bold text-primary"">Doctors</h6>
    </div>
    <div class=""card-body"">
        <div class=""table-responsive"">
            <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                <div class=""col-auto"">
                    <label class=""sr-only"" for=""inlineFormInputGroup"">Username</label>
                    <div class=""input-group mb-2"">
                        <div class=""input-group-prepend"">
                            <div class=""input-group-text""><i class=""fas fa-search""></i></div>
                        </div>
                        <input type=""search"" class=""form-control col-5"" id=""search"" onkeyup=""Search()"" placeholder=""Search for doctors..."">
                    </div>
                </div>
                <thead>
                    <tr>

                        <th>
                            First Name
                        </th>
");
            WriteLiteral(@"                        <th>
                            Middle Name
                        </th>
                        <th>
                            Last Name
                        </th>
                        <th>
                            Specialty
                        </th>
                        <th>
                            Gender
                        </th>
                    </tr>
                </thead>
                <tbody id=""myTbody"">
");
            EndContext();
#line 45 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
                      
                        int counter = 0;
                        string color = "";
                    

#line default
#line hidden
            BeginContext(1773, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 49 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
                     foreach (var item in doctors)
                    {
                        if (counter++ % 2 == 0)
                        {
                            color = "#F5F5F5";
                        }
                        else
                        {
                            color = "";
                        }

#line default
#line hidden
            BeginContext(2124, 27, true);
            WriteLiteral("                        <tr");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 2151, "\"", 2184, 3);
            WriteAttributeValue("", 2159, "background-color:", 2159, 17, true);
#line 59 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
WriteAttributeValue(" ", 2176, color, 2177, 6, false);

#line default
#line hidden
            WriteAttributeValue("", 2183, ";", 2183, 1, true);
            EndWriteAttribute();
            BeginContext(2185, 121, true);
            WriteLiteral(">\r\n\r\n                            <td>\r\n                                <a href=\"#\">\r\n                                    ");
            EndContext();
            BeginContext(2307, 56, false);
#line 63 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ClinicaUser.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(2363, 143, true);
            WriteLiteral("\r\n                                </a>\r\n                            </td>\r\n\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2507, 57, false);
#line 68 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ClinicaUser.MiddleName));

#line default
#line hidden
            EndContext();
            BeginContext(2564, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2668, 55, false);
#line 71 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ClinicaUser.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(2723, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2827, 45, false);
#line 74 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Speciality));

#line default
#line hidden
            EndContext();
            BeginContext(2872, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2976, 41, false);
#line 77 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(3017, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(3120, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26208b7b393c0d66ffcb5e15ab93b50057eb0abe9392", async() => {
                BeginContext(3184, 32, true);
                WriteLiteral("Edit <i class=\"far fa-edit\"></i>");
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
#line 80 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
                                                              WriteLiteral(item.ClinicaUser.Id);

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
            BeginContext(3220, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 83 "C:\Users\hp\Desktop\Clinica\Views\Admin\_ViewDoctor.cshtml"
                    }

#line default
#line hidden
            BeginContext(3311, 866, true);
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
</div>

<script>
    function Search() {
        var input, filter, myTbody, trCell, a, i, txtValue;
        input = document.getElementById('search');
        filter = input.value.toUpperCase();
        myTbody = document.getElementById(""myTbody"");
        trCell = myTbody.getElementsByTagName('tr');

        // Loop through all list items, and hide those who don't match the search query
        for (i = 0; i < trCell.length; i++) {
            a = trCell[i].getElementsByTagName(""td"")[0];
            txtValue = a.textContent || a.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                trCell[i].style.display = """";
            } else {
                trCell[i].style.display = ""none"";
            }
        }
    }
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Users> Html { get; private set; }
    }
}
#pragma warning restore 1591
