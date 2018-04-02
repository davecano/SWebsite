using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Data
{
    class MysqlPagination : PaginationBase, IPagination
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

            string sql2 = @"{2} limit {0},{1}"; // 跳过{0}行 取{1}个

            return string.Format(sql2, (pageindex - 1) * pagesize, pagesize, SqlString);
        }
    }
}
