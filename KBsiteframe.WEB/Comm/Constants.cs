namespace MyCmsWEB
{
    public class Constants
    {
        /// <summary>
        ///     传递ReturnUrl的查询字符串常量
        /// </summary>
        public const string QUERYSTRING_RETURN_URL = "returnUrl";

        ///
        public const string QUERYSTRING_QUERY_CONDITION = "queryCondition";

        public const string VIEWSTATE_QUERY_CONDITION = "__QUERYCONDITION";

        /// <summary>
        ///     默认分页大小
        /// </summary>
        public static int GRIDVIEW_PAGE_SIZE = 15;

        public static string DefaultPassword = "999999";
        public static string PassWordEncodeType = "MD5";
        public static string AdminName = "admin";

        /// <summary>
        ///     默认的企业维护角色编号
        /// </summary>
        public static string DefaultCompanyDataRoleID = "CompanyData";

        /// <summary>
        ///     默认的企业投标角色编号
        /// </summary>
        public static string DefaultCompanyBidRoleID = "CompanyBid";

        /// <summary>
        ///     审核通过
        /// </summary>
        public static int ExaminStatusPass = 1;

        /// <summary>
        ///     审核未通过
        /// </summary>
        public static int ExaminStatusNoPass = 2;
    }
}