using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SecurityHeadersTalk
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            
            
            // Hand coded but I would use a library.  In .NET - use NWebSec or NetEscapades.AspNetCore.SecurityHeaders
            app.Use(async (context, next) =>
            {
                // context.Response.Headers.Add("x-frame-options", "DENY");
                
                // context.Response.Headers.Add("content-security-policy", "script-src 'self'; style-src 'self'; img-src 'self' www.google.com; media-src 'none'");
                // context.Response.Headers.Add("content-security-policy", "script-src 'self'; style-src 'none'; img-src 'self' www.google.com; media-src 'none'");
                
                // context.Response.Headers.Add("feature-policy", "camera 'none'");
                    
                await next();
            });
            
            
            
            
            
            
            
         
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}