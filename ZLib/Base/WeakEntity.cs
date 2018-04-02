using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Z
{
    /// <summary>
    /// 用于传递数据的弱类型实体
    /// 
    /// 
    /// </summary>
    public class WeakEntity : EntityBase
    {
        public DataRow Data { get; set; }
        public string PrimaryKey { get; set; }
        private IDictionary<string, object> m_Dic = null;
        private string m_tablename = null;

        /// <summary>
        /// 涉及的表名称
        /// </summary>
        public string TableName
        {
            get { return m_tablename; }
            set { m_tablename = value; }
        }


        /// <summary>
        /// 构造函数，创建一个弱实体
        /// </summary>
        /// <param name="tablename">弱实体映射的表名。
        /// 如果不使用弱实体进行数据库更改可以为空</param>
        public WeakEntity(string tablename, DataRow data)
        {
            m_Dic = new Dictionary<string, object>();
            m_tablename = tablename;
            this.Data = data;
        }

        /// <summary>
        /// 将DataRow转换成实体
        /// </summary>
        /// <param name="dr"></param>
        public override void ParseDataRow(DataRow dr)
        {
            foreach (DataColumn item in dr.Table.Columns)
            {
                m_Dic[item.ColumnName] = Convert.IsDBNull(dr[item]) ? null : dr[item];
            }
        }

        /// <summary>
        /// 将实体数据转换为DataRow
        /// </summary>
        /// <returns></returns>
        public override DataRow ToDataRow()
        {
            DataTable dt = new DataTable();

            foreach (var item in m_Dic.Keys)
            {
                dt.Columns.Add(item);
            }


            var dr = dt.NewRow();

            foreach (var item in m_Dic.Keys)
            {
                dr[item] = m_Dic[item] == null ? Convert.DBNull : m_Dic[item];
            }
            return dr;

        }

        /// <summary>
        /// 将实体转换为json字符串
        /// </summary>
        /// <returns></returns>
        public override string ToJsonString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(m_Dic);
        }

        /// <summary>
        /// 将json字符串反序列化成实体
        /// </summary>
        /// <param name="json"></param>
        public override void ParseJsonString(string json)
        {
            m_Dic = Newtonsoft.Json.JsonConvert.DeserializeObject<IDictionary<string, object>>(json);

        }

        /// <summary>
        /// 对实体进行赋值获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                if (m_Dic.ContainsKey(key))
                {
                    return m_Dic[key];
                }

                return null;

            }
            set
            {

                m_Dic[key] = value;
            }
        }
    }
}
