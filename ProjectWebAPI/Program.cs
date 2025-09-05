using ApplicationLayer;
using ServiceLayer;

namespace ProjectWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Auth
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            //Conrollers
            builder.Services.AddControllers();

            //Add AL and DAL services
            builder.Services.AddApplicationLayer();
            builder.Services.AddDataAccessLayerAdaptor(builder.Configuration);
            builder.Services.AddServiceLayer();

            //Cors
            builder.Services.AddCors(options => {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:96850")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });


            var app = builder.Build();

            //Routing
            app.UseRouting();
           
            //Cors
            app.UseCors();

            //Swagger

            //Auth
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            //Endpoints
            app.MapControllers();


            app.Run();
        }
    }
}
