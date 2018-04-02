using System;
namespace Z
{
    /// <summary>
    /// 表别名属性
    /// </summary>
    [AttributeUsage(System.AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class TableAttribute : System.Attribute
    {
        /// <summary>
        /// 表别名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 是否包含Identity列的表，如果是，插入将返回Scope_Identity()。
        /// </summary>
        public bool IdentityTable { get; set; }

        /// <summary>
        /// 将主键以逗号为分隔符表示在表属性中，注意主键名的大小写
        /// </summary>
        public string PrimaryKeys { get; set; }
    }
    /// <summary>
    /// 列属性
    /// </summary>
    [AttributeUsage(System.AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public sealed class ColumnAttribute : System.Attribute
    {
        /// <summary>
        /// 是否标示
        /// </summary>
        public bool Identity { get; set; }
        /// <summary>
        /// 是否主键，表设置优先级高于字段，如果设置了表的主键，字段的PrimaryKey属性即无效
        /// </summary>
        public bool PrimaryKey { get; set; }

        /// <summary>
        /// 列别名
        /// </summary>
        public string ColumnName { get; set; }


        /// <summary>
        /// Oracle专用（更新的Oracle序列名称）
        /// </summary>
        public string SeqenceName { get; set; }
    }

   
    /// <summary>
    /// 该字段表示数据库在更新或插入数据时，忽略该字段的数据及信息。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {

    }

}