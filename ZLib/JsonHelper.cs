using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;
using System.Data;
namespace Z
{
   public class JsonHelper
    {

       /// <summary>
        /// List<T>转Json
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="data"></param>
       /// <returns></returns>
        public static string Obj2Json<T>(T data)
        {
            try
            {
                DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
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

       /// <summary>
        /// Json转List<T>
       /// </summary>
       /// <param name="json"></param>
       /// <param name="t"></param>
       /// <returns></returns>
        public static Object Json2Obj(String json, Type t)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(t);
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    return serializer.ReadObject(ms);
                }
            }
            catch
            {
                return null;
            }
        }


       /// <summary>
       /// datatable转json
       /// </summary>
       /// <param name="dt"></param>
       /// <returns></returns>
        public static string DataTable2Json(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            StringBuilder jsonBuilder = new StringBuilder();
            // jsonBuilder.Append("{"); 
            //jsonBuilder.Append(dt.TableName.ToString());  
            jsonBuilder.Append("[");//转换成多个model的形式
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            //  jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

       /// <summary>
        /// Json转对象
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="json"></param>
       /// <returns></returns>
        public static T Json2Obj<T>(string json)
        {

            T obj = Activator.CreateInstance<T>();

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {

                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());

                return (T)serializer.ReadObject(ms);

            }

        }
    }
}
