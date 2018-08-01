<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistorManage.aspx.cs" Inherits="KBsiteframe.Web.Manager.ContentManage.VistorManage" %>

<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Z" TagPrefix="webdiyer" %>


<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="/assets/css/font-awesome-ie7.min.css" />
		<![endif]-->
    <link rel="stylesheet" href="/assets/css/ace.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="/assets/css/ace-skins.min.css" />

    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="/assets/css/ace-ie.min.css" />
		<![endif]-->
    <!-- ace settings handler -->

    <script src="/assets/js/ace-extra.min.js"></script>


    <!--[if lt IE 9]>
		<script src="/assets/js/html5shiv.js"></script>
		<script src="/assets/js/respond.min.js"></script>
		<![endif]-->
    <script type="text/javascript" src="/js/jquery-1.11.3.min.js"></script>
	<script type="text/javascript" src="/js/My97DatePicker4.7.2/WdatePicker.js"></script>
	<script type="text/javascript" src="/js/layer/layer.min.js"></script>
    <script type="text/javascript" src="/js/Common.js"></script>
    <script>
        $(document).ready(function () {
            $("#ZButton3").click(function () {
                var ret = true;
                $checked = $("#tlist").find('input[name*="select"][type="checkbox"]:checked');
                if ($checked.length != 1) {
                    layer.msg("请选择需要修改的用户信息", 2, 8);
                    return false;
                }
                return ret;
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="zbquery">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-1 align-right">用户名称</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </div>
                        <label class="col-sm-1 align-right">登录帐号：</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtUserLoginName" runat="server"></asp:TextBox>
                        </div>
                        <label class="col-sm-1 align-right">用户角色</label>
                        <div class="col-sm-2 align-left">
                            <asp:DropDownList ID="dpUserRole" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-1 align-right">机构名称</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtOrgName" runat="server"></asp:TextBox>
                        </div>
                        <label class="col-sm-1 align-right">用户状态</label>
                        <div class="col-sm-2 align-left">
                            <asp:DropDownList ID="dpUserStatus" runat="server">
                                    <asp:ListItem>全部</asp:ListItem>
                                    <asp:ListItem>启用</asp:ListItem>
                                    <asp:ListItem>禁用</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer align-center">
                <cc1:ZButton ID="zbquery" runat="server" Text="查询" OnClick="zbquery_Click" />
                &nbsp;
            <%--    <cc1:ZButton ID="ZButton2" runat="server" Text="新增" OnClick="ZButton2_Click" ModuleCode="UserManage" Operate="添加" />
                &nbsp;
                <cc1:ZButton ID="ZButton3" runat="server" Text="修改" OnClick="ZButton3_Click" ModuleCode="UserManage" Operate="修改" />
                &nbsp;--%>
                <cc1:ZButton ID="ZButton4" runat="server" Text="删除" OnClientClick="return DeleteConfirm('tlist', '请选择需要删除的用户信息', '确定要删除吗？');" OnClick="ZButton4_Click" ModuleCode="UserManage" Operate="删除" EnableTheming="false"  class="btn btn-sm btn-danger" />
                &nbsp;
                <cc1:ZButton ID="ZButton5" runat="server" Text="重置密码" OnClientClick="return DeleteConfirm('tlist', '请选择需要重置密码的资质信息', '确定要重置密码吗？');" OnClick="ZButton5_Click" ModuleCode="UserManage" Operate="重置密码" EnableTheming="false"  class="btn btn-sm btn-warning" />
                &nbsp;
                <cc1:ZButton ID="ZButton6" runat="server" Text="启用/禁用" OnClientClick="return DeleteConfirm('tlist', '请选择需要启禁用的用户信息', '确定要启用/禁用吗？');" OnClick="ZButton6_Click" ModuleCode="UserManage" Operate="启禁用" />
            
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table class="table table-striped table-bordered table-hover table-condensed" id="tlist">
                    <thead>
                        <tr class="table-header">
                            <th class="center">选</th>
                         
                            <th class="center">用户名称</th>
                            <th class="center">最后登录IP</th>
                            <th class="center">手机</th>
                              <th class="center">邮箱</th>
                            <th class="center">状态</th>
                            <th class="center">操作</th>
                            
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rplist" runat="server"  OnItemDataBound="rplist_OnItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td class="center">
                                        <input type="checkbox" value='<%#Eval("UserID") %>' id="cbselect" name="cbselect" onclick="Change(event, 'tlist');" runat="server" />
                                    </td>
                                    <td class="center"><%#Eval("UserLoginName") %></td>
                                
                                    <td class="center"><%#Eval("LastIP") %></td>
                                    <td class="center"><%#Eval("Phone") %></td>
                                      <td class="center"><%#Eval("Email") %></td>
                                    <td class="center"><%#BindIsUse(Eval("IsUse")) %></td>
                                     <td>
                                         <asp:HiddenField runat="server" Value='<%#Eval("UserID") %>' ID="hfuserid"/>
                                        <cc1:ZButton ID="zbsbmit" runat="server" ModuleCode="UserManage" Operate="修改" CssClass="btn btn-success btn-sm" Text="审核通过" CommandArgument='<%#Eval("UserID") %>' OnClick="zbsbmit_OnClick" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="pull-right">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
    </form>
</body>
</html>
