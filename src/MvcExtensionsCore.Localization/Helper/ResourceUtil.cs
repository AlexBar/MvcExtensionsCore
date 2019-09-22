namespace MvcExtensionsCore
{
    using System;
    using JetBrains.Annotations;

    internal static class ResourceUtil
    {
        /// <summary>
        /// Format Resource key for given <paramref name="containerType"/> and <paramref name="propertyName"/>
        /// </summary>
        /// <param name="containerType">Container type</param>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        [NotNull]
        public static string GetResourceKey([NotNull] Type containerType, string propertyName)
        {
            return $"{containerType.Name}_{propertyName}";
        }

        /// <summary>
        /// Checks if Resource file <paramref name="resourceKey"/> contains a <paramref name="resourceKey"/>
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="resourceKey"></param>
        /// <returns></returns>
        public static bool HasResourceValue(Type resourceType, string resourceKey)
        {
            return resourceType.HasProperty(resourceKey);
        }
    }
}