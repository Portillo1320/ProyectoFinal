using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProyectoFinal.Data.Models;
using System;
using System.Linq;

namespace ProyectoFinal.Data
{
    public class AppDbInitializer
    {
        //Metodo para agregar datos a BD
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Alumnos.Any())
                {
                    context.Alumnos.AddRange(new Alumno()
                    {
                        Nombre = "1st Alumno Name",
                        Apellido = "1st Alumno LastName",
                        FecNac = DateTime.Now
                    },
                    new Alumno()
                    {
                        Nombre = "2nd Alumno Name",
                        Apellido = "2nd Alumno LastName",
                        FecNac = DateTime.Now
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
