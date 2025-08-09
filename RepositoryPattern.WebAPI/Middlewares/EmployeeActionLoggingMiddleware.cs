using Microsoft.EntityFrameworkCore;
using RepositoryPattern.ApplicationLayer.DTOs;
using RepositoryPattern.ApplicationLayer.Interfaces;
using RepositoryPattern.DomainLayer.Entities;
using RepositoryPattern.InfrastructureLayer;
using System.Text;

namespace RepositoryPattern.WebAPI.Middlewares
{
    public class EmployeeActionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public EmployeeActionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ILogHistoryService logHistoryService)
        {
            if (context.Request.Method == HttpMethods.Post ||
                context.Request.Method == HttpMethods.Put ||
                context.Request.Method == HttpMethods.Delete)
            {
                string actionName = context.Request.Method switch
                {
                    "POST" => "Add",
                    "PUT" => "Edit",
                    "DELETE" => "Delete",
                    _ => "Unknown"
                };

                var pathSegments = context.Request.Path.Value?.Split('/', StringSplitOptions.RemoveEmptyEntries);
                string entityName = pathSegments != null && pathSegments.Length > 1 ? pathSegments[1] : "Unknown";
                string entityId = pathSegments != null && pathSegments.Length > 2 ? pathSegments[2] : "";

                var logEntry = new LogHistoryDto
                {
                    Action = actionName,
                    EntityName = entityName,
                    EntityId = entityId
                };

                await logHistoryService.AddAsync(logEntry);
            }

            await _next(context);
        }
    }
}
     