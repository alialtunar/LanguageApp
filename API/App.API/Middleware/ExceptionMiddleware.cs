using App.Application.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using App.Application.Interfaces;
using App.Persistance.Context;
using System.Net.Http;
using System.Threading;
using System;

namespace App.API.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ApplicationDbContext _context;

        public ExceptionMiddleware(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await LogExceptionToDatabaseAsync(ex,context.Request);
                await HandleExceptionAsync(context, ex);

            }
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            if (ex is ValidationException validationException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsJsonAsync(new
                {
                    errors = validationException.Errors.Select(s => s.PropertyName).ToArray(),
                });

                var errorAsDto = ServiceResult.Fail(ex.Message, HttpStatusCode.InternalServerError);

            }
            else
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new
                {
                    errors = new[] { ex.Message },
                   
                });
            }
        }

        private async Task LogExceptionToDatabaseAsync(Exception ex, HttpRequest request)
        {
            ErrorLog errorLog = new()
            {
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace,
                RequestPath = request.Path,
                RequestMethod = request.Method,
                Timestamp = DateTime.Now,
            };

            await _context.Set<ErrorLog>().AddAsync(errorLog, default);
            await _context.SaveChangesAsync(default);
        }
    }
}
