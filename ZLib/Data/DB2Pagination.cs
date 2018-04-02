using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Z.Data
{
    /// <summary>
    /// 支持DB2的分页语句分析
    /// </summary>
    internal class DB2Pagination : PaginationBase, IPagination
    {
        /// <summary>
        /// 获取指定页分页语句
        /// </summary>
        /// <param name="pageindex">第几页</param>
        /// <param name="pagesize">每页数据</param>
        /// <returns></returns>
        public override string GetSpecialPageSql(int pageindex, int pagesize)
        {
            if (pagesize == 0)
            {
                return SqlString;
            }

            StringBuilder sqlcopy = new StringBuilder(32);
            if (QueryCache.ContainsKey(SqlString)) // 使用构造缓存
            {
                sqlcopy = new StringBuilder(QueryCache[SqlString]);
            }
            else
            {

                Regex sqlregex = new Regex(@"order\s+by(?<order>.+?)", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
                Regex replaceorderby = new Regex(@"order\s+by.+?$", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);


                if (!sqlregex.IsMatch(SqlString))
                {
                    throw new Exception(string.Format("分页语句必须需要Order By排序\r\nError Sql:{0}", SqlString));
                }
                Match match = sqlregex.Match(SqlString);

                string order = match.Groups["order"].Value;



                string sqlwithoutorderby = replaceorderby.Replace(SqlString, "");
                sqlcopy.AppendFormat(@"SELECT * FROM (
SELECT TEMP_TABLE.*, ROW_NUMBER() OVER (ORDER BY {0}) POS FROM ({1}", order, sqlwithoutorderby);

                sqlcopy.Append(" FETCH FIRST {1} ROWS ONLY) AS TEMP_TABLE)  T_TB");

                QueryCache[SqlString] = sqlcopy.ToString();
            }



            return string.Format(sqlcopy.ToString() + " WHERE T_TB.POS BETWEEN {0} AND {1}", (pageindex - 1) * pagesize + 1, pageindex * pagesize);
        }
    }
}
