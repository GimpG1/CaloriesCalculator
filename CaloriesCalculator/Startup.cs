using CaloriesCalculator.Services;
using CaloriesCalculator.Structure;
using CaloriesCalculator.Validations;
using Calzolari.Grpc.AspNetCore.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CaloriesCalculator
{
    public sealed class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IActivity, ActivityLevel>();

            services.AddGrpc( options => options.EnableMessageValidation());
            services.AddSingleton<IValidatorErrorMessageHandler>(new CalculateValidationHandler());
            services.AddGrpcValidation();

            services.AddValidator<CalculateRequestValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<CalculatorService>();
            });
        }
    }
}
