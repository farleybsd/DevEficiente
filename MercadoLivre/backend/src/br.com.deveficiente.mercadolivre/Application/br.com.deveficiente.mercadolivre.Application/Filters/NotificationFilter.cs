
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Newtonsoft.Json;
using br.com.deveficiente.mercadolivre.Domain.NotificationObjects;
using br.com.deveficiente.mercadolivre.Domain.ResultObjects;

namespace br.com.deveficiente.mercadolivre.Application.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext _notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var result = new Result<object>()
                {
                    Succeeded = false,
                    Errors = _notificationContext.Notifications.Select(x => x.Message).ToList()
                };

                await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(result));

                return;
            }
            await next();
        }
    }
}
