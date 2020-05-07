using System;
using System.Collections.Generic;
using Autofac;

namespace SocietyPass.Mobile.Core
{
    public static class AppContainer
    {
        private static IContainer _container;
        private static readonly List<Module> ExtraModules = new List<Module>();

        public static T Resolve<T>()
        {
            if (_container == null)
            {
                _container = CreateIocContainer();
            }
            return _container.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            if (_container == null)
            {
                _container = CreateIocContainer();
            }
            return _container.Resolve(type);
        }

        public static T Resolve<T>(object objectToPass)
        {
            if (_container == null)
            {
                _container = CreateIocContainer();
            }
            return _container.Resolve<T>(new NamedParameter("objectToPass", objectToPass));
        }

        public static T Resolve<T>(object objectToPass, bool complete)
        {
            if (_container == null)
            {
                _container = CreateIocContainer();
            }
            return _container.Resolve<T>(new NamedParameter("objectToPass", objectToPass), new NamedParameter("complete", complete));
        }

        public static void AddExtraModule(Module registerCallBack)
        {
            ExtraModules.Add(registerCallBack);
        }

        private static IContainer CreateIocContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AppModule>();
            foreach (var extraModule in ExtraModules)
            {
                containerBuilder.RegisterModule(extraModule);
            }
            try
            {
                var container = containerBuilder.Build();
                return container;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    }
}