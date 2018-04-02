using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z
{
    /// <summary>
    /// 支持事务的接口
    /// 
    /// 使用方法
    /// 获取接口后
    /// 在try中开启及关闭事务
    /// 
    /// 在catch中回滚事务
    /// </summary>
    public interface ITransation
    {
        /// <summary>
        /// 开启一个事务
        /// </summary>
        void BeginTrans();

        /// <summary>
        /// 提交一个事务
        /// </summary>
        void CommitTrans();

        /// <summary>
        /// 回滚一个事务
        /// </summary>
        void RollTrans();

        /// <summary>
        /// 是否开启了事务
        /// </summary>
        bool IsStartTrans { get; set; }
    }
}
