using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Z.Data
{
    /// <summary>
    /// Oracle相关的语句分析
    /// </summary>
    class OraclePagination : PaginationBase, IPagination
    {
        /// <summary>
        /// 获取指定页码数据的查询语句
        /// </summary>
        /// <param name="pageindex">要查询第几页</param>
        /// <param name="pagesize">每页记录数</param>
        /// <returns></returns>
        public override string GetSpecialPageSql(int pageindex, int pagesize)
        {
            if (pagesize == 0)
            {
                return SqlString;
            }

            // 拼接分页语句
            string sql2 = @"SELECT * FROM (SELECT A.* ,ROWNUM rn FROM ({2})  A WHERE ROWNUM <= {1}) A where rn >= {0}";

            return string.Format(sql2, (pageindex - 1) * pagesize + 1, pageindex * pagesize, SqlString);
        }
    }
}
