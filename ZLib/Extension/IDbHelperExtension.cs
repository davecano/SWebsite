using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z.Data;
using System.Data;
using System.Text.RegularExpressions;

namespace Z
{
    /// <summary>
    /// 所有新框架对外开放扩展方法
    /// </summary>
    public static class IDbHelperExtension
    {

        #region Query

        /// <summary>
        /// 查询数据并返回DataTable
        /// </summary>
        /// <param name="idb">数据连接上下文</param>
        /// <param name="sql">待执行的语句</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页数据量（0，表示不分页）</param>
        /// <param name="totalcount">查询记录总数</param>
        /// <returns>返回结果DataTable</returns>
        public static DataTable Query(this IDbHelper idb, string sql, int pageindex, int pagesize, out int totalcount)
        {
            totalcount = 0;
            return Query(idb, sql, pageindex, pagesize, out totalcount, true);
        }

        /// <summary>
        /// 查询数据并返回DataTable
        /// </summary>
        /// <param name="idb">数据连接上下文</param>
        /// <param name="sql">待执行的语句</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页数据量（0，表示不分页）</param>
        /// <returns>返回结果DataTable</returns>
        public static DataTable Query(this IDbHelper idb, string sql, int pageindex, int pagesize)
        {
            int totalcount = 0;
            return Query(idb, sql, pageindex, pagesize, out totalcount, false);
        }

     
        /// <summary>
        /// 核心调用，所有关于分页的重载方法都是调用本函数
        /// 
        /// 查询数据并返回对象实体列表DataTable
        /// </summary>
        /// <param name="idb">数据连接上下文</param>
        /// <param name="sql">待执行的语句</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="totalcount">记录总数</param>
        /// <param name="bl_getcount">是否获取记录总数，如果是true返回正确的记录总数，false返回0.</param>
        /// <returns>返回结果DataTable</returns>
        public static DataTable Query(this IDbHelper idb, string sql, int pageindex, int pagesize, out int totalcount, bool bl_getcount)
        {
            Z.Data.PageDescribe des = new Z.Data.PageDescribe(sql, pagesize);
            des.PageIndex = pageindex;
            des.IDbHelper = idb;

            if (bl_getcount)
            {
                totalcount = des.TotalCount;
            }
            else
            {
                totalcount = 0;
            }
            return des.GetSpecailPage();
        }

        /// <summary>
        /// 查询数据并返回对象实体列表DataTable
        /// </summary>
        /// <param name="idb">数据连接上下文</param>
        /// <param name="tablename">待查询的表名或者视图名</param>
        /// <param name="query">查询Query对象</param>
        /// <param name="pageindex">查询页码</param>
        /// <param name="pagesize">每页数据量（0，表示不分页）</param>
        /// <returns>返回结果DataTable</returns>
        public static DataTable Query(this IDbHelper idb, string tablename, Query query, int pageindex, int pagesize)
        {

            int totalcount;
            return Query(idb, tablename, query, pageindex, pagesize, out totalcount, false);
        }

        /// <summary>
        /// 查询数据并返回对象实体列表DataTable
        /// </summary>
        /// <param name="idb">数据连接上下文</param>
        /// <param name="tablename">待查询的表名或者视图名</param>
        /// <param name="query">查询Query对象</param>
        /// <param name="pageindex">查询页码</param>
        /// <param name="pagesize">每页数据量（0，表示不分页）</param>
        /// <param name="totalcount">返回记录总数</param>
        /// <returns>返回结果DataTable</returns>
        public static DataTable Query(this IDbHelper idb, string tablename, Query query, int pageindex, int pagesize, out int totalcount)
        {
            return Query(idb, tablename, query, pageindex, pagesize, out totalcount, true);
        }

        /// <summary>
        /// 查询数据并返回DataTable
        /// </summary>
        /// <param name="idb">数据连接上下文</param>
        /// <param name="tablename">待查询的表名或者视图名</param>
        /// <param name="query">查询Query对象</param>
        /// <param name="pageindex">查询页码</param>
        /// <param name="pagesize">每页数据量（0，表示不分页）</param>
        /// <param name="totalcount">返回记录总数，如果不获取记录总数返回0.</param>
        /// <param name="bl_getocunt">是否获取记录总数</param>
        /// <returns>返回结果DataTable</returns>
        public static DataTable Query(this IDbHelper idb, string tablename, Query query, int pageindex, int pagesize, out int totalcount, bool bl_getocunt)
        {
            query.DBType = idb.DBType; // 设置数据库类型
            string sql = "SELECT * FROM {0} WHERE 1=1 {1}";
            sql = string.Format(sql, tablename, query.GetCondition(true));
            return Query(idb, sql, pageindex, pagesize, out totalcount, bl_getocunt);
        }

