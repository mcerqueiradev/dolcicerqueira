using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using wapp_dolcicerqueira.Repositories.Implementations;
using wapp_dolcicerqueira.Repositories.Interfaces;
using wapp_dolcicerqueira.Repositories.Repositories.Implementations;
using wapp_dolcicerqueira.Repositories.Repositories.Interfaces;
using wapp_dolcicerqueira.Services.Implementations;
using wapp_dolcicerqueira.Services.Interfaces;

namespace wapp_dolcicerqueira
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
            services.AddControllersWithViews();

            // Registo dos Repositórios
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ILIngredientsRepository, LIngredientsRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IMeasureRepository, MeasureRepository>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<ITestemonialsRepository, TestemonialsRepository>();
            services.AddScoped<IFriendsRepository, FriendsRepository>();

            // Resgisto dos Serviços
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ILIngredientsService, LIngredientsService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IMeasureService, MeasureService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<ITestemonialsService, TestemonialsService>();
            services.AddScoped<IFriendsService, FriendsService>();
            services.AddMvc(options => options.EnableEndpointRouting = false);

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "recipesByCategory",
                    template: "recipe/category/{category}",
                    defaults: new { controller = "Recipe", action = "GetByCategory" }
                );
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "ClearAuthorId",
                pattern: "ClearAuthorId",
                defaults: new { controller = "Home", action = "ClearAuthorId" });
            });
        }
    }
}
