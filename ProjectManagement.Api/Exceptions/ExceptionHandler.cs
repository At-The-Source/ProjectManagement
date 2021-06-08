using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjectManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Exceptions
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _requestDelegate;
        public ExceptionHandler(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception e)
            {
                await ConvertException(context, e);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    status = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValidationErrors);
                    break;
                case BadRequestException badRequestException:
                    status = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException notFoundException:
                    status = HttpStatusCode.NotFound;
                    break;
                case Exception e:
                    status = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)status;
            if (result == string.Empty) { result = JsonConvert.SerializeObject(new { error = exception.Message }); }
            return context.Response.WriteAsync(result);
        }
    }
}
