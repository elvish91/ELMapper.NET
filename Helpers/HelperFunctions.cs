using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ELMapper.NET
{
    internal static class HelperFunctions
    {
        internal static List<string> ExcludePropertiesFromSource(MappingOptions? options, PropertyInfo[] sourceProps)
        {
            var ignore = options?.Ignore ?? new List<string>();


            var comparer = StringComparer.OrdinalIgnoreCase;

            var sourceNames = sourceProps
                .Select(p => p.Name)
                .ToHashSet(comparer);

            var ignoreSet = new HashSet<string>(ignore, comparer);


            foreach (var prop in ignoreSet)
            {
                if (string.IsNullOrWhiteSpace(prop))
                    throw new ArgumentException("Ignore property name cannot be null or empty.");

                if (!sourceNames.Contains(prop))
                {
                    throw new InvalidOperationException(
                        $"Ignore property '{prop}' does not exist in source.");
                }
            }

            return ignoreSet.ToList();
        }

        internal static PropertyInfo[] MaskProperties(MappingOptions options, PropertyInfo[] destinationProps)
        {
            IEnumerable<PropertyInfo>? query = null;
            if(options?.Masking!=null && options.Masking.Count() > 0)
            {
               var masked_dict = options.Masking;
               query = from md in masked_dict
                            join dp in destinationProps on md.Key equals dp.Name
                            select dp;
            }
            return query?.ToArray() ?? [];
        }

        internal static IEnumerable<(PropertyInfo From, PropertyInfo To)> BuildMappingQuery(PropertyInfo[] sourceProps, PropertyInfo[] destinationProps, MappingOptions? options)
        {

            var ignoreList = ExcludePropertiesFromSource(options, sourceProps);

            var ignore = new HashSet<string>(
                ignoreList ?? Enumerable.Empty<string>(),
                StringComparer.OrdinalIgnoreCase);

            if (options?.Masking!=null && options.Masking.Count() > 0)
            {
                var maskedProps = MaskProperties(options!, destinationProps);
                options!.MaskingIncluded = true;

                return from x in sourceProps
                       from y in destinationProps
                       where string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase)
                          && !ignore.Contains(x.Name)
                       let z = maskedProps.FirstOrDefault(p =>
                                string.Equals(p.Name, y.Name, StringComparison.OrdinalIgnoreCase))
                       select (x, z ?? y);
            }
            else
            {
                
                return from x in sourceProps
                        from y in destinationProps
                        where string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase)
                            && !ignore.Contains(x.Name)
                        select (x, y);
            }
               
        }
    }
}
