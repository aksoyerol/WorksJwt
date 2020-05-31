using Microsoft.Extensions.DependencyInjection;
using WorkJwt.Business.Concrete;
using WorkJwt.Business.Interfaces;
using WorksJwt.Dal.Concrete.EntityFrameworkCore.Repositories;
using WorksJwt.Dal.Interfaces;

namespace WorkJwt.Business.Containers.MicrosoftIoc
{
    public static class CustomExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
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

        }
    }
}