        /// <summary>
        /// 查询数据并返回对象实体列表
        /// </summary>
        /// <typeparam name="T">对象实体</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="query">查询Query对象</param>
        /// <param name="pageindex">查询页码</param>
        /// <param name="pagesize">每页数据量（0，表示不分页）</param>
        /// <returns>返回结果实体对象列表</returns>
        public static IList<T> Query<T>(this IDbHelper idb, Query query, int pageindex, int pagesize) where T : class, new()
        {
            int totalcount;
            return Query<T>(idb, query, pageindex, pagesize, out totalcount, false);
        }

        /// <summary>
        /// 查询数据分页并返回对象实体列表
        /// </summary>
        /// <typeparam name="T">对象实体类型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="query">查询Query对象</param>
        /// <param name="pageindex">查询页码</param>
        /// <param name="pagesize">每页数据量（0，表示不分页）</param>
        /// <param name="totalcount">记录总数，系统必定返回记录总数</param>
        /// <returns>返回结果实体对象列表</returns>
        public static IList<T> Query<T>(this IDbHelper idb, Query query, int pageindex, int pagesize, out int totalcount) where T : class, new()
        {

            return Query<T>(idb, query, pageindex, pagesize, out totalcount, true);
        }

        /// <summary>
        /// 蒋林彬扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="idb"></param>
        /// <param name="sql"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalcount"></param>
        /// <param name="bl_getcount"></param>
        /// <returns></returns>
        public static IList<T> Query<T>(this IDbHelper idb, string sql, int pageindex, int pagesize, out int totalcount) where T : class, new()
        {

            var dt = Query(idb, sql, pageindex, pagesize, out totalcount, true);

            return DALUtil.GetEntity<T>(dt);

        }

        /// <summary>
        /// 查询数据并返回对象实体列表
        /// </summary>
        /// <typeparam name="T">对象实体</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="query">查询Query对象</param>
        /// <param name="pageindex">查询页码</param>
        /// <param name="pagesize">每页数据量（0，表示不分页）</param>
        /// <param name="totalcount">记录总数，如果不获取记录总数返回0.</param>
        /// <param name="bl_getcount">是否获取记录总数</param>
        /// <returns>实体对象列表</returns>
        public static IList<T> Query<T>(this IDbHelper idb, Query query, int pageindex, int pagesize, out int totalcount, bool bl_getcount) where T : class, new()
        {

            string sql = "SELECT * FROM {0} WHERE 1=1 {1}";
            sql = string.Format(sql, DALUtil.GetTableName<T>(), query.GetCondition(true));

            var dt = Query(idb, sql, pageindex, pagesize, out totalcount, bl_getcount);

            return DALUtil.GetEntity<T>(dt);

        }

        /// <summary>
        /// jlb扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="idb"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IList<T> Query<T>(this IDbHelper idb, Query query) where T : class, new()
        {

            string sql = "SELECT * FROM {0} WHERE 1=1 {1}";
            sql = string.Format(sql, DALUtil.GetTableName<T>(), query.GetCondition(true));
           
            var dt = idb.ExecuteTable(sql);

            return DALUtil.GetEntity<T>(dt);

        }
        /// <summary>
        /// 蒋林彬扩展
        /// </summary>
        /// <param name="idb"></param>
        /// <param name="tablename"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataTable Query(this IDbHelper idb, string tablename, Query query)
        {
            query.DBType = idb.DBType; // 设置数据库类型
            string sql = "SELECT * FROM {0} WHERE 1=1 {1}";
            sql = string.Format(sql, tablename, query.GetCondition(true));
            return idb.ExecuteTable(sql);
        }

