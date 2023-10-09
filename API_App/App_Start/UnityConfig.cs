using API_App.Models;
using API_App.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace API_App
{

    /// <summary>
    /// The class that represents a STatic INstance for DI Container
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Method that is used to register all dependenies into the Container
        /// </summary>
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<RCompanyEntities>();
             container.RegisterType<IDataAccessService<Department,int>, DepartmentDataService>();
            container.RegisterType<IDataAccessService<Employee,int>,EmployeeDataService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}