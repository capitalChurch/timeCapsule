using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeCapsule.Model;

namespace CapsulaTempo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string _corsPolicyName = "churchAndDevelopment";
        private readonly string _corsInDevelopment = "developmentCors";

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TimeCapsuleApp>();
            services.AddTransient<SendEmails>();

            services.AddCors(options =>
            {
//                options.AddPolicy(this._corsPolicyName, builder =>
//                    builder.WithOrigins("http://cartaparaofuturo.igrejacapital.org.br",
//                            "http://cartaparaofuturo.igrejacapital.org.br.s3-website-sa-east-1.amazonaws.com",
//							"https://www.kevynklava.com")
//                        .AllowAnyHeader()
//                        .AllowAnyMethod());

                
                options.AddPolicy(this._corsInDevelopment, builder => 
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
            
            

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(this._corsInDevelopment);
            }
            
            app.UseCors(this._corsPolicyName);
            app.UseMvc();

        }
    }
}