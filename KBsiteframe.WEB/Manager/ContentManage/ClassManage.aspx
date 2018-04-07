<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassManage.aspx.cs" Inherits="MyCmsWEB.Content.ClassManage" %>
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
    <script>
        function checkform() {
        
            if ($.trim($("#txtClassName").val()) == "") {
                layer.tips("请输入栏目名称", $("#txtClassName"), { guide: 1, time: 3 });
                $("#txtClassName").focus();
             return false;
            }
            if ($.trim($("#txtParentClassID").val()) == "") {
                layer.tips("请输入父栏目", $("#txtParentClassID"), { guide: 1, time: 3 });
                $("#txtParentClassID").focus();
               return false;
            }
            if ($.trim($("#txtClassSort").val()) == "") {
                layer.tips("请输入排序号", $("#txtClassSort"), { guide: 1, time: 3 });
                $("#txtClassSort").focus();
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                         <%--<label class="col-sm-1 align-right">栏目ID</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtModuleCode" runat="server"/>
                        </div>--%>
                        <label class="col-sm-1 align-right">栏目名称</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtClassName" runat="server"/>
                        </div>
                       
                        <label class="col-sm-1 align-right">父栏目</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtParentClassID" runat="server"/>
                        </div>
                          <div class="form-group">
                        <label class="col-sm-1 align-right">排序号</label>
                        <div class="col-sm-2 align-left">
                            <asp:TextBox ID="txtClassSort" runat="server"/>
                        </div>
                    </div>
                  
                        <label class="col-sm-2 align-right">导航栏显示</label>
                        <div class="col-sm-1 align-left">
                         <asp:CheckBox ID="CheckboxNav" runat="server" Text="显示" CssClass="ace" />
                        </div>
                           <label class="col-sm-2 align-right">首页显示</label>
                        <div class="col-sm-1 align-left">
                         <asp:CheckBox ID="CheckboxIndex" runat="server" Text="显示" CssClass="ace" />
                        </div>
                               <label class="col-sm-2 align-right">是否禁用</label>
                        <div class="col-sm-1 align-left">
                         <asp:CheckBox ID="CheckIsforbidden" runat="server" Text="禁用" CssClass="ace" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer align-center">
                <cc1:ZButton ID="ZButton1" runat="server" Text="添加" OnClientClick="return checkform();" OnClick="ZButton1_OnClick" ModuleCode="ClassManage" Operate="添加" CssClass="btn btn-sm btn-primary"  />
                &nbsp;
               <%-- <cc1:ZButton ID="ZButton2" runat="server" Text="修改"  OnClick="ZButton2_OnClick"ModuleCode="MenuManage" Operate="修改" />--%>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <table class="table table-striped table-bordered table-hover table-condensed">
                    <thead>
                        <tr class="table-header">
                            <th class="hidden-xs center">栏目ID</th>
                         
                            <th class="center">栏目名称</th>
                            <th class="center hidden-xs">父栏目</th>
                            <th class="center hidden-xs">排序号</th>
                            <th class="center hidden-xs">导航栏显示</th>
                            <th class="center hidden-xs">首页显示</th>
                            <th class="center">是否禁用</th>
                            <th class="center">删除</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpmenu" runat="server" OnItemCommand="rpmenu_OnItemCommand" OnItemDataBound="rpmenu_OnItemDataBound" >
                            <ItemTemplate>
                                <asp:Panel ID="PlItem" runat="server">
                                  <tr>
                                    <td class="center hidden-xs"><%#Eval("Id") %></td>
                                    <td class="center">
                                     <%#Eval("ClassName") %>
                                    </td>
                                    <td class="center hidden-xs">
                                       <%#Eval("ParentId") %>
                                    </td>
                                
                                    <td class="center hidden-xs">
                                     <%#Eval("SortRank") %>
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:CheckBox ID="cIsOnNav" runat="server" Enabled="False" Checked='<%#(bool)Eval("IsOnNav") %>' />
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:CheckBox ID="cIsOnIndex" runat="server" Enabled="False" Checked='<%#(bool)Eval("IsOnIndex") %>' />
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:TextBox ID="tIsForbidden" runat="server" Enabled="False" Width="80" Text='<%#(bool)Eval("IsForbidden") %>'></asp:TextBox>
                                    </td>
                                 
                                    <td class="center">
                                        <cc1:ZLinkButton ID="zlbj" CommandName="bj"  runat="server" CommandArgument='<%#Eval("Id") %>' ModuleCode="ClassManage" Operate="修改">修改</cc1:ZLinkButton>
                                        <cc1:ZLinkButton ID="zlsc" CommandName="sc" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('确定要删除吗');" runat="server" ModuleCode="MenuManage" Operate="删除">删除</cc1:ZLinkButton>
                                      <%--  <cc1:ZButton ID="ZButton2" runat="server" Text="修改"  OnClick="ZButton2_OnClick"ModuleCode="MenuManage" Operate="修改" />--%>
                                    </td>
                                </tr>   
                                </asp:Panel>
                                 <asp:Panel ID="PlEdit" runat="server">
                                  <tr>
                                    <td class="center hidden-xs"><%#Eval("Id") %></td>
                                    <td class="center">
                                        <asp:TextBox ID="TextBox1" runat="server" Width="100" Text='<%#Eval("ClassName") %>'></asp:TextBox>
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:TextBox ID="TextBox2" runat="server" Width="290" Text='<%#Eval("ParentId") %>'></asp:TextBox>
                                    </td>
                                
                                    <td class="center hidden-xs">
                                        <asp:TextBox ID="TextBox3" runat="server" Width="25" Text='<%#Eval("SortRank") %>'></asp:TextBox>
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#(bool)Eval("IsOnNav") %>' />
                                    </td>
                                    <td class="center hidden-xs">
                                        <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%#(bool)Eval("IsOnIndex") %>' />
                                    </td>
                                    <td class="center hidden-xs">
                                       
                                          <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%#(bool)Eval("IsForbidden") %>' />
                                    </td>
                                 
                                    <td class="center">
                                        <cc1:ZLinkButton ID="zlqx" CommandName="qx"  runat="server" ModuleCode="ClassManage" Operate="设置">取消</cc1:ZLinkButton>
                                        <cc1:ZLinkButton ID="zlqd" CommandName="qd" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('确定要更新吗');" runat="server" ModuleCode="ClassManage" Operate="修改">确定</cc1:ZLinkButton>
                                      <%--  <cc1:ZButton ID="ZButton2" runat="server" Text="修改"  OnClick="ZButton2_OnClick"ModuleCode="MenuManage" Operate="修改" />--%>
                                    </td>
                                </tr>   
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

