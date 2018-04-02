using System.Collections.Generic;
using System.Data;
using Z.Data;

namespace MyCmsWEB.Comm
{
    public class ImportData
    {
        public Dictionary<string, string> Cols;
        private readonly DbHelper db = new DbHelper();

      

        /// <summary>
        ///     导入数据库后，进行重复数据的删除操作
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="projectid"></param>
        public void ReGetherMyImport(string tableName, string projectid)
        {
            var sql = " delete " + tableName + " where tempid not in (select max(t1.tempid) "
                      + " from " + tableName + " t1 group by t1.sortname,t1.goodscatalog, "
                      + " t1.bidproductname,t1.varietal,t1.bidoutlookc,t1.bidmodel,t1.compose, "
                      + " t1.bzoutlookc,t1.bidcompanyname,t1.sccompany,t1.registnames,t1.bzcl, "
                      + " t1.small,t1.confine,t1.registno,t1.registdate,t1.beizhu,t1.normprice, "
                      + " t1.okprice,t1.openprice,t1.oneprice,t1.twoprice,t1.hsb,t1.jyj, "
                      + " t1.projectid having projectid = '" + projectid + "') "
                      + " and projectid = '" + projectid + "'";

            db.ExecuteNonQuery(sql);
        }

        public DataTable GetTableDesc()
        {
            return db.ExecuteTable("select * from BidResultDetail where 1<>1");
        }

        public int DeleteBidResultByMiaosuID(string miaosuid)
        {
            return db.ExecuteNonQuery("delete from BidResultDetail where ResultID=" + miaosuid);
        }
    }

 
}