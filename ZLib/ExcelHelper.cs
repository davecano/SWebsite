using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
namespace Z
{
    public class ExcelHelper
    {
        #region 导入表格

        /// <summary>
        /// 读取Excel文件,内容存储在DataSet中
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="sSelect">选择语句{"A:F"表示选择A到F列,包含A,F列, "A1:B2"表示选择A1到B2范围,包括A1,B2}</param>
        /// <param name="bTitle">是否将第一行作为标题行,如果是则可以采用 dr["天津"] 的形式读取数据,否则采取dr[0]的形式</param>
        /// <returns></returns>
        public static DataTable ExcelToDataDataTable(string fileName, string sSelect, bool bTitle)
        {
            //HDR=Yes，这代表第一行是标题，不做为数据使用 ，如果用HDR=NO，则表示第一行不是标题，做为数据来使用。系统默认的是YES
            //IMEX有3个值：当IMEX=2 时，EXCEL文档中同时含有字符型和数字型时，比如第C列有3个值，2个为数值型 123，1个为字符型 ABC，当导入时，
            //页面不报错了，但库里只显示数值型的123，而字符型的ABC则呈现为空值。当IMEX=1时，无上述情况发生，库里可正确呈现 123 和 ABC.
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=\"Excel 8.0;HDR=" + (bTitle ? "YES" : "NO") + ";IMEX=1\"";
            var conn = new OleDbConnection(strConn);
            string strExcel = string.Format(@"select * from [sheet1${0}]", sSelect);
            var ds = new DataSet();
            try
            {
                conn.Open();
                var xlsCommand = new OleDbDataAdapter(strExcel, strConn);
                xlsCommand.Fill(ds, "sheet1$");
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0];
            return null;
        }
        #endregion

        #region ExportToExcel：导出excel
        /// <summary>
        /// 将DataTable转成Excel[Table]字符串. 可用于直接输出.
        /// </summary>
        /// <param name="dt">传入的DataTable数据, 必须提供标题!</param>
        /// <returns></returns>
        public static string DTToExcelStr(DataTable dt)
        {
            string newLine = "<table cellspacing=\"1\" border=\"1\">";
            newLine += "<tr><td colspan=\"" + dt.Columns.Count + "\" align=\"center\">" + dt.TableName + "</td></tr>";
            newLine += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                newLine += "<td>" + dt.Columns[i].Caption + "</td>";
            }
            newLine += "</tr>";
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                newLine += "<tr>";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    newLine += "<td>" + dt.Rows[j][i] + "</td>";
                }
                newLine += "</tr>";
            }
            newLine += "</table>";
            return newLine;
        }

        /// <summary> 
        /// dtData是要导出为Excel的DataTable,FileName是要导出的Excel文件名(不加.xls) 
        /// </summary> 
        /// <param name="dtData"></param> 
        /// <param name="FileName"></param> 
        public static void DataTableToExcel(System.Data.DataTable dtData, String FileName)
        {
            System.Web.UI.WebControls.GridView dgExport = null;
            //当前对话 
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            //IO用于导出并返回excel文件 
            System.IO.StringWriter strWriter = null;
            System.Web.UI.HtmlTextWriter htmlWriter = null;

            if (dtData != null)
            {
                //设置编码和附件格式 
                //System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8)作用是方式中文文件名乱码 
                curContext.Response.AddHeader("content-disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");
                curContext.Response.ContentType = "application nd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                curContext.Response.Charset = "GB2312";

                //导出Excel文件 
                strWriter = new System.IO.StringWriter();
                htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

                //为了解决dgData中可能进行了分页的情况,需要重新定义一个无分页的GridView 
                dgExport = new System.Web.UI.WebControls.GridView();
                dgExport.DataSource = dtData.DefaultView;
                dgExport.AllowPaging = false;
                dgExport.DataBind();

                //下载到客户端 
                dgExport.RenderControl(htmlWriter);
                curContext.Response.Write(strWriter.ToString());
                curContext.Response.End();
            }
        }

        public static void DataToExcel(object dtData, String FileName)
        {
            System.Web.UI.WebControls.GridView dgExport = null;
            //当前对话 
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            //IO用于导出并返回excel文件 
            System.IO.StringWriter strWriter = null;
            System.Web.UI.HtmlTextWriter htmlWriter = null;

            if (dtData != null)
            {
                //设置编码和附件格式 
                //System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8)作用是方式中文文件名乱码 
                curContext.Response.AddHeader("content-disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");
                curContext.Response.ContentType = "application nd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                curContext.Response.Charset = "GB2312";

                //导出Excel文件 
                strWriter = new System.IO.StringWriter();
                htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

                //为了解决dgData中可能进行了分页的情况,需要重新定义一个无分页的GridView 
                dgExport = new System.Web.UI.WebControls.GridView();
                dgExport.DataSource = dtData;
                dgExport.AllowPaging = false;
                dgExport.DataBind();

                //下载到客户端 
                dgExport.RenderControl(htmlWriter);
                curContext.Response.Write(strWriter.ToString());
                curContext.Response.End();
            }
        }

        #endregion
    }
}
