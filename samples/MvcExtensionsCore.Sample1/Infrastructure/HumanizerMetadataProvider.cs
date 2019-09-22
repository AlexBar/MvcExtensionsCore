namespace MvcExtensionsCore.Sample1.Infrastructure
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using JetBrains.Annotations;

    using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

    public class HumanizerMetadataProvider : IDisplayMetadataProvider
    {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            var propertyAttributes = context.Attributes;
            var modelMetadata = context.DisplayMetadata;
            var propertyName = context.Key.Name;

            if (IsTransformRequired(propertyName, modelMetadata, propertyAttributes))
            {
                modelMetadata.DisplayName = () => propertyName.SplitUpperCaseToString();
                //propertyName.Humanize().Transform(To.TitleCase);
            }
        }

        private static bool IsTransformRequired(string propertyName, DisplayMetadata modelMetadata, IReadOnlyList<object> propertyAttributes)
        {
            if (modelMetadata.DisplayName != null)
                return false;

            if (!string.IsNullOrEmpty(modelMetadata.SimpleDisplayProperty))
                return false;

            if (propertyAttributes.OfType<DisplayNameAttribute>().Any())
                return false;

            if (propertyAttributes.OfType<DisplayAttribute>().Any())
                return false;

            if (string.IsNullOrEmpty(propertyName))
                return false;

            return true;
        }
    }

    public static class StringUtils
    {
        /// <summary>
        /// Splits upper case word to a string with spaces
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [CanBeNull]
        public static string SplitUpperCaseToString(this string source)
        {
            if (source == null)
            {
                return null;
            }
            return string.Join(" ", source.SplitUpperCaseToWords());
        }

        /// <summary>
        /// Splits upper case word to a array of words
        /// </summary>
        [NotNull]
        public static string[] SplitUpperCaseToWords(this string source)
        {
            if (source == null)
            {
                return new string[] { };
            }

            if (source.Length == 0)
            {
                return new[] { string.Empty };
            }

            var words = new List<string>();
            var wordStartIndex = 0;

            var letters = source.ToCharArray();
            var previousChar = char.MinValue;

            // skip the first letter. we don't care what case it is
            for (var i = 1; i < letters.Length; i++)
            {
                if (char.IsUpper(letters[i]) && !char.IsUpper(previousChar) && !char.IsWhiteSpace(previousChar))
                {
                    // grab everything before the current index
                    words.Add(new string(letters, wordStartIndex, i - wordStartIndex));
                    wordStartIndex = i;
                }
                previousChar = letters[i];
            }

            // get last word
            words.Add(new string(letters, wordStartIndex, letters.Length - wordStartIndex));

            return words.ToArray();
        }
    }
}