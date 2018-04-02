<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodeUpdate.aspx.cs" Inherits="KBsiteframe.Web.Manager.SysManage.CodeUpdate" %>

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
    <script src="../../js/Common.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            

        });
        function CheckForm() {
            var ret = true;
            if ($.trim($("#txtCodeName").val()) == "") {
                layer.tips("请输入字典名称", $("#txtCodeName"), { guide: 1, time: 3 });
                $("#txtCodeName").focus();
                return false;
            }
            if ($.trim($("#txtCodeText").val()) == "") {
                layer.tips("请输入字典文本", $("#txtCodeText"), { guide: 1, time: 3 });
                $("#txtCodeText").focus();
                return false;
            }
            if ($.trim($("#txtCodeValue").val()) == "") {
                layer.tips("请输入字典值", $("#txtCodeValue"), { guide: 1, time: 3 });
                $("#txtCodeValue").focus();
                return false;
            }
            if ($.trim($("#txtSortNo").val()) == "") {
                layer.tips("请输入排序号", $("#txtSortNo"), { guide: 1, time: 3 });
                $("#txtSortNo").focus();
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
        <asp:HiddenField ID="hfCodeID" runat="server" />
        <div class="page-content">
            <div class="page-header">
                <h1>
				    <small>
					    字典信息
				    </small>
			    </h1>
            </div>
            <div class="row show-grid">
                <div class="col-xs-12">
                    <div class="form-group">
					    <label class="col-sm-2 align-right control-label no-padding-right">字典名称</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtCodeName" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal1" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
					    </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">字典文本</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtCodeText" runat="server" Width="150px"></asp:TextBox>
                            <asp:Literal ID="Literal2" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
					    </div>
				    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">字典值</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtCodeValue" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal3" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
					    </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">排序号</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtSortNo" runat="server"/>
                            <asp:Literal ID="Literal4" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
					    </div>
				    </div>
                </div>
            </div>
            <div class="clearfix form-actions">
                <div class="center">
                    <input id="Reset1" class="btn btn-sm btn-warning" type="reset" value="还原" />
                    &nbsp;
                    <cc1:ZButton ID="btnAdd" runat="server" Text="修改" OnClientClick="return CheckForm();" OnClick="btnAdd_Click" ModuleCode="CodeManage" Operate="修改" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
