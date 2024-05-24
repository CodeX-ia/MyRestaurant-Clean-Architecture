//using MyRestaurant.Application;
//using MyRestaurant.Infrastructure;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace MyRestaurant
//{
//    public class Startup
//    {
//        public IConfiguration Configuration { get; }

//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddApplication();
//            services.AddInfrastructure(Configuration);

//            services.AddControllers();

//            // Hapus atau komentar bagian ini
//            /*
//            // Configure JWT authentication
//            var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
//            services.AddAuthentication(options =>
//            {
//                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            })
//            .AddJwtBearer(options =>
//            {
//                options.RequireHttpsMetadata = false;
//                options.SaveToken = true;
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(key),
//                    ValidateIssuer = true,
//                    ValidateAudience = true,
//                    ValidIssuer = Configuration["Jwt:Issuer"],
//                    ValidAudience = Configuration["Jwt:Audience"]
//                };
//            });
//            */

//            services.AddEndpointsApiExplorer();
//            services.AddSwaggerGen();
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthentication();
//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller=Home}/{action=Index}/{id?}");
//            });
//        }
//    }
//}
