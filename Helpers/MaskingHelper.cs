using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMapper.NET.Helpers
{
    internal static class MaskingHelper
    {
        internal static string ApplyMask(string originalValue, string maskPattern)
        {
            if (string.IsNullOrWhiteSpace(originalValue))
                return originalValue;

            if (maskPattern.StartsWith("KeepLast(", StringComparison.OrdinalIgnoreCase))
            {
                var count = int.Parse(maskPattern["KeepLast(".Length..^1]);

                return new string('*', originalValue.Length - count)
                       + originalValue[^count..];
            }

            if (maskPattern.StartsWith("KeepFirst(", StringComparison.OrdinalIgnoreCase))
            {
                var count = int.Parse(maskPattern["KeepFirst(".Length..^1]);

                return originalValue[..count]
                       + new string('*', originalValue.Length - count);
            }

            if (maskPattern.StartsWith("KeepFirstLast(", StringComparison.OrdinalIgnoreCase))
            {
                var args = maskPattern["KeepFirstLast(".Length..^1]
                    .Split(',');

                var first = int.Parse(args[0]);
                var last = int.Parse(args[1]);

                return originalValue[..first]
                       + new string('*', originalValue.Length - first - last)
                       + originalValue[^last..];
            }

            if (string.Equals(maskPattern, "MaskAll()", StringComparison.OrdinalIgnoreCase))
            {
                return new string('*', originalValue.Length);
            }

            return originalValue;
        }
    }
}
