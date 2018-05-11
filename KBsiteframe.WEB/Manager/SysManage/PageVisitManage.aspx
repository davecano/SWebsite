<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageVisitManage.aspx.cs" Inherits="KBsiteframe.WEB.Manager.SysManage.PageVisitManage" %>


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
         <link href="/css/style.css" rel="stylesheet" />
    <script  type="text/javascript" src="/js/AreaDropDown.js"></script>
    <script src="/assets/js/ace-extra.min.js"></script>


    <!--[if lt IE 9]>
		<script src="/assets/js/html5shiv.js"></script>
		<script src="/assets/js/respond.min.js"></script>
		<![endif]-->
    <script type="text/javascript" src="/js/jquery-1.11.3.min.js"></script>
	<script type="text/javascript" src="/js/My97DatePicker4.7.2/WdatePicker.js"></script>
	<script type="text/javascript" src="/js/layer/layer.min.js"></script>
    <script>
  
    </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="zbquery">
        <div class="panel panel-default">
            <div class="panel-body">
                    <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-1 align-right">页面名称</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtPageName" runat="server"/>
                        </div>
                              <label class="col-sm-1 align-right">浏览时间</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox runat="server" name="ExecuteDateStart" type="text" class="Wdate" ID="StarTime" onFocus="WdatePicker({maxDate:'#F{$dp.$D(\'StarTime\',{d:730});}',minDate:'#F{$dp.$D(\'StarTime\',{d:0});}',startDate:'#F{$dp.$D(\'StarTime\',{d:365});}',alwaysUseStartDate:true})" Width="70px"></asp:TextBox>
                        </div>
                     
                    </div>
                </div>
            </div>
            <div class="panel-footer align-center">
                <cc1:ZButton ID="zbquery" runat="server" Text="查询" OnClick="zbquery_OnClick" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table class="table table-striped table-bordered table-hover table-condensed" id="tlist">
                    <thead>
                        <tr class="table-header">
                            <th class="center">访问流水号</th>
                            <th class="center">访问IP</th>
                            <th class="center">访问时间</th>
                            <th class="center">页面名称</th>
                             <th class="center">点击量</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rplist" runat="server" >
                            <ItemTemplate>
                                <tr>
                                    <td class="center"><%#Eval("VDetailID") %></td>
                                    <td class="center"><%#Eval("IP") %></td>
                                   <td class="center"><%#$@"{Eval("VTime"):D}" %></td>
                                   <td class="center"><%#Eval("PageName") %></td>
                                       <td class="center"><%#Eval("Hits")??0 %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="pull-right">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_OnPageChanged">
            </webdiyer:AspNetPager>
        </div>
    </form>
</body>
</html>
