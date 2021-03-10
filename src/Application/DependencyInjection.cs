using AutoMapper;
using demo_ca_app.Application.Common.Behaviours;
using demo_ca_app.Application.GraphQL.GraphQLQueries;
using demo_ca_app.Application.GraphQL.GraphQLSchema;
using FluentValidation;
using GraphQL.Server;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace demo_ca_app.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            // Graphql configuration
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<RatingSchema>();

            services.AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(RatingSchema), ServiceLifetime.Scoped);

            return services;
        }
    }
}
