using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.Web.Share
{
    public partial class UpdatePassword : PageBase
    {
        public UpdatePassword()
        {
            ModuleCode = "UserManage";
            PageOperate = PurOperate.修改;
        }

        BSysOperateLog bsol = new BSysOperateLog();
        BUser bu = new BUser();
        private string userID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Q("ID", out userID);

        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
           var usermodel= bu.GetUserByUserID(userID);
            if (usermodel.UserPassword == EncryptHelper.EncryptPassword(PubCom.CheckString(txtOldPsw.Text.Trim()),Constants.PassWordEncodeType))
            {
                string newpsw = EncryptHelper.EncryptPassword(PubCom.CheckString(txtNewPsw.Text.Trim()), Constants.PassWordEncodeType);//new密码
                if (bu.Update(new SysUser() { UserID = userID, UserPassword = newpsw }) == 1)
              {
                // 插入日志
                SysOperateLog log = new SysOperateLog();
                log.LogID = StringHelper.getKey();
                log.LogType = LogType.帐户信息.ToString();
                log.LogObjectID = userID;
                log.LogObjectName = "[" + usermodel.UserLoginName + "]" + usermodel.UserName;
                log.OperateUser = GetLogUserName();
                log.OperateDate = DateTime.Now;
                log.LogOperateType = "密码重置";
                log.LogBeforeObject = JsonHelper.Obj2Json<string>("[原密码：]" + usermodel.UserPassword);
                log.LogAfterObject = JsonHelper.Obj2Json<string>("[新密码：]" + EncryptHelper.Encode(newpsw));
                bsol.Insert(log);
                 
                    Message.ShowOKAndBack(this,"修改密码成功！");
                   
              }
            }
            else
            {
                Message.ShowWrong(this,"用户密码错误，请重试！");
            }
        
        }
    }
}