using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyStandup.Common.TagHelpers
{
    [HtmlTargetElement("form")]
    public class FormAjaxTagHelper : TagHelper
    {
        [HtmlAttributeName("ajax-request")]
        public string AjaxRequest { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(!string.IsNullOrEmpty(AjaxRequest) && AjaxRequest.ToLowerInvariant() == "true")
            {
                output.Attributes.Add("data-ajax", "true");
                output.Attributes.Add("data-ajax-method", "post");
                output.Attributes.Add("data-ajax-mode", "replace");
                output.Attributes.Add("data-ajax-begin", "GlobalFunction.AjaxBegin()");
                output.Attributes.Add("data-ajax-success", "GlobalFunction.AjaxSuccess(data)");
                output.Attributes.Add("data-ajax-failure", "GlobalFunction.AjaxFailure(data)");
            }
        }
    }
}
