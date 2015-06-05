namespace GRCE.Web
{
    using System;
    using System.Web.Http;

    using GRCE.Web.App_Start;

    using Microsoft.Practices.Unity;
    using Unity.WebApi;

    public static class UnityConfig
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = UnityContainerFactory.CreateContainer();
            
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        #endregion

        public static void RegisterComponents()
        {
            var container = GetConfiguredContainer();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}