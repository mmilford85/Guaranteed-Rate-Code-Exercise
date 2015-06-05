namespace GRCE.Web.App_Start
{
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

            return _container;
        }
    }
}