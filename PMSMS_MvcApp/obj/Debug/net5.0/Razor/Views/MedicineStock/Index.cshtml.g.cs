#pragma checksum "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "592629002ad60e1b86e71a59c95d9523d6327251"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MedicineStock_Index), @"mvc.1.0.view", @"/Views/MedicineStock/Index.cshtml")]
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
#nullable restore
#line 1 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\_ViewImports.cshtml"
using PMSMS_MvcApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\_ViewImports.cshtml"
using PMSMS_MvcApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"592629002ad60e1b86e71a59c95d9523d6327251", @"/Views/MedicineStock/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efd603ae064eb8cfc1c2c523f7ebd39966b6df3c", @"/Views/_ViewImports.cshtml")]
    public class Views_MedicineStock_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MedicineStockRepository.Models.MedicineStock>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "592629002ad60e1b86e71a59c95d9523d63272513938", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.MedicineId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.MedicineName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ChemicalComposition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TargetAilment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateOfExpiry));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NumberOfTabletsInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 37 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.MedicineId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.MedicineName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ChemicalComposition));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TargetAilment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DateOfExpiry));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 56 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NumberOfTabletsInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 61 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { MedicineId = item.MedicineId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 62 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { MedicineId = item.MedicineId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 63 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { MedicineId = item.MedicineId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 66 "D:\_Cognizant (CTS) stuff\_Internship_Final_Project\_Project\PharmacyMediSupplyMaganmentSys\PMSMS_MvcApp\Views\MedicineStock\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MedicineStockRepository.Models.MedicineStock>> Html { get; private set; }
    }
}
#pragma warning restore 1591
