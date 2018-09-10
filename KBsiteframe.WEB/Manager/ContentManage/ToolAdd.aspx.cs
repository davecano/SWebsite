using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.WEB.Manager.ContentManage
{

    public partial class ToolAdd : PageBase
    {
        public ToolAdd()
        {
            ModuleCode = "ToolManage";
            PageOperate = PurOperate.添加;
        }


        BSysCode bsc = new BSysCode();
        BSysOperateLog bsol = new BSysOperateLog();
        BTool ba = new BTool();
        BExpert be = new BExpert();
        BProject bp = new BProject();
        BMember bm = new BMember();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
            }
        }

        void BindDropDownList()
        {
            Utils.BindDropDownList(typeof (ToolType), dpToolType, "");
            Utils.BindDropDownList(typeof (PathType), dppathtype, "");

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Tool a = new Tool();

            a.ToolID = ba.GetMaxID() + 1;

            a.ToolName = PubCom.CheckString(txtToolName.Text.Trim());
            a.UploadTime = DateTime.Now;
            a.Uploader = GetLogUserName();
            a.ToolType = dpToolType.SelectedValue;
            //做个判定
            a.PathType = dppathtype.SelectedValue;
            a.ToolPath = PubCom.CheckString(txtToolPath.Text.Trim());
            string Extension = Path.GetExtension(PubCom.CheckString(txtToolPath.Text.Trim())); //扩展名 ".aspx"
            if (string.IsNullOrEmpty(Extension))
            {
                Message.ShowWrong(this, "请输入文件后缀名！如.mp4");
                return;
            }
            else
            {
                a.ToolSuffix = Extension.Substring(1);
            }
            if (ba.Insert(a) == 1)
            {

                //// 插入日志
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.工具信息.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "新增建构工具";

                log.LogAfterObject = JsonHelper.Obj2Json(a); //不包含附件
                log.LogRemark = "";
                bsol.Insert(log);
                Message.ShowOKAndRedirect(this, "添加成功", "ToolManage.aspx");
            }
            else
            {
                Message.ShowWrong(this, "添加失败");
            }
        }
    }
}
