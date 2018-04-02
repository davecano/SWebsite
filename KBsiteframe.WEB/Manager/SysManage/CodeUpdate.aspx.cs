using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Model;
using MyCmsWEB;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.Web.Manager.SysManage
{
    public partial class CodeUpdate : PageBase
    {
        public CodeUpdate()
        {
            ModuleCode = "CodeManage";
            PageOperate = PurOperate.修改;
        }

        BSysCode bsc = new BSysCode();
        BSysOperateLog bsol=new BSysOperateLog();
        string codeid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            codeid = PubCom.Q("ID");
            if (codeid == "")
            {
                Message.ShowWrongAndClose(this, "参数错误");
                return;
            }

            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        void BindDetail()
        {
            SysCode sc = bsc.GetCodeByID(int.Parse(codeid));
            if (null != sc)
            {
                hfCodeID.Value = sc.CodeID.ToString();
                txtCodeName.Text = sc.CodeName;
                txtCodeText.Text = sc.CodeText;
                txtCodeValue.Text = sc.CodeValue;
                txtSortNo.Text = sc.SortNo.ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SysCode sc = new SysCode();
            sc.CodeID = int.Parse(hfCodeID.Value);
            sc.CodeName = PubCom.CheckString(txtCodeName.Text.Trim());
            sc.CodeText = PubCom.CheckString(txtCodeText.Text.Trim());
            sc.CodeValue = PubCom.CheckString(txtCodeValue.Text.Trim());
            sc.SortNo = int.Parse(txtSortNo.Text.Trim());
            SysCode scold = bsc.GetCodeByID(sc.CodeID);
            if (bsc.Update(sc) != 1)
            {
                Message.ShowWrong(this, "修改失败");
                return;

            }
            else
            {
                //// 插入日志
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.数据字典.ToString();
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "数据修改";
                log.LogBeforeObject = JsonHelper.Obj2Json(scold);
                log.LogAfterObject = JsonHelper.Obj2Json(sc);
                bsol.Insert(log);
                Message.ShowOKAndReflashParent(this, "修改成功", "zbquery");
            }
        }
    }
}