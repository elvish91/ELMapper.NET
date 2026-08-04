using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMapper.NET
{
    public static class Mask
    {
        public static string KeepLast(int count)
            => $"KeepLast({count})";

        public static string KeepFirst(int count)
            => $"KeepFirst({count})";

        public static string KeepFirstLast(int first, int last)
            => $"KeepFirstLast({first},{last})";

        public static string MaskAll()
            => "MaskAll()";
    }
}
