namespace GRCE.Web.App_Start
{
    using GRCE.Domain.ServiceInterfaces;
    using GRCE.Domain.Services;

    using Microsoft.Practices.Unity;

    public static class UnityContainerFactory
    {
        private static IUnityContainer _container;

        public static IUnityContainer CreateContainer()
        {
            if (_container != null)
            {
                return _container;
            }

            _container = new UnityContainer();

            _container.RegisterType<IWebApiRecordService, RecordsService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IRecordService, RecordsService>(new ContainerControlledLifetimeManager());

            return _container;
        }
    }
}