using ELMapper.NET.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ELMapper.NET.BusinessLogic
{
    internal class ELMapperBL : IELMapperNET
    {



        private List<string> ExcludePropertiesFromSource( MappingOptions? options, PropertyInfo[] sourceProps)
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

        private IEnumerable<(PropertyInfo From, PropertyInfo To) > BuildMappingQuery(PropertyInfo[] sourceProps,PropertyInfo[] destinationProps, MappingOptions? options)
        {
            var ignoreList = ExcludePropertiesFromSource(options, sourceProps);

            var ignore = new HashSet<string>(
                ignoreList ?? Enumerable.Empty<string>(),
                StringComparer.OrdinalIgnoreCase);

            return from x in sourceProps
                   from y in destinationProps
                   where string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase)
                      && !ignore.Contains(x.Name)
                   select (x, y);
        }

        public IEnumerable<T_Destination> MapIEnumerable<T_Source, T_Destination>(IEnumerable<T_Source> enumerableFrom, List<T_Destination>? listTo = null,
            MappingOptions? mappingOptions=null)
            where T_Source : class
            where T_Destination : class, new()
        {
            try
            {
                if (listTo is null)
                {
                    listTo = new List<T_Destination>();
                }


                PropertyInfo[] arr_props_obj_From = typeof(T_Source).GetProperties();
                PropertyInfo[] arr_props_obj_To = typeof(T_Destination).GetProperties();



                #region query for filter (default and ignore)
               

               var _query = BuildMappingQuery(arr_props_obj_From, arr_props_obj_To, mappingOptions);


                foreach (T_Source obj_from in enumerableFrom)
                {
                    T_Destination obj_to = new T_Destination();

                    foreach (var (fromProp, toProp) in _query)
                    {
                        if (fromProp.CanRead && toProp.CanWrite)
                        {
                            toProp.SetValue(
                                obj_to,
                                fromProp.GetValue(obj_from, null),
                                null);
                        }
                    }

                    listTo.Add(obj_to);
                }

                #endregion

                return listTo;
            }
            catch (InvalidOperationException op_exc)
            {
                throw new InvalidOperationException(op_exc.Message, op_exc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }

        }

        public async Task<IEnumerable<T_Destination>> MapIEnumerableAsync<T_Source, T_Destination>(IEnumerable<T_Source> enumerableFrom, List<T_Destination>? listTo = null
            , MappingOptions? mappingOptions = null)
            where T_Source : class
            where T_Destination : class, new()
        {
            try
            {
                if (listTo is null)
                {
                    listTo = new List<T_Destination>();
                }


                PropertyInfo[] arr_props_obj_From = typeof(T_Source).GetProperties();
                PropertyInfo[] arr_props_obj_To = typeof(T_Destination).GetProperties();


                #region query for filter (default and ignore)


                var _query = BuildMappingQuery(arr_props_obj_From, arr_props_obj_To, mappingOptions);



                foreach (T_Source obj_from in enumerableFrom)
                {
                    T_Destination obj_to = new T_Destination();


                    foreach (var (fromProp, toProp) in _query)
                    {
                        if (fromProp.CanRead && toProp.CanWrite)
                        {
                            toProp.SetValue(
                                obj_to,
                                fromProp.GetValue(obj_from, null),
                                null);
                        }
                    }

                    listTo.Add(obj_to);
                }

                #endregion

                return await Task.FromResult(listTo);
            }
            catch (InvalidOperationException op_exc)
            {
                throw new InvalidOperationException(op_exc.Message, op_exc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        public  T_Destination MapObject<T_Source, T_Destination>(T_Source objFrom, T_Destination? objTo = null
             , MappingOptions? mappingOptions = null)
            where T_Source : class
            where T_Destination : class, new()
        {
            try
            {
                if (objTo is null)
                {
                    objTo = new T_Destination();
                }



                PropertyInfo[] arr_props_obj_From = typeof(T_Source).GetProperties();
                PropertyInfo[] arr_props_obj_To = typeof(T_Destination).GetProperties();

                #region query for filter (default and ignore)


                var _query = BuildMappingQuery(arr_props_obj_From, arr_props_obj_To, mappingOptions);

                foreach (var (fromProp, toProp) in _query)
                {
                    if (fromProp.CanRead && toProp.CanWrite)
                    {
                        toProp.SetValue(
                            objTo,
                            fromProp.GetValue(objFrom, null),
                            null);
                    }
                }
                #endregion

                return objTo;

            }
            catch (InvalidOperationException op_exc)
            {
                throw new InvalidOperationException(op_exc.Message, op_exc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }

        }

        public async Task<T_Destination> MapObjectAsync<T_Source, T_Destination>(T_Source objFrom, T_Destination? objTo = null
             , MappingOptions? mappingOptions = null)
            where T_Source : class
            where T_Destination : class, new()
        {
            try
            {
                if (objTo is null)
                {
                    objTo = new T_Destination();
                }

                PropertyInfo[] arr_props_obj_From = typeof(T_Source).GetProperties();
                PropertyInfo[] arr_props_obj_To = typeof(T_Destination).GetProperties();


                #region query for filter (default and ignore)


                var _query = BuildMappingQuery(arr_props_obj_From, arr_props_obj_To, mappingOptions);


                foreach (var (fromProp, toProp) in _query)
                {
                    if (fromProp.CanRead && toProp.CanWrite)
                    {
                        toProp.SetValue(
                            objTo,
                            fromProp.GetValue(objFrom, null),
                            null);
                    }
                }
                #endregion

                return await Task.FromResult(objTo);

            }
            catch (InvalidOperationException op_exc)
            {
                throw new InvalidOperationException(op_exc.Message, op_exc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }
    }
}
