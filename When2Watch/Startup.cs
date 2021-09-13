using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using When2Watch.BLL.Interfaces;
using When2Watch.BLL.Mappers;
using When2Watch.BLL.Services;
using When2Watch.DAL.Database.Context;
using When2Watch.DAL.Database.Interfaces;
using When2Watch.DAL.Database.Repositories;
using When2Watch.DAL.Identity.Data;

namespace When2Watch
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
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("IdentityConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            //services.AddIdentity<IdentityUser, IdentityRole>(options =>
                //{
                    //options.User.RequireUniqueEmail = true;
                //})
                    //.AddEntityFrameworkStores<AppIdentityDbContext>()
                    //.AddDefaultTokenProviders();

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            services.AddCors();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CommentMappingProfile());
                mc.AddProfile(new EpisodeMappingProfile());
                mc.AddProfile(new EpisodeStatusMappingProfile());
                mc.AddProfile(new FriendMappingProfile());
                mc.AddProfile(new FriendshipRequestMappingProfile());
                mc.AddProfile(new MessageMappingProfile());
                mc.AddProfile(new SeasonMappingProfile());
                mc.AddProfile(new SeriesMappingProfile());
                mc.AddProfile(new UserMappingProfile());
                mc.AddProfile(new WatchlistMappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<ISeriesRepository, SeriesRepository>();
            services.AddTransient<ISeriesService, SeriesService>();
            
            services.AddTransient<ISeasonRepository, SeasonRepository>();
            services.AddTransient<ISeasonService, SeasonService>();

            services.AddTransient<IEpisodeRepository, EpisodeRepository>();
            services.AddTransient<IEpisodeService, EpisodeService>();

            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentService, CommentService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
