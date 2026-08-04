using ELMapper.NET.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ELMapper.NET.DependencyInjection
{
    internal class ELMapperNET:IELMapperNET
    { 
        private readonly IELMapperNETService _ELMapperNETService;
        internal ELMapperNET(IELMapperNETService ELMapperNETService) { 

            this._ELMapperNETService = ELMapperNETService;
        }

        public IEnumerable<T_Destination> MapIEnumerable<T_Source, T_Destination>(IEnumerable<T_Source> enumerableFrom, List<T_Destination>? listTo = null,
           MappingOptions? mappingOptions = null)
           where T_Source : class
           where T_Destination : class, new()
        {

            return _ELMapperNETService.MapIEnumerable(enumerableFrom, listTo, mappingOptions);
        }

        public async Task<IEnumerable<T_Destination>> MapIEnumerableAsync<T_Source, T_Destination>(IEnumerable<T_Source> enumerableFrom, List<T_Destination>? listTo = null
            , MappingOptions? mappingOptions = null)
            where T_Source : class
            where T_Destination : class, new()
        {
            return await _ELMapperNETService.MapIEnumerableAsync(enumerableFrom, listTo, mappingOptions);
        }

        public T_Destination MapObject<T_Source, T_Destination>(T_Source objFrom, T_Destination? objTo = null
             , MappingOptions? mappingOptions = null)
            where T_Source : class
            where T_Destination : class, new()
        {

            return _ELMapperNETService.MapObject(objFrom, objTo, mappingOptions);
        }

        public async Task<T_Destination> MapObjectAsync<T_Source, T_Destination>(T_Source objFrom, T_Destination? objTo = null
             , MappingOptions? mappingOptions = null)
            where T_Source : class
            where T_Destination : class, new()
        {
            return await  _ELMapperNETService.MapObjectAsync(objFrom, objTo, mappingOptions);
        }
    }

}
