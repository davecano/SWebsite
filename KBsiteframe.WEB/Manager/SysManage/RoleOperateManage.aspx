<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleOperateManage.aspx.cs" Inherits="KBsiteframe.Web.Manager.SysManage.RoleOperateManage" %>

<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>

<
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
            $("#Nav", parent.document).html("角色权限管理");
        });
    </script>
    <style type="text/css">
        .show-grid [class ^="col-"] {
            padding-bottom: 5px;
        }
    </style>

</head>
<body>
    <form id="form2" runat="server">
        <div class="page-content">
            <div class="page-header">
                <h1>
				    <small>
					    角色权限设置
				    </small>
			    </h1>
            </div>
            <div class="row show-grid">
                <div class="col-xs-12">
                    <div class="form-group">
					    <label class="col-sm-2 align-right control-label no-padding-right">当前角色</label>
					    <div class="col-sm-3">
                            <asp:Literal ID="litRoleName" runat="server"></asp:Literal>
					    </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">是否启用</label>
					    <div class="col-sm-3">
                            <asp:Literal ID="litIsUse" runat="server"></asp:Literal>
					    </div>
				    </div>
                </div>
                <asp:Repeater ID="rproleoperate" runat="server" OnItemDataBound="rproleoperate_ItemDataBound">
                    <ItemTemplate>
                                
                        <div class="col-xs-12">
                            <div class="form-group">
                                <label class="col-sm-2 align-right control-label no-padding-right"><%#Eval("MenuName") %></label>
                                <div class="col-sm-8">
                                    <asp:CheckBoxList ID="cboperate" runat="server" RepeatColumns="11" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                                </div>
                                </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="clearfix form-actions">
                <div class="col-md-offset-5 col-md-12">
                    <input id="Return" class="btn btn-sm btn-info" type="button" value="返回" onclick="window.location.href = 'RoleManage.aspx'" />
                    &nbsp;
                    <cc1:ZButton ID="ZButton1" runat="server" Text="修改" OnClick="ZButton1_Click" ModuleCode="RoleManage" Operate="分配权限" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>