using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KBsiteframe.Model
{

    public class ModelConstants 
    {
        //常量
        public static string FileBathPath = "CQFile";//资质上传文件的根目录
        public static string DocumentBathPath = "DocumentFile"; // 文档上传文件的根目录
        public static string InvoiceBathPath = "InvoiceFile"; // 文档上传文件的根目录
        public static string BidResultBathPath = "BidResultFile"; // 文档上传文件的根目录
        public static string DeliveryPricesBasePath ="DeliveryPricesFile"; // 文档上传文件的根目录
        
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

    /// <summary>
    /// 资质类别
    /// </summary>
    public enum CQType
    {
        企业资质,
        产品资质
    }

    public enum CollectionType
    {
        导入,
        推送
    }

    public enum AgencySource
    {
        手工,
        导入,
        推送
    }

    public enum NodeConfType
    {
        表单,
        文件
    }

    public enum FieldType
    {
        无限文本,
        有限文本,
        整数,
        小数,
        日期
    }

    public enum NodeStatus
    {
        未完成,
        已过期,
        已完成
    }

    public enum ProjectStatus
    {
        准备中,
        进行中,
        暂停中,
        已结束
    }

    public enum SendType
    {
        邮件,
        短信,
        站内
    }

    public enum SendStatus
    {
        未推送,
        推送成功,
        推送失败
    }
    public enum PriceSource
    {
       选取,
       自定义
       
    }
    public enum DeliveryTypeName
    {
        Meheco,
        Health,
        Others

    }

    public enum LogType
    {
        帐户信息,
        菜单信息,
        角色信息,
        部门信息,
        地区信息,
        数据字典,
        企业信息,
        医院信息,
        产品类别,
        产品信息,
        竞品信息,
        企业资质,
        产品资质,
        终端类型,
        终端价格,
        竞品价格,
        中标对应,
        收费信息,
        医保信息,
        代理信息,
        项目阶段,
        节点信息,
        模版信息,
        项目信息,
        日志信息,
        资质类别
    }
}
