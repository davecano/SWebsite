using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.Bll;
using KBsiteframe.Model;
using KBsiteframe.WEB.Comm;

namespace KBsiteframe.WEB.Website
{
    public partial class index : VistorPageBase
    {
        BNew bn = new BNew();
        public IList<New> piclist = new List<New>();

        BNotice bo = new BNotice();
        BDynamic bd = new BDynamic();
        protected void Page_Load(object sender, EventArgs e)
        {
            EventHandler += () => plLogin.Visible = true;
            if (!IsPostBack)
            {

                BindDetail();
                BindDropdownList();

            }
        }

        private void BindDropdownList()
        {

        }

        private void BindDetail()
        {
            //绑定新闻,先将新闻信息列表展示
            IList<New> NewsTitleList = bn.GetNewsTitleList();

            rpNewList.DataSource = NewsTitleList;
            rpNewList.DataBind();
            var tlist = NewsTitleList.Take(3).ToList();
            foreach (var pic in tlist)
            {
                pic.NewsPicPath = ConfigurationManager.AppSettings["FileBasicPath"] + "/"
                  + pic.NewsPicPath;
                piclist.Add(pic);
            }
            if (tlist.Count < 3)
                for (int i = 0; i < 3 - tlist.Count; i++)
                {
                    piclist.Add(new New());
                }

            //绑定通知公告
            rpNoticeList.DataSource = bo.GetNoticesTitleList();
            rpNoticeList.DataBind();
            //绑定联盟动态
            rpLMlist.DataSource = bd.GetDynamicsTitleList(DynamicType.联盟动态);
            rpLMlist.DataBind();
            //绑定团队动态
            rpTDlist.DataSource = bd.GetDynamicsTitleList(DynamicType.团队动态);
            rpTDlist.DataBind();
        }


    }
}