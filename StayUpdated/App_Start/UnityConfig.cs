using StayUpdated.Interfaces;
using StayUpdated.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace StayUpdated
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();

			container.RegisterType<INewsService, NewsService>();
			container.RegisterType<IUserSettingsService, UserSettingsService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}