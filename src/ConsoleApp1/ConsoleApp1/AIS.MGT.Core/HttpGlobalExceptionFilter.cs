using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace AIS.MGT.Core
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errors = new List<string>();
            HttpStatusCode httpStatusCode;

            if (typeof(ValidationException).IsAssignableFrom(context.Exception.GetType()))
            {
                httpStatusCode = HttpStatusCode.BadRequest;
                errors.Add(context.Exception.Message);
            }
            else
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
                errors.Add("服务器发生未知错误，请重试。");
            }

            //if (_env.IsDevelopment())
            //{
            //    errors.AddRange(GetExceptionMessage(context.Exception));
            //    errors.Add(context.Exception.StackTrace);
            //}

            context.Result = new ObjectResult(errors)
            {
                StatusCode = (int)httpStatusCode,
            };
            context.HttpContext.Response.StatusCode = (int)httpStatusCode;

            context.ExceptionHandled = true;
        }
        private IEnumerable<string> GetExceptionMessage(Exception ex)
        {
            if (ex == null)
            {
                yield break;
            }

            yield return ex.Message;

            if (ex.InnerException != null)
            {
                foreach (var item in GetExceptionMessage(ex.InnerException))
                {
                    yield return item;
                }
            }
        }
    }
}
