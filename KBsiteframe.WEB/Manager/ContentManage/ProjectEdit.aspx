<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ProjectEdit.aspx.cs" Inherits=" KBsiteframe.WEB.Manager.ContentManage.ProjectEdit" %>

<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改项目</title>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
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

    <style type="text/css">
        .show-grid [class ^="col-"] {
            padding-bottom: 5px;
        }
    </style>
    <script type="text/javascript">
        function onFileChange(sender) {
            document.getElementById("ImgNews").src = window.URL.createObjectURL(sender.files[0]);

        }
        function CheckForm() {
            var ret = true;

            if ($.trim($("#DpProjectPeriod").val()) == "") {
                layer.tips("请输入项目阶段", $("#DpProjectPeriod"), { guide: 1, time: 3 });
                $("#DpProjectPeriod").focus();
                return false;
            }
        
            if ($.trim($("#txtName").val()) == "") {
                layer.tips("请输入项目名称", $("#txtName"), { guide: 1, time: 3 });
                $("#txtName").focus();
                return false;
            }
            if ($.trim($("#txtOrgName").val()) == "") {
                layer.tips("请输入所属机构名称", $("#txtOrgName"), { guide: 1, time: 3 });
                $("#txtOrgName").focus();
                return false;
            }
            
            if ($.trim($("#StarTime").val()) == "") {
                layer.tips("请选择开始时间", $("#StarTime"), { guide: 1, time: 3 });
                $("#StarTime").focus();
                return false;
            }
            if ($.trim($("#EndTime").val()) == "") {
                layer.tips("请选择结束时间", $("#EndTime"), { guide: 1, time: 3 });
                $("#EndTime").focus();
                return false;
            }
            

            if ($.trim($("#txtContent").val()) == "") {
                layer.tips("请输入项目内容", $("#txtContent"), { guide: 1, time: 3 });
                $("#txtContent").focus();
                return false;
            }
       

            return ret;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-content">
            <div class="page-header">
                <h1>
                    <small>修改项目
                    </small>
                </h1>
            </div>
            <div class="row show-grid">
                <asp:HiddenField runat="server" ID="hfProjectID"/>
     <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">项目阶段</label>
                        <div class="col-sm-3">
                          <asp:DropDownList runat="server" ID="DpProjectPeriod"/>
                            <asp:Literal ID="Literal7" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                          <label class="col-sm-2 align-right control-label no-padding-right">所属专家</label>
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" ID="dpExpert" />
                        </div>
                      
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">项目名称</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal5" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">所属机构</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtOrgName" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal1" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right  control-label no-padding-right">开始时间</label>
                        <div class="col-sm-3">
                              <asp:TextBox ID="StarTime" Width="120px" class="Wdate" runat="server" name="ExeCuteDateStart" onFocus="var EndTime=$dp.$('EndTime'); WdatePicker({el:'StarTime',onpicked:function(){EndTime.focus();},vel:'EndTime', maxDate:'%y-%M-%d'})" CssClass="form-control"></asp:TextBox>
                            <asp:Literal ID="Literal2" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">结束时间</label>
                        <div class="col-sm-3">
                           <asp:TextBox runat="server" name="ExecuteDateEnd" type="text" Width="120px" class="Wdate" ID="EndTime" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StarTime\',{d:0});}',startDate:'#F{$dp.$D(\'StarTime\',{d:365});}',alwaysUseStartDate:true})" CssClass="form-control"></asp:TextBox>
                            <asp:Literal ID="Literal3" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                    </div>
                </div>


                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">项目内容</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="600px" Height="200px"></asp:TextBox>
                            <asp:Literal ID="Literal4" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>

                    </div>
                </div>
            
        
                <div class="col-xs-12">
                    <div class="form-group">
                     
                        <label class="col-sm-2 align-right control-label no-padding-right">联盟成员</label>
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" ID="dpLm" />
                        </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">团队成员</label>
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" ID="dpTd" />
                        </div>
                    </div>

                </div>

            </div>
            <div class="clearfix form-actions">
                <div class="col-md-offset-5 col-md-12">
                    <input id="Return" class="btn btn-sm btn-info" type="button" value="返回" onclick="window.location.href = 'ProjectManage.aspx'" />
                    &nbsp;
                    <input id="Reset1" class="btn btn-sm btn-warning" type="reset" value="清空" />
                    &nbsp;
                    <cc1:ZButton ID="btnAdd" runat="server" CssClass="btn btn-sm btn-primary" Text="修改" OnClientClick="return CheckForm();" OnClick="btnAdd_OnClick" ModuleCode="ProjectManage" Operate="修改" />
                    &nbsp;
                   
                </div>
            </div>
        </div>
    </form>
</body>
</html>
