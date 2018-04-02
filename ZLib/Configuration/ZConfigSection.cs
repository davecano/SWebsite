using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Reflection;


namespace Z
{
    /// <summary>
    /// 配置项
    /// </summary>
    public sealed class EntityConfigurator
    {
        /// <summary>
        /// 默认配置参数
        /// </summary>
        public static void Configure()
        {
            try
            {
                Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            }
            catch
            {

            }


        }

        /// <summary>
        /// 从数据流配置结构
        /// </summary>
        /// <param name="stream"></param>
        public static void Configure(Stream stream)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(stream);

            var nodes = xmldoc.SelectNodes("configuration/Entity/Table");
            foreach (XmlNode item in nodes)
            {
                string classname = item.Attributes["classname"].Value;

                var type = GetValidType(classname);
                string tablename = item.Attributes["TableName"].Value;
                if (string.IsNullOrEmpty(tablename))
                {
                    throw new ConfigurationErrorsException("TableName不能为空！");
                }

                string IdentityTable = item.Attributes["IdentityTable"].Value;


                // 根据类型设置 表名缓存
                if (type != null && !Data.DALUtil.m_TableNameCache.ContainsKey(type))
                {
                    Data.DALUtil.m_TableNameCache[type] = tablename;
                }

                // 设置表信息缓存

                Data.DALUtil.m_TableInfoCache[tablename] = new Data.TableInfo() { TableName = tablename, IdentityTable = GetStringBool(IdentityTable), ClassType = type };





                var columnenodes = item.SelectNodes("Column");

                foreach (XmlNode itcolumn in columnenodes)
                {

                    string PropertyName = itcolumn.Attributes["PropertyName"].Value;
                    bool prikey = GetStringBool(GetAttributeValue(itcolumn.Attributes["PrimaryKey"]));
                    string SeqenceName = GetAttributeValue(itcolumn.Attributes["SeqenceName"]);
                    string ColumnName = itcolumn.Attributes["ColumnName"].Value ?? PropertyName;
                    Data.ColumnInfo coinfo = new Data.ColumnInfo() { ColumnName = ColumnName, PrimaryKey = prikey, SeqenceName = SeqenceName, PropertyName = PropertyName };

                    string key = string.Format("{0}_{1}", tablename, PropertyName);
                    Data.DALUtil.m_ColumnNameCache[key] = coinfo;
                    // 如果是主键维护主键缓存
                    if (prikey)
                    {
                        if (Data.DALUtil.m_PKCache.ContainsKey(key))
                        {
                            Data.DALUtil.m_PKCache[tablename].Add(ColumnName);

                        }
                        else
                        {
                            Data.DALUtil.m_PKCache[tablename] = new List<string>(new string[] { ColumnName });
                        }
                    }
                }



            }
        }

        /// <summary>
        /// 配置文件信息
        /// </summary>
        /// <param name="file"></param>
        public static void Configure(FileInfo file)
        {

            Configure(file.FullName);

        }

        /// <summary>
        /// 通过文件名配置系统
        /// </summary>
        /// <param name="filename"></param>

        public static void Configure(string filename)
        {
            using (Stream s = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                Configure(s);
            }
        }

        private static string GetAttributeValue(XmlAttribute att)
        {
            if (att == null)
            {
                return null;
            }
            else
            {
                return att.Value;
            }
        }

        /// <summary>
        /// 根据字符串返回true or false
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private static bool GetStringBool(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                return false;
            }
            else
            {
                if (v.ToLower() == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private static Type GetValidType(string assembly)
        {
            var strarray = assembly.Split(',');

            if (strarray.Length == 2)
            {
                var ass = Assembly.Load(strarray[1].Trim());
                return ass.GetType(strarray[0]);
            }
            else
            {
                return null;
            }

        }
    }

}
