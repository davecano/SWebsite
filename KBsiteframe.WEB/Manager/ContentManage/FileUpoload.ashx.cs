using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic.Devices;

namespace KBsiteframe.WEB.Manager.ContentManage
{
    /// <summary>
    /// FileUpoload 的摘要说明
    /// </summary>

    public class FileUpoload : IHttpHandler
    {
        private string basefilename = HttpContext.Current.Server.MapPath("/Upload/ToolAttach/");
        private long totalCount = 0;
        public void ProcessRequest(HttpContext context)
        {
            if (Directory.Exists(context.Server.MapPath("/Upload/ToolAttach/")) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(context.Server.MapPath("/Upload/ToolAttach/"));
            }
            HttpRequest req = context.Request;
            string rquesttype = req.Form["rquesttype"];
            switch (rquesttype)
            {
                case "chekcfile": chekcfile(req); break;
                case "uploadblob": uploadblob(req); break;
                case "finishupload": finishupload(req); break;
            }

        }

        /// <summary>
        /// 结束文件上传，修改上传后的名称
        /// </summary>
        /// <param name="req"></param>
        public void finishupload(HttpRequest req)
        {
            //接收前端传递过来的参数
            var md5value = req.Form["md5value"];//文件md5加密的字符串
            var filename = req.Form["filename"];//文件的名称
            var totalsize = req.Form["totalsize"];//文件的总大小

            string fullname = basefilename + md5value + ".part";//ii
            string okname = basefilename + md5value + ".ok";//上传完毕之后再该目录下创建一个.ok后缀的文件，这个文件的大小为0，没有内容，不占空间，主要用于前端检查这个文件是否已经存在了
            var oldname = basefilename + filename;
            Computer MyComputer = new Computer();
            try
            {
                File.Create(okname);
                FileInfo fi = new FileInfo(oldname);
                if (fi.Exists)
                {
                    fi.Delete();
                }
                MyComputer.FileSystem.RenameFile(fullname, filename);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                var str = string.Format("{{\"data\":\"ok\"}}");
                HttpContext.Current.Response.Write(str);
            }
        }


        /// <summary>
        /// 处理文件分块上传的数据
        /// </summary>
        /// <param name="req"></param>
        public void uploadblob(HttpRequest req)
        {
            if (req.Files.Count <= 0)
            {
                HttpContext.Current.Response.Write("获取服务器上传文件失败");
                return;
            }
            HttpPostedFile _file = req.Files[0];
            //获取参数
            string filename = req.Form["filename"];
            string md5value = req.Form["md5value"];
            var tempfilename = md5value + ".part";
            //如果是int 类型当文件大的时候会出问题 最大也就是 1.9999999990686774G
            long loaded = Convert.ToInt64(req.Form["loaded"]);
            totalCount += loaded;
            string newname = basefilename + tempfilename;
            Stream stream = _file.InputStream;
            if (stream.Length <= 0)
                throw new Exception("接收的数据不能为空");
            byte[] dataOne = new byte[stream.Length];
            stream.Read(dataOne, 0, dataOne.Length);
            FileStream fs;
            try
            {
                fs = new FileStream(newname, FileMode.Append, FileAccess.Write, FileShare.Read, 1024);
                fs.Write(dataOne, 0, dataOne.Length);
                fs.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                stream.Close();
                //检查文件已经上传的大小是否等于文件的总大小
            }
            HttpContext.Current.Response.Write("分段数据保存成功");
        }

        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="req"></param>
        public void chekcfile(HttpRequest req)
        {
            var md5value = req.Form["md5value"];//得到前端传递过来的文件的mdf字符串
            var path_ok = basefilename + md5value + ".ok";
            var path_part = basefilename + md5value + ".part";
            int flag = 0;
            string json = string.Empty;
            if (File.Exists(path_ok))//传完了
            {
                flag = 2;
                json = string.Format("{{\"flag\":\"{0}\"}}", flag);
            }
            else if (File.Exists(path_part))//传了一部分
            {
                flag = 1;
                var startindex = new FileInfo(path_part).Length.ToString();
                json = string.Format("{{\"flag\":\"{0}\",\"startindex\":\"{1}\"}}", flag, startindex);
            }
            else//新文件
            {
                flag = 0;
                json = string.Format("{{\"flag\":\"{0}\",\"startindex\":\"0\"}}", flag);
            }
            HttpContext.Current.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}