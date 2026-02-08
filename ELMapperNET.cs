using System.Reflection;
using System.Runtime.CompilerServices;
using ELMapper.NET.BusinessLogic;
using ELMapper.NET.Contracts;

namespace ELMapper.NET
{  
        public static class ELMapperNET
        {
       
        public static async Task<T_Destination> MapObjectAsync<T_Source, T_Destination>(this T_Source objFrom, T_Destination? objTo=null)
        where T_Source : class where T_Destination : class, new()
        {
            
            IELMapperNET _IELMapperNET = new ELMapperBL();
            return await _IELMapperNET.MapObjectAsync(objFrom, objTo);
            
            
        }
        public static T_Destination MapObject<T_Source, T_Destination>(this T_Source objFrom, T_Destination? objTo = null)
         where T_Source : class where T_Destination : class, new()
        {
            IELMapperNET _IELMapperNET = new ELMapperBL();
            return _IELMapperNET.MapObject(objFrom, objTo);
            
        }
        public static async Task<IEnumerable<T_Destination>> MapIEnumerableAsync<T_Source, T_Destination>(this IEnumerable<T_Source> enumerableFrom, List<T_Destination>? listTo=null)
            where T_Source : class where T_Destination : class, new()
        {

            IELMapperNET _IELMapperNET = new ELMapperBL();
            return await _IELMapperNET.MapIEnumerableAsync(enumerableFrom, listTo);
            


        }
        public static IEnumerable<T_Destination> MapIEnumerable<T_Source, T_Destination>(this IEnumerable<T_Source> enumerableFrom, List<T_Destination>? listTo = null)
            where T_Source : class where T_Destination : class, new()
        {
            IELMapperNET _IELMapperNET = new ELMapperBL();
            return _IELMapperNET.MapIEnumerable(enumerableFrom, listTo);
            
        }
    }
   
}
