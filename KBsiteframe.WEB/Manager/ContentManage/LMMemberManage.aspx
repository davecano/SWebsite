<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LMMemberManage.aspx.cs" Inherits="KBsiteframe.WEB.Manager.ContentManage.LMMemberManage" %>


<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Z" TagPrefix="webdiyer" %>


<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>团队成员管理</title>
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
                    
                        <label class="col-sm-1 align-right">成员姓名</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </div>
                        <label class="col-sm-1 align-right">电话</label>
                        <div class="col-sm-2 align-left">
                       <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                         
                        </div>
                      
                        <label class="col-sm-1 align-right">Email</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-1 align-right control-label no-padding-right">学历</label>
                        <div class="col-sm-2">
                         <asp:TextBox runat="server" ID="txtQualification"></asp:TextBox>
                        </div>
                        <label class="col-sm-1 align-right control-label no-padding-right">所属机构</label>
                        <div class="col-sm-2">
                      <asp:TextBox runat="server" ID="txtOrganization"></asp:TextBox>
                        </div>
                      

                    </div>
              
                </div>
            </div>
            <div class="panel-footer align-center">
                <cc1:ZButton ID="zbquery" runat="server" Text="查询" ModuleCode="TDMemberManage" OnClick="zbquery_OnClick" Operate="查询" CssClass="btn btn-sm btn-primary" />
                &nbsp;
                <cc1:ZButton ID="ZButton2" runat="server" Text="新增" ModuleCode="TDMemberManage" OnClick="ZButton2_OnClick" Operate="添加" CssClass="btn btn-sm btn-primary" />

            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table class="table table-striped table-bordered table-hover table-condensed" id="tlist">
                    <thead>
                        <tr class="table-header">
                            <th class="center col-sm-1">选</th>

                            <th class="center">成员姓名</th>

                            <th class="center ">电话</th>

                            <th class="center ">Email</th>
                            <th class="center ">学历</th>
                            <th class="center">所属机构</th>
                           
                          
                            <th class="center">操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rplist" runat="server" OnItemCommand="rplist_OnItemCommand">
                            <ItemTemplate>
                                 <tr >
                                    <td class="center">
                                        <input type="checkbox" value='<%#Eval("MemberID") %>' id="cbselect" name="cbselect" onclick="Change(event, 'tlist');" runat="server" />
                                    </td>
                                    <td class="center"><%#Eval("MemberName") %></td>
                                            <td class="center"><%#Eval("Phone") %></td>
                                            <td class="center"><%#Eval("Email")%></td>
                                      <td class="center"><%#Eval("Qualification") %></td>
                                            <td class="center"><%#Eval("Organization")%></td>
                                 
                                    <td class="center">
                                        <cc1:ZLinkButton ID="zlbj" CommandName="bj" runat="server" CommandArgument='<%#Eval("MemberID") %>' ModuleCode="TDMemberManage" Operate="修改" CssClass="btn btn-primary btn-sm">修改</cc1:ZLinkButton>
                                        <cc1:ZLinkButton ID="zlsc" CommandName="sc" runat="server" CommandArgument='<%#Eval("MemberID") %>' OnClientClick="return confirm('确定要删除吗？');" ModuleCode="TDMemberManage" Operate="删除" CssClass="btn btn-danger btn-sm">删除</cc1:ZLinkButton>
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
