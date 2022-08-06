using BlogPostsManagementSystem.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsManagementSystem
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<ApplicationDbContext>(
                options => options.UseInMemoryDatabase("BlogsManagement"));

            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            }

            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();
            //app.UseAuthentication();

            //app.UseAuthorization();

            //app.UseEndpoints(r =>
            //{
            //    r.MapControllers();
            //    r.MapDefaultControllerRoute();
            //});
        }
    }
}
