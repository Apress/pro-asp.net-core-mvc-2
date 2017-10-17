using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ModelValidation {

    public class Startup {

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().AddMvcOptions(opts =>
                opts.ModelBindingMessageProvider
                    .SetValueMustNotBeNullAccessor(value => "Please enter a value")
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
