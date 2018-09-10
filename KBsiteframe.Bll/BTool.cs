using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using KBsiteframe.Dll;
using KBsiteframe.Model;
using Z;

namespace KBsiteframe.Bll
{
    public class BTool
    {
        DTool dd = new DTool();

        #region"增删改"
        public int Insert(Tool m)
        {
            return dd.Insert(m);
        }
        public int Update(Tool m)
        {
            return dd.Update(m);
        }
        public int Delete(Tool m)
        {

            return dd.Delete(m);
        }
        #endregion


        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<Tool> GetToolsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dd.GetToolsList(q, pageindex, pagesize, out totalcount);
        }
        public IList<Tool> GetToolsList(Query q)
        {
            return dd.GetToolsList(q);
        }
    
        public Tool GetToolsByID(int noticeid)
        {
            return dd.GetToolsById(noticeid);
        }
        public int GetMaxID()
        {
            return dd.GetMaxID();
        }
        public int UploadFile(HttpPostedFile hpf, string UploadBasePath, int toolid, string tooltype)
        {
            string timePackage = DateTime.Now.Year + "_" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            string hzm = Path.GetExtension(hpf.FileName);
            bool flag = false;
            foreach (string s in ModelConstants.ToolUploadFile.Split('|'))
            {
                if (s.ToLower() == hzm.ToLower())
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
                return -4;

            string path = ModelConstants.ToolBathPath + "/" + timePackage + "/";

            string path_p = UploadBasePath + path;
            if (!Directory.Exists(path_p))
                Directory.CreateDirectory(path_p);

            string fn = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            if (hpf.ContentLength > 0)
            {
                if (hpf.ContentLength > 1048576 * ModelConstants.ToolFileMaxLength)
                {
                    return -2;
                }
                else
                {

                    hpf.SaveAs(path_p + fn + hzm);
                    //更新tool
                    return dd.Update(new Tool()
                    {
                        ToolID = toolid,
                        ToolPath = path + fn + hzm,
                        ToolSuffix = hzm
                    });

                }
            }
            else
            {
                return -3;
            }
        }
        public void DownloadFile(string fileURL)
        {
            fileURL = HttpContext.Current.Server.MapPath(fileURL);
            if (File.Exists(fileURL))
            {
                //fileURL为带路径的文件全名

                FileInfo fileInfo = new FileInfo(fileURL);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + HttpContext.Current.Server.UrlEncode(fileInfo.Name.ToString()));
                HttpContext.Current.Response.AddHeader("content-length", fileInfo.Length.ToString());

                HttpContext.Current.Response.ContentType = "application/octet-stream"; ;
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
                HttpContext.Current.Response.WriteFile(fileURL);

            }
            else
            {

            }
        }
    }
}
