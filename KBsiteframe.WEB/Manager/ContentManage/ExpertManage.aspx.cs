using System;
using System.Collections.Generic;
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

    public partial class ExpertManage : PageBase
    {
        public ExpertManage()
        {
            ModuleCode = "ExpertManage";
            PageOperate = PurOperate.查询;
        }




       
        BSysOperateLog bsol = new BSysOperateLog();
      
        BExpert be = new BExpert();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
                  BindingList();
            }
        }
        void BindDropDownList()
        {
            Utils.BindDropDownList(typeof(ExpertType), dpEIdentification, "");

        }


        private void BindingList()
        {
            Query qm = Query.Build(new { SortFields = "IsTop, Sort" });

            
            string Name = PubCom.CheckString(txtExpertName.Text.Trim());
            if (Title != "")
                qm.Add("EName", Name);
            string country = PubCom.CheckString(txtCountry.Text.Trim());
            if (country != "")
                qm.Add("ECountry", country);
           
              if(dpIsTop.SelectedValue!="")
                  qm.Append(dpIsTop.SelectedValue == "0" ? "IsTop=0" : "IsTop=1 or IsTop is null");

            int ret = 0;
            rplist.DataSource = be.GetExpertsList(qm, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out ret);
            rplist.DataBind();
            AspNetPager1.RecordCount = ret;
            // 插入日志  query
            SysOperateLog log = new SysOperateLog();
            log.LogID = StringHelper.getKey();
            log.LogType = LogType.专家信息.ToString();
            log.OperateUser = GetLogUserName();
            log.OperateDate = DateTime.Now;
            log.LogOperateType = "专家查询";
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
            Response.Redirect("ExpertAdd.aspx");
        }

        protected void rplist_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "bj")
            {
                Response.Redirect("ExpertEdit.aspx?ID=" + e.CommandArgument);
            }
            if (e.CommandName == "sc")
            {

                int id = int.Parse(e.CommandArgument.ToString());
                var newsmodel = be.GetExpertsByID(id);

                if (be.Delete(newsmodel) == 1)
                {

                    //// 插入日志  delete
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.专家信息.ToString();
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "专家删除";
                    log.LogBeforeObject = JsonHelper.Obj2Json(newsmodel);
                    bsol.Insert(log);
                    Message.ShowOK(this, "删除专家成功!");
                }
            

                else
                    Message.ShowWrong(this, "删除专家失败");

            }
            BindingList();
        }

        protected void ZButton3_OnClick(object sender, EventArgs e)
        {
            string[] key = PubCom.GetRepeaterKeyList(rplist, "cbselect");
            if (key.Length > 0)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    if (!string.IsNullOrEmpty(key[i]))
                    {
                       
                        int expertid = Utils.StrToInt(key[i],0);
                       int sort=Utils.StrToInt((rplist.Items[i].FindControl("txtsort") as TextBox).Text,0) ;
                        Expert olde = be.GetExpertsByID(expertid);
                      int rec=  be.Update(new Expert()
                        {
                            ExpertID = expertid,
                            Istop = true,
                            Sort = sort
                        });
                        if (rec != 1)
                        {
                            Message.ShowWrong(this, "设置置顶专家失败！请重试");
                            return;
                        }
                        else
                        {
                            // 插入日志  update

                            Expert e2 = be.GetExpertsByID(expertid);
                            SysOperateLog log = new SysOperateLog();
                            log.LogID = StringHelper.getKey();
                            log.LogType = LogType.专家信息.ToString();
                            log.OperateUser = GetLogUserName();
                            log.OperateDate = DateTime.Now;
                            log.LogOperateType = "专家是否置顶修改";
                            log.LogBeforeObject = JsonHelper.Obj2Json(olde);
                            log.LogAfterObject = JsonHelper.Obj2Json(e2);
                            bsol.Insert(log);
                        }
                    }
                     
                    }

                Message.ShowOKAndReflashOfDelete(this, "设置置顶专家成功！", "zbquery");
            }
               
            }
        
    }
}