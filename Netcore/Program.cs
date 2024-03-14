using ClassLibrary;
using System.Collections.Generic;
namespace Netcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            List<EN> datos = new List<EN>();
            BL bL = new BL();
            app.MapGet("/datos", () =>
            {

                return bL.mostrar_datos();

            });


            app.MapPost("/ingresar",(EN dat) => {

                return bL.agregar_datos(dat);

            });


            app.MapPost("/delete", (int id) =>
            {

                return bL.eliminar_datos(id);


            });

            app.MapPost("/update", (EN _en) =>
            {

                return bL.actualizar_datos(_en);


            });



            app.Run();
        }
    }
}
