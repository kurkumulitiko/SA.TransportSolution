using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SA.Transport.Presentation.WebApi.Model;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace SA.Transport.Presentation.WebApi.Extensions.Middlware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        public ExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await Handler(context, ex);
            }
        }

        private async Task Handler(HttpContext context, Exception exception)
        {
            string titleText = "Internal Server Error.";
            string message = "Internal error occured. Connect to administrator";
            var traceId = Activity.Current?.Id ?? context?.TraceIdentifier;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(
               JsonConvert.SerializeObject(
                   new
                   {
                       type = titleText,
                       title = titleText,
                       status = context.Response.StatusCode,
                       traceId = traceId,
                       errors = new
                       {
                           message = new string[] { message }
                       }
                   }
              ));
        }
    }

}
