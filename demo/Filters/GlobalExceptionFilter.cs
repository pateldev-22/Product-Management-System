using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace demo.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public GlobalExceptionFilter(
            ILogger<GlobalExceptionFilter> logger,
            IModelMetadataProvider modelMetadataProvider)
        {
            _logger = logger;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "An unhandled exception occurred");

            var result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState)
                {
                    ["Message"] = context.Exception.Message,
                    ["StackTrace"] = context.Exception.StackTrace
                }
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
