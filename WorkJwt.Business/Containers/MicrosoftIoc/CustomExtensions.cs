using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WorkJwt.Business.Concrete;
using WorkJwt.Business.Interfaces;
using WorkJwt.Business.ValidationRules.FluentValidation;
using WorksJwt.Dal.Concrete.EntityFrameworkCore.Repositories;
using WorksJwt.Dal.Interfaces;
using WorksJwt.Entities.DTOs.ProductDtos;

namespace WorkJwt.Business.Containers.MicrosoftIoc
{
    public static class CustomExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtManager>();

            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));

            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddTransient<IValidator<ProductAddDto>,ProductAddDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>,ProductUpdateDtoValidator>();

            
        }
    }
}
