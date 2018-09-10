using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
    public partial class ToolManage : PageBase
    {
        public ToolManage()
        {
            ModuleCode = "ToolManage";
            PageOperate=PurOperate.查询;
        }
 
      
       BTool bn=new BTool();
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
           Utils.BindDropDownList(typeof(ToolType),dpToolType,"");
          
            dptoolupload.Items.Clear();

            dptoolupload.Items.Add(new ListItem("上传附件", ""));
            FieldInfo[] fields = typeof(ToolType).GetFields();
            for (int i = 1; i < fields.Length; i++)
            {
                dptoolupload.Items.Add(new ListItem(fields[i].Name));
            }
          

        }

        private void BindingList()
        {
            Query qm =new Query();
            qm.OrderBy("CHARINDEX(RTRIM(CAST(ToolType as NCHAR)),'视频文件,文本文件,压缩文件'), UploadTime desc");

            string name = PubCom.CheckString(txtName.Text.Trim());
            if (name != "")
                qm.Add("ToolName", name);
         
           
            if (dpToolType.SelectedValue != "")
                qm.Add("ToolType", dpToolType.SelectedValue );


            int ret = 0;
            rplist.DataSource = bn.GetToolsList(qm, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out ret);
            rplist.DataBind();
            AspNetPager1.RecordCount = ret;
            // 插入日志  query
            SysOperateLog log = new SysOperateLog();
            log.LogID = StringHelper.getKey();
            log.LogType = LogType.工具信息.ToString();
            log.OperateUser = GetLogUserName();
            log.OperateDate = DateTime.Now;
            log.LogOperateType = "工具信息查询";
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
            Response.Redirect("ToolAdd.aspx");
        }

        protected void rplist_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {

            int id = int.Parse(e.CommandArgument.ToString());
            var model = bn.GetToolsByID(id);
            string realpath;
            if (e.CommandName=="bj")
            {
                Response.Redirect("ToolEdit.aspx?ID=" + e.CommandArgument);
            }
            else if (e.CommandName == "sc")
            {
              
           

                if (bn.Delete(model) == 1)
                {
                    //// 插入日志  delete
                    SysOperateLog log = new SysOperateLog();
                    log.LogID = StringHelper.getKey();
                    log.LogType = LogType.工具信息.ToString();
                    log.OperateUser = GetLogUserName();
                    log.OperateDate = DateTime.Now;
                    log.LogOperateType = "工具信息删除";
                    log.LogBeforeObject = JsonHelper.Obj2Json(model);
                    bsol.Insert(log);
                 
                    Message.ShowOK(this, "删除工具信息成功!");
                }
        
                
                else
                    Message.ShowWrong(this, "删除工具信息失败");
                
            }
            else if (e.CommandName == "xz")
            {
                //做个判定
                if (model.PathType == PathType.服务器.ToString())
                {
                    realpath = PicFilePathV + "ToolAttach/" + model.ToolPath;
                }
                else /*if (model.PathType == PathType.链接.ToString())*/
                    realpath = model.ToolPath;

                    bn.DownloadFile(realpath);  
            }
          
            BindingList();
        }

        protected void rplist_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hftoolid=e.Item.FindControl("hftoolid") as HiddenField;
            ZLinkButton zb1=e.Item.FindControl("zlxz") as ZLinkButton;
            ZButton   zb2=e.Item.FindControl("zbsub") as ZButton;
           Tool t= bn.GetToolsByID(Utils.StrToInt(hftoolid.Value, 0));
            if (t.ToolSuffix == "mp4" || t.ToolSuffix == "webm" || t.ToolSuffix=="ogg")
            {
                zb1.Visible = false;
                zb2.Visible = true;
            }
            else
            {
                zb1.Visible = true;
                zb2.Visible = false;
            }
        }
    }
}