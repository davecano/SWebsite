
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="KBsiteframe.Web.Share.UserInfo" %>

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
    <script type="text/javascript">
        $(document).ready(function () {
            

        });
      
        function CheckForm() {
            var ret = true;

            if ($.trim($("#txtPhone").val()) == "") {
                layer.tips("请输入手机号码", $("#txtPhone"), { guide: 1, time: 3 });
                $("#txtPhone").focus();
                return false;
            }
            if (!$("#txtPhone").val().match(/^1[34578]\d{9}$/)) {
                //alert("手机号码格式不正确！");
                layer.tips("手机号码格式不正确", $("#txtPhone"), { guide: 1, time: 3 });
                //$("#moileMsg").html("<font color='red'>手机号码格式不正确！请重新输入！</font>"); 
                $("#txtPhone").focus();
                return false;
            }
            if ($.trim($("#txtMail").val()) == "") {
                layer.tips("请输入邮箱", $("#txtMail"), { guide: 1, time: 3 });
                $("#txtMail").focus();
                return false;
            }
            if (!$("#txtMail").val().match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/)) {
                //alert("邮箱格式不正确");
                layer.tips("邮箱格式不正确", $("#txtMail"), { guide: 1, time: 3 });
                //$("#confirmMsg").html("<font color='red'>邮箱格式不正确！请重新输入！</font>"); 
                $("#txtMail").focus();
                return false;
            }
            if ($.trim($("#txtUserLoginName").val()) == "") {
                layer.tips("请输入登录名", $("#txtUserLoginName"), { guide: 1, time: 3 });
                $("#txtUserLoginName").focus();
                return false;
            }
            if ($.trim($("#txtUserName").val()) == "") {
                layer.tips("请输入用户名称", $("#txtUserName"), { guide: 1, time: 3 });
                $("#txtUserName").focus();
                return false;
            }

     
            return ret;
        }
     

    </script>
    <style type="text/css">
        .show-grid [class ^="col-"] {
            padding-bottom: 5px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfID" runat="server" />
        <div class="page-content">
            <div class="page-header">
                <h1>
				    <small>
					    用户信息
				    </small>
			    </h1>
            </div>
            <div class="row show-grid">
                <div class="col-xs-12">
                    <div class="form-group">
					    <label class="col-sm-2 align-right control-label no-padding-right">登录帐号</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtUserLoginName" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal1" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
					    </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">用户名称</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtUserName" runat="server" Width="150px"></asp:TextBox>
                            <asp:Literal ID="Literal7" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
					    </div>
				    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">手机号码</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal2" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
					    </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">性别</label>
					    <div class="col-sm-3">
                            <asp:RadioButtonList ID="rbsex" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">男</asp:ListItem>
                                <asp:ListItem>女</asp:ListItem>
                            </asp:RadioButtonList>
					    </div>
				    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">电话号码</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
					    </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">电子邮箱</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal6" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
					    </div>
				    </div>
                </div>
               
            </div>
            <div class="clearfix form-actions">
                <div class="col-md-offset-5 col-md-12">
                    <input id="Return" class="btn btn-sm btn-info" type="button" value="返回" onclick="window.location.href = '/Share/right.aspx'" />
                    &nbsp;
                    <input id="Reset1" class="btn btn-sm btn-warning" type="reset" value="还原" />
                    &nbsp;
                    <cc1:ZButton ID="btnAdd" runat="server" Text="修改" OnClientClick="return CheckForm();" OnClick="btnAdd_Click" ModuleCode="UserManage" Operate="修改" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
