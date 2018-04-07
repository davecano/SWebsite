using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.BLL;
using KBsiteframe.Model;
using MyCmsWEB;
using SysBase.BLL;
using SysBase.Model;
using Z;

namespace KBsiteframe.Web.Manager.SysManage
{
    public partial class AreaManege : PageBase
    {
        public AreaManege()
        {
            ModuleCode = "AreaManege";
            PageOperate = PurOperate.查询;
        }

        BArea ba = new BArea();
        BSysOperateLog bsol=new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        void BindList()
        {
            Query q = Query.Build(new { SortFields = "AreaID" });
            string name = PubCom.CheckString(txtAreaName.Text.Trim());
            if (name != "")
            {
                q.Add("AreaName", name);
            }
            int rec = 0;
            //获取数据列表
            rplist.DataSource = ba.GetAreaList(q, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out rec);
            rplist.DataBind();
            //赋值起始页
            AspNetPager1.RecordCount = rec;
            //// 插入日志
            SysOperateLog log = new SysOperateLog();
            log.LogID = StringHelper.getKey();
            log.LogType = LogType.地区信息.ToString();
            log.OperateUser = GetLogUserName();
            log.OperateDate = DateTime.Now;
            log.LogOperateType = "地区查询";
            log.LogAfterObject = JsonHelper.Obj2Json<string>(q.GetCondition(true));
            bsol.Insert(log);
        }

        protected void zbquery_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            BindList();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindList();
        }
    }
}