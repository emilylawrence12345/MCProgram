using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeathCareMemberCoreProj;
using HeathCareMemberCoreProj.DBContext;
using HeathCareMemberCoreProj.Implementation.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GetMemberPhysician
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
            services.AddSwaggerGen(c =>

            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthcareMember360 Get Member Physician API", Version = "v1" });

            });

            string connectionString = Configuration.GetConnectionString("HM360DBConnection");



            services.AddDbContext<HM360DBContext>(options =>

            {

                try

                {

                    options.UseSqlServer(connectionString,

                    sqlServerOptionsAction: sqlOptions =>

                    {

                        sqlOptions.EnableRetryOnFailure(

                        maxRetryCount: 5,

                        maxRetryDelay: TimeSpan.FromSeconds(30),

                        errorNumbersToAdd: null);

                    });

                }

                catch (System.Exception ex)

                {

                    throw ex;

                    //Log.Error("Exception occurred in DB Context", ex);

                }

            });

            services.AddTransient<HM360DBContext>();

            services.AddScoped(typeof(IMemberRepository), typeof(MemberRepository));

            services.AddScoped<IMemberService, MemberService>();

            services.Add(new ServiceDescriptor(typeof(IConfiguration),

                 provider => Configuration,

                 ServiceLifetime.Singleton));
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
            app.UseSwagger();



            app.UseSwaggerUI(c =>

            {

                c.SwaggerEndpoint("../swagger/v1/swagger.json", "HealthcareMember360 Get Claims V1");



            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
