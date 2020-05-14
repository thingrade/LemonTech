using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LemonTech.Repository.Helpers
{
    public static class DataReaderExtensions
    {
        public static async Task<List<T>> MapToList<T>(this DbDataReader dr) where T : new()
        {
            List<T> retVal = null;

            if (dr != null && dr.HasRows)
            {

                retVal = new List<T>();

                var entity = typeof(T);

                var props = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                var propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);

                while (await dr.ReadAsync())
                {

                    var newObject = new T();

                    for (var index = 0; index < dr.FieldCount; index++)
                    {

                        if (propDict.ContainsKey(dr.GetName(index).ToUpper()))
                        {

                            var info = propDict[dr.GetName(index).ToUpper()];

                            if (info != null && info.CanWrite)
                            {

                                var val = dr.GetValue(index);

                                try
                                {
                                    info.SetValue(newObject, val == DBNull.Value ? null : val, null);
                                }
                                catch (Exception ex)
                                {

                                    throw new Exception(ex.Message, new Exception(info.Name));
                                }
                            }
                        }
                    }

                    retVal.Add(newObject);
                }
            }

            return retVal;
        }

        public static async Task<T> MapToModel<T>(this DbDataReader dr) where T : new()
        {

            if (dr != null && dr.HasRows)
            {
                var entity = typeof(T);

                var props = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                var propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);

                if (await dr.ReadAsync())
                {

                    var newObject = new T();

                    for (var index = 0; index < dr.FieldCount; index++)
                    {

                        if (propDict.ContainsKey(dr.GetName(index).ToUpper()))
                        {

                            var info = propDict[dr.GetName(index).ToUpper()];

                            if (info != null && info.CanWrite)
                            {

                                var val = dr.GetValue(index);

                                try
                                {
                                    info.SetValue(newObject, val == DBNull.Value ? null : val, null);
                                }
                                catch (Exception ex)
                                {

                                    throw new Exception(ex.Message, new Exception(info.Name));
                                }
                            }
                        }
                    }

                    return newObject;
                }
            }

            return default(T);
        }
    }
}
