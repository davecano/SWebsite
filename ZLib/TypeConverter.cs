using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Z
{


    /// <summary>
    /// 安全高效的类型转换帮助
    /// </summary>
    class ConvertHelper
    {
        object _obj;
        /// <summary>
        /// 该类可以把构造函数中传入的一个对象转换成需要的类型
        /// </summary>
        /// <param name="obj">传入的对象</param>
        public ConvertHelper(object obj)
        {
            _obj = obj;
        }

        /// <summary>
        /// 将该类型转换为Int32，若转换失败返回null。
        /// </summary>
        /// <example>
        /// 代码示例
        /// <code> 
        /// int? r1 = new HZ.Common.ConvertHelper("100").ToInt32;//r1值为100
        /// </code>
        /// </example>
        /// <value>
        /// 将传入的对象转换为可空的Int32(int?)，若转换失败返回null。
        /// </value>
        /// <remarks>
        /// 如果传入的类型不能转换成整数,则返回null
        /// </remarks>
        public int? ToInt32
        {
            get
            {
                int r;
                if (int.TryParse(String, out r))
                    return r;
                else
                    return null;
            }
        }

        /// <summary>
        /// 将该类型转换为Int64，若转换失败返回null。
        /// </summary>
        /// <example>
        /// 代码示例
        /// <code> 
        /// long? r1 = new HZ.Common.ConvertHelper("100").ToInt64;//r1 为 long 100
        /// </code>
        /// </example>
        /// <value>
        /// 将传入的对象转换为可空的Int64(long?)，若转换失败返回null。
        /// </value>
        /// <remarks>如果传入的类型不能转换成长整数,返回null</remarks>
        public long? ToInt64
        {
            get
            {
                long r;
                if (long.TryParse(String, out r))
                    return r;
                else
                    return null;
            }
        }

        /// <summary>
        /// 将该类型转换为DateTime，若转换失败返回null。
        /// </summary>
        /// <example>
        /// 代码示例
        /// <code>
        ///  DateTime? r1 = new HZ.Common.ConvertHelper("2009-02-13").ToDateTime; //r2 为 2009-2-13 0:00:00
        ///  DateTime? r2 = new HZ.Common.ConvertHelper("2009-02-13 14:20:37").ToDateTime;//r3 为 2009-2-13 14:20:37
        /// </code>
        /// </example>
        /// <value>
        /// 将传入的对象转换为可空的DateTime(DateTime?)，若转换失败返回null。
        /// </value>
        /// <remarks>如果传入的类型不能转换成DateTime,返回null</remarks>
        public DateTime? ToDateTime
        {
            get
            {
                DateTime r;
                if (DateTime.TryParse(String, out r))
                    return r;
                else
                    return null;
            }
        }

        /// <summary>
        /// 将传入的对象转换为String，如果对象为空则返回string.Empty;如果对象不为空，则返回该对象的ToString重载属性。
        /// </summary>
        /// <example>
        /// 代码示例
        /// <code>
        ///     object ss = new object();//新建一个对象
        ///     string str = new HZ.Common.ConvertHelper(obj).String; //str的值为ToString重载属性返回值.
        /// </code>
        /// </example>
        /// <value>
        /// 将传入的对象转换为String，如果对象为空则返回string.Empty;如果对象不为空，则返回该对象的ToString重载属性。
        /// </value>
        /// <remarks>如果传入的对象为空,则返回string.Empty</remarks>
        public string String
        {
            get
            {
                return ToString();
            }
        }

        /// <summary>
        /// 将该类型转换为Double，若转换失败返回null。
        /// </summary>
        /// <example>
        /// 代码示例
        /// <code>
        /// double? d1 = new HZ.Common.ConvertHelper("2.01").ToDouble; // d1 2.01   
        /// </code>
        /// </example>
        /// <value>
        /// 将传入的对象转换为可空的Double(Double?)，若转换失败返回null。
        /// </value>
        /// <remarks>如果传入的类型不能转换成double,返回值为null</remarks>
        public double? ToDouble
        {
            get
            {
                double r;
                if (double.TryParse(String, out r))
                    return r;
                else
                    return null;
            }
        }

        /// <summary>
        /// 将该类型转换为Decimal，若转换失败返回null。
        /// </summary>
        /// <example>
        /// 代码示例
        /// <code>
        ///     decimal? d1 = new HZ.Common.ConvertHelper("2.01").ToDecimal;//2.01
        ///     //abc 不能转换成decimal,返回null    
        /// </code>
        /// </example>
        /// <value>
        /// 将传入的对象转换为可空的decimal(decimal?)，若转换失败返回null。
        /// </value>
        /// <remarks>如果传入的类型不能转换成decimal,返回值为null</remarks>
        public decimal? ToDecimal
        {
            get
            {
                decimal r;
                if (decimal.TryParse(String, out r))
                    return r;
                else
                    return null;
            }
        }

        /// <summary>
        /// 将该类型转换为Float，若转换失败返回null。
        /// </summary>
        /// <example>
        /// 代码示例
        /// <code>
        /// float? fo1 = new HZ.Common.ConvertHelper("2.01").ToFloat;//2.01
        /// </code>
        /// </example>
        /// <value>
        /// 将传入的对象转换为可空的float(float?)，若转换失败返回null。
        /// </value>
        /// <remarks>如果传入的类型不能转换成float,返回值为null</remarks>
        public float? ToFloat
        {
            get
            {
                float r;
                if (float.TryParse(String, out r))
                    return r;
                else
                    return null;
            }
        }

        /// <summary>
        /// 将该类型转换为Bool，若转换失败返回null。
        /// </summary>
        /// <example>
        /// 代码示例
        /// <code>
        ///     bool? b1 = new HZ.Common.ConvertHelper("true").ToBool;//b1为true
        /// </code>
        /// </example>
        /// <value>
        /// 将传入的对象转换为可空的bool(bool?)，若转换失败返回null。
        /// </value>
        /// <remarks>
        /// 传入的只能是TrueString或者FalseString,不能是其他(0，1也不行)，否则转换失败，返回null。
        /// </remarks>
        public bool? ToBool
        {
            get
            {
                if (_obj == null || _obj == Convert.DBNull)
                {
                    return null;
                }
                if (String.ToLower() == "false" || String == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        /// <summary>
        /// 将该类型转换为Byte，若转换失败返回null。
        /// </summary>
        /// <example>
        /// 代码示例
        /// <code>
        ///      byte? b2 = new HZ.Common.ConvertHelper("200").ToByte;//b2值为200
        /// </code>
        /// </example>
        /// <value>
        /// 将传入的对象转换为可空的byte(byte?)，若转换失败返回null。
        /// </value>
        /// <remarks> 
        /// byte 为一个8为无符号整数，最大只能转换255。如果不能转换成byte，则返回null
        /// </remarks>
        public byte? ToByte
        {
            get
            {
                byte r;
                if (byte.TryParse(String, out r))
                    return r;
                else
                    return null;
            }
        }
        /// <summary>
        /// 转换为String对象
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Convert.ToString(_obj);
        }
    }

    /// <summary>
    /// 转换静态类
    /// </summary>
    public static class TypeConverter
    {
        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="obj">待转换的对象</param>
        /// <returns>字符串</returns>
        public static string ToString(object obj)
        {
            return Convert.ToString(obj);
        }
        /// <summary>
        /// 将字符串去除null转换为字符串
        /// </summary>
        /// <param name="obj">带转换的字符串</param>
        /// <returns>如果传入参数是null，返货""，否则返回自身。</returns>
        public static string ToString(string obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            else
            {
                return obj;
            }
        }

        /// <summary>
        /// 转换为可空的整数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ToInt32(object obj)
        {
            return new ConvertHelper(obj).ToInt32;
        }



        /// <summary>
        /// 转换为长整数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long? ToInt64(object obj)
        {
            return new ConvertHelper(obj).ToInt64;
        }

        /// <summary>
        /// 转换为单精度数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float? ToFloat(object obj)
        {
            return new ConvertHelper(obj).ToFloat;
        }

        /// <summary>
        /// 转换为双精度数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ToDouble(object obj)
        {
            return new ConvertHelper(obj).ToDouble;
        }

        /// <summary>
        /// 转换为双精度数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ToDouble2(string obj)
        {
            if (string.IsNullOrEmpty(obj))
            {
                return double.MinValue;
            }
            double dec;
            if (double.TryParse(obj, out dec))
            {
                return dec;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 转换为货币精度数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(object obj)
        {
            return new ConvertHelper(obj).ToDecimal;
        }

        /// <summary>
        /// 转换为货币，如果传入字符串为空，则返回DbNULL
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(string obj)
        {
            if (string.IsNullOrEmpty(obj))
            {
                return decimal.MinValue;
            }
            decimal dec;
            if (decimal.TryParse(obj, out dec))
            {
                return dec;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 转换为时间日期
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(object obj)
        {
            return new ConvertHelper(obj).ToDateTime;
        }

        /// <summary>
        /// 转换为时间日期,如果转换失败则更新为空。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime2(string obj)
        {
            if (string.IsNullOrEmpty(obj))
            {
                return DateTime.MinValue;
            }
            DateTime now;
            if (DateTime.TryParse(obj, out now))
            {
                return now;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 转换为布尔型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool? ToBool(object obj)
        {
            return new ConvertHelper(obj).ToBool;
        }

        /// <summary>
        /// 将可空日期转换为可空字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string DateTimeToString(DateTime? dt, string format)
        {
            if (dt == null)
            {
                return "";
            }
            else
            {
                return dt.Value.ToString(format);
            }
        }


        /// <summary>
        /// 转化一个DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            //创建属性的集合    
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口    

            Type type = typeof(T);
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列    
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in list)
            {
                //创建一个DataRow实例    
                DataRow row = dt.NewRow();
                //给row 赋值    
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                //加入到DataTable    
                dt.Rows.Add(row);
            }
            return dt;
        }



        /// <summary>    
        /// DataTable 转换为List 集合    
        /// </summary>    
        /// <typeparam name="TResult">类型</typeparam>    
        /// <param name="dt">DataTable</param>    
        /// <returns></returns> 

        public static List<T> ToList<T>(this DataTable dt) where T : class, new()
        {
            //创建一个属性的列表    
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            //获取TResult的类型实例  反射的入口    

            Type t = typeof(T);

            //获得TResult 的所有的Public 属性 并找出TResult属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表     
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });

            //创建返回的集合    

            List<T> oblist = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                //创建TResult的实例    
                T ob = new T();
                //找到对应的数据  并赋值    
                prlist.ForEach(p => { if (row[p.Name] != DBNull.Value) p.SetValue(ob, row[p.Name], null); });
                //放入到返回的集合中.    
                oblist.Add(ob);
            }
            return oblist;
        }




        /// <summary>    
        /// 将集合类转换成DataTable    
        /// </summary>    
        /// <param name="list">集合</param>    
        /// <returns></returns>    
        public static DataTable ToDataTableTow(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        /// <summary>    
        /// 将泛型集合类转换成DataTable
        /// </summary>    
        /// <typeparam name="T">集合项类型</typeparam>    
        /// <param name="list">集合</param>    
        /// <returns>数据集(表)</returns>    
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            return ToDataTable<T>(list, null);
        }


        /// <summary>    
        /// 将泛型集合类转换成DataTable    
        /// </summary>    
        /// <typeparam name="T">集合项类型</typeparam>    
        /// <param name="list">集合</param>    
        /// <param name="propertyName">需要返回的列的列名</param>    
        /// <returns>数据集(表)</returns>    
        public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (propertyName != null)
                propertyNameList.AddRange(propertyName);
            DataTable result = new DataTable();
            result.TableName = typeof(T).Name.ToString();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        result.Columns.Add(pi.Name);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                            result.Columns.Add(pi.Name);
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(list[i], null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
    }
}
