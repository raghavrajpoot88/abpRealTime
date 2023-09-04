using chatterBox.ApiLogs;
using chatterBox.DTO;
using chatterBox.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Clients;
using Volo.Abp.Users;
using Volo.Abp.Validation.Localization;

namespace chatterBox.Middleware
{
    public class customMiddleware : IMiddleware
    {
        private readonly IServiceScopeFactory _scopeFactory;
        //private readonly ILogger<customMiddleware> _logger;, ILogger<customMiddleware> logger
        private readonly ICurrentUser _currentUser;
        //private readonly chatterBoxDbContext _dbContext;,chatterBoxDbContext dbContext

        //private readonly RequestDelegate _next;
        //private readonly ILogger<CustomMiddle> _logger;, ILogger<CustomMiddle> logger
        //private readonly ApplicationDbContext _DbContext; ,  ApplicationDbContext applicationDbContext

        public customMiddleware(IServiceScopeFactory scopeFactory
                            , ICurrentUser currentUser)
        {
            //_next = next;
            _scopeFactory = scopeFactory;
            //_logger = logger;
            _currentUser = currentUser;
            //_dbContext = dbContext;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            if (httpContext.Request.HasFormContentType)
            {
                var form = await httpContext.Request.ReadFormAsync();

                if (form.ContainsKey("Password"))
                {
                    form = new FormCollection(form.Where(x => x.Key != "Password").ToDictionary(k => k.Key, v => v.Value));
                    httpContext.Request.Form = form;
                }
            }


            //_logger.LogInformation($"{userEmailDetail}");
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<chatterBoxDbContext>();

                LogDetails log = new LogDetails();

                log.creationTime = DateTime.Now;
                HttpRequest httpRequest = httpContext.Request;
                
                //log 
                log.Id = Guid.NewGuid().ToString();
                var ip = httpRequest.HttpContext.Connection.RemoteIpAddress;
                log.clientIpAddress = ip == null ? null : ip.ToString();

                //request
                log.parameter = await ReadBodyFromRequest(httpRequest);

                ////username
                try
                {
                    var current = _currentUser.GetId();
                    var user = dbContext.Users.FirstOrDefault(m => m.Id == current);
                    var userEmailDetail = user?.UserName;
                    log.userName = userEmailDetail;
                }
                catch (InvalidOperationException)
                {
                    log.userName = null;
                }
                //var jsonString = logCreator.LogString(); /*log json*/
                //_logger.LogInformation(log);

                dbContext.logsInfo.Add(log);
                await dbContext.SaveChangesAsync();
            }
            //await _DbContext.requestlogs.AddAsync(log);
            //await _DbContext.SaveChangesAsync();

            //_logger.LogTrace(jsonString);
            //_logger.LogInformation(logCreator.LogString());
            //_logger.LogWarning(jsonString);
            //_logger.LogCritical(logCreator.LogString());

            await next(httpContext);



        }

        private async Task<string> ReadBodyFromRequest(HttpRequest request)
        {
            // Ensure the request's body can be read multiple times 
            // (for the next middlewares in the pipeline).
            request.EnableBuffering();
            using var streamReader = new StreamReader(request.Body, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();
            // Reset the request's body stream position for 
            // next middleware in the pipeline.
            request.Body.Position = 0;
            return requestBody;
        }
    }


    //// Extension method used to add the middleware to the HTTP request pipeline.
    //public static class customMiddlewareExtensions
    //{
    //    public static ApplicationInitializationContext UsecustomMiddleware(this ApplicationInitializationContext builder)
    //    {
    //        return builder.GetApplicationBuilder.UseMiddleware<customMiddleware>();
    //    }
    //}
}

