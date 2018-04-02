using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z
{
    /// <summary>
    /// 操作权限代码
    /// </summary>
    public enum PurOperate
    {
        添加,
        删除,
        修改,
        查询,
        审核,
        重置密码,
        分配权限,
        启禁用,
        导入,
        设置,
        导出,
        上传,
        下载,
        发布,
        置顶,
        打印,
        关联,
        查看
    }

    public enum Module
    {
        #region 系统管理
        用户管理,
        菜单管理,
        角色管理,
        部门管理,
        地区管理,
        日志管理
        #endregion
    }
}
