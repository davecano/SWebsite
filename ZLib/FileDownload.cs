using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;   
namespace Z
{
    /// <summary>
    /// 文件下杂类
    /// </summary>
    public class FileDownload
    {
        public static void downLoad(string path,string filename)
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                System.Web.HttpContext.Current.Response.Clear();
                //System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpContext.Current.Server.UrlEncode(filename+fi.Extension));
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpContext.Current.Server.UrlEncode(filename));
                System.Web.HttpContext.Current.Response.AddHeader("Content-Length", fi.Length.ToString());
                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream;charset=gb2321";
                System.Web.HttpContext.Current.Response.WriteFile(fi.FullName);
                System.Web.HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.Close();
            }
        }
    }
}
