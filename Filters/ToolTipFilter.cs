using Orchard.Mvc.Filters;
using System.Web.Mvc;
using Orchard.UI.Admin;
using Orchard.UI.Resources;

namespace Orchard.ToolTip.Filters
{
    public class ToolTipFilter : FilterProvider, IResultFilter
    {
        private readonly IResourceManager _resourceManager;

        public ToolTipFilter(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public void OnResultExecuted(ResultExecutedContext filterContext) { }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (AdminFilter.IsApplied(filterContext.RequestContext)) return;

            if (!(filterContext.Result is ViewResult)) return;
            
            _resourceManager.RegisterFootScript("<script src=\"/modules/orchard.tooltip/scripts/tooltip.js\"></script>");
            _resourceManager.RegisterLink(new LinkEntry() { Href = "/modules/orchard.tooltip/styles/tooltip.css", Rel = "stylesheet", Type = "text/css" });
        }
    }
}