        static Regex select = new Regex("^select", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// 查询数据返回实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="sql">查询的sql语句</param>
        /// <returns>返回的实体对象列表</returns>
        public static IList<T> Query<T>(this IDbHelper idb, string sql) where T : class, new()
        {
            if (!select.IsMatch(sql))
            {
                sql = string.Format("SELECT * FROM {0} WHERE {1}", DALUtil.GetTableName<T>(), sql);
            }

            using (var idr = idb.ExecuteReader(sql))
            {
                return DALUtil.GetEntity<T>(idr);
            }

        }

        /// <summary>
        /// 查询数据返回实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="sql">查询的sql语句</param>
        /// <param name="paras">查询的参数列表，例如WHERE条件中Id=@0，@0 为第一个参数</param>
        /// <returns>返回的实体对象列表</returns>
        public static IList<T> Query<T>(this IDbHelper idb, string sql, object[] paras) where T : class, new()
        {
            if (!select.IsMatch(sql))
            {
                sql = string.Format("SELECT * FROM {0} WHERE {1}", DALUtil.GetTableName<T>(), sql);
            }

            List<IDataParameter> list = new List<IDataParameter>();
            int i = 0;
            foreach (var item in paras)
            {
                var idp = idb.GetIDataParameter();
                idp.ParameterName = DALUtil.GetParameterPrefix(idb) + i++.ToString();
                idp.Value = item;
                list.Add(idp);
            }
            if (idb.DBType == DataBaseType.Oracle)
            {

                sql = sql.Replace("@", ":");
            }
            using (var idr = idb.ExecuteReader(CommandType.Text, sql, list.ToArray()))
            {
                return DALUtil.GetEntity<T>(idr);
            }
        }


        #endregion

        #region"根据条件查询单个实体"
        public static T GetEntityWithQuery<T>(this IDbHelper idb, Query query) where T : class, new()
        {

            string sql = "SELECT * FROM {0} WHERE 1=1 {1}";
            sql = string.Format(sql, DALUtil.GetTableName<T>(), query.GetCondition(false));

            var dt = idb.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {

                return DALUtil.GetEntity<T>(dt)[0];
            }
            else
            {
                return default(T);
            }

        }

        #endregion
        #region"根据sql语句得到单个实体"
        public static T GetEntityWithSql<T>(this IDbHelper idb, string sql) where T : class, new()
        {
            var dt = idb.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {

                return DALUtil.GetEntity<T>(dt)[0];
            }
            else
            {
                return default(T);
            }

        }

        #endregion
        #region GetModelById

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="pk">主键 例如id=1 写入 GetEntityById(1)</param>
        /// <returns>如果存在该实体，返回实体，否则返回null。</returns>
        /// <remarks>
        /// 对于多主键实体，主键的顺序必须是 实体的顺序否则系统会取不到正确的数据。
        /// 
        /// </remarks>
        public static T GetEntityById<T>(this IDbHelper idb, params object[] pk) where T : class, new()
        {

            // 根据实体获取主键
            var pklist = DALUtil.GetPKAttribute<T>();
            if (pklist.Count != pk.Count())
            {
                // 实体的主键 个数如果不一致 系统自动抛出异常
                throw new Exception("主键设置个数不一致");
            }
            List<IDataParameter> list = new List<IDataParameter>();
            string where = "1=1";
            for (int i = 0; i < pklist.Count; i++)
            {
                where += " AND " + pklist[i] + " = " + DALUtil.GetParameterPrefix(idb) + i.ToString();
                var idp = idb.GetIDataParameter();
                idp.ParameterName = DALUtil.GetParameterPrefix(idb) + i.ToString();
                idp.Value = pk[i];
                list.Add(idp);
            }

            var dt = idb.ExecuteTable(CommandType.Text, string.Format("SELECT * FROM {0} WHERE {1}", DALUtil.GetTableName<T>(), where), list.ToArray());
            if (dt.Rows.Count > 0)
            {

                return DALUtil.GetEntity<T>(dt)[0];
            }
            else
            {
                return default(T);
            }
        }

        #endregion


        #region 增删改

        /// <summary>
        /// 修改一个实体，注意主键必须赋值
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="entity">需要修改的实体</param>
        /// <returns>成功影响的条数，如果没有修改返回0.</returns>
        public static int Update<T>(this IDbHelper idb, T entity) where T : class, new()
        {
            string sql;
            IList<IDataParameter> paras = null;
            // 获取待更新的参数列表
            paras = DALUtil.GetModelUpdateParas<T>(entity, out sql, idb);
            return idb.ExecuteNonQuery(CommandType.Text, sql, paras.ToArray());
        }
        /// <summary>
        /// 根据指定主键删除一个实体 
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="pk">主键列表，注意：主键列表的顺序必须与实体完全一致</param>
        /// <param name="pk1">主键值</param>
        /// <returns>返回影响的记录条数，如果该数据不存在返回0</returns>
        public static int Delete<T>(this IDbHelper idb, string pk1) where T : class, new()
        {
            return Delete<T>(idb, new object[] { pk1 });
        }
        /// <summary>
        /// 根据指定主键删除一个实体 
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="pk">主键列表，注意：主键列表的顺序必须与实体完全一致</param>
        /// <param name="pk1">主键值
        /// </param>
        /// <param name="pk2">主键值</param>
        /// <returns>返回影响的记录条数，如果该数据不存在返回0</returns>
        public static int Delete<T>(this IDbHelper idb, string pk1, string pk2) where T : class, new()
        {
            return Delete<T>(idb, new object[] { pk1, pk2 });
        }

        /// <summary>
        /// 根据指定主键删除一个实体 
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="pk1">主键值
        /// </param>
        /// <param name="pk2">主键值列表，注意：主键列表的顺序必须与实体完全一致</param>
        /// <returns>返回影响的记录条数，如果该数据不存在返回0</returns>
        public static int Delete<T>(this IDbHelper idb, int pk1, int pk2) where T : class, new()
        {
            return Delete<T>(idb, new object[] { pk1, pk2 });
        }

        /// <summary>
        /// 根据指定主键删除一个实体 
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="pk1">主键值列表，注意：主键列表的顺序必须与实体完全一致
        /// </param>
        /// <returns>返回影响的记录条数，如果该数据不存在返回0</returns>
        public static int Delete<T>(this IDbHelper idb, int pk1) where T : class, new()
        {
            return Delete<T>(idb, new object[] { pk1 });
        }

        /// <summary>
        /// 根据指定主键删除一个实体 
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="pk">主键列表，注意：主键列表的顺序必须与实体完全一致</param>
        /// <returns>返回影响的记录条数，如果该数据不存在返回0</returns>
        public static int Delete<T>(this IDbHelper idb, object[] pk) where T : class, new()
        {

            string tablename = DALUtil.GetTableName<T>();
            var pks = DALUtil.GetPKAttribute<T>();
            if (pks.Count != pk.Length)
            {
                throw new Exception("主键个数与传入参数不一致");
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pk.Length; i++)
            {
                sb.AppendFormat(" AND {0} = '{1}'", pks[i], pk[i]);
            }

            string sql = string.Format("DELETE FROM {0} WHERE 1=1{1}", tablename, sb.ToString());
            return idb.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据实体内的主键删除一个实体
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="entity">待删除的实体，注意：实体的主键必须赋值</param>
        /// <returns>返回影响的记录条数，如果该数据不存在返回0</returns>
        public static int Delete<T>(this IDbHelper idb, T entity) where T : class, new()
        {
            string sql;
            IList<IDataParameter> paras = null;

            // 获取待删除的参数列表
            paras = DALUtil.GetModelDeleteParas<T>(entity, out sql, idb);
            if (paras.Count == 0)
            {

                throw new EntityErrorException("没有主键参数的数据不能删除", entity);
            }
            return idb.ExecuteNonQuery(CommandType.Text, sql, paras.ToArray());
        }

        /// <summary>
        /// 插入一条新的记录
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="idb">数据库连接上下文</param>
        /// <param name="entity">待新增的实体，注意：如果是Sql server标识列或者oracle使用序列生成主键的，主键请留空。</param>
        /// <returns>返回影响的记录条数</returns>
        public static int Insert<T>(this IDbHelper idb, T entity) where T : class, new()
        {

            string sql;
            IList<IDataParameter> paras = null;
            // 获取插入的参数列表
            paras = DALUtil.GetModelInsertParas<T>(entity, out sql, idb);

            if (idb.DBType == DataBaseType.SqlServer && DALUtil.IsIdentityTable<T>())
            {
                return Convert.ToInt32(idb.ExecuteScalar(CommandType.Text, sql, paras.ToArray()));
            }
            else if (idb.DBType == DataBaseType.Oracle && DALUtil.SequenceInsert<T>())
            {
                string seqname = DALUtil.GetSequenceName<T>();
                // 如果启用事务
                if (idb.IsStartTrans)
                {
                    idb.ExecuteNonQuery(CommandType.Text, sql, paras.ToArray());

                    int n = Convert.ToInt32(idb.ExecuteScalar(string.Format("SELECT {0}.CURRVAL FROM DUAL", seqname)));
                    return n;
                }
                // 不启动事务
                else
                {
                    try
                    {
                        idb.BeginTrans();
                        idb.ExecuteNonQuery(CommandType.Text, sql, paras.ToArray());

                        int n = Convert.ToInt32(idb.ExecuteScalar(string.Format("SELECT {0}.CURRVAL FROM DUAL", seqname)));
                        idb.CommitTrans();
                        return n;
                    }
                    catch (Exception ex)
                    {
                        idb.RollTrans();

                        throw ex;
                    }

                }
            }
            else

                return idb.ExecuteNonQuery(CommandType.Text, sql, paras.ToArray());

        }

        #endregion

        #region 弱实体操作

        static int WeakEntityInsert(this IDbHelper idb, WeakEntity entity)
        {
            return 1;
        }


        static int WeakEntityUpdate(this IDbHelper idb, WeakEntity entity)
        {
            return 1;
        }

        #endregion

    }
}