using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Reflection;
using System.Collections;
using Z;
using System.Text;

namespace Z
{
  public   class StringHelper
    {
        /// <summary>
        /// 对象转换成字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ConvertObjectToString<T>(T obj)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            object[] array = new object[properties.Length];
            string strSearchword = "";
            for (int i = 0; i < properties.Length; i++)
            {
                if (strSearchword.Length > 0) strSearchword += ";";

                if (!string.IsNullOrEmpty(properties[i].Name))
                {
                    strSearchword += properties[i].Name + ":" + properties[i].GetValue(obj, null);
                }
            }
            return strSearchword;
        }

        /// <summary>
        /// 字符串还原成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ConvertStringToObject<T>(string str) where T : new()
        {
            Hashtable htValues = ConvertStringToHashtable(str);
            //此处可作安全检查 
            //TODO:
            if (htValues.Count == 0)
            {
                //空值
                return default(T);
            }

            //构造泛型实体
            T result = new T();
            //获得泛型类型
            Type t = typeof(T);
            //属性集合
            PropertyInfo[] properties = t.GetProperties();
            //属性赋值
            foreach (var item in properties)
            {
                //字符串
                if (item.PropertyType == typeof(string))
                {
                    item.SetValue(result,TypeConverter.ToString(item.Name), null);
                }
                //整数（不可空）
                if (item.PropertyType == typeof(int))
                {
                    item.SetValue(result, TypeConverter.ToInt32(item.Name) ?? 0, null);
                }
                //整数（可空）
                if (item.PropertyType == typeof(int?))
                {
                    item.SetValue(result, TypeConverter.ToInt32(item.Name), null);
                }
                //布尔（不可空）
                if (item.PropertyType == typeof(bool))
                {
                    item.SetValue(result, TypeConverter.ToBool(item.Name) ?? false, null);
                }
                //布尔（可空）
                if (item.PropertyType == typeof(bool?))
                {
                    item.SetValue(result, TypeConverter.ToBool(item.Name), null);
                }
                //时间（不可空）
                if (item.PropertyType == typeof(DateTime))
                {
                    item.SetValue(result, TypeConverter.ToDateTime(item.Name).GetValueOrDefault(DateTime.Now), null);
                }
                //时间（可空）
                if (item.PropertyType == typeof(DateTime?))
                {
                    item.SetValue(result, TypeConverter.ToDateTime2(item.Name), null);
                }
                //实数（不可空）
                if (item.PropertyType == typeof(double))
                {
                    item.SetValue(result, TypeConverter.ToDouble(item.Name), null);
                }
                //实数（可空）
                if (item.PropertyType == typeof(double?))
                {
                    item.SetValue(result, TypeConverter.ToDouble2(item.Name), null);
                }
                //十进制实数（不可空）
                if (item.PropertyType == typeof(decimal))
                {
                    item.SetValue(result, TypeConverter.ToDecimal(item.Name), null);
                }
                //十进制实数（可空）
                if (item.PropertyType == typeof(decimal?))
                {
                    item.SetValue(result, TypeConverter.ToDecimal(item.Name), null);
                }
            }
            return result;
        }
        /// <summary>
        /// 字符串转换成Hash表
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static Hashtable ConvertStringToHashtable(string str)
        {
            string[] strArray1 = str.Split(new char[] { ';' });
            Hashtable htValues = new Hashtable();

            string[] strArray2 = new string[2];
            for (int i = 0; i < strArray1.Length; i++)
            {
                strArray2 = strArray1[i].Split(new char[] { ':' });
                if (strArray2.Length >= 2 && !string.IsNullOrEmpty(strArray2[0]))
                {
                    htValues.Add(strArray2[0], strArray2[1]);
                }
            }
            return htValues;
        }
        /// <summary>
        ///  自定义拼接IList某列数据
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="tlist"> 需要拼接的IList</param>
        /// <param name="fieldname">列名</param>
        /// <param name="splitstring">分割符</param>
        /// <param name="usequot">是否使用单引号包含值</param>
        /// <returns>返回拼接后字符串</returns>
        public static string GetModelFieldArrayString<T>(IList<T> tlist, string fieldname, string splitstring, bool usequot)
        {
            Type type = typeof(T);
            PropertyInfo property = type.GetProperty(fieldname);
            if (property == null)
            {
                throw new ArgumentException("fieldname", "");

            }

            if (!usequot || property.PropertyType != typeof(string))
            {
                System.Text.StringBuilder result = new System.Text.StringBuilder(512);
                for (int i = 0; i < tlist.Count; i++)
                {
                    if (i == 0)
                    {
                        result.Append(property.GetValue(tlist[i], null));
                    }
                    else
                    {
                        result.AppendFormat("{0}{1}", splitstring, property.GetValue(tlist[i], null).ToString().Replace(splitstring, " "));
                    }

                }
                return result.ToString();
            }
            else
            {
                System.Text.StringBuilder result = new System.Text.StringBuilder(512);
                for (int i = 0; i < tlist.Count; i++)
                {
                    if (i == 0)
                    {
                        result.AppendFormat("'{0}'", property.GetValue(tlist[i], null));
                    }
                    else
                    {
                        result.AppendFormat("{0}'{1}'", splitstring, property.GetValue(tlist[i], null).ToString().Replace(splitstring, " "));
                    }

                }
                return result.ToString();
            }


        }

      private static int serial = 0;
      
        public static string getKey() 
        {
            StringBuilder sb = new StringBuilder();
            // 获取系统时间并格式化
            DateTime dt = DateTime.Now;
            string dfDate = dt.ToString("yyyyMMddHHmmssffff");

            // 初始值自增
            serial++;

            // 生成3位随机数
            Random rad = new Random();//实例化随机数产生器rad；
            int value = rad.Next(100, 1000);//用rad生成大于等于100，小于等于999的随机数
            
            // 赋值
            sb.Append(dfDate);
            sb.Append(value);
            sb.Append(serial.ToString().PadLeft(3, '0'));

            return sb.ToString();

        }

        public static string Obj2Json<T>(T data)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, data);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
