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
            #region ȫ������֧�ֿ���
            //services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.SetIsOriginAllowed(_ => true)
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials();
            //}));
            #endregion
            #region ȫ������֧�ֿ����޶���Դ��
            //services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.WithOrigins(new string[] { "*" })    //*Ϊ������Դ
            //    .AllowAnyMethod()
            //    .AllowAnyHeader();
            //}));
            #endregion
            #region �޶���Դ ָ����Դ�ɿ���
            //services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.WithOrigins(new string[] { "https://www.cnblogs.com" })    //from origin 'https://www.cnblogs.com' has been blocked by CORS  
            //    .AllowAnyMethod()
            //    .AllowAnyHeader();
            //}));
            #endregion
            #region �޶�Action ָ�������ɿ���
            //services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.AllowAnyOrigin()
            //    .WithMethods(new string[] { "Index" })    //�Ƿ������ƶ�����·������  ����÷�����Ҫ֧�ֿ�����������Ψһ������
            //    .AllowAnyHeader();
            //}));
            #endregion
            #region �޶�Header �ǹٷ�header�ĳ�Ա
            //services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            //{
            //    builder.AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .WithHeaders(new string[] { "x-custom-header" });   //x-custom-header�ǳ�����header��Ա
            //}));
            #endregion
            #region �����޶�
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
            app.UseCors("MyPolicy");    //UseCors����UseRouting��UseEndpoints֮�䣬����UseMvc�����UseMvc����

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
