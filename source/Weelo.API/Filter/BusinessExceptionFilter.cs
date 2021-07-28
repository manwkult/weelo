namespace Weelo.API.Filters
{
    using Weelo.Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Weelo.API.Responses;

    public sealed class BusinessExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            DomainException domainException = context.Exception as DomainException;
            if (domainException != null)
            {
                var response = new Response(0, null, domainException.Message);

                context.Result = new BadRequestObjectResult(response);
                context.Exception = null;
            }
        }
    }
}
