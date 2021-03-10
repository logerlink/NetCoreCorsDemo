using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCorsDemo2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            #region 全部请求支持跨域
            //services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.SetIsOriginAllowed(_ => true)
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials();
            //}));
            #endregion
            #region 全部请求支持跨域（限定来源）
            //services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.WithOrigins(new string[] { "*" })    //*为所有来源
            //    .AllowAnyMethod()
            //    .AllowAnyHeader();
            //}));
            #endregion
            #region 限定来源 指定来源可跨域
            //services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.WithOrigins(new string[] { "https://www.cnblogs.com" })    //from origin 'https://www.cnblogs.com' has been blocked by CORS  
            //    .AllowAnyMethod()
            //    .AllowAnyHeader();
            //}));
            #endregion
            #region 限定Action 指定方法可跨域
            //services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.AllowAnyOrigin()
            //    .WithMethods(new string[] { "Index" })    //是方法名称而不是路由名称  如果该方法需要支持跨域，最好能起个唯一的名字
            //    .AllowAnyHeader();
            //}));
            #endregion
            #region 限定Header 非官方header的成员
            //services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .WithHeaders(new string[] { "x-custom-header" });   //x-custom-header非常见的header成员
            //}));
            #endregion
            #region 分组限定
            services.AddCors(x => x.AddPolicy("XiaoMingPolicy", builder =>
            {
                builder.AllowAnyOrigin();
            }));
            services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin();
            }));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("MyPolicy");    //UseCors放在UseRouting和UseEndpoints之间，若有UseMvc则放在UseMvc后面

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
