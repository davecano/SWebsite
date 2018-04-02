<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperateLog.aspx.cs" Inherits="KBsiteframe.Web.Manager.SysManage.OperateLog" %>

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
  
</head>
<body>
    <form id="form1" runat="server" defaultbutton="zbquery">
        <div class="panel panel-default">
   
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-1 align-right">日志类别：</label>
                        <div class="col-sm-3 align-left">
                           
                            <asp:DropDownList ID="dpLogType" runat="server"></asp:DropDownList>
                        </div>
                  <label class="col-sm-1 align-right">操作用户：</label>
                        <div class="col-sm-3 align-left">
                            <asp:TextBox ID="txtOperateUser" runat="server"></asp:TextBox>
                        </div>
                   
                     
                    </div>
                    <div class="form-group">
                        <label class="col-sm-1 align-right">操作时间</label>
                        <div class="col-sm-3 align-left">
                            <asp:TextBox ID="StarTime" class="Wdate" runat="server" name="ExeCuteDateStart" onFocus="var EndTime=$dp.$('EndTime'); WdatePicker({el:'StarTime',onpicked:function(){EndTime.focus();},vel:'EndTime', maxDate:'%y-%M-%d'})" Width="70px"></asp:TextBox>
                            至
                            <asp:TextBox runat="server" name="ExecuteDateEnd" type="text" class="Wdate" ID="EndTime" onFocus="WdatePicker({maxDate:'#F{$dp.$D(\'StarTime\',{d:730});}',minDate:'#F{$dp.$D(\'StarTime\',{d:0});}',startDate:'#F{$dp.$D(\'StarTime\',{d:365});}',alwaysUseStartDate:true})" Width="70px"></asp:TextBox>
                        </div>
                         
                         
                    
                    </div>
                </div>
            </div>
            <div class="panel-footer align-center">
                <cc1:ZButton ID="zbquery" runat="server" Text="查询" OnClick="zbquery_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table class="table table-striped table-bordered table-hover table-condensed" id="tlist">
                    <thead>
                        <tr class="table-header">
                            <th class="center">日志类别</th>
                        
                            <th class="center">操作用户</th>
                            <th class="center">操作时间</th>
                            <th class="center">日志操作类别</th>
                           
                            <th class="center">操作备注</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rplist" runat="server" OnItemCommand="rplist_OnItemCommand" >
                            <ItemTemplate>
                                <tr>
                                    <td class="center"><%#Eval("LogType") %></td>
                                   <%-- <td class="center"><%#Eval("LogObjectName") %></td>--%>
                                    <td class="center"><%#Eval("OperateUser") %></td>
                                    <td class="center"><%#string.Format("{0:f}",Eval("OperateDate")) %></td>
                                    <td class="center">
                                        <cc1:ZLinkButton ID="zlbView" runat="server" Text='<%#Eval("LogOperateType") %>' CommandArgument='<%#Eval("LogID") %>' CommandName="ck" ModuleCode="OperateLog" Operate="查看"/>
                                    </td>
                                   <%-- <td class="center"><%#Eval("LogBeforeObject") %></td>
                                     <td class="center"><%#Eval("LogAfterObject") %></td>--%>
                                     <td class="center"><%#Eval("LogRemark") %></td>
                                      
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