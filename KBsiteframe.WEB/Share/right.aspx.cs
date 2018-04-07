using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBsiteframe.BLL;
using KBsiteframe.Model;
using MyCmsWEB;
using Z;

namespace KBsiteframe.Web.Share
{
    public partial class right : PageBase
    {

        BQualifications bq = new BQualifications();
        BProduct bp = new BProduct();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = CurrentAccount.User.UserName;
            // 获取当前时间
            DateTime time = DateTime.Now;
            if (time.Hour >= 0 && time.Hour < 6)
            {
                str += "凌晨好";
            }
            else if (time.Hour > 5 && time.Hour < 11)
            {
                str += "上午好";
            }
            else if (time.Hour > 10 && time.Hour < 13)
            {
                str += "中午好";
            }
            else if (time.Hour > 12 && time.Hour < 18)
            {
                str += "下午好";
            }
            else if (time.Hour > 17 && time.Hour < 24)
            {
                str += "晚上好";
            }

            lblLoginUser.Text = str.ToString();

            //BindDB();
            BindTX();
        }

        //void BindDB()
        //{
        //    // 获取企业资质未审核条数
        //    int equalityNum = 0;
        //    Query eqq = new Query();
        //    eqq.OrderBy("QualificationsID desc");
        //    eqq.Add("q.ExamineStatus", ExaminStatus.未审核);
        //    eqq.Add("IsProduct", false);

        //    IList<Qualifications> ecqlist = bq.GetQualificationsList(eqq);

        //    if (null != ecqlist)
        //    {
        //        equalityNum = ecqlist.Count;
        //    }

        //    ltrEQuality.Text = equalityNum.ToString();

        //    // 获取产品资质未审核条数
        //    int pqualityNum = 0;
        //    Query pqq = new Query();
        //    pqq.OrderBy("QualificationsID desc");
        //    pqq.Add("q.ExamineStatus", ExaminStatus.未审核);
        //    pqq.Add("IsProduct", true);

        //    IList<Qualifications> pcqlist = bq.GetQualificationsList(pqq);

        //    if (null != pcqlist)
        //    {
        //        pqualityNum = pcqlist.Count;
        //    }

        //    ltrPQuality.Text = pqualityNum.ToString();

        //    // 获取产品未审核条数
        //    int productNum = 0;
        //    Query pq = new Query();
        //    pq.OrderBy("ProductID desc");

        //    pq.Add("ExamineStatus", ExaminStatus.未审核);

        //    IList<Product> plist = bp.GetProductList(pq);

        //    if (null != plist)
        //    {
        //        productNum = plist.Count;
        //    }

        //    ltrProduct.Text = productNum.ToString();
        //}

        void BindTX()
        {
            // 获取注册证即将到期条数
            int regNum = 0;
            Query rq = new Query();
            rq.OrderBy("QualificationsID desc");
            rq.Add("q.ExamineStatus", ExaminStatus.审核通过);
            rq.Add("IsRegister", true);
            rq.Append("DATEDIFF(day,  GETDATE(),EndTime) >= 0 and DATEDIFF(day,  GETDATE(),EndTime) <= " + QualificationReminderDate);


            IList<Qualifications> rlist = bq.GetQualificationsList(rq);

            if (null != rlist)
            {
                regNum = rlist.Count;
            }

            ltrRegQuality.Text = regNum.ToString();

            // 获取注册证已到期条数
            int regEndNum = 0;
            Query req = new Query();
            req.OrderBy("QualificationsID desc");
            req.Add("q.ExamineStatus", ExaminStatus.审核通过);
            req.Add("IsRegister", true);
            req.Append("DATEDIFF(day,  GETDATE(),EndTime) < 0");


            IList<Qualifications> relist = bq.GetQualificationsList(req);

            if (null != relist)
            {
                regEndNum = relist.Count;
            }

            ltrRegEnd.Text = regEndNum.ToString();


            // 获取企业资质即将到期条数
            int eNum = 0;
            Query eoq = new Query();
            eoq.OrderBy("QualificationsID desc");
            eoq.Add("IsProduct", false);
            eoq.Add("q.ExamineStatus", ExaminStatus.审核通过);
            eoq.Append("DATEDIFF(day,  GETDATE(),EndTime) >= 0 and DATEDIFF(day,  GETDATE(),EndTime) <= " + QualificationReminderDate);

            IList<Qualifications> elist = bq.GetQualificationsList(eoq);

            if (null != elist)
            {
                eNum = elist.Count;
            }

            ltrEOQuality.Text = eNum.ToString();

            // 获取产品资质即将到期条数
            int pNum = 0;
            Query poq = new Query();
            poq.OrderBy("QualificationsID desc");
            poq.Add("q.ExamineStatus", ExaminStatus.审核通过);
            poq.Add("IsProduct", true);
            poq.Append("DATEDIFF(day,  GETDATE(),EndTime) >= 0 and DATEDIFF(day,  GETDATE(),EndTime) <= " + QualificationReminderDate);

            IList<Qualifications> plist = bq.GetQualificationsList(poq);

            if (null != plist)
            {
                pNum = plist.Count;
            }

            ltrPOQuality.Text = pNum.ToString();

            // 获取企业资质已到期条数
            int eEndNum = 0;
            Query eoeq = new Query();
            eoeq.OrderBy("QualificationsID desc");
            eoeq.Add("q.ExamineStatus", ExaminStatus.审核通过);
            eoeq.Add("IsProduct", false);
            eoeq.Append("DATEDIFF(day,  GETDATE(),EndTime) < 0");

            IList<Qualifications> eoelist = bq.GetQualificationsList(eoeq);

            if (null != eoelist)
            {
                eEndNum = eoelist.Count;
            }

            ltrEOEnd.Text = eEndNum.ToString();

            // 获取产品资质已到期条数
            int pEndNum = 0;
            Query poeq = new Query();
            poeq.OrderBy("QualificationsID desc");
            poeq.Add("q.ExamineStatus", ExaminStatus.审核通过);
            poeq.Add("IsProduct", true);
            poeq.Append("DATEDIFF(day,  GETDATE(),EndTime) < 0");

            IList<Qualifications> poelist = bq.GetQualificationsList(poeq);

            if (null != poelist)
            {
                pEndNum = poelist.Count;
            }

            ltrPOEnd.Text = pEndNum.ToString();

        }
    }
}