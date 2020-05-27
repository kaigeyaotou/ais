using AIS.MGT.QueryStack.IRepository;
using AIS.MGT.QueryStack.SqlServer.Repository;
using MGT.AIS.IRepository;
using MGT.AIS.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace MGT.AIS
{
    public static class RepositoryExtensions
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddTransient<IAISRepository, AISRepository>();
            services.AddTransient<IPreminumFinanceRepository, PreminumFinanceRepository>();
        }
    }
}
