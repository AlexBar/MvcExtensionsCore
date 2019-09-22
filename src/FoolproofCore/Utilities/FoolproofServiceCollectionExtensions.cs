namespace FoolproofCore
{
    using Microsoft.AspNetCore.Mvc.DataAnnotations;
    using Microsoft.Extensions.DependencyInjection;

    public static class FoolproofServiceCollectionExtensions
    {
        
        /// <summary>
        /// FoolproofValidatiomAttributeAdapterProvider intead of default one. Call after .AddMvc()
        /// </summary>
        /// <param name="services"></param>
        private static IServiceCollection AddFoolproof(this IServiceCollection services)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider, FoolproofValidatiomAttributeAdapterProvider>();
            return services;
        }

        /// <summary>
        /// FoolproofValidatiomAttributeAdapterProvider intead of default one. 
        /// </summary>
        /// <param name="builder"></param>
        public static IMvcCoreBuilder AddFoolproof(this IMvcCoreBuilder builder)
        {
            builder.Services.AddFoolproof();
            return builder;
        }

        /// <summary>
        /// FoolproofValidatiomAttributeAdapterProvider intead of default one. 
        /// </summary>
        /// <param name="builder"></param>
        public static IMvcBuilder AddFoolproof(this IMvcBuilder builder)
        {
            builder.Services.AddFoolproof();
            return builder;
        }
    }
}