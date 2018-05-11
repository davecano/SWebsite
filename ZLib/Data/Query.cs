/*
 * 
 * 
 * 修改日志
2012年4月23日星期一
Qm[“Append”] 增加系统自动累加条件
调用时只需要设置Append的条件
 * 目前支持以下几种写法，其中Append不会清空已有数据
   var qm = Query.Build(new { ProductId = 100, ProductName = "%葡萄糖%", SortFields = "ProductId DESC" });
            qm["Append"] = "ID = 10";
            qm["Append"] = " AND NAme LIKE '%IDS%'";
            qm["Append"] = "AND UUU LIKE '%IDS%'";
            qm.In("ID", new string[] { "20", "30", "40" });
            qm.NotIn("Name", new object[] { 1, 2, 3, 4 });
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Z
{
    /// <summary>
    /// 查询词典对象
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    [Serializable]
    public class Query
    {
        /// <summary>
        /// 创建一个查询条件生成类
        /// </summary>
        /// <returns></returns>
        public static Query Build()
        {
            return new Query();
        }


        /// <summary>
        /// 自动根据传入对象建立Query实体
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Query Build(object obj)
        {
            // todo
            var qm = new Query();

            foreach (var item in obj.GetType().GetProperties())
            {
                qm[item.Name] = item.GetValue(obj, null);


            }
            return qm;
        }

        /// <summary>
        /// 查询数据词典 
        /// </summary>
        private Dictionary<string, object> m_QueryDictionary = new Dictionary<string, object>();

        /// <summary>
        /// 查询词典
        /// </summary>
        internal Dictionary<string, object> QueryDictionary
        {
            get { return m_QueryDictionary; }
            set { m_QueryDictionary = value; }
        }


        private DataBaseType m_dbtype = DataBaseType.SqlServer;

        /// <summary>
        /// 数据类型目前仅仅支持SqlServer、Oracle
        /// </summary>
        internal DataBaseType DBType
        {
            get { return m_dbtype; }
            set { m_dbtype = value; }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Query()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dic">需要传入的查询词典</param>
        public Query(IDictionary<string, object> dic)
        {
            m_QueryDictionary = (Dictionary<string, object>)dic;
        }
        /// <summary>
        /// 获取查询实体词典
        /// </summary>
        /// <param name="key">设置字段名称</param>
        /// <returns>待赋值的值</returns>
        public object this[string key]
        {
            get
            {
                if (this.m_QueryDictionary.ContainsKey(key))
                {

                    return this.m_QueryDictionary[key];
                }
                return null;

            }
            set
            {


                // 如果是Append相关 系统必须保证Append是有效的逻辑表达式
                // Append必须为String并且为正常赋值，否则按照正常处理
                if (key == "Append" && !string.IsNullOrEmpty((string)value))
                {
                    string newvalue = (string)value;
                    newvalue = Regex.Replace(newvalue, @"^\s*and\s*|^\s*", "", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline);

                    newvalue = " AND " + newvalue;
                    // 如果目前系统有值
                    if (this.m_QueryDictionary.ContainsKey(key))
                    {
                        string old = (string)this.m_QueryDictionary[key];
                        if (!string.IsNullOrEmpty(old))
                        {
                            this.m_QueryDictionary[key] = old + newvalue;
                        }
                        else
                        {
                            this.m_QueryDictionary[key] = value;
                        }
                    }
                    else
                    {
                        if (!newvalue.StartsWith("1=1"))
                        {
                            this.m_QueryDictionary[key] = "1=1" + newvalue;

                        }
                        else
                            this.m_QueryDictionary[key] = newvalue;
                    }
                }
                else
                {
                    this.m_QueryDictionary[key] = value;
                }
            }
        }

        /// <summary>
        /// 获取查询实体值列表
        /// </summary>
        internal Dictionary<string, object>.KeyCollection Keys
        {
            get { return m_QueryDictionary.Keys; }
        }

        /// <summary>
        /// 自动转换
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static implicit operator Dictionary<string, object>(Query d)
        {
            return d.m_QueryDictionary;
        }
        /// <summary>
        /// 自动转换
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static implicit operator Query(Dictionary<string, object> dic)
        {

            Query qm = new Query(dic);
            return qm;
        }

        /// <summary>
        /// json序列化
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(m_QueryDictionary);
        }

        /// <summary>
        /// 适用于区域多选择
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public Query LikeEndWith(string key,object[] values)
        {
            string sql = "";
            for (int i=0; i < values.Length; i++)
            {
                if (i == 0)
                {
                    sql += key + " like '" + values[i] + "%'";
                }
                else
                {
                    sql += " or  areaid  like '" + values[i] + "%'";
                }
            }
                AddAppend(sql);
            return this;
        }
        /// <summary>
        /// 自动拼接In语句
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public Query In(string key, object[] values)
        {
            AddAppend(string.Format(" AND {0} IN ({1})", key, GetStringSlpit(values)));
            return this;
        }

        /// <summary>
        /// 自动拼接NotIn语句
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public Query NotIn(string key, object[] values)
        {
            AddAppend(string.Format(" AND {0} NOT IN ({1})", key, GetStringSlpit(values)));
            return this;
        }

        /// <summary>
        /// 根据String数组 获取IN 语句
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private string GetStringSlpit(object[] values)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in values)
            {
                sb.AppendFormat("'{0}',", item);
            }
            return sb.ToString().TrimEnd(',');
        }

        /// <summary>
        ///  增加Append的类型
        /// </summary>
        /// <param name="appendinfo">必须为 AND ______ 格式</param>
        void AddAppend(string appendinfo)
        {

            this["Append"] = appendinfo;

        }


        /// <summary>
        /// 增加查询条件
        /// </summary>
        /// <param name="key">查询字段（字段可带>= 或者 =）</param>
        /// <param name="value">查询值</param>
        /// <returns>查询结果</returns>
        public Query Lt(string key, object value)
        {

            return Operate("<=", key, value);
        }
        /// <summary>
        /// 增加查询条件
        /// </summary>
        /// <param name="key">查询字段（字段可带>= 或者 =）</param>
        /// <param name="value">查询值</param>
        /// <returns>查询结果</returns>
        public Query Gt(string key, object value)
        {

            return Operate(">=", key, value);
        }
        /// <summary>
        /// 增加查询条件
        /// </summary>
        /// <param name="key">查询字段（字段不带>= 或者 =）</param>
        /// <param name="value">查询值</param>
        /// <returns>查询结果</returns>
        public Query Gt(string key, object value,bool noteq)
        {

            return Operate(">", key, value);
        }
        /// <summary>
        /// 增加查询条件
        /// </summary>
        /// <param name="key">查询字段（字段可带>= 或者 =）</param>
        /// <param name="value">查询值</param>
        /// <returns>查询结果</returns>
        public Query Eq(string key, object value)
        {

            return Operate("=", key, value);
        }

        /// <summary>
        /// 简单增加一个查询条件由系统自动处理
        /// </summary>
        /// <param name="key">字段</param>
        /// <param name="value">查询的值，字符串类型自动使用LIKE '%{p}%' ， 其余字段一律使用等于查询。</param>
        /// <returns></returns>
        public Query Add(string key, object value)
        {
            return Operate("", key, value);
        }

        /// <summary>
        /// 增加查询条件
        /// </summary>
        /// <param name="key">查询字段（字段可带>= 或者 =）</param>
        /// <param name="value">查询值</param>
        /// <returns>查询结果</returns>
        public Query Like(string key, string value)
        {

            return Operate("", key, value);
        }
        /// <summary>
        /// 增加查询条件
        /// </summary>
        /// <param name="key">查询字段（字段可带>= 或者 =）</param>
        /// <param name="value">查询值</param>
        /// <returns>查询结果</returns>
        public Query Between(string key, object lessvalue, object morevalue)
        {

            return Operate(">=", key, lessvalue).Operate("<=", key, morevalue);
        }


        /// <summary>
        /// 额外的查询条件
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Query Append(string value)
        {

            return Operate("", "append", value);
        }

        /// <summary>
        /// 提供排序字段
        /// </summary>
        /// <param name="value">排序字段ProductId ASC
        /// 注意，如果是p.ProductId 需要写成ProductId。
        /// 系统不支持使用前缀方式的分页查询条件
        /// </param>
        /// <returns>增加该条件后的结果</returns>
        public Query OrderBy(string value)
        {

            return Operate("", "sortfields", value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Query Operate(string op, string key, object value)
        {
            this.m_QueryDictionary[key + op] = value;
            return this;
        }

        /// <summary>
        /// 根据查询词典或者查询条件
        /// </summary>
        /// <returns></returns>
        public string GetCondition(bool useorderby)
        {
            Regex regex = new Regex(">=|>|<=|<|=");
            // return "";
            //构造查询条件
            StringBuilder where = new StringBuilder(512);
            string sortproperty = "";
            foreach (var item in this.m_QueryDictionary.Keys)
            {
                object obj = m_QueryDictionary[item];
                if (obj == null)
                    continue;

                //字符串类型
                if (obj.GetType() == typeof(string))
                {
                    // 排序字段相关
                    if (item.ToLower() == "sortfields")
                    {
                        if (useorderby)
                        {
                            sortproperty = (string)m_QueryDictionary[item];
                        }
                        continue;
                    }
                    if (item.ToLower() == "append")
                    {
                        where.AppendFormat(" AND ({0})", obj);
                        continue;
                    }
                    //if (item.ToLower() == "areaid")
                    //{
                    //    where.AppendFormat(" AND {0} LIKE '{1}%'", item, obj.ToString().TrimEnd('0'));
                    //    continue;
                    //}

                    if (obj.ToString() == string.Empty)
                    {
                        continue;
                    }

                    if (item.EndsWith("%"))
                    {
                        where.AppendFormat(" AND {0} LIKE '{1}'", item.TrimEnd('%'), obj);
                        continue;

                    }
                    if (item.EndsWith("="))
                    {
                        where.AppendFormat(" AND {0} = '{1}'", item.TrimEnd('='), obj);
                        continue;

                    }


                    //主键字段精确查询
                    if (item.ToLower().EndsWith("id"))
                    {
                        where.AppendFormat(" AND {0} = '{1}'", item, obj.ToString().Replace("'", ""));
                    }
                    else
                    {
                        if (regex.IsMatch(item))
                        {
                            where.AppendFormat(" AND {0} {1} '{2}'", regex.Replace(item, ""), regex.Match(item).Value,
                               GetLike(obj.ToString().Replace("'", "")));
                        }
                        else
                        {
                            where.AppendFormat(" AND {0} LIKE '{1}'", item, GetLike(obj.ToString().Replace("'", "")));
                        }
                    }
                }

                //实数类型
                if (obj.GetType() == typeof(double?) || obj.GetType() == typeof(double))
                {

                    if (regex.IsMatch(item))
                    {
                        where.AppendFormat(" AND {0} {1} {2}", regex.Replace(item, ""), regex.Match(item).Value, obj);
                    }
                    else
                    {

                        where.AppendFormat(" AND {0} = {1}", item, obj);
                    }


                }
                //实数类型
                if (obj.GetType() == typeof(decimal?) || obj.GetType() == typeof(decimal))
                {

                    if (regex.IsMatch(item))
                    {
                        where.AppendFormat(" AND {0} {1} {2}", regex.Replace(item, ""), regex.Match(item).Value, obj);
                    }
                    else
                    {

                        where.AppendFormat(" AND {0} = {1}", item, obj);
                    }

                }
                //整数类型
                if (obj.GetType() == typeof(int?) || obj.GetType() == typeof(int))
                {

                    if (regex.IsMatch(item))
                    {
                        where.AppendFormat(" AND {0} {1} {2}", regex.Replace(item, ""), regex.Match(item).Value, obj);
                    }
                    else
                    {
                        where.AppendFormat(" AND {0} = {1}", item, obj);
                    }


                }
                //日期类型
                if (obj.GetType() == typeof(DateTime?) || obj.GetType() == typeof(DateTime))
                {

                    if (regex.IsMatch(item))
                    {
                        if (m_dbtype == DataBaseType.Oracle)
                        {
                            where.AppendFormat(" AND {0} {1} to_date('{2}','yyyy-mm-dd hh24:Mi:ss')", regex.Replace(item, ""), regex.Match(item).Value, ((DateTime)obj).ToString());
                        }
                        else
                            where.AppendFormat(" AND {0} {1} '{2}'", regex.Replace(item, ""), regex.Match(item).Value, ((DateTime)obj).ToString());
                    }
                    else
                    {
                        if (m_dbtype == DataBaseType.Oracle)
                        {
                            where.AppendFormat(" AND {0} = to_date('{1}','yyyy-mm-dd hh24:Mi:ss')", item, ((DateTime)obj).ToString());
                        }
                        else
                            where.AppendFormat(" AND {0} = '{1}'", item, ((DateTime)obj).ToString());
                    }



                }
                //逻辑类型
                if (obj.GetType() == typeof(bool?) || obj.GetType() == typeof(bool))
                {
                    where.AppendFormat(" AND {0} = {1}", item, (((bool)obj) ? 1 : 0));
                }
            }



            if (useorderby)
            {
                if (string.IsNullOrEmpty(sortproperty))
                {
                    throw new Exception("选择排序后，排序字段不能空。");

                }
                return where.ToString() + string.Format(" ORDER BY {0}", sortproperty);
            }
            else
                return where.ToString();


        }
        /// <summary>
        /// 根据查询条件获取相应的查询
        /// </summary>
        /// <param name="condition">LIKE '%ABC%'中的ABC</param>
        /// <returns>处理后的查询</returns>
        private static string GetLike(string condition)
        {
            if (condition.Contains("%"))
            {
                return condition;
            }
            else
            {
                return string.Format("%{0}%", condition);
            }
        }
    }
}
