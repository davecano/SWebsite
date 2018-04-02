<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperateLogView.aspx.cs" Inherits="KBsiteframe.Web.Manager.SysManage.OperateLogView" %>
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
 <link href="/css/style.css" rel="stylesheet" />
    <script  type="text/javascript" src="/js/AreaDropDown.js"></script>
    <script src="/assets/js/ace-extra.min.js"></script>


    <!--[if lt IE 9]>
		<script src="/assets/js/html5shiv.js"></script>
		<script src="/assets/js/respond.min.js"></script>
		<![endif]-->
    <link rel="stylesheet" href="/css/custom.css" />
    <script type="text/javascript" src="/js/jquery-1.11.3.min.js"></script>
	<script type="text/javascript" src="/js/My97DatePicker4.7.2/WdatePicker.js"></script>
	<script type="text/javascript" src="/js/layer/layer.min.js"></script>
    <script type="text/javascript" src="/js/jquery.MultiFile.js"></script>
    <script type="text/javascript" src="/js/Common.js"></script>
    <script type="text/javascript">
   
    </script>
    <style type="text/css">
        .show-grid [class ^="col-"] {
            padding-bottom: 5px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <asp:HiddenField ID="hfID" runat="server" />
        <div class="page-content">
            <div class="page-header">
                <h1>
				    <small>
					   日志查看详情
				    </small>
			    </h1>
            </div>
            <div class="row show-grid">
                <div class="col-xs-12">
                    <div class="form-group">
					    <label class="col-sm-2 align-right control-label no-padding-right">日志类型 </label>
					    <div class="col-sm-3">
                            <asp:HiddenField ID="HfLogID" runat="server" />
                            <asp:Literal ID="ltLogType" runat="server" ></asp:Literal>
					    </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">操作人员 </label>
					    <div class="col-sm-3">
                       <asp:Literal ID="ltOperateUser" runat="server" ></asp:Literal>
					    </div>
				    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">用户操作类型 </label>
					    <div class="col-sm-3">
                             <asp:Literal ID="ltLogOperateType" runat="server" ></asp:Literal>
					    </div>
                   
				    </div>
                </div>
                 <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">日志操作前对象</label>
					    <div class="col-sm-10">
                            <asp:Literal ID="ltLogBeforeObject" runat="server"  ></asp:Literal>
					    </div>
				    </div>
                </div>
             <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">日志操作后对象</label>
					    <div class="col-sm-10">
                            <asp:Literal ID="ltLogAfterObject" runat="server"></asp:Literal>
					    </div>
				    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">操作备注</label>
					    <div class="col-sm-10">
                              <asp:Literal ID="ltLogRemark" runat="server"  ></asp:Literal>
					    </div>
				    </div>
                </div>
              
            </div>
            <div class="clearfix form-actions">
                <div class="col-md-offset-5 col-md-12">
                    <input id="Return" class="btn btn-sm btn-info" type="button" value="返回" onclick="window.location.href = 'OperateLog.aspx'" />
                  
                </div>
            </div>
        </div>
    </form>
</body>
</html>
