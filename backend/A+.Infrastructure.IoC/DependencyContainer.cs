using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Desafio_A__Educacao.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IStudentService,StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            //automapper

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        }
    }
}
