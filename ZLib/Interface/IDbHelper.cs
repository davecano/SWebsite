using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Z
{
    /// <summary>
    /// 数据库执行接口
    /// 
    /// 使用SQLHelper OracleHelper 继承的接口
    /// </summary>
    public interface IDbHelper : ITransation, ICloneable
    {

        /// <summary>
        /// 执行一个T-SQL (不返回结果集)
        /// </summary>
        /// <param name="cmdText">T-SQL 命令</param>
        /// <returns>返回一个 int 表示这个命令所影响的行数</returns>
        int ExecuteNonQuery(string cmdText);
        /// <summary>
        ///执行一个T-SQL命令(可以含参数)(不返回结果集) 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="cmdType">命令类型 (存储过程, 文本, 等)</param>
        /// <param name="cmdText">存储过程名称 or T-SQL 命令</param>
        /// <param name="commandParameters">一组用于执行该命令的参数</param>
        /// <returns>返回执行这个命令所影响的行数</returns>
        int ExecuteNonQuery(CommandType cmdType, string cmdText, params IDataParameter[] commandParameters);

        /// <summary>
        /// 批量插入使用
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns>返回真假值</returns>
        bool ExecuteNonQuery(DataTable dt);

        /// <summary>
        /// 执行一个T-SQL命令(返回结果集)
        /// </summary>
        /// <param name="cmdText">T-SQL 命令</param>
        /// <returns>返回一个System.Data.IDataReader</returns> 
        IDataReader ExecuteReader(string cmdText);
        /// <summary>
        /// 执行一个T-SQL命令(返回结果集)
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks> 
        /// <param name="cmdType">命令类型(存储过程, 文本, 等)</param>
        /// <param name="cmdText">存储过程名称 or T-SQL 命令</param>
        /// <param name="commandParameters">一组用于执行该命令的参数</param>
        /// <returns>一个包含查询结果的 DataReader</returns>
        IDataReader ExecuteReader(CommandType cmdType, string cmdText, params IDataParameter[] commandParameters);
        /// <summary>
        /// 执行一个命令(返回结果集的第一行第一列结果)
        /// </summary>
        /// <param name="cmdText">T-SQL 命令</param>
        /// <returns>返回一个可以转换成预期类型的object对象</returns>
        object ExecuteScalar(string cmdText);
        /// <summary>
        /// 执行一个命令(返回结果集的第一行第一列结果)
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks> 
        /// <param name="cmdType">命令类型(存储过程, 文本, 等)</param>
        /// <param name="cmdText">存储过程名称 or T-SQL 命令</param>
        /// <param name="commandParameters">一组用于执行该命令的参数</param>
        /// <returns>返回一个可以转换成预期类型的object对象</returns>
        object ExecuteScalar(CommandType cmdType, string cmdText, params IDataParameter[] commandParameters);
        /// <summary>
        /// 执行一个T-SQL命令(返回一个DataTable)
        /// </summary>
        /// <param name="cmdText">T-SQL 命令</param>
        /// <returns>返回包含结果的DataTable </returns>
        DataTable ExecuteTable(string cmdText);
        /// <summary>
        /// 执行一个T-SQL命令(返回一个DataTable)
        /// </summary>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等)</param>
        /// <param name="cmdText">存储过程名称 or T-SQL 命令</param>
        /// <param name="commandParameters">一组用于执行该命令的参数</param>
        /// <returns>返回包含结果的DataTable</returns>
        DataTable ExecuteTable(CommandType cmdType, string cmdText, params IDataParameter[] commandParameters);
        /// <summary>
        /// 执行一个T-SQL命令(返回一个DataSet)
        /// </summary>
        /// <param name="cmdText">T-SQL 命令</param>
        /// <returns>返回一个 DataSet</returns>
        DataSet ExecuteDataSet(string cmdText);
        /// <summary>
        /// 执行一个T-SQL命令(返回一个DataSet)
        /// </summary>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等)</param>
        /// <param name="cmdText">存储过程名称 or T-SQL 命令</param>
        /// <param name="commandParameters">一组用于执行该命令的参数</param>
        /// <returns>返回一个 DataSet</returns>
        DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params IDataParameter[] commandParameters);
        /// <summary>
        /// 在同一事务下批量执行语句
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等)</param>
        /// <param name="cmdText">存储过程名称 or T-SQL 命令</param>
        /// <param name="commandParameters">一组用于执行该命令的参数</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(IDbTransaction trans, CommandType cmdType, string cmdText, params IDataParameter[] commandParameters);
        /// <summary>
        /// 在同一连接下批量执行语句(需要手动关闭连接)
        /// </summary>
        /// <param name="conn">自定义连接</param>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等)</param>
        /// <param name="cmdText">存储过程名称 or T-SQL 命令</param>
        /// <param name="commandParameters">一组用于执行该命令的参数</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(IDbConnection conn, CommandType cmdType, string cmdText, params IDataParameter[] commandParameters);
        /// <summary>
        /// 获取或设置当前连接字符串
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// 获取当前DBHelper数据库类型
        /// </summary>
        DataBaseType DBType { get; set; }

        /// <summary>
        /// 获取当前IDb数据库类型的参数
        /// </summary>
        /// <returns></returns>
        IDataParameter GetIDataParameter();
    }
}
