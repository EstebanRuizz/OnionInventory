using Application.Behaviours;
using Application.Mappings;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceExtension
    {
        public static void AddIOCApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationiBehaviours<,>));
            services.AddMediatR(service => service.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            var mapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<GeneralMappingProfile>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
