namespace MvcExtensionsCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Initialize MvcExtension infrastucture
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="configure">Add add some custom metadata after all initializations</param>
        /// <returns></returns>
        public static IMvcCoreBuilder AddMvcExtentions(this IMvcCoreBuilder mvcBuilder, Action<IModelMetadataRegistry> configure)
        {
            return AddMvcExtentions(mvcBuilder, new[] { Assembly.GetCallingAssembly() }, configure);
        }

        /// <summary>
        /// Initialize MvcExtension infrastucture
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="assemblies">Assemblies to look for model metadata</param>
        /// <returns></returns>
        public static IMvcCoreBuilder AddMvcExtentions(this IMvcCoreBuilder mvcBuilder, params Assembly[] assemblies)
        {
            if (assemblies.Length == 0)
            {
                assemblies = new[] { Assembly.GetCallingAssembly() };
            }

            return AddMvcExtentions(mvcBuilder, assemblies, null);
        }

        /// <summary>
        /// Initialize MvcExtension infrastucture
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="assemblies">Assemblies to look for model metadata</param>
        /// <param name="configure">Add add some custom metadata after all initializations</param>
        /// <returns></returns>
        public static IMvcCoreBuilder AddMvcExtentions(this IMvcCoreBuilder mvcBuilder, IEnumerable<Assembly> assemblies, Action<IModelMetadataRegistry> configure)
        {
            AddMvcExtentionsInternal(mvcBuilder.Services, assemblies, configure);            
            return mvcBuilder;
        }
        
        /// <summary>
        /// Initialize MvcExtension infrastucture
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="configure">Add add some custom metadata after all initializations</param>
        /// <returns></returns>
        public static IMvcBuilder AddMvcExtentions(this IMvcBuilder mvcBuilder, Action<IModelMetadataRegistry> configure)
        {
            return AddMvcExtentions(mvcBuilder, new[] { Assembly.GetCallingAssembly() }, configure);
        }

        /// <summary>
        /// Initialize MvcExtension infrastucture
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="assemblies">Assemblies to look for model metadata</param>
        /// <returns></returns>
        public static IMvcBuilder AddMvcExtentions(this IMvcBuilder mvcBuilder, params Assembly[] assemblies)
        {
            if (assemblies.Length == 0)
            {
                assemblies = new[] { Assembly.GetCallingAssembly() };
            }

            return AddMvcExtentions(mvcBuilder, assemblies, null);
        }

        /// <summary>
        /// Initialize MvcExtension infrastucture
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="assemblies">Assemblies to look for model metadata</param>
        /// <param name="configure">Add add some custom metadata after all initializations</param>
        /// <returns></returns>
        public static IMvcBuilder AddMvcExtentions(this IMvcBuilder mvcBuilder, IEnumerable<Assembly> assemblies, Action<IModelMetadataRegistry> configure)
        {
            AddMvcExtentionsInternal(mvcBuilder.Services, assemblies, configure);
            return mvcBuilder;
        }

        /// <summary>
        /// Initialize MvcExtension infrastucture. Calling assemply will be scanned for metadata.
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="configure">Add add some custom metadata after all initializations</param>
        /// <returns></returns>
        public static IServiceCollection AddMvcExtentions(this IServiceCollection services, Action<IModelMetadataRegistry> configure)
        {
            return AddMvcExtentions(services, new[] { Assembly.GetCallingAssembly() }, configure);
        }

        /// <summary>
        /// Initialize MvcExtension infrastucture. 
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <param name="configure">Add add some custom metadata after all initializations</param>
        /// <returns></returns>
        public static IServiceCollection AddMvcExtentions(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (assemblies.Length == 0)
            {
                assemblies = new[] { Assembly.GetCallingAssembly() };
            }

            return AddMvcExtentions(services, assemblies, null);
        }

        /// <summary>
        /// Initialize MvcExtension infrastucture. 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies">Assemblies to find metadata</param>
        /// <param name="configure">Add add some custom metadata after all initializations</param>
        /// <returns></returns>
        public static IServiceCollection AddMvcExtentions(this IServiceCollection services, IEnumerable<Assembly> assemblies, Action<IModelMetadataRegistry> configure)
        {
            AddMvcExtentionsInternal(services, assemblies, configure);

            return services;
        }

        private static IModelMetadataRegistry AddMvcExtentionsInternal(IServiceCollection services, IEnumerable<Assembly> assemblies, Action<IModelMetadataRegistry> configure)
        {
            IModelMetadataRegistry registry = new ModelMetadataRegistry();
            services.AddSingleton(registry);

            var classes = ConfigurationsScanner
                .GetMetadataClasses(assemblies)
                .Select(s => (IModelMetadataConfiguration)Activator.CreateInstance(s.MetadataConfigurationType))
                .Where(t => t != null);

            var configurations = classes;
            foreach (var configuration in configurations)
            {
                registry.RegisterConfiguration(configuration);
            }

            configure?.Invoke(registry);

            services.Configure<MvcOptions>(
                o =>
                {
                    var mvcExtensionsCoreMetadataProvider = new MvcExtensionsCoreMetadataProvider(registry);
                    o.ModelMetadataDetailsProviders.Insert(0, mvcExtensionsCoreMetadataProvider);
                });

            return registry;
        }
    }
}
