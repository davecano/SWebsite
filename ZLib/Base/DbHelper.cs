using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Z.Data
{
    /// <summary>
    /// 数据库访问层的实现
    /// 
    /// 如果需要使用内置的其他类型，请使用构造函数
    /// DbHelper(DbProviderFactory factory, DataBaseType dbtype)
    /// </summary>
    public class DbHelper : IDbHelper
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(DbHelper));
        private Stopwatch sw = new Stopwatch();
        /// <summary>
        /// 创建对象工厂
        /// </summary>
        private DbProviderFactory m_factory = null;

        /// <summary>
        /// 创建对象工厂
        /// </summary>
        public DbProviderFactory DbProviderFactory
        {
            get { return m_factory; }
            set { m_factory = value; }
        }

        /// <summary>
        /// 根据prividername获取数据库类型
        /// </summary>
        /// <param name="prividername"></param>
        /// <returns></returns>
        private DataBaseType GetDbType(string prividername)
        {
            switch (prividername)
            {
                case "System.Data.OracleClient":
                    return DataBaseType.Oracle;
                case "MySql.Data.MySqlClient":
                    return DataBaseType.Mysql;
                case "System.Data.SQLite":
                    return DataBaseType.SQLite;
                case "System.Data.SqlServerCe":
                    return DataBaseType.SQLCe;
                case "IBM.Data.DB2":
                    return DataBaseType.IBMDB2;
                default:
                    return DataBaseType.SqlServer;
            }

        }
        /// <summary>
        /// 创建一个DbHlelper
        /// </summary>
        /// <param name="dbtype">创建的数据库类型</param>
        public DbHelper(DataBaseType dbtype)
            : this(dbtype, System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString)
        {

        }

        /// <summary>
        /// 使用自定义工厂创建DbHelper，Oracle SqlServer 
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="dbtype"></param>
        public DbHelper(DbProviderFactory factory, DataBaseType dbtype)
        {
            this.DBType = dbtype;
            this.m_factory = factory;
            this.ConnectionString =
               System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString;
        }


        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="dbtype"></param>
        /// <param name="connectstring"></param>
        public DbHelper(DataBaseType dbtype, string connectstring)
        {
            this.DBType = dbtype;
            var config = System.Configuration.ConfigurationManager.ConnectionStrings[0];

            this.m_factory = System.Data.Common.DbProviderFactories.GetFactory(config.ProviderName);

            this.ConnectionString =
               connectstring;
        }




        #region 虚函数


        /// <summary>
        /// 当前数据库执行超时时间
        /// </summary>
        public int CommandTimeout { get; set; }

        /// <summary>
        /// 获取Dbconnection
        /// </summary>
        /// <returns></returns>
        public virtual System.Data.Common.DbConnection GetDbConnection()
        {
            if (m_factory != null)
            {

                return m_factory.CreateConnection();
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据连接字符串，获取数据库连接
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <returns></returns>
        public virtual DbConnection GetDbConnection(string connectionstring)
        {
            var db = GetDbConnection();
            db.ConnectionString = connectionstring;
            return db;
        }

        /// <summary>
        /// 获取DBCommand
        /// </summary>
        /// <returns></returns>
        public virtual DbCommand GetDbCommand()
        {
            if (m_factory != null)
            {

                return m_factory.CreateCommand();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 获取DB事务
        /// </summary>
        /// <returns></returns>
        public virtual DbTransaction GetDbTransaction()
        {
            //  throw new NotImplementedException();
            if (m_Trans != null)
            {

                return m_Trans;
            }
            else
            {
                m_Trans = GetDbConnection().BeginTransaction();
                return m_Trans;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual DbDataAdapter GetDbDataAdapter()
        {
            if (m_factory != null)
            {

                return m_factory.CreateDataAdapter();
            }
            else
            {
                throw new NotImplementedException();
            }

        }
        #endregion

        #region 构造函数

        /// <summary>
        /// 设置连接字符串
        /// </summary>
        public DbHelper()
        {
            var config = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"];
            this.DbProviderFactory = System.Data.Common.DbProviderFactories.GetFactory(config.ProviderName);

            this.ConnectionString = config.ConnectionString;

            this.DBType = GetDbType(config.ProviderName);
        }

        #endregion

        #region 字段及属性


        /// <summary>
        /// 是否已经开启事务
        /// </summary>
        private bool m_BeginTrans = false;

        /// <summary>
        /// 是否开启事务
        /// </summary>
        public bool IsStartTrans
        {
            get { return m_BeginTrans; }
            set { m_BeginTrans = value; }
        }
        /// <summary>
        /// 事务
        /// </summary>
        protected DbTransaction m_Trans = null;
        /// <summary>
        /// 事务使用的连接
        /// </summary>
        private DbConnection m_Conn = null;
        #endregion

        #region IDbHelper Members



        /// <summary>
        /// 执行语句不返回结果
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(CommandType.Text, cmdText, null);
        }

        /// <summary>
        /// 执行语句，可以同时执行存储过程。
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(System.Data.CommandType cmdType, string cmdText, params System.Data.IDataParameter[] commandParameters)
        {
            DbCommand cmd = GetDbCommand();
            if (m_BeginTrans)
            {
                PrepareCommand(cmd, null, m_Trans, cmdType, cmdText, commandParameters);
                sw.Reset();
                sw.Start();
                int val = cmd.ExecuteNonQuery();
                sw.Stop();
                log.Debug(string.Format("execute sql takes {0} ms : {1}", sw.ElapsedMilliseconds, cmdText));
                cmd.Parameters.Clear();
                return val;
            }
            else
                using (DbConnection conn = GetDbConnection(ConnectionString))
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    sw.Reset();
                    sw.Start();


                    int val = cmd.ExecuteNonQuery();
                    sw.Stop();
                    log.Debug(string.Format("execute sql takes {0} ms : {1}", sw.ElapsedMilliseconds, cmdText));
                    cmd.Parameters.Clear();
                    return val;
                }
        }

        /// <summary>
        /// 执行语句并返回IDataReader
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>

        public virtual System.Data.IDataReader ExecuteReader(string cmdText)
        {
            return ExecuteReader(CommandType.Text, cmdText, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public virtual System.Data.IDataReader ExecuteReader(System.Data.CommandType cmdType, string cmdText, params System.Data.IDataParameter[] commandParameters)
        {
            DbCommand cmd = GetDbCommand();
            DbConnection conn = GetDbConnection(ConnectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {

                DbDataReader rdr = null;
                if (m_BeginTrans)
                {
                    PrepareCommand(cmd, m_Conn, null, cmdType, cmdText, commandParameters);
                    sw.Reset();
                    sw.Start();

                    rdr = cmd.ExecuteReader();

                    sw.Stop();
                    log.Debug(string.Format("execute sql takes {0} ms : {1}", sw.ElapsedMilliseconds, cmdText));
                }
                else
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    sw.Reset();
                    sw.Start();


                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    sw.Stop();
                    log.Debug(string.Format("execute sql takes {0} ms : {1}", sw.ElapsedMilliseconds, cmdText));
                }

                cmd.Parameters.Clear();
                return (IDataReader)rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public virtual object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(CommandType.Text, cmdText, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public virtual object ExecuteScalar(System.Data.CommandType cmdType, string cmdText, params System.Data.IDataParameter[] commandParameters)
        {
            DbCommand cmd = GetDbCommand();
            if (m_BeginTrans)
            {
                PrepareCommand(cmd, null, m_Trans, cmdType, cmdText, commandParameters);

                sw.Reset();
                sw.Start();


                object val = cmd.ExecuteScalar();
                sw.Stop();
                log.Debug(string.Format("execute sql takes {0} ms : {1}", sw.ElapsedMilliseconds, cmdText));

                cmd.Parameters.Clear();
                return val;
            }
            else
                using (DbConnection conn = GetDbConnection(ConnectionString))
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    sw.Reset();
                    sw.Start();


                    object val = cmd.ExecuteScalar();

                    sw.Stop();
                    log.Debug(string.Format("execute sql takes {0} ms : {1}", sw.ElapsedMilliseconds, cmdText));
                    cmd.Parameters.Clear();
                    return val;
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public virtual System.Data.DataTable ExecuteTable(string cmdText)
        {
            return ExecuteDataSet(cmdText).Tables[0];
        }

        public virtual System.Data.DataTable ExecuteTable(System.Data.CommandType cmdType, string cmdText, params System.Data.IDataParameter[] commandParameters)
        {
            return ExecuteDataSet(cmdType, cmdText, commandParameters).Tables[0];
        }

        public virtual System.Data.DataSet ExecuteDataSet(string cmdText)
        {
            return ExecuteDataSet(CommandType.Text, cmdText, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public virtual DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params IDataParameter[] commandParameters)
        {



            DbCommand cmd = GetDbCommand();

            if (m_BeginTrans)
            {
                PrepareCommand(cmd, m_Conn, null, cmdType, cmdText, commandParameters);
                var adp = GetDbDataAdapter();
                adp.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sw.Reset();
                sw.Start();


                adp.Fill(ds);
                sw.Stop();
                log.Debug(string.Format("execute sql takes {0} ms : {1}", sw.ElapsedMilliseconds, cmdText));
                return ds;
            }
            else
                using (DbConnection conn = GetDbConnection(ConnectionString))
                {

                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    var adp = GetDbDataAdapter();
                    adp.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    sw.Reset();
                    sw.Start();


                    adp.Fill(ds);
                    sw.Stop();
                    log.Debug(string.Format("execute sql takes {0} ms : {1}", sw.ElapsedMilliseconds, cmdText));
                    return ds;
                }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual System.Data.IDbConnection CreateConnection()
        {
            return GetDbConnection(ConnectionString);
        }

        /// <summary>
        /// 在事务中执行插入等操作
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(IDbTransaction trans, CommandType cmdType, string cmdText, params IDataParameter[] commandParameters)
        {
            DbCommand cmd = GetDbCommand();
            PrepareCommand(cmd, null, (DbTransaction)trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(IDbConnection conn, CommandType cmdType, string cmdText, params IDataParameter[] commandParameters)
        {
            DbCommand cmd = GetDbCommand();
            PrepareCommand(cmd, (DbConnection)conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;

        }



        /// <summary>
        /// 批量插入使用
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns></returns>
        public virtual bool ExecuteNonQuery(DataTable dt)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(connection);
                sqlbulkcopy.BulkCopyTimeout = 100;  //超时之前操作完成所允许的秒数
                sqlbulkcopy.BatchSize = dt.Rows.Count;  //每一批次中的行数
                sqlbulkcopy.DestinationTableName = dt.TableName;  //服务器上目标表的名称
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sqlbulkcopy.ColumnMappings.Add(i, i);  //映射定义数据源中的列和目标表中的列之间的关系
                }
                sqlbulkcopy.WriteToServer(dt);  // 将DataTable数据上传到数据表中
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }


        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        public virtual void BeginTrans()
        {
            m_BeginTrans = true;

            m_Conn = GetDbConnection();
            m_Conn.ConnectionString = this.ConnectionString;
            m_Conn.Open();
            m_Trans = m_Conn.BeginTransaction();


        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public virtual void RollTrans()
        {
            m_BeginTrans = false;
            m_Trans.Rollback();
            m_Conn.Close();
            m_Trans = null;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public virtual void CommitTrans()
        {
            m_BeginTrans = false;
            m_Trans.Commit();

            m_Conn.Close();
            m_Trans = null;
        }



        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        protected virtual void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction trans, CommandType cmdType, string cmdText, IDataParameter[] cmdParms)
        {
            if (m_Trans != null && m_BeginTrans)
            {
                cmd.Transaction = m_Trans;
                cmd.Connection = m_Conn;

            }
            else
            {

                cmd.Connection = conn;

                if (cmd.Connection.State != ConnectionState.Open)
                    conn.Open();

            }

            System.Diagnostics.Debug.WriteLine(cmdText);
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;


            // 超时设置
            string strCommandTimeout = System.Configuration.ConfigurationManager.AppSettings["CommandTimeout"];
            int inttimeout;
            if (!string.IsNullOrEmpty(strCommandTimeout) && int.TryParse(strCommandTimeout, out inttimeout))
            {

                cmd.CommandTimeout = inttimeout;
            }


            #region 参数检验

            // 参数检验，忽略多于的参数，跑出缺少参数
            if (cmdParms != null)
            {

                foreach (IDataParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
            #endregion

        }



        /// <summary>
        /// 当前连接数据库类型
        /// </summary>
        public DataBaseType DBType { get; set; }


        #endregion

        #region ICloneable Members

        /// <summary>
        /// 复制一个当前对象
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            return new DbHelper(this.m_factory, this.DBType) { CommandTimeout = this.CommandTimeout, ConnectionString = this.ConnectionString };
        }

        #endregion

        #region IDbHelper Members


        /// <summary>
        /// 获取IDataParameter
        /// </summary>
        /// <returns></returns>
        public IDataParameter GetIDataParameter()
        {
            return DbProviderFactory.CreateParameter();
        }

        #endregion
    }
}
