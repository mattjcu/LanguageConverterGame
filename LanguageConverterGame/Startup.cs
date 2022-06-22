using LanguageConverterGame.Infraustrature;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LanguageConverterGame.Authentication;
using LanguageConverterGame.Services;
using LanguageConverterGame.Services.CreateUser;

namespace LanguageConverterGame
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
            var connection = Configuration.GetConnectionString("PlayGroundDatabase");
            services.AddDbContextPool<PlaygroundContext>(options => options.UseSqlServer(connection));
            // services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));

            var key = "ebe4e230-f5a2-4d65-87f6-4eb68a656e5f";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
                };
            });
            services.AddTransient<IFindUsers, FindUser>();
            services.AddTransient<IJwtAuth>(sp => new Authenticate(key, sp.GetRequiredService<IFindUsers>()));
            services.AddTransient<ICreateUsers, CreateUser>();
            services.AddTransient<IFindMessages, FindMessages>();
            services.AddTransient<ITranslateMessages, TranslateMessage>();
            services.AddTransient<ICreateMessages, CreateMessage>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Language Game", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "playground v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
