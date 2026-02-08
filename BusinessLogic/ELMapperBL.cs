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
        

        public IEnumerable<T_Destination> MapIEnumerable<T_Source, T_Destination>(IEnumerable<T_Source> enumerableFrom, List<T_Destination>? listTo = null)
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



                var _query = (from x in arr_props_obj_From
                              join y in arr_props_obj_To on x.Name equals y.Name
                              select new { x, y });

                foreach (T_Source obj_from in enumerableFrom)
                {
                    T_Destination obj_to = new T_Destination();

                    foreach (var item in _query)
                    {
                        PropertyInfo propFrom = item.x;

                        PropertyInfo propTo = item.y;

                        propTo.SetValue(obj_to, propFrom.GetValue(obj_from, null), null);

                    }
                    listTo.Add(obj_to);

                }

                return listTo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }

        }

        public async Task<IEnumerable<T_Destination>> MapIEnumerableAsync<T_Source, T_Destination>(IEnumerable<T_Source> enumerableFrom, List<T_Destination>? listTo = null)
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



                var _query = (from x in arr_props_obj_From
                              join y in arr_props_obj_To on x.Name equals y.Name
                              select new { x, y });

                foreach (T_Source obj_from in enumerableFrom)
                {
                    T_Destination obj_to = new T_Destination();

                    foreach (var item in _query)
                    {
                        PropertyInfo propFrom = item.x;

                        PropertyInfo propTo = item.y;

                        propTo.SetValue(obj_to, propFrom.GetValue(obj_from, null), null);


                    }
                    listTo.Add(obj_to);


                }

                return await Task.FromResult(listTo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        public  T_Destination MapObject<T_Source, T_Destination>(T_Source objFrom, T_Destination? objTo = null)
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

                var _query = (from x in arr_props_obj_From
                              join y in arr_props_obj_To
                              on x.Name equals y.Name
                              select new { x, y });

                foreach (var item in _query)
                {
                    PropertyInfo propFrom = item.x;

                    PropertyInfo propTo = item.y;

                    propTo.SetValue(objTo, propFrom.GetValue(objFrom, null), null);
                }

                return objTo;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }

        }

        public async Task<T_Destination> MapObjectAsync<T_Source, T_Destination>(T_Source objFrom, T_Destination? objTo = null)
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

                var _query = (from x in arr_props_obj_From
                              join y in arr_props_obj_To
                              on x.Name equals y.Name
                              select new { x, y });

                foreach (var item in _query)
                {
                    PropertyInfo propFrom = item.x;

                    PropertyInfo propTo = item.y;

                    propTo.SetValue(objTo, propFrom.GetValue(objFrom, null), null);

                }

                return await Task.FromResult(objTo);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }
    }
}
