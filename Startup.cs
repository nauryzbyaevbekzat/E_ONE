using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
namespace Eventum.One2
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // indicates whether the publisher will be validated when the token is validated
                            ValidateIssuer = true,
                            // string representing the publisher
                            ValidIssuer = AuthOptions.ISSUER,

                            // whether the consumer of the token will be validated
                            ValidateAudience = true,
                            // set consumer token
                            ValidAudience = AuthOptions.AUDIENCE,
                            // whether lifetime will be validated
                            ValidateLifetime = true,

                            // set the security key
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // validate the security key
                            ValidateIssuerSigningKey = true,
                        };
                    });
            // get the connection string from the config file
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // add the MobileContext as a service to the application
            services.AddDbContext<EventumOneContext>(options => options.UseSqlServer(connection));
           
            services.AddControllers();

            services.AddSwaggerGen( c => {
                
               


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insert token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer" 

                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement { { 
                            
                        new OpenApiSecurityScheme{ 
                            Reference = new OpenApiReference{ 
                            
                                Type = ReferenceType.SecurityScheme,
                                Id= "Bearer"
                            }
                        
                        }, new string[]{ }
                    
                    } });
            });
            
          

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(

              
             );
        }
    }
}
