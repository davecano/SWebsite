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
    public partial class CodeAdd : PageBase
    {
        public CodeAdd()
        {
            ModuleCode = "CodeManage";
            PageOperate = PurOperate.添加;
        }

        BSysCode bsc = new BSysCode();
        BSysOperateLog bsol=new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SysCode sc = new SysCode();
            sc.CodeID = bsc.GetMaxID() + 1;
            sc.CodeName = PubCom.CheckString(txtCodeName.Text.Trim());
            sc.CodeText = PubCom.CheckString(txtCodeText.Text.Trim());
            sc.CodeValue = PubCom.CheckString(txtCodeValue.Text.Trim());
            sc.SortNo = int.Parse(txtSortNo.Text.Trim());

            if (bsc.Insert(sc) != 1)
            {
                Message.ShowWrong(this, "添加失败");
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
                log.LogOperateType = "数据新增";
             
                log.LogAfterObject = JsonHelper.Obj2Json(sc);
                bsol.Insert(log);
                Message.ShowOKAndReflashParent(this, "添加成功", "zbquery");
            }
        }
    }
}