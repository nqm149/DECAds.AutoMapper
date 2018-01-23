using Microsoft.Extensions.DependencyInjection;

namespace DECAds.AutoMapper
{
    public class Bootstrapper
    {
        public void Init(IServiceCollection container)
        {
            RegisterServices(container);
        }

        private void RegisterServices(IServiceCollection container)
        {
            container.AddSingleton<IAutoMapperService, AutoMapperService>();
        }
    }
}
