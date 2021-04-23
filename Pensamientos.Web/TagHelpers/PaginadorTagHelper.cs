using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pensamientos.Domain.Models;

namespace Pensamientos.Web.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginadorTagHelper : TagHelper
    {
    }
}
