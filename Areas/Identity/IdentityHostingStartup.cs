using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainingADIntegration.Data;

[assembly: HostingStartup(typeof(TrainingADIntegration.Areas.Identity.IdentityHostingStartup))]
namespace TrainingADIntegration.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TrainingADIntegrationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TrainingADIntegrationContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TrainingADIntegrationContext>();
            });
        }
    }
}