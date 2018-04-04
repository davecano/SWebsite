using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Model;
using SysBase.BLL;
using SysBase.Model;
using Z;
using System.Data;
using KBsiteframe.WEB.Comm;


namespace KBsiteframe.Web.Manager.SysManage
{
    public partial class OperateManage : PageBase
    {
        public OperateManage()
        {
            ModuleCode = "";
            PageOperate = PurOperate.分配权限;
        }

        int mid = 0;
        BMenu bm = new BMenu();
        BOperate bo = new BOperate();
        BSysOperateLog bsol=new BSysOperateLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            string tempmid = "";
            Q("ID", out tempmid);
            mid = int.Parse(tempmid);
            if (!IsPostBack)
            {
                BindInfo();
            }
        }

        void BindInfo()
        {
            SysMenu sm = new SysMenu();
            sm = bm.GetSysMenuByID(mid);
            if (sm != null)
            {
                litMenuName.Text = sm.MenuName;
                litModuleCode.Text = sm.ModuleCode;
                IList<SysOperate> lso = bo.GetMenuOperate(mid);
                rpoperate.DataSource = GetAllOperate(lso);
                rpoperate.DataBind();
            }

        }

        DataTable GetAllOperate(IList<SysOperate> lso)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("OperateName");
            dt.Columns.Add("IsCan");
            foreach (int po in Enum.GetValues(typeof(PurOperate)))
            {
                string strName = Enum.GetName(typeof(PurOperate), po);//获取名称
                DataRow dr = dt.NewRow();
                dr["OperateName"] = strName;

                if (lso.Where(p => p.OperateName == strName).ToList().Count > 0)
                {
                    dr["IsCan"] = 1;
                }
                else
                {
                    dr["IsCan"] = 0;
                }
                dt.Rows.Add(dr);
            }
            return dt;

        }

        public bool BindIsCan(string s)
        {
            if (s.ToString() == "1")
                return true;
            else
                return false;
        }

        protected void zbupdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rpoperate.Items.Count; i++)
            {
                CheckBox cb = rpoperate.Items[i].FindControl("cboperate") as CheckBox;
                if (cb.Checked)
                {
                    if (!bo.IsHaveOperareName(mid, cb.Text.Trim()))
                    {
                        SysOperate so=new SysOperate();
                        so.MenuID = mid;
                        so.OperateID = bo.GetMaxID() + 1;
                        so.OperateName = cb.Text.Trim();
                        bo.Insert(so);
                        //bo.Insert(new SysOperate() { MenuID = mid, OperateID = bo.GetMaxID() + 1, OperateName = cb.Text.Trim() });
                        SysOperateLog log = new SysOperateLog();
                        log.LogID = StringHelper.getKey();
                        log.LogType = LogType.菜单信息.ToString();
                        log.LogObjectID = mid.ToString();
                        log.LogObjectName = bm.GetSysMenuByID(mid).MenuName;
                        log.OperateUser = GetLogUserName();
                        log.OperateDate = DateTime.Now;
                        log.LogOperateType = "设置操作";
                      
                        log.LogAfterObject =JsonHelper.Obj2Json(so) ;
                        log.LogRemark = "添加的菜单操作";
                        bsol.Insert(log);
                    }
                }
            }

            Response.Redirect("MenuManage.aspx");
        }
    }
}