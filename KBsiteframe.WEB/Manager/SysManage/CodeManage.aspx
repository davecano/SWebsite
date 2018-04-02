<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodeManage.aspx.cs" Inherits="KBsiteframe.Web.Manager.SysManage.CodeManage" %>

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

    <script src="/assets/js/ace-extra.min.js"></script>


    <!--[if lt IE 9]>
		<script src="/assets/js/html5shiv.js"></script>
		<script src="/assets/js/respond.min.js"></script>
		<![endif]-->
    <script type="text/javascript" src="/js/jquery-1.11.3.min.js"></script>
	<script type="text/javascript" src="/js/My97DatePicker4.7.2/WdatePicker.js"></script>
	<script type="text/javascript" src="/js/layer/layer.min.js"></script>
    <script type="text/javascript" src="/js/Common.js"></script>
    <script>
        $(document).ready(function () {
            $("#ZButton2").click(function () {
                ShowIframe("添加字典信息", "CodeAdd.aspx", '780px', '500px');
                return false;
            });
            $("#ZButton3").click(function () {
                UpdateConfirm('tlist', '请选择需要修改的字典信息', "修改字典信息", "CodeUpdate.aspx?ID=", '780px', '500px');
                return false;
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
                        <label class="col-sm-1 align-right">字典名称</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtCodeName" runat="server"/>
                        </div>
                        <label class="col-sm-1 align-right">字典文本</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtCodeText" runat="server"/>
                        </div>
                        <label class="col-sm-1 align-right">字典值</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtCodeValue" runat="server"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer align-center">
                <cc1:ZButton ID="zbquery" runat="server" Text="查询" OnClick="zbquery_Click" ModuleCode="CodeManage" Operate="查询" />
                &nbsp;
                <cc1:ZButton ID="ZButton2" runat="server" Text="新增" ModuleCode="CodeManage" Operate="添加" />
                &nbsp;
                <cc1:ZButton ID="ZButton3" runat="server" Text="修改" ModuleCode="CodeManage" Operate="修改" />
                &nbsp;
                <cc1:ZButton ID="ZButton4" runat="server" Text="删除" OnClientClick="return confirm('确实要删除吗?');" OnClick="ZButton4_Click" ModuleCode="CodeManage" Operate="删除"  EnableTheming="false"  class="btn btn-sm btn-danger" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table class="table table-striped table-bordered table-hover table-condensed" id="tlist">
                    <thead>
                        <tr class="table-header">
                            <th class="center">选</th>
                            <th class="center">字典名称</th>
                            <th class="center">字典文本</th>
                            <th class="center">字典值</th>
                            <th class="center">排序号</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rplist" runat="server" >
                            <ItemTemplate>
                                <tr>
                                    <td class="center">
                                        <input type="checkbox" value='<%#Eval("CodeID") %>' id="cbselect" name="cbselect" onclick="Change(event, 'tlist');" runat="server" />
                                    </td>
                                    <td class="center"><%#Eval("CodeName") %></td>
                                    <td class="center"><%#Eval("CodeText") %></td>
                                    <td class="center"><%#Eval("CodeValue") %></td>
                                    <td class="center"><%#Eval("SortNo") %></td>
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
