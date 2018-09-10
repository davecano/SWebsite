<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToolManage.aspx.cs" Inherits="KBsiteframe.WEB.Manager.ContentManage.ToolManage" %>

<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Z" TagPrefix="webdiyer" %>


<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>公告管理</title>
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
    <script type="text/javascript">
        //详情    
        $(document).ready(function () {
            $("#dptoolupload").change(function () {
                var type = $("#dptoolupload").get(0).selectedIndex;
                ShowIframeNotClose("ToolAttachUpload.aspx?ID=" + type);
            });
        });
        function enterView($button) {

            //ShowIframeNotClose("TicketView.aspx?ID=" + $button.attr("data-value"));
            //location.href = "UpdateEnterpriseOfQuali.aspx?CQID=" + $button.attr("data-value2");
            window.open("/Pub/ShowVideo.aspx?ID=" + $button.attr("data-value"));
            return false;
        }
    </script>
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
                        <label class="col-sm-1 align-right">名称</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
                        </div>
                      
                        <label class="col-sm-1 align-right">类型</label>
                        <div class="col-sm-2 align-left">
                            <asp:DropDownList ID="dpToolType" runat="server" />
                          
                        </div>
                    </div>
               
                </div>
            </div>
            <div class="panel-footer align-center">
                <cc1:ZButton ID="zbquery" runat="server" Text="查询" ModuleCode="ToolManage" OnClick="zbquery_OnClick" Operate="查询" CssClass="btn btn-sm btn-primary" />
                &nbsp;
                <cc1:ZButton ID="ZButton2" runat="server" Text="新增" ModuleCode="ToolManage" OnClick="ZButton2_OnClick" Operate="添加" CssClass="btn btn-sm btn-primary" />
                  &nbsp;
             <asp:DropDownList runat="server"  ID="dptoolupload" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table class="table table-striped table-bordered table-hover table-condensed" id="tlist">
                    <thead>
                        <tr class="table-header">
                            <th class="center col-sm-1">选</th>
                            
                            <th class="center">名称</th>
                              <th class="center">类型</th>
                      

                            <th class="center ">上传者</th>
                             <th class="center ">上传时间</th>
                               <th class="center ">详情</th>
                                <th class="center ">操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rplist" runat="server" OnItemCommand="rplist_OnItemCommand" OnItemDataBound="rplist_OnItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td class="center">
                                        <input type="checkbox" value='<%#Eval("ToolID") %>' id="cbselect" name="cbselect" onclick="Change(event, 'tlist');" runat="server" />
                                    </td>
                                 
                                  
                                       <td class="center" title='<%#Eval("ToolName") %>'>
                                           <%#Utils.CutString(Eval("ToolName") ,20)%>
                                       </td>
                                      <td class="center"><%#Eval("ToolType") %></td>
                                
                                    
                                    <td class="center"><%#String.Format(@"{0:D}", Eval("Uploader")) %></td>
                                      <td class="center"><%#String.Format(@"{0:D}", Eval("UploadTime")) %></td>
                                        <td class="center">
                                        <cc1:ZLinkButton ID="zlxz" CommandName="xz" runat="server" CommandArgument='<%#Eval("ToolID") %>' ModuleCode="ToolManage" Operate="下载" EnableTheming="False" CssClass="btn btn-info btn-sm">下载</cc1:ZLinkButton>
                                <%--         <cc1:ZLinkButton ID="zlbf" CommandName="bj" runat="server" CommandArgument='<%#Eval("ToolID") %>' ModuleCode="ToolManage" Operate="查询" CssClass="btn btn-inverse btn-sm">播放</cc1:ZLinkButton>--%>
                                         <cc1:ZButton ID="zbsub" runat="server" ModuleCode="ToolManage" Operate="查询" EnableTheming="False" CssClass="btn btn-inverse btn-sm" Text="播放" data-value='<%#Eval("ToolID") %>' OnClientClick="return enterView($(this))" />
                                    </td>
                                    <td class="center">
                                         <asp:HiddenField runat="server" ID="hftoolid" Value='<%#Eval("ToolID") %>' />
                                        <cc1:ZLinkButton ID="zlbj" CommandName="bj" runat="server" CommandArgument='<%#Eval("ToolID") %>' ModuleCode="ToolManage" Operate="修改" CssClass="btn btn-success btn-sm" EnableTheming="False">修改</cc1:ZLinkButton>
                                        <cc1:ZLinkButton ID="zlsc" CommandName="sc" runat="server" CommandArgument='<%#Eval("ToolID") %>' OnClientClick="return confirm('确定要删除吗？');" ModuleCode="ToolManage" EnableTheming="False" CssClass="btn btn-danger btn-sm" Operate="删除">删除</cc1:ZLinkButton>
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
