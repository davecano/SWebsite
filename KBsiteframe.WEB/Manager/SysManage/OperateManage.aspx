<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperateManage.aspx.cs" Inherits="KBsiteframe.Web.Manager.SysManage.OperateManage" %>
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
            $("#Nav", parent.document).html("操作管理");
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
					    设置操作
				    </small>
			    </h1>
            </div>
            <div class="row show-grid">
                <div class="col-xs-12">
                    <div class="form-group">
					    <label class="col-sm-2 align-right control-label no-padding-right">当前菜单项</label>
					    <div class="col-sm-3">
                            <asp:Literal ID="litMenuName" runat="server"></asp:Literal>
					    </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">模块代码</label>
					    <div class="col-sm-3">
                            <asp:Literal ID="litModuleCode" runat="server"></asp:Literal>
					    </div>
				    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">操作权限</label>
				    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right"></label>
					    <div class="col-sm-8">
                            <asp:Repeater ID="rpoperate" runat="server">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cboperate" runat="server" Checked='<%#BindIsCan(Eval("IsCan").ToString()) %>' Text='<%#Eval("OperateName") %>' CssClass="ace"/>
                                    &nbsp;
                                </ItemTemplate>
                            </asp:Repeater>
					    </div>
				    </div>
                </div>
            </div>
            <div class="clearfix form-actions">
                <div class="col-md-offset-5 col-md-12">
                    <input id="Return" class="btn btn-sm btn-info" type="button" value="返回" onclick="window.location.href = 'MenuManage.aspx'" />
                    &nbsp;
                    <cc1:ZButton ID="zbupdate" runat="server" Text="修改" OnClick="zbupdate_Click" ModuleCode="MenuManage" Operate="分配权限" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>