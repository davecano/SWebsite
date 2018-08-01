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

    public partial class StuMemberManage : PageBase
    {
        public StuMemberManage()
        {
            ModuleCode = "StuMemberManage";
            PageOperate = PurOperate.查询;
        }





        BSysOperateLog bsol = new BSysOperateLog();
     
   
        BMember bm = new BMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                BindingList();
            }
        }

    

        private void BindingList()
        {
            Query qm = Query.Build(new { SortFields = "MemberID" });

            qm.Add("MemberType", MemberType.普通学生.ToString());
            string Name = PubCom.CheckString(txtName.Text.Trim());
            if (Name != "")
                qm.Add("MemberName", Name);
            string Phone = PubCom.CheckString(txtPhone.Text.Trim());
            if (Phone != "")
                qm.Add("Phone", Phone);
            string Email = PubCom.CheckString(txtEmail.Text.Trim());
            if (Email != "")
                qm.Add("Email", Email);
            string Qualification = PubCom.CheckString(txtQualification.Text.Trim());
            if (Qualification != "")
                qm.Add("Qualification", Qualification);
            string Organization = PubCom.CheckString(txtOrganization.Text.Trim());
            if (Organization != "")
                qm.Add("Organization", Organization);
             
            int ret = 0;
            rplist.DataSource = bm.GetMembersList(qm, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out ret);
            rplist.DataBind();
            AspNetPager1.RecordCount = ret;

            // 插入日志  query
            SysOperateLog log = new SysOperateLog();
            log.LogID = StringHelper.getKey();
            log.LogType = LogType.普通学生信息.ToString();
            log.OperateUser = GetLogUserName();
            log.OperateDate = DateTime.Now;
            log.LogOperateType = "普通学生信息查询";
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
            Response.Redirect("StuMemberAdd.aspx");
        }

        protected void rplist_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "bj")
            {
                Response.Redirect("StuMemberEdit.aspx?ID=" + e.CommandArgument);
            }
            if (e.CommandName == "sc")
            {

                int id = int.Parse(e.CommandArgument.ToString());
                var newsmodel = bm.GetMembersByID(id);

                if (bm.Delete(newsmodel) == 1)
                {

                    //// 插入日志  delete
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.普通学生信息.ToString();
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "删除普通学生信息";
                    log.LogBeforeObject = JsonHelper.Obj2Json(newsmodel);
                    bsol.Insert(log);

                    Message.ShowOK(this, "删除普通学生信息成功!");
                }
          
                else
                    Message.ShowWrong(this, "删除联普通学生信息失败");

            }
            BindingList();
        }

        protected void zbTop_OnClick(object sender, EventArgs e)
        {
            string[] key = PubCom.GetRepeaterKeyList(rplist, "cbselect");
            if (key.Length > 0)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    if (!string.IsNullOrEmpty(key[i]))
                    {

                        int memberid = Utils.StrToInt(key[i], 0);
                        int sort = Utils.StrToInt((rplist.Items[i].FindControl("txtsort") as TextBox).Text, 0);
                        Member olde = bm.GetMembersByID(memberid);
                        int rec = bm.Update(new Member()
                        {
                            MemberID = memberid,
                         
                            Sort = sort
                        });
                        if (rec != 1)
                        {
                            Message.ShowWrong(this, "设置显示学生失败！请重试");
                            return;
                        }
                        else
                        {
                            // 插入日志  update

                            Member m2 = bm.GetMembersByID(memberid);
                            SysOperateLog log = new SysOperateLog();
                            log.LogID = StringHelper.getKey();
                            log.LogType = LogType.普通学生信息.ToString();
                            log.OperateUser = GetLogUserName();
                            log.OperateDate = DateTime.Now;
                            log.LogOperateType = "学生是否前端显示";
                            log.LogBeforeObject = JsonHelper.Obj2Json(olde);
                            log.LogAfterObject = JsonHelper.Obj2Json(m2);
                            bsol.Insert(log);
                        }
                    }

                }

                Message.ShowOKAndReflashOfDelete(this, "设置学生前端显示成功！", "zbquery");
            }

        }
    }
}