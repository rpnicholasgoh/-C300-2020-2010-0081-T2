#pragma checksum "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2fc471e4ee069201cab0b30e5839b3d49d3988dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_EventDetails), @"mvc.1.0.view", @"/Views/Event/EventDetails.cshtml")]
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
#line 1 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\_ViewImports.cshtml"
using System.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\_ViewImports.cshtml"
using FYP1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fc471e4ee069201cab0b30e5839b3d49d3988dd", @"/Views/Event/EventDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea32259e63f2d020ed2bfbac3b473f35782ffaa8", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_EventDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Event>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fc471e4ee069201cab0b30e5839b3d49d3988dd3435", async() => {
                WriteLiteral("\r\n    <h2>Event Details</h2>\r\n\r\n    <div class=\"form-group row\">\r\n        <label class=\"control-label col-sm-2\">ID:</label>\r\n        <label class=\"control-label col-sm-5\">");
#nullable restore
#line 8 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                                         Write(Model.event_id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n    </div>\r\n    <div class=\"form-group row\">\r\n        <label class=\"control-label col-sm-2\">Event Name:</label>\r\n        <label class=\"control-label col-sm-5\">");
#nullable restore
#line 12 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                                         Write(Model.event_name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n    </div>\r\n    <div class=\"form-group row\">\r\n        <label class=\"control-label col-sm-2\">Description:</label>\r\n        <label class=\"control-label col-sm-5\">");
#nullable restore
#line 16 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                                         Write(Model.event_description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n    </div>\r\n    <div class=\"form-group row\">\r\n        <label class=\"control-label col-sm-2\">Venue:</label>\r\n        <label class=\"control-label col-sm-5\">");
#nullable restore
#line 20 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                                         Write(Model.venue);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n    </div>\r\n    <div class=\"form-group row\">\r\n        <label class=\"control-label col-sm-2\">Category:</label>\r\n        <label class=\"control-label col-sm-5\">");
#nullable restore
#line 24 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                                         Write(Model.category);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n    </div>\r\n    <div class=\"form-group row\">\r\n        <label class=\"control-label col-sm-2\">Date & Time:</label>\r\n        <label class=\"control-label col-sm-5\">");
#nullable restore
#line 28 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                                         Write(String.Format("{0:dd-MM-yyyy HH:mm}", Model.start_dt));

#line default
#line hidden
#nullable disable
                WriteLiteral(" to ");
#nullable restore
#line 28 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                                                                                                   Write(String.Format("{0:dd-MM-yyyy HH:mm}", Model.end_dt));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n    </div>\r\n\r\n    <div class=\"form-group row\">\r\n        <label class=\"control-label col-sm-2\">Document(s):</label>\r\n        <div class=\"col-sm-5\">\r\n");
#nullable restore
#line 34 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
             if (ValidUtl.CheckIfEmpty(Model.docName) == false)
            {
                string remainingStr = Model.docName;
                int detectNextLine = Model.docName.IndexOf("\n");
                int detectLastNextLine = Model.docName.LastIndexOf("\n");
                string docs = "";
                if (detectNextLine == -1) // 1 file
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fc471e4ee069201cab0b30e5839b3d49d3988dd7629", async() => {
#nullable restore
#line 42 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                                               Write(Model.docName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1811, "~/file/", 1811, 7, true);
#nullable restore
#line 42 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
AddHtmlAttributeValue("", 1818, Model.docName, 1818, 14, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 43 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                }// working
                else // >2 files
                {
                    while (detectNextLine != -1)
                    {
                        docs = remainingStr.Substring(0, detectNextLine);

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fc471e4ee069201cab0b30e5839b3d49d3988dd9895", async() => {
#nullable restore
#line 49 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                                          Write(docs);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2117, "~/file/", 2117, 7, true);
#nullable restore
#line 49 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
AddHtmlAttributeValue("", 2124, docs, 2124, 5, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(", ");
#nullable restore
#line 49 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                                                                       
                        remainingStr = remainingStr.Substring(detectNextLine + 1);
                        detectNextLine = remainingStr.IndexOf("\n");
                    }
                    docs = Model.docName.Substring(detectLastNextLine + 1);

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fc471e4ee069201cab0b30e5839b3d49d3988dd12228", async() => {
#nullable restore
#line 54 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                                      Write(docs);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2440, "~/file/", 2440, 7, true);
#nullable restore
#line 54 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
AddHtmlAttributeValue("", 2447, docs, 2447, 5, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 55 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
                }
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <label class=\"control-label col-sm-5\">-</label>\r\n");
#nullable restore
#line 60 "D:\FYP\Presentation\FYP-Final\FYP-Final\FYP-Final\FYP-Trial\Views\Event\EventDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Event> Html { get; private set; }
    }
}
#pragma warning restore 1591
