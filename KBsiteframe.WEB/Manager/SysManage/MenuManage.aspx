<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuManage.aspx.cs" Inherits="KBsiteframe.Web.Manager.SysManage.MenuManage" %>
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
        function checkform()
        {
            var ret = true;
            if ($.trim($("#txtMenuName").val()) == "") {
                layer.tips("请输入菜单名称", $("#txtMenuName"), { guide: 1, time: 3 });
                $("#txtMenuName").focus();
                return false;
            }
            if ($.trim($("#txtParentMenuID").val()) == "") {
                layer.tips("请输入父节点编号", $("#txtParentMenuID"), { guide: 1, time: 3 });
                $("#txtParentMenuID").focus();
                return false;
            }
            if ($.trim($("#txtMenuSort").val()) == "") {
                layer.tips("请输入排序号", $("#txtMenuSort"), { guide: 1, time: 3 });
                $("#txtMenuSort").focus();
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
                        <label class="col-sm-1 align-right">菜单名称</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtMenuName" runat="server"/>
                        </div>
                        <label class="col-sm-1 align-right">代码</label>
                        <div class="col-sm-3 align-left">
                            <asp:TextBox ID="txtModuleCode" runat="server"/>
                        </div>
                        <label class="col-sm-1 align-right">父节点</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtParentMenuID" runat="server"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-1 align-right">排序号</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtMenuSort" runat="server"/>
                        </div>
                        <label class="col-sm-1 align-right">页面地址</label>
                        <div class="col-sm-3 align-left">
                            <asp:TextBox ID="txtPageUrl" runat="server"/>
                        </div>
                        <label class="col-sm-1 align-right">设置</label>
                        <div class="col-sm-3 align-left">
                            <asp:CheckBox ID="cbIsVisiable" runat="server" Text="显示" CssClass="ace" />
                            <asp:CheckBox ID="cbIsLeaf" runat="server" Text="页节点" CssClass="ace" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer align-center">
                <cc1:ZButton ID="ZButton1" runat="server" Text="添加" OnClientClick="return checkform();" OnClick="ZButton1_Click" ModuleCode="MenuManage" Operate="添加" />
                &nbsp;
                <cc1:ZButton ID="ZButton2" runat="server" Text="修改" OnClick="ZButton2_Click" ModuleCode="MenuManage" Operate="修改" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <table class="table table-striped table-bordered table-hover table-condensed">
                    <thead>
                        <tr class="table-header">
                            <th class="hidden-xs center">编号</th>
                            <th class="center">名称</th>
                            <th class="center">地址</th>
                            <th class="center hidden-xs">父节点</th>
                            <th class="center hidden-xs">排序</th>
                            <th class="center hidden-xs">显示</th>
                            <th class="center hidden-xs">页节点</th>
                            <th class="center hidden-xs">代码</th>
                            <th class="center hidden-xs">图标</th>
                            <th class="center">删除</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpmenu" runat="server" OnItemCommand="rpmenu_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td class="center hidden-xs"><%#Eval("MenuID") %></td>
                                    <td class="center">
                                        <asp:TextBox ID="tMenuName" runat="server" Width="100" Text='<%#Eval("MenuName") %>'></asp:TextBox>
                                    </td>
                                    <td class="center">
                                        <asp:TextBox ID="tPageUrl" runat="server" Width="290" Text='<%#Eval("PageUrl") %>'></asp:TextBox>
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:TextBox ID="tParentMenuID" runat="server" Width="25" Text='<%#Eval("ParentMenuID") %>'></asp:TextBox>
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:TextBox ID="tMenuSort" runat="server" Width="25" Text='<%#Eval("MenuSort") %>'></asp:TextBox>
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:CheckBox ID="cIsVisiable" runat="server" Checked='<%#(bool)Eval("IsVisiable") %>' />
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:CheckBox ID="cIsLeaf" runat="server" Checked='<%#(bool)Eval("IsLeaf") %>' />
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:TextBox ID="tModuleCode" runat="server" Width="80" Text='<%#Eval("ModuleCode") %>'></asp:TextBox>
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:TextBox ID="tMenuIco" runat="server" Width="80" Text='<%#Eval("MenuIco") %>'></asp:TextBox>
                                    </td>
                                    <td class="center">
                                        <cc1:ZLinkButton ID="zlsc" CommandName="sc" CommandArgument='<%#Eval("MenuID") %>' OnClientClick="return confirm('确定要删除吗');" runat="server" ModuleCode="MenuManage" Operate="删除">删除</cc1:ZLinkButton>
                                        <cc1:ZLinkButton ID="zlsetoperate" runat="server" CommandName="setoperate" Text="设置操作" CommandArgument='<%#Eval("MenuID") %>' ModuleCode="MenuManage" Operate="分配权限"></cc1:ZLinkButton>
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
