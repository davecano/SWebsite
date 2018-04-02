/*
 * 
 * 关于数据访问层实体之间转换以及主键缓存等功能
 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Linq.Expressions;

namespace Z.Data
{
    /// <summary>
    /// 与数据访问层相关操作工具
    /// </summary>
    public class DALUtil
    {
        #region 与性能相关的缓存
        static DALUtil()
        {
            // 首次读取底层函数时 配置系统

            Z.EntityConfigurator.Configure();
        }

        /// <summary>
        /// 表名缓存，类型对表信息
        /// </summary>
        internal static Dictionary<Type, string> m_TableNameCache = new Dictionary<Type, string>();


        /// <summary>
        /// 表信息缓存，通过表名查询表的信息
        /// </summary>
        internal static Dictionary<string, TableInfo> m_TableInfoCache = new Dictionary<string, TableInfo>();
        /// <summary>
        /// 列名缓存
        /// TableName_PropertyName = 属性
        /// </summary>
        internal static Dictionary<string, ColumnInfo> m_ColumnNameCache = new Dictionary<string, ColumnInfo>();


        /// <summary>
        /// 主键结果缓存，表对列信息
        /// </summary>
        // 主键缓存与表直接有关
        internal static Dictionary<string, IList<string>> m_PKCache = new Dictionary<string, IList<string>>();


        /// <summary>
        /// 设置类型缓存
        /// </summary>
        internal static readonly Dictionary<Type, Func<Type, object, object>> _queryCache = new Dictionary<Type, Func<Type, object, object>>();

        #endregion

        #region 将数据返回实体


        /// <summary>
        /// 根据Idatareader获取实体列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="idr">相关的Idatareader</param>
        /// <returns>实体数组</returns>
        public static List<T> GetEntity<T>(IDataReader idr)
        {
            List<T> lst = new List<T>();
            Dictionary<string, Func<T, object, object>> dic = new Dictionary<string, Func<T, object, object>>();
            var dt = idr.GetSchemaTable();

            List<string> columns = new List<string>();
            foreach (DataRow item in dt.Rows)
            {
                columns.Add(item["ColumnName"].ToString().ToUpper());
            }

            foreach (var item in typeof(T).GetProperties())
            {
                // 如果字段含有该列数据
                if (columns.Contains(GetColumnName(item).ToUpper()))
                {
                    Func<T, object, object> fc = SetDelegate<T>(item.GetSetMethod(), item.PropertyType);
                    dic.Add(item.Name.ToUpper(), fc);
                }
            }

            while (idr.Read())
            {
                T model = (T)Activator.CreateInstance(typeof(T));

                foreach (var item in typeof(T).GetProperties())
                {

                    if (dic.ContainsKey(item.Name.ToUpper()) && !Convert.IsDBNull(idr[GetColumnName(item).ToUpper()]))
                    {
                        Func<T, object, object> fc = dic[item.Name.ToUpper()];
                        fc(model, ChangeType(idr[GetColumnName(item).ToUpper()], item.PropertyType));
                    }
                }
                lst.Add(model);
            }
            return lst;
        }



        /// <summary>
        /// 根据DataTable获取实体列表
        /// </summary>
        /// <typeparam name="T">泛型实体类型</typeparam>
        /// <param name="dt">数据DataTable</param>
        /// <returns>实体列表</returns>
        public static List<T> GetEntity<T>(DataTable dt)
        {
            List<T> lst = new List<T>();
            Dictionary<string, Func<T, object, object>> dic = new Dictionary<string, Func<T, object, object>>();

            foreach (var item in typeof(T).GetProperties())
            {
                // 如果字段含有该列数据
                if (dt.Columns.Contains(GetColumnName(item)))
                {
                    Func<T, object, object> fc = SetDelegate<T>(item.GetSetMethod(), item.PropertyType);
                    dic.Add(item.Name, fc);
                }
            }

            foreach (DataRow dr in dt.Rows)
            {
                T model = (T)Activator.CreateInstance(typeof(T));


                foreach (var item in typeof(T).GetProperties())
                {

                    if (dic.ContainsKey(item.Name) && !Convert.IsDBNull(dr[GetColumnName(item)]))
                    {
                        Func<T, object, object> fc = dic[item.Name];
                        fc(model, ChangeType(dr[GetColumnName(item)], item.PropertyType));
                    }
                }
                lst.Add(model);
            }

            return lst;
        }


        /// <summary>
        /// 生成赋值的express tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="m"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Func<T, object, object> SetDelegate<T>(MethodInfo m, Type type)
        {
            ParameterExpression param_obj = Expression.Parameter(typeof(T), "obj");
            ParameterExpression param_val = Expression.Parameter(typeof(object), "val");



            UnaryExpression body_val = Expression.Convert(param_val, type);

            MethodCallExpression body = Expression.Call(param_obj, m, body_val);
            Action<T, object> set = Expression.Lambda<Action<T, object>>(body, param_obj, param_val).Compile();

            return (instance, v) =>
            {
                set(instance, v);
                return null;
            };
        }

        #endregion

        #region 获取实体的特性信息


        /// <summary>
        /// 根据实体获取表名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal static string GetTableName<T>() where T : class ,new()
        {
            var type = typeof(T);

            return GetTableName(type);
        }
        /// <summary>
        /// 根据实体获取表名
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        internal static string GetTableName(Type type)
        {
            if (m_TableNameCache.ContainsKey(type))
            {
                return m_TableNameCache[type];
            }
            else
            {

                string tablename =  type.Name;
                object[] tableobjs = type.GetCustomAttributes(typeof(TableAttribute), false);

                if (tableobjs.Length > 0)
                {
                    var att = ((TableAttribute)tableobjs[0]);
                    string s = att.TableName;
                    if (!string.IsNullOrEmpty(s))
                        tablename = s;


                    m_TableNameCache[type] = tablename;


                    m_TableInfoCache[tablename] = new TableInfo() { TableName = tablename, IdentityTable = att.IdentityTable, ClassType = type };

                    return tablename;
                } //获取自定义表名
                else
                {
                    m_TableNameCache[type] = tablename;
                    return tablename;
                }
            }
        }
        /// <summary>
        /// 获取列对应的数据库字段名
        /// </summary>
        /// <param name="property">反射的属性名</param>
        /// <returns>数据库字段名</returns>
        internal static string GetColumnName(PropertyInfo property)
        {
            var str = GetTableName(property.DeclaringType) + "_" + property.Name;
            // 缓存第一优先
            if (m_ColumnNameCache.ContainsKey(str))
            {
                return m_ColumnNameCache[str].ColumnName;
            }
            else
            {

                string columnname = property.Name;
                object[] objs = property.GetCustomAttributes(typeof(ColumnAttribute), false);
                if (objs.Length > 0)
                {

                    string tempc = ((ColumnAttribute)objs[0]).ColumnName;
                    if (!string.IsNullOrEmpty(tempc))
                    {

                        columnname = tempc;
                    }
                    

                    // 类属性存在 则直接新增到缓存中
                    m_ColumnNameCache[str] = new ColumnInfo() { ColumnName = columnname, PrimaryKey = ((ColumnAttribute)objs[0]).PrimaryKey, PropertyName = property.Name };
                    return columnname;
                }
                else
                {
                    // 类属性不存在 则按照默认规则存储。
                    m_ColumnNameCache[str] = new ColumnInfo() { ColumnName = columnname, PrimaryKey = false, PropertyName = property.Name };
                    return columnname;
                }
            }
        }



        /// <summary>
        /// 根据实体类型获取主键
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static IList<string> GetPKAttribute<T>()
        {
            var type = typeof(T);
            return GetPKAttribute(type);
        }
        /// <summary>
        /// 根据实体类型获取主键
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static IList<string> GetPKAttribute(Type type)
        {
            if (m_PKCache.ContainsKey(GetTableName(type)))
            {
                return new List<string>(m_PKCache[GetTableName(type)]);
            }
            else
            {
                // 如果缓存不存在， 直接读取配置硬数据
                List<string> pkstring = new List<string>();
                foreach (var item in type.GetProperties())
                {
                    if (IsPK(item, type))
                    {
                        pkstring.Add(GetColumnName(item));
                    }

                }

                // todo
                /*if (m_PKCache[GetTableName(type)])
                {= pkstring;
                    
                }
                 */
                return pkstring;
            }

        }


        /// <summary>
        /// 该属性是否该实体的主键
        /// </summary>
        /// <param name="item">字段属性</param>
        /// <param name="type">实体类型</param>
        /// <returns>true or false</returns>
        internal static bool IsPK(PropertyInfo item, Type type)
        {

            string tablename = GetTableName(type);
            IList<string> pks = null;
            if (m_PKCache.ContainsKey(tablename))
            {
                pks = m_PKCache[tablename];
                var columnname = GetColumnName(item);
                if (pks.Contains(columnname))
                {
                    return true;
                }
            }






            object[] objarrays = item.GetCustomAttributes(typeof(ColumnAttribute), false);

            return objarrays.Length > 0 && (objarrays[0] as ColumnAttribute).PrimaryKey;
        }

        /// <summary>
        /// 获取属性的序列对象 Oracle数据库生成序列实体时专用
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        internal static string GetSeqenceName(PropertyInfo item)
        {
            // 强定义优先
            object[] objarrays = item.GetCustomAttributes(typeof(ColumnAttribute), false);
            if (objarrays.Length > 0)
            {
                ColumnAttribute ca = objarrays[0] as ColumnAttribute;
                return ca.SeqenceName;
            }
            else
            {
                string key = GetTableName(item.DeclaringType) + "_" + item.Name;
                // 从配置缓存中读取
                if (m_ColumnNameCache.ContainsKey(key))
                {
                    return m_ColumnNameCache[key].SeqenceName;
                }
                else
                {
                    return "";
                }

            }
        }

        #endregion

        #region 数据库增删改相关参数




        /// <summary>
        /// 获取实体Sqlparameter
        /// </summary>
        /// <typeparam name="T">实体对象类型</typeparam>
        /// <param name="t">实体</param>
        /// <returns>Sqlparameter列表</returns>
        internal static IList<IDataParameter> GetParasPure<T>(T t, IDbHelper idb)
        {
            List<IDataParameter> paras = new List<IDataParameter>();
            Type type = typeof(T);
            foreach (var item in type.GetProperties())
            {
                object value = item.GetValue(t, null);
                if (value == null)
                {
                    continue;
                }

                if (item.PropertyType == typeof(double?) && double.IsNaN(((double?)value).Value))
                {
                    value = Convert.DBNull;
                }

                if (item.PropertyType == typeof(DateTime?) && ((DateTime?)value).Value == DateTime.MinValue)
                {
                    value = Convert.DBNull;
                }
                if (item.PropertyType == typeof(int?) && ((int?)value).Value == int.MinValue)
                {
                    value = Convert.DBNull;
                }

                if (item.PropertyType == typeof(decimal?) && ((decimal?)value).Value == decimal.MinValue)
                {
                    value = Convert.DBNull;
                }
                IDataParameter para = GetIDataParameter(idb);
                para.ParameterName = GetParameterPrefix(idb) + GetColumnName(item);
                para.Value = value;
                paras.Add(para);
            }
            return paras;

        }


        /// <summary>
        /// 参数化获取插入的参数化语句
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="t">实体对象</param>
        /// <param name="sql">返回需要执行的语句</param>
        /// <param name="idb">数据库上下文</param>
        /// <returns>返回执行的DataParameter</returns>
        internal static IList<IDataParameter> GetModelInsertParas<T>(T t, out string sql, IDbHelper idb) where T : class ,new()
        {
            StringBuilder sbfields = new StringBuilder();
            StringBuilder sbvalues = new StringBuilder();
            Type type = typeof(T);
            // 系统中是否存在序列
            // bool isseq = false;
            // 序列名
            string seqname = "";
            foreach (var item in type.GetProperties())
            {
                object value = item.GetValue(t, null);

                // 如果是Oracle数据库并且系统使用序列作为插入对象
                if (idb.DBType == DataBaseType.Oracle)
                {
                    string SeqenceName = GetSeqenceName(item);
                    if (!string.IsNullOrEmpty(SeqenceName))
                    {
                        // isseq = true;
                        seqname = SeqenceName;
                        sbfields.Append(string.Format("{0},", GetColumnName(item)));
                        sbvalues.AppendFormat("{0}.nextval,", SeqenceName);
                    }
                }


                if (value != null)
                {
                    sbfields.Append(string.Format("{0},", GetColumnName(item)));
                    sbvalues.AppendFormat("{1}{0},", GetColumnName(item), GetParameterPrefix(idb));
                }
            }
            string tablename = GetTableName<T>();

            sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tablename, sbfields.ToString().TrimEnd(','), sbvalues.ToString().TrimEnd(','));

            if (IsIdentityTable<T>() && idb.DBType == DataBaseType.SqlServer)
            {
                sql += "\r\nSELECT SCOPE_IDENTITY()";
            }
            //if (isseq && idb.DBType == DataBaseType.Oracle)
            //{
            //    sql += string.Format("\r\nSELECT {0}.curval FROM DUAL", seqname);
            //}
            return GetParasPure(t, idb);
        }

        /// <summary>
        /// 获取更新实体的执行语句以及执行参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        internal static IList<IDataParameter> GetModelUpdateParas<T>(T t, out string sql, IDbHelper idb) where T : class, new()
        {
            StringBuilder sbpk = new StringBuilder();
            StringBuilder sbfields = new StringBuilder();
            Type type = typeof(T); //获取类型




            string tablename = GetTableName<T>();
            foreach (var item in type.GetProperties())
            {
                if (item.GetValue(t, null) == null)
                {
                    continue;
                }


                bool ispk = IsPK(item, type);


                if (ispk)
                {
                    sbpk.AppendFormat(" AND {0} = {1}{0}", GetColumnName(item), GetParameterPrefix(idb));
                }
                else
                {
                    sbfields.AppendFormat(",{0} = {1}{0}", GetColumnName(item), GetParameterPrefix(idb));
                }
            }
            if (sbpk.Length == 0)
            {
                throw new Exception("无主键的实体无法更新");
            }
            sql = string.Format("UPDATE {0} SET {1} WHERE 1=1{2}", tablename, sbfields.ToString().TrimStart(','), sbpk.ToString());
            return GetParasPure(t, idb);
        }

        /// <summary>
        /// 获取指定数据库操作类的Parameter
        /// </summary>
        /// <param name="idb"></param>
        /// <returns></returns>
        private static IDataParameter GetIDataParameter(IDbHelper idb)
        {


            return (idb as DbHelper).DbProviderFactory.CreateParameter();

        }





        /// <summary>
        /// 获取删除参数
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">实体</param>
        /// <param name="sql">获取删除的sql</param>
        /// <returns></returns>
        internal static IList<IDataParameter> GetModelDeleteParas<T>(T t, out string sql, IDbHelper idb) where T : class ,new()
        {

            IList<IDataParameter> re = new List<IDataParameter>();
            StringBuilder sb = new StringBuilder();
            Type type = typeof(T);
            string tablename = GetTableName<T>();
            IList<string> keys = GetPKAttribute<T>();
            bool first = true;
            foreach (var item in keys)
            {
                PropertyInfo property = type.GetProperty(item);
                if (first)
                {
                    sb.AppendFormat("{0} = {1}{0}", property.Name, GetParameterPrefix(idb));
                    first = false;
                }
                else
                {
                    sb.AppendFormat(" AND {0} = {1}{0}", property.Name, GetParameterPrefix(idb));
                }
                var idp = idb.GetIDataParameter();
                idp.ParameterName = GetParameterPrefix(idb) + property.Name;
                idp.Value = property.GetValue(t, null);
                re.Add(idp);
            }
            sql = string.Format("DELETE FROM {0} WHERE {1}", tablename, sb.ToString());
            return re;
        }

        #endregion

        #region 与数据库相关


        /// <summary>
        /// 根据数据库类型获取参数化的前缀
        /// </summary>
        /// <param name="idb">数据库上下文</param>
        /// <returns>oracle返回:，SqlServer返回@</returns>
        internal static string GetParameterPrefix(IDbHelper idb)
        {

            if (idb.DBType == DataBaseType.Oracle || idb.DBType == DataBaseType.SQLite)
            {
                return ":";
            }
            else if (idb.DBType == DataBaseType.Mysql)
            {
                return "?";
            }
            else
            {
                return "@";
            }
        }
        #endregion


        /// <summary>
        /// 获取表格是否Identity表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal static bool IsIdentityTable<T>()
        {

            object[] objs = typeof(T).GetCustomAttributes(typeof(TableAttribute), false);
            if (objs.Length > 0)
            {
                var tb = objs[0] as TableAttribute;
                return tb.IdentityTable;
            }
            else
                return false;
        }

        /// <summary>
        /// 将值变换为目标类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        internal static object ChangeType(object value, Type conversionType)
        {
            // 相同转换类型直接转换
            if (value.GetType() == conversionType || conversionType.FullName.Contains(value.GetType().FullName))
            {
                return value;
            }
            else // 不同类型之间转换
            {

                if (conversionType == typeof(int) || conversionType == typeof(int?))
                {
                    return TypeConverter.ToInt32(value);

                }
                else if (conversionType == typeof(Int64) || conversionType == typeof(Int64?))
                {
                    return TypeConverter.ToInt64(value);
                }
                else if (conversionType == typeof(double) || conversionType == typeof(double?))
                {
                    return TypeConverter.ToDouble(value);
                }
                else if (conversionType == typeof(decimal) || conversionType == typeof(decimal?))
                {
                    return TypeConverter.ToDecimal(value);
                }
                else if (conversionType == typeof(DateTime) || conversionType == typeof(DateTime?))
                {
                    return TypeConverter.ToDateTime(value);
                }
                else if (conversionType == typeof(bool) || conversionType == typeof(bool?))
                {
                    return TypeConverter.ToBool(value);
                }
            }

            return Convert.ChangeType(value, conversionType);
        }

        /// <summary>
        /// 实体是否有Sequence特性
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <returns></returns>
        internal static bool SequenceInsert<T>()
        {
            if (!string.IsNullOrEmpty(GetSequenceName<T>()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取该对象Sequence
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal static string GetSequenceName<T>()
        {

            Type type = typeof(T);

            string seqname = "";
            foreach (var item in type.GetProperties())
            {
                string tmp = GetSeqenceName(item);

                if (!string.IsNullOrEmpty(tmp))
                {
                    seqname = tmp;
                    break;

                }
            }


            return seqname;
        }
    }
}
