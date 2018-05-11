using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI.WebControls;
using KBsiteframe.Dll;
using KBsiteframe.Model;
using Z;

namespace KBsiteframe.Bll
{
    public class BNew
    {
        DNew dn = new DNew();

        #region"增删改"
        public int Insert(New m)
        {
            return dn.Insert(m);
        }
        public int Update(New m)
        {
            return dn.Update(m);
        }
        public int Delete(New m)
        {

            return dn.Delete(m);
        }
        #endregion


        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<New> GetNewsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return dn.GetNewsList(q, pageindex, pagesize, out totalcount);
        }
        public IList<New> GetNewsList(Query q)
        {
            return dn.GetNewsList(q);
        }

        public IList<New> GetNewsTitleList()
        {
            return dn.GetNewsTitleList();
        }

        public New GetNewsByID(int newsid)
        {
            return dn.GetNewsById(newsid);
        }
        public int GetMaxID()
        {
            return dn.GetMaxID();
        }
        public bool UploadValidate(FileUpload pic_upload, Label lbl_pic, string UploadBasePath, int newsid)
        {
            string SavePath = DateTime.Now.Year + "_" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            Boolean fileOk, res = false;

            if (pic_upload.HasFile)
            {
                string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
                //验证上传文件是否图片格式
                fileOk = IsImage(fileExtension);

                if (fileOk)
                {
                    //对上传文件的大小进行检测，限定文件最大不超过8M
                    if (pic_upload.PostedFile.ContentLength < 8192000)
                    {

                        string path = ModelConstants.NewsBathPath + "/" + SavePath + "/";

                        string path_p = UploadBasePath + path;
                        if (!Directory.Exists(path_p))
                            Directory.CreateDirectory(path_p);
                        string filename = CreatePasswordHash(pic_upload.FileName, 4) + fileExtension;
                        string mappath = path_p + filename;
                        //这是存到服务器上的虚拟路径
                        //string mappath = HttpContext.Current.Server.MapPath(virpath); //转换成服务器上的物理路径
                        pic_upload.PostedFile.SaveAs(mappath); //保存图片
                        //显示图片
                        //ImgNews.ImageUrl =".."+ virpath;
                        //清空提示
                        lbl_pic.Text = "";
                        //更新新闻表
                        if (dn.Update(new New()
                        {
                            NewsID = newsid,
                            NewsPicPath = path + filename
                        }) == 1)

                            res = true;
                    }
                    else
                    {
                        //pic.ImageUrl = "";
                        lbl_pic.Text = "文件大小超出8M！请重新选择！";
                    }
                }
                else
                {
                    //pic.ImageUrl = "";
                    lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
                }


            }
            //取得文件的扩展名,并转换成小写
            return res;
        }
        private bool IsImage(string str)
        {

            bool isimage = false;
            string thestr = str.ToLower();
            //限定只能上传jpg和gif图片
            string[] allowExtension = { ".jpg", ".gif", ".bmp", ".png" };
            //对上传的文件的类型进行一个个匹对
            for (int i = 0; i < allowExtension.Length; i++)
            {
                if (thestr == allowExtension[i])
                {
                    isimage = true;
                    break;
                }
            }
            return isimage;
        }
        private string CreatePasswordHash(string pwd, int saltLenght)
        {
            string strSalt = CreateSalt(saltLenght);
            //把密码和Salt连起来
            string saltAndPwd = String.Concat(pwd, strSalt);
            //对密码进行哈希
            string hashenPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1");
            //转为小写字符并截取前16个字符串
            hashenPwd = hashenPwd.ToLower().Substring(0, 16);
            //返回哈希后的值
            return hashenPwd;
        }

        private string CreateSalt(int saltLenght)
        {
            //生成一个加密的随机数
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[saltLenght];
            rng.GetBytes(buff);
            //返回一个Base64随机数的字符串
            return Convert.ToBase64String(buff);
        }
    }
}
