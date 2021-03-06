﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LMDynamicManage.aspx.cs" Inherits="KBsiteframe.WEB.Manager.ContentManage.LMDynamicManage" %>

<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Z" TagPrefix="webdiyer" %>


<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>联盟动态管理</title>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />
    <script type="text/javascript" src="/Ueditor/ueditor.config.js"></script>
    <script type="text/javascript" src="/Ueditor/ueditor.all.min.js"></script>
    <script type="text/javascript" src="/Ueditor/lang/zh-cn/zh-cn.js"></script>
    <link rel="stylesheet" href="/Ueditor/themes/default/dialogbase.css" />
    <link href="/Ueditor/themes/default/css/ueditor.css" rel="stylesheet" />
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

</head>
<body>
    <form id="form1" runat="server" defaultbutton="zbquery">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <%--   <label class="col-sm-1 align-right">所属栏目</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtClassName" runat="server"></asp:TextBox>
                        </div>--%>
                        <label class="col-sm-1 align-right">标题</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label class="col-sm-1 align-right">上传者</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label class="col-sm-1 align-right">发布时间</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox runat="server" name="ExecuteDateStart" type="text" class="Wdate" ID="StarTime" onFocus="WdatePicker({maxDate:'#F{$dp.$D(\'StarTime\',{d:730});}',minDate:'#F{$dp.$D(\'StarTime\',{d:0});}',startDate:'#F{$dp.$D(\'StarTime\',{d:365});}',alwaysUseStartDate:true})" Width="70px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">


                        <label class="col-sm-1 align-right">是否置顶</label>
                        <div class="col-sm-2 align-left">
                            <asp:DropDownList ID="dpIsTop" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">==请选择==</asp:ListItem>
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:DropDownList>

                            <%-- <asp:CheckBox ID="IsTop" runat="server" Text="显示" CssClass="ace" />--%>
                        </div>
                      
                    </div>
                </div>
            </div>
            <div class="panel-footer align-center">
                <cc1:ZButton ID="zbquery" runat="server" Text="查询" ModuleCode="LMDynamicManage" OnClick="zbquery_OnClick" Operate="查询" CssClass="btn btn-sm btn-primary" />
                &nbsp;
                <cc1:ZButton ID="ZButton2" runat="server" Text="新增" ModuleCode="LMDynamicManage" OnClick="ZButton2_OnClick" Operate="添加" CssClass="btn btn-sm btn-primary" />

                <%--   <cc1:ZButton ID="ZButton3" runat="server" Text="修改" OnClick="ZButton3_Click" ModuleCode="HospitalManage" Operate="修改" />--%>

                <%--<cc1:ZButton ID="ZButton4" runat="server" Text="删除" OnClientClick="return DeleteConfirm('tlist', '请选择需要删除的医院信息', '确定要删除吗？');" OnClick="ZButton4_Click" ModuleCode="NewsManage" Operate="删除"  EnableTheming="false"  class="btn btn-sm btn-danger" />--%>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table class="table table-striped table-bordered table-hover table-condensed" id="tlist">
                    <thead>
                        <tr class="table-header">
                            <th class="center col-sm-1">选</th>

                            <th class="center">标题</th>
                            <th class="center ">上传者</th>
                            <th class="center ">发布时间</th>

                            <th class="center ">是否置顶</th>
                             <th class="center ">浏览数</th>
                            <th class="center">修改</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rplist" runat="server" OnItemCommand="rplist_OnItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td class="center">
                                        <input type="checkbox" value='<%#Eval("DynamicID") %>' id="cbselect" name="cbselect" onclick="Change(event, 'tlist');" runat="server" />
                                    </td>
                                    <td class="center"><%#Eval("Title") %></td>
                                    <td class="center"><%#Eval("Uploader") %></td>


                                    <td class="center"><%#String.Format(@"{0:D}", Eval("SubTime")) %></td>
                                    <td class="center"><%#Utils.Istrue(Eval("IsTop"))%></td>
                                    <td class="center"><%#Eval("DynamicViews")??0 %></td>
                                    <td class="center">
                                        <cc1:ZLinkButton ID="zlbj" CommandName="bj" runat="server" CommandArgument='<%#Eval("DynamicID") %>' ModuleCode="LMDynamicManage" Operate="修改">修改</cc1:ZLinkButton>
                                        <cc1:ZLinkButton ID="zlsc" CommandName="sc" runat="server" CommandArgument='<%#Eval("DynamicID") %>' OnClientClick="return confirm('确定要删除吗？');" ModuleCode="LMDynamicManage" Operate="删除">删除</cc1:ZLinkButton>
                                    </td>
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
