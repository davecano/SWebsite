﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KBsiteframe.Model
{

    public class ModelConstants
    {
        //常量
        public static string FileBathPath = "ArticleFile";//文章上传文件的根目录
        public static string ArticlePicBathPath = "ArticlePic";//文章上传图片的根目录
        public static string TreatiseBathPath = "TreatisePic";//专著上传图片的根目录
        public static string ExpertBathPath = "ExpertPic";//专家上传图片的根目录
        public static string NewsBathPath = "NewsPic";//新闻上传图片的根目录
        public static string DocumentBathPath = "DocumentFile"; // 文档上传文件的根目录
        public static string InvoiceBathPath = "InvoiceFile"; // 文档上传文件的根目录
        public static string BidResultBathPath = "BidResultFile"; // 文档上传文件的根目录
        public static string DeliveryPricesBasePath = "DeliveryPricesFile"; // 文档上传文件的根目录

        public static string ProjectBathPath = "ProjectFile"; // 文档上传文件的根目录
        public static int FileMaxLength = 3;//上传文件最大大小。单位MB
        public static string CanUploadFile = ".png|.jpg|.jpeg|.gif|.bmp|.xls|.xlsx|.rar|.zip|.doc|.docx|.pdf|.ppt|.pptx";
        public static string BidUploadFile = ".xls|.xlsx";
        public static string DeliveryPricesFile = ".xls|.xlsx";

        public static string SendOverMsg = "【{0}】已到期，请及时处理";
        public static string SendAdvanceMsg = "【{0}】即将到期，请及时处理";
        public static string SendProjectMsg = "【{0}】已进行到您所参与的【{1}】节点，请及时处理！";
        public static string SendWebUrl = "/Enterprises/ProjectsManage/ProjectView_Info.aspx?ID=";
        public static string SendEQWebUrl = "/Enterprises/QualificationsManage/EQualityUpdate.aspx?ID=";
        public static string SendPQWebUrl = "/Enterprises/QualificationsManage/PQualityUpdate.aspx?ID=";

        public static string SheetName = "投标产品表";
        //public static string ProductViewCode = "ProductManage|BidResultManage|PQualityManage|DeliveryPricesManage|PricesManage|HealthCareManage|AgencyManage|ProjectManage|CompeteProductManage";
    }

    /// <summary>
    /// 审核状态
    /// </summary>
    public enum UserStatus
    {
        未审核,
        审核中,
        审核通过,
        审核不通过
    }
    /// <summary>
    /// 审核状态
    /// </summary>
    public enum ExaminStatus
    {
        未审核,
        审核中,
        审核通过,
        审核不通过
    }



    public enum FieldType
    {
        无限文本,
        有限文本,
        整数,
        小数,
        日期
    }



    public enum LogType
    {
        帐户信息,
        菜单信息,
        角色信息,
        日志信息,
        部门信息,
        数据字典,
        文章信息,
        新闻信息,
        专著信息,
        项目信息,
        专家信息,
        联盟动态信息,
        团队动态信息,
        团队成员信息,
        联盟成员信息,
        公告信息
    }

    public enum MemberType
    {
        联盟成员,
        团队成员
    }
    public enum DynamicType
    {
        联盟动态=1,
        团队动态=2
    }
    public enum ExpertType
    {
        普通专家 = 1,
        成员进盟 = 2,
        校内专家=3
    }
    public enum NoticeType
    {
        未过期,
        已过期,
        禁用
    }
}
