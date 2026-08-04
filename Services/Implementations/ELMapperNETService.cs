using ELMapper.NET.Helpers;
using ELMapper.NET.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static ELMapper.NET.HelperFunctions;

namespace ELMapper.NET.Services.Implementations
{
    internal class ELMapperNETService : IELMapperNETService
    {

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



                #region query for filter, masking (default and ignore)

                
                var _query = BuildMappingQuery(arr_props_obj_From, arr_props_obj_To, mappingOptions);

                

                foreach (T_Source obj_from in enumerableFrom)
                {
                    T_Destination obj_to = new T_Destination();

                    foreach (var (fromProp, toProp) in _query)
                    {
                       
                        if (fromProp.CanRead && toProp.CanWrite)
                        {
                            if (mappingOptions?.MaskingIncluded == true &&
                                mappingOptions.Masking != null && mappingOptions.Masking.TryGetValue(toProp.Name, out var maskPattern))
                            {
                                string fromProp_str = fromProp.GetValue(obj_from, null)?.ToString() ?? throw new Exception($"The pattern value of property {fromProp.Name} is wrong");
                                string fromProp_str_masked = MaskingHelper.ApplyMask(fromProp_str!, maskPattern);
                                toProp.SetValue(
                                obj_to,
                                fromProp_str_masked, null);
                            }
                            else
                            {
                                toProp.SetValue(
                                obj_to,
                                fromProp.GetValue(obj_from, null),
                                null);
                            }

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


                #region query for filter, masking (default and ignore)


                var _query = BuildMappingQuery(arr_props_obj_From, arr_props_obj_To, mappingOptions);

                

                foreach (T_Source obj_from in enumerableFrom)
                {
                    T_Destination obj_to = new T_Destination();


                    foreach (var (fromProp, toProp) in _query)
                    {

                        if (fromProp.CanRead && toProp.CanWrite)
                        {
                            if (mappingOptions?.MaskingIncluded == true &&
                                mappingOptions.Masking != null && mappingOptions.Masking.TryGetValue(toProp.Name, out var maskPattern))
                            {
                               string fromProp_str = fromProp.GetValue(obj_from, null)?.ToString() ?? throw new Exception($"The pattern value of property {fromProp.Name} is wrong");
                               string fromProp_str_masked = MaskingHelper.ApplyMask(fromProp_str!, maskPattern);
                                toProp.SetValue(
                                obj_to,
                                fromProp_str_masked, null);
                            }
                            else
                            {
                                toProp.SetValue(
                                obj_to,
                                fromProp.GetValue(obj_from, null),
                                null);
                            }
                             
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

        public  T_Destination MapObject<T_Source, T_Destination>(T_Source obj_from, T_Destination? obj_to = null
             , MappingOptions? mappingOptions = null)
            where T_Source : class
            where T_Destination : class, new()
        {
            try
            {
                if (obj_to is null)
                {
                    obj_to = new T_Destination();
                }



                PropertyInfo[] arr_props_obj_From = typeof(T_Source).GetProperties();
                PropertyInfo[] arr_props_obj_To = typeof(T_Destination).GetProperties();

                #region query for filter, masking (default and ignore)


                var _query = BuildMappingQuery(arr_props_obj_From, arr_props_obj_To, mappingOptions);

                foreach (var (fromProp, toProp) in _query)
                {
                    if (fromProp.CanRead && toProp.CanWrite)
                    {
                        if (mappingOptions?.MaskingIncluded == true &&
                            mappingOptions.Masking != null && mappingOptions.Masking.TryGetValue(toProp.Name, out var maskPattern))
                        {
                            string fromProp_str = fromProp.GetValue(obj_from, null)?.ToString() ?? throw new Exception($"The pattern value of property {fromProp.Name} is wrong");
                            string fromProp_str_masked = MaskingHelper.ApplyMask(fromProp_str!, maskPattern);
                            toProp.SetValue(
                            obj_to,
                            fromProp_str_masked, null);
                        }
                        else
                        {
                            toProp.SetValue(
                            obj_to,
                            fromProp.GetValue(obj_from, null),
                            null);
                        }

                    }
                }
                #endregion

                return obj_to;

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

        public async Task<T_Destination> MapObjectAsync<T_Source, T_Destination>(T_Source obj_from, T_Destination? obj_to = null
             , MappingOptions? mappingOptions = null)
            where T_Source : class
            where T_Destination : class, new()
        {
            try
            {
                if (obj_to is null)
                {
                    obj_to = new T_Destination();
                }

                PropertyInfo[] arr_props_obj_From = typeof(T_Source).GetProperties();
                PropertyInfo[] arr_props_obj_To = typeof(T_Destination).GetProperties();


                #region query for filter, masking (default and ignore)


                var _query = BuildMappingQuery(arr_props_obj_From, arr_props_obj_To, mappingOptions);


                foreach (var (fromProp, toProp) in _query)
                {
                    if (fromProp.CanRead && toProp.CanWrite)
                    {
                        if (mappingOptions?.MaskingIncluded == true &&
                            mappingOptions.Masking != null && mappingOptions.Masking.TryGetValue(toProp.Name, out var maskPattern))
                        {
                            string fromProp_str = fromProp.GetValue(obj_from, null)?.ToString() ?? throw new Exception($"The pattern value of property {fromProp.Name} is wrong");
                            string fromProp_str_masked = MaskingHelper.ApplyMask(fromProp_str!, maskPattern);
                            toProp.SetValue(
                            obj_to,
                            fromProp_str_masked, null);
                        }
                        else
                        {
                            toProp.SetValue(
                            obj_to,
                            fromProp.GetValue(obj_from, null),
                            null);
                        }

                    }
                }
                #endregion

                return await Task.FromResult(obj_to);

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
