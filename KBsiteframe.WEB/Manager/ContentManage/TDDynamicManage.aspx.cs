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
    public partial class TDDynamicManage : PageBase
    {
        public TDDynamicManage()
        {
            ModuleCode = "TDDynamicManage";
            PageOperate=PurOperate.查询;
        }
 
      
        BDynamic bd=new BDynamic();
   BSysOperateLog bsol=new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingList();
            }
        }

        private void BindingList()
        {
            Query qm = Query.Build(new {SortFields = "IsTop Desc,SubTime Desc" });
            //联盟动态
            qm.Add("DynamicType", DynamicType.团队动态.ToString());

            string Title = PubCom.CheckString(txtTitle.Text.Trim());
            if (Title != "")
                qm.Add("Title", Title);
            string Author = PubCom.CheckString(txtAuthor.Text.Trim());
            if (Author != "")
                qm.Add("Uploader", Author);
            string Subtime = PubCom.CheckString(StarTime.Text.Trim());
         
   
            if (Subtime != "")
                qm.Add("Subtime", DateTime.Parse(Subtime));
         
            if (dpIsTop.SelectedValue != "")
                qm.Add("IsTop", dpIsTop.SelectedValue == "1" );


            int ret = 0;
            rplist.DataSource = bd.GetDynamicsList(qm, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out ret);
            rplist.DataBind();
            AspNetPager1.RecordCount = ret;
            // 插入日志  query
            SysOperateLog log = new SysOperateLog();
            log.LogID = StringHelper.getKey();
            log.LogType = LogType.团队动态信息.ToString();
            log.OperateUser = GetLogUserName();
            log.OperateDate = DateTime.Now;
            log.LogOperateType = "团队动态信息查询";
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
            Response.Redirect("TDDynamicAdd.aspx");
        }

        protected void rplist_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="bj")
            {
                Response.Redirect("TDDynamicEdit.aspx?ID=" + e.CommandArgument);
            }
            if (e.CommandName == "sc")
            {
              
                int id = int.Parse(e.CommandArgument.ToString());
                var newsmodel = bd.GetDynamicsByID(id);

                if (bd.Delete(newsmodel) == 1)
                {
                    //// 插入日志  delete
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.联盟动态信息.ToString();
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "团队动态信息删除";
                    log.LogBeforeObject = JsonHelper.Obj2Json(newsmodel);
                    bsol.Insert(log);
                 
                    Message.ShowOK(this, "删除团队动态成功!");
                }
        
                
                else
                    Message.ShowWrong(this,"删除团队动态失败");
                
            }
            BindingList();
        }
    }
}