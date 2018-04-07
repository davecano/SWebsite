using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms_BLL;
using MyCms_Model;
using Z;

namespace MyCmsWEB.Content
{
    public partial class ClassManage : PageBase
    {
    
        mycms_class_Manage mcm = new mycms_class_Manage();

        public ClassManage()
        {
            ModuleCode = "ClassManage";
            PageOperate = PurOperate.查询;
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClass();
            }
        }

        List<mycms_class> lmc=new List<mycms_class>();
        private int _id;

        private void BindClass()
        {

            var qm = Query.Build(new {SortFields = "ParentId,SortRank"});
            qm.Add("IsForbidden", 0);
            GetAllNotes(mcm.GetClassList(qm), 0);
            rpmenu.DataSource = lmc;
            rpmenu.DataBind();


        }

        private void GetAllNotes(IList<mycms_class> getClassList, int i)
        {
            foreach (var roots in getClassList.Where(p => p.ParentId == i))
                //when i==0,then the leafs are the root notes
            {
                lmc.Add(roots);
                //foreach (var leafs in getClassList.Where(p => p.ParentId == roots.Id))
                //{
                //    lmc.Add(leafs);
                //}   
                GetAllNotes(getClassList,roots.Id);
            }
        }

        protected void ZButton1_OnClick(object sender, EventArgs e)
        {
            mycms_class mc = new mycms_class();
            mc.Id = mcm.GetMaxID() + 1;
            mc.ClassName = PubCom.CheckString(txtClassName.Text.Trim());
            mc.ParentId = int.Parse(PubCom.CheckString(txtParentClassID.Text.Trim()));
            mc.SortRank = int.Parse(PubCom.CheckString(txtClassSort.Text.Trim()));
            mc.IsOnNav = CheckboxNav.Checked;
            mc.IsOnIndex = CheckboxIndex.Checked;
            mc.IsForbidden = CheckIsforbidden.Checked;
            if (mcm.Insert(mc) != 1)
            {
                Message.ShowWrong(this, "添加栏目失败");
                return;
            }

            else
            {
                string sPath = Server.MapPath(@"~/") + "Html\\" + mc.Id;
                if (!Directory.Exists(sPath))
                {
                    Directory.CreateDirectory(sPath);
                }
                Message.ShowOK(this,"添加栏目成功");
                BindClass();
            }
          
        }

        protected void ZButton2_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < rpmenu.Items.Count; i++)
            {
                
            }
        }

        protected void rpmenu_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "bj")
            {
                _id = int.Parse(e.CommandArgument.ToString()); //获取命令ID号
            }
            else if (e.CommandName == "qx")
            {
                _id = -1;
            }
            else if (e.CommandName == "sc")
            {
                _id = int.Parse(e.CommandArgument.ToString()); //获取命令ID号
                //这里是删除方法
                Query qm = Query.Build(new {SortFields = "ParentId,SortRank"});
                qm.Add("IsForbidden", 0);
                qm.Append("ParentId=" + _id);
                if (mcm.GetClassList(qm).Count != 0)
                {
                    Message.ShowWrong(this, "请删除子栏目");
                    return;
                }
                if (mcm.Delete(new mycms_class() {Id = _id}) != 1)
                {
                    Message.ShowWrong(this, "删除失败");
                    return;
                }
                else
                {
                    string sPath = Server.MapPath(@"~/") + "Html\\" + _id;
                    DirectoryInfo di = new DirectoryInfo(sPath);
                    di.Delete(true);
                    Message.ShowOK(this, "删除栏目成功");
                }
            }
            else if (e.CommandName == "qd")
            {
                mycms_class mc = new mycms_class();
                mc.Id = int.Parse(((ZLinkButton) e.Item.FindControl("zlsc")).CommandArgument);
                mc.ClassName = ((TextBox) e.Item.FindControl("TextBox1")).Text.Trim();
                mc.ParentId = int.Parse(((TextBox) e.Item.FindControl("TextBox2")).Text.Trim());
                mc.SortRank = int.Parse(((TextBox) e.Item.FindControl("TextBox3")).Text.Trim());
                mc.IsOnNav = ((CheckBox) e.Item.FindControl("CheckBox1")).Checked;
                mc.IsOnIndex = ((CheckBox) e.Item.FindControl("CheckBox2")).Checked;
                mc.IsForbidden = ((CheckBox) e.Item.FindControl("CheckBox3")).Checked;
                UpdateClass(mc);
            }
            BindClass();
        }

        private void UpdateClass(mycms_class mc)
        {
            mcm.Update(mc);
            Message.ShowOK(this,"更新栏目成功");
        }

        protected void rpmenu_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            //判断Repeater控件中的数据是否是绑定的数据源，如果是的话将会验证是否进行了编辑操作
            //ListItemType 枚举表示在一个列表控件可以包括，例如 DataGrid、 DataList和 Repeater 控件的不同项目。 
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //获取绑定的数据源，这里要注意上面使用sqlReader的方法来绑定数据源，所以下面使用的DbDataRecord方法获取的
                //如果绑定数据源是DataTable类型的使用下面的语句就会报错.
              //  System.Data.Common.DbDataRecord record = (System.Data.Common.DbDataRecord)e.Item.DataItem;
              // var record = (DataRowView) e.Item.DataItem;
              //使用泛型做数据源时，则是泛型对应的类型，例如List<AttachFile> 为数据源，则
              var record = (mycms_class)e.Item.DataItem;
               
                //DataTable类型的数据源验证方式
                //System.Data.DataRowView record = (DataRowView)e.Item.DataItem;
                //判断数据源的id是否等于现在的id，如果相等的话证明现点击了编辑触发了userRepeat_ItemCommand事件
                if (_id == int.Parse(record.Id.ToString()))
                {
                    ((Panel)e.Item.FindControl("plItem")).Visible = false;
                    ((Panel)e.Item.FindControl("plEdit")).Visible = true;
                }
                else
                {
                    ((Panel)e.Item.FindControl("plItem")).Visible = true;
                    ((Panel)e.Item.FindControl("plEdit")).Visible = false;
                }
            }
        }
    }
}