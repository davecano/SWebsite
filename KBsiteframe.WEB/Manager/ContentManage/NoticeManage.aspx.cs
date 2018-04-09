using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class NoticeManage : PageBase
    {
        public NoticeManage()
        {
            ModuleCode = "NoticeManage";
            PageOperate=PurOperate.查询;
        }
 
      
       BNotice bn=new BNotice();
   BSysOperateLog bsol=new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdownList();
                BindingList();
            }
        }

        private void BindDropdownList()
        {
           Utils.BindDropDownList(typeof(NoticeType),dpNoticeStatus,"");
        }

        private void BindingList()
        {
            Query qm = Query.Build(new {SortFields = "LastUpdateDate Desc" });
            

            string Title = PubCom.CheckString(txtTitle.Text.Trim());
            if (Title != "")
                qm.Add("NoticeTitle", Title);
            string CreateUser = PubCom.CheckString(txtCreateUser.Text.Trim());
            if (CreateUser != "")
                qm.Add("CreateUser", CreateUser);
            string Subtime = PubCom.CheckString(StarTime.Text.Trim());
         
   
            if (Subtime != "")
                qm.Add("CreateDate", DateTime.Parse(Subtime));
         
            if (dpNoticeStatus.SelectedValue != "")
                qm.Add("NoticeStatus", dpNoticeStatus.SelectedValue );


            int ret = 0;
            rplist.DataSource = bn.GetNoticesList(qm, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out ret);
            rplist.DataBind();
            AspNetPager1.RecordCount = ret;
            // 插入日志  query
            SysOperateLog log = new SysOperateLog();
            log.LogID = StringHelper.getKey();
            log.LogType = LogType.公告信息.ToString();
            log.OperateUser = GetLogUserName();
            log.OperateDate = DateTime.Now;
            log.LogOperateType = "公告信息查询";
            log.LogAfterObject = JsonHelper.Obj2Json<string>(qm.GetCondition(true));
            bsol.Insert(log);

        }

        protected void zbquery_OnClick(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindingList();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindingList();
        }

        protected void ZButton2_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("NoticeAdd.aspx");
        }

        protected void rplist_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="bj")
            {
                Response.Redirect("NoticeEdit.aspx?ID=" + e.CommandArgument);
            }
            if (e.CommandName == "sc")
            {
              
                int id = int.Parse(e.CommandArgument.ToString());
                var newsmodel = bn.GetNoticesByID(id);

                if (bn.Delete(newsmodel) == 1)
                {
                    //// 插入日志  delete
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.公告信息.ToString();
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "公告信息删除";
                    log.LogBeforeObject = JsonHelper.Obj2Json(newsmodel);
                    bsol.Insert(log);
                 
                    Message.ShowOK(this, "删除公告信息成功!");
                }
        
                
                else
                    Message.ShowWrong(this, "删除公告信息失败");
                
            }
            BindingList();
        }
    }
}