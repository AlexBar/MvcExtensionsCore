namespace MvcExtensionsCore
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using JetBrains.Annotations;

    /// <summary>
    /// Defines a utility class to validate method arguments.
    /// </summary>
    internal static class Invariant
    {
        /// <summary>
        /// Determines whether the given argument is not null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        [DebuggerStepThrough]
        public static void IsNotNull([NotNull] object value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName, string.Format(CultureInfo.CurrentUICulture, ExceptionMessages.CannotBeNull, parameterName));
            }
        }
    }
}