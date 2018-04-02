<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentManage.aspx.cs" Inherits="KBsiteframe.Web.Manager.SysManage.DepartmentManage" %>
<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
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
    <script>
        $(document).ready(function () {
            $("#Nav", parent.document).html("部门管理");
        });
        function checkform() {
            var ret = true;
            if ($.trim($("#txtDepartmentName").val()) == "") {
                layer.tips("请输入部门名称", $("#txtDepartmentName"), { guide: 1, time: 3 });
                $("#txtDepartmentName").focus();
                return false;
            }
            return ret;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-1 align-right">部门名称</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtDepartmentName" runat="server"/>
                        </div>
                        <label class="col-sm-1 align-right">是否启用</label>
                        <div class="col-sm-3 align-left">
                            <asp:CheckBox ID="cbIsUse" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer align-center">
                <cc1:ZButton ID="ZButton1" runat="server" Text="添加" OnClientClick="return checkform();" OnClick="ZButton1_Click" ModuleCode="DepartmentManage" Operate="添加" />
                &nbsp;
                <cc1:ZButton ID="ZButton2" runat="server" Text="修改" OnClick="ZButton2_Click" ModuleCode="DepartmentManage" Operate="修改" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <table class="table table-striped table-bordered table-hover table-condensed">
                    <thead>
                        <tr class="table-header">
                            <th class="hidden-xs center">编号</th>
                            <th class="center">名称</th>
                            <th class="center">是否启用</th>
                            <th class="center">操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rplist" runat="server" OnItemCommand="rplist_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td class="center hidden-xs"><%#Eval("DepartmentID") %></td>
                                    <td class="center">
                                        <asp:TextBox ID="tDepartmentName" Width="180px" runat="server" Text='<%#Eval("DepartmentName") %>'></asp:TextBox>
                                    </td>
                                    <td class="center">
                                        <asp:CheckBox ID="cIsUse" runat="server" Checked='<%#(bool)Eval("IsUse") %>' />
                                    </td>
                                    <td class="center">
                                        <cc1:ZLinkButton ID="zlsc" CommandName="sc" CommandArgument='<%#Eval("DepartmentID") %>' OnClientClick="return confirm('删除部门有风险！将会同时删除部门下所属用户。确定要删除吗');" runat="server" ModuleCode="DepartmentManage" Operate="删除">删除</cc1:ZLinkButton>
                                        <%--<cc1:ZLinkButton ID="zlsetoperate" runat="server" CommandName="setoperate" Text="设置操作" CommandArgument='<%#Eval("RoleID") %>' Operate="分配权限" ModuleCode="DepartmentManage"></cc1:ZLinkButton>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>    
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

