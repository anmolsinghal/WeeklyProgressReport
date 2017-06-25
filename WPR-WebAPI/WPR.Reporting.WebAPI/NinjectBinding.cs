using Ninject;
using WPR.Repository.Interface;
using System;
using System.Reflection;
using WPR.Reporting.BLL;

namespace Core.Reporting.WebAPI
{
    public class NinjectBinding
    {
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        });

        private static void RegisterServices(KernelBase kernel)
        {
            kernel.Bind<IProjectRepository>().To<ProjectRepository>();
        }
    }

}