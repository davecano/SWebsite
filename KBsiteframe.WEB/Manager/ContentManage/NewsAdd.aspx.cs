using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.Web.Manager.ContentManage
{
    public partial class NewsAdd : PageBase
    {
        public NewsAdd()
        {
            ModuleCode = "NewsManage";
            PageOperate = PurOperate.添加;
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utils.BindDropDownList(typeof(NewsType), dpNewstype, "");
                Utils.BindDropDownList(typeof(StaticType), dpstatictype, "");
                //Lbtime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }


  

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            New n = new New();
           BNew bn=new BNew();
           BSysOperateLog bsol=new BSysOperateLog();
            n.NewsID = bn.GetMaxID() + 1;
            n.IsTop = CbIstop.Checked;
            n.IsHot = CbIsHot.Checked;
            n.NewsContent = container.Text;
            n.SubmitTime=DateTime.Now;
            //n.SavePath = "details" + DateTime.Now.Year + "_" + DateTime.Now.Month + "/" +DateTime.Now.Day;
            n.Uploader = PubCom.CheckString(txtauthor.Text.Trim());
            n.Title = PubCom.CheckString(txtTitle.Text.Trim());
            n.summary = PubCom.CheckString(txtsummary.Text.Trim());
            n.NewsType = dpNewstype.SelectedValue;
            n.StaticType = dpstatictype.SelectedValue;
            //string PicUrl = "";
            //if (UploadValidate(out PicUrl))
            //{
            //    n.IsImg = 1;
            //    mp.Id = mpm.GetMaxID() + 1;
            //    mp.NewsId = n.Id;
            //    mp.Title = pic_upload.FileName;
            //    mp.PicUrl = PicUrl;
            //    mpm.Insert(mp);
            //}
            //else
            //{
            //    n.IsImg = 1;
            //}NewsManage
      
            if (bn.Insert(n) != 1)
            {Message.ShowWrong(this,"添加文章失败！");
              
            }
            else
            {
                bn.UploadValidate(pic_upload, lbl_pic, PicFilePath,  n.NewsID);
                //// 插入日志 add
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.新闻信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "新闻新增";

                log.LogAfterObject = JsonHelper.Obj2Json(n);
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this,"添加文章成功","NewsManage.aspx");
            }
        }

   

        //private bool UploadValidate(out string PicUrl)
        //{
        //    Boolean fileOk, res = false;
        //    PicUrl = "";
        //    if (pic_upload.HasFile)//验证是否包含文件
        //    {
        //        //取得文件的扩展名,并转换成小写
        //        string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
        //        //验证上传文件是否图片格式
        //        fileOk = IsImage(fileExtension);

        //        if (fileOk)
        //        {
        //            //对上传文件的大小进行检测，限定文件最大不超过8M
        //            if (pic_upload.PostedFile.ContentLength < 8192000)
        //            {
        //                string filepath = "/upload/";
        //                if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
        //                {
        //                    Directory.CreateDirectory(Server.MapPath(filepath));
        //                }
        //                string virpath = filepath + CreatePasswordHash(pic_upload.FileName, 4) + fileExtension;//这是存到服务器上的虚拟路径
        //                string mappath = Server.MapPath(virpath);//转换成服务器上的物理路径
        //                pic_upload.PostedFile.SaveAs(mappath);//保存图片
        //                //显示图片
        //                //pic.ImageUrl = virpath;
        //                //清空提示
        //                lbl_pic.Text = "";
        //                PicUrl = virpath;
        //                res = true;
                       

        //            }
        //            else
        //            {
        //                //pic.ImageUrl = "";
        //                lbl_pic.Text = "文件大小超出8M！请重新选择！";
        //            }
        //        }
        //        else
        //        {
        //            //pic.ImageUrl = "";
        //            lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
        //        }
        //    }
      
        //    return res;

        //}

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
    }

}