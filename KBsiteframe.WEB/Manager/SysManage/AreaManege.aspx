<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaManege.aspx.cs" Inherits="KBsiteframe.Web.Manager.SysManage.AreaManege" %>

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
        var page = 1;
        $(document).ready(function () {

            $("#txtAreaName").on('input', function () {
                //$("#txtAreaName").oninput(function () {
         

                ChangeCoords();

                Load(); //加载数据
                OninputPagination(); //加载分页信息  
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
                        <label class="col-sm-1 align-right">省级/市级/自治区：</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtAreaName" runat="server"></asp:TextBox>
                                                <div id="searchresult" style="display: none">
                       <table cellpadding='2' cellspacing='0' class="areatable">

 <tbody id="nr">

 </tbody> 
</table>
   <ul class="pagination" id="pagination" style="margin: 0 auto;text-align: center">  
        </ul> 
  </div>
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
                            <th class="center">地区编号</th>
                            <th class="center">地区名称</th>
                            <th class="center">地区简称</th>
                            <th class="center">地区级别</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rplist" runat="server" >
                            <ItemTemplate>
                                <tr>
                                    <td class="center"><%#Eval("AreaID") %></td>
                                    <td class="center"><%#Eval("AreaName") %></td>
                                    <td class="center"><%#Eval("AreaNameJc") %></td>
                                    <td class="center"><%#Eval("AreaID").ToString() == Eval("ParentAreaID").ToString() ? "省级/自治区":"市级" %></td>
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
