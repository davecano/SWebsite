using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using KBsiteframe.Dll;
using KBsiteframe.Model;
using Z;

namespace KBsiteframe.Bll
{
    public class BExpert
    {
        DExpert de = new DExpert();
        DArticle da=new DArticle();
        DTreatise dt=new DTreatise();
        DProject dp=new DProject();
        #region"增删改"
        public int Insert(Expert m)
        {
            return de.Insert(m);
        }
        public int Update(Expert m)
        {
            return de.Update(m);
        }
        public int Delete(Expert m)
        {
            //专家删除要更新文章、专著、项目关于专家的编号
            da.sqlUpdate(m.ExpertID, "Expert");
            dt.sqlUpdate(m.ExpertID, "Expert");
            dp.sqlUpdate(m.ExpertID, "Expert");
            return de.Delete(m);
        }
        #endregion


        /// <summary>
        /// 根据条件查询所有菜单
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IList<Expert> GetExpertsList(Query q, int pageindex, int pagesize, out int totalcount)
        {
            return de.GetExpertsList(q, pageindex, pagesize, out totalcount);
        }
        public IList<Expert> GetExpertsList(Query q)
        {
            return de.GetExpertsList(q);
        }
  
        public Expert GetExpertsByID(int newsid)
        {
            return de.GetExpertsById(newsid);
        }
        public int GetMaxID()
        {
            return de.GetMaxID();
        }
        public int UploadFile(HttpPostedFile hpf, string UploadBasePath, string SavePath)
        {
            string hzm = Path.GetExtension(hpf.FileName);
            bool flag = false;
            foreach (string s in ModelConstants.CanUploadFile.Split('|'))
            {
                if (s.ToLower() == hzm.ToLower())
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
                return -4;

            string path = ModelConstants.ExpertBathPath + "/" + SavePath + "/";

            string path_p = UploadBasePath + path;
            if (!Directory.Exists(path_p))
                Directory.CreateDirectory(path_p);

            string fn = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            if (hpf.ContentLength > 0)
            {
                if (hpf.ContentLength > 1048576 * ModelConstants.FileMaxLength)
                {
                    return -2;
                }
                else
                {

                    hpf.SaveAs(path_p + fn + hzm);
                    //判断是否为图片
                    if (hzm.ToLower() == ".jpg" || hzm.ToLower() == ".jpeg" || hzm.ToLower() == ".gif" || hzm.ToLower() == ".png" || hzm.ToLower() == ".bmp")
                    {
                        //生成缩略图
                        Thumbnail.MakeThumbnailImage(path_p + fn + hzm, path_p + fn + "_s" + hzm, 200, 200);

                    }
                    return 1;
                }
            }
            else
            {
                return -3;
            }
        }

        public bool UploadValidate(FileUpload pic_upload, Label lbl_pic, string UploadBasePath, string SavePath, int ExpertID)
        {
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

                        string path = ModelConstants.ExpertBathPath + "/" + SavePath + "/";

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
                        //更新专家表
                        if (de.Update(new Expert()
                        {
                            ExpertID = ExpertID,
                            EPicPath = path + filename
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
