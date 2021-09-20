using labostic.Controllers;
using Labostic.Services;
using Labostic.Services.Repository.IRepository;
using Labostic.Skill.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic
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
            services.AddControllersWithViews().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FinalProject")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<ISocial, Labostic.Services.Repository.Social>();
            services.AddScoped<ISetting, Labostic.Services.Repository.Setting>();
            services.AddScoped<IResearch, Labostic.Services.Repository.Research>();
            services.AddScoped<ISubscribe, Labostic.Services.Repository.Subscribe>();
            services.AddScoped<IMessage, Labostic.Services.Repository.Message>();
            services.AddScoped<IFaq, Labostic.Services.Repository.Faq>();
            services.AddScoped<IQuestion, Labostic.Services.Repository.Question>();
            services.AddScoped<IResearch, Labostic.Services.Repository.Research>();
            services.AddScoped<IResearchSquar, Labostic.Services.Repository.ResearchSquar>();
            services.AddScoped<IResearchCategory, Labostic.Services.Repository.ResearchCategory>();
            services.AddScoped<IWriter, Labostic.Services.Repository.Writer>();
            services.AddScoped<IDoctor, Labostic.Services.Repository.Doctor>();
            services.AddScoped<IPosition, Labostic.Services.Repository.Position>();
            services.AddScoped<IAwards, Labostic.Services.Repository.Awards>();
            services.AddScoped<ISkill, Labostic.Services.Repository.Skill>();
            services.AddScoped<IAboutSign, Labostic.Services.Repository.AboutSign>();
            services.AddScoped<IWorkProcess, Labostic.Services.Repository.WorkProcess>();
            services.AddScoped<IAboutStatistic, Labostic.Services.Repository.AboutStatistic>();
            services.AddScoped<IWhyChoose, Labostic.Services.Repository.WhyChoose>();
            services.AddScoped<IHomeCircle, Labostic.Services.Repository.HomeCircle>();
            services.AddScoped<ISlider, Labostic.Services.Repository.Slider>();
            services.AddScoped<ITrustedExp, Labostic.Services.Repository.TrustedExp>();
            services.AddScoped<IPartner, Labostic.Services.Repository.Partner>();
            services.AddScoped<ITestimonial, Labostic.Services.Repository.Testimonial>();
            services.AddScoped<ILabTech, Labostic.Services.Repository.LabTech>();
            services.AddScoped<ICheck, Labostic.Services.Repository.Check>();
            services.AddScoped<IAnswer, Labostic.Services.Repository.Answer>();
            services.AddScoped<IMessage, Labostic.Services.Repository.Message>();
            services.AddScoped<IWriterToResearch, Labostic.Services.Repository.WriterToResearch>();
            services.AddScoped<IAppointment, Labostic.Services.Repository.Appointment>();
            services.AddScoped<IServices, Labostic.Services.Repository.Services>();
            services.AddScoped<ISocialToDoctor, Labostic.Services.Repository.SocialToDoctor>();
            services.AddScoped<ISkillToDoctor, Labostic.Services.Repository.SkillToDoctor>();
            services.AddScoped<IExperience, Labostic.Services.Repository.Experience>();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                   name: "areas",
                   areaName: "admin",
                   pattern: "Admin/{controller=Account}/{action=Login}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
