using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMapper.NET.Contracts
{
    public interface IELMapperNET
    {
        Task<T_Destination> MapObjectAsync<T_Source, T_Destination>(T_Source objFrom, T_Destination? objTo = null, MappingOptions? mappingOptions = null)
        where T_Source : class where T_Destination : class, new();

        T_Destination MapObject<T_Source, T_Destination>(T_Source objFrom, T_Destination? objTo = null, MappingOptions? mappingOptions = null)
         where T_Source : class where T_Destination : class, new();

        Task<IEnumerable<T_Destination>> MapIEnumerableAsync<T_Source, T_Destination>(IEnumerable<T_Source> enumerableFrom, List<T_Destination>? listTo = null, MappingOptions? mappingOptions = null)
            where T_Source : class where T_Destination : class, new();

        IEnumerable<T_Destination> MapIEnumerable<T_Source, T_Destination>(IEnumerable<T_Source> enumerableFrom, List<T_Destination>? listTo = null, MappingOptions? mappingOptions = null)
            where T_Source : class where T_Destination : class, new();
    }
}
