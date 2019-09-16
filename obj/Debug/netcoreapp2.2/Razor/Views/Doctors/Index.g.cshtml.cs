#pragma checksum "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bfaccccc1ae4ee403929727a8d0eaf3c8acae6f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctors_Index), @"mvc.1.0.view", @"/Views/Doctors/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Doctors/Index.cshtml", typeof(AspNetCore.Views_Doctors_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfaccccc1ae4ee403929727a8d0eaf3c8acae6f9", @"/Views/Doctors/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71c71d13737d87dabd05f348d5a3136668d83fd4", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctors_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Clinica.Models.Doctor>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(86, 1514, true);
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
#line 43 "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml"
                      
                        int counter = 0;
                        string color = "";
                    

#line default
#line hidden
            BeginContext(1733, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 47 "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml"
                     foreach (var item in Model)
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
            BeginContext(2082, 27, true);
            WriteLiteral("                        <tr");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 2109, "\"", 2142, 3);
            WriteAttributeValue("", 2117, "background-color:", 2117, 17, true);
#line 57 "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml"
WriteAttributeValue(" ", 2134, color, 2135, 6, false);

#line default
#line hidden
            WriteAttributeValue("", 2141, ";", 2141, 1, true);
            EndWriteAttribute();
            BeginContext(2143, 121, true);
            WriteLiteral(">\r\n\r\n                            <td>\r\n                                <a href=\"#\">\r\n                                    ");
            EndContext();
            BeginContext(2265, 56, false);
#line 61 "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ClinicaUser.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(2321, 141, true);
            WriteLiteral("\r\n                                </a>\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2463, 57, false);
#line 65 "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ClinicaUser.MiddleName));

#line default
#line hidden
            EndContext();
            BeginContext(2520, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2624, 55, false);
#line 68 "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ClinicaUser.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(2679, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2783, 45, false);
#line 71 "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Speciality));

#line default
#line hidden
            EndContext();
            BeginContext(2828, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2932, 41, false);
#line 74 "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(2973, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(3076, 99, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bfaccccc1ae4ee403929727a8d0eaf3c8acae6f99213", async() => {
                BeginContext(3136, 35, true);
                WriteLiteral("Details <i class=\"far fa-edit\"></i>");
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
#line 77 "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml"
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
            BeginContext(3175, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 80 "C:\Users\hp\Desktop\Clinica\Views\Doctors\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(3266, 866, true);
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
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Clinica.Models.Doctor>> Html { get; private set; }
    }
}
#pragma warning restore 1591
