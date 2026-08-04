using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMapper.NET
{
    public class MappingOptions
    {
        internal bool MaskingIncluded { get; set; } = false;
        public Dictionary<string, string>? Masking { get; set; }
        public List<string>? Ignore { get; set; }
    }
}
