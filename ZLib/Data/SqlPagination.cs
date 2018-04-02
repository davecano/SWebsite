using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Z.Data
{
    class SqlPagination : PaginationBase, IPagination
    {

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
SELECT *, ROW_NUMBER() OVER (ORDER BY {0}) POS FROM ({1})  _Temp)  _TB", order, sqlwithoutorderby);



                QueryCache[SqlString] = sqlcopy.ToString();
            }

            sqlcopy.AppendFormat(" WHERE _TB.POS BETWEEN {0} AND {1}", (pageindex - 1) * pagesize + 1, pageindex * pagesize);
            return sqlcopy.ToString();
        }

    }
}
