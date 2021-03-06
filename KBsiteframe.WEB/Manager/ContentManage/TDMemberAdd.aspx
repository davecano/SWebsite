﻿<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="TDMemberAdd.aspx.cs" Inherits=" KBsiteframe.WEB.Manager.ContentManage.TDMemberAdd" %>

<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加团队成员</title>
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

            if ($.trim($("#txtMName").val()) == "") {
                layer.tips("请输入成员姓名", $("#txtMName"), { guide: 1, time: 3 });
                $("#txtMName").focus();
                return false;
            }
        
            //if ($.trim($("#txtPhone").val()) == "") {
            //    layer.tips("请输入手机号码", $("#txtPhone"), { guide: 1, time: 3 });
            //    $("#txtPhone").focus();
            //    return false;
            //}
            if ($.trim($("#txtPhone").val()) != ""&&!$("#txtPhone").val().match(/^1[34578]\d{9}$/)) {
                //alert("手机号码格式不正确！");
                layer.tips("手机号码格式不正确", $("#txtPhone"), { guide: 1, time: 3 });
                //$("#moileMsg").html("<font color='red'>手机号码格式不正确！请重新输入！</font>"); 
                $("#txtPhone").focus();
                return false;
            }
            if ($.trim($("#txtMail").val()) == "") {
                layer.tips("请输入邮箱", $("#txtMail"), { guide: 1, time: 3 });
                $("#txtMail").focus();
                return false;
            }
            if (!$("#txtMail").val().match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/)) {
                //alert("邮箱格式不正确");
                layer.tips("邮箱格式不正确", $("#txtMail"), { guide: 1, time: 3 });
                //$("#confirmMsg").html("<font color='red'>邮箱格式不正确！请重新输入！</font>"); 
                $("#txtMail").focus();
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
                    <small>添加团队成员
                    </small>
                </h1>
            </div>
            <div class="row show-grid">
                   <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">成员图片</label>
                        <div class="col-sm-3">
                            <asp:Image ID="ImgNews" runat="server" ImageUrl="~/images/nopic.gif" Width="160" Height="150" />

                        </div>

                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">


                        <div class="col-sm-3 col-sm-offset-2">
                            <asp:FileUpload ID="pic_upload" runat="server" onchange="onFileChange(this);" /><asp:Label ID="lbl_pic" runat="server" Style="color: red">上传图片格式为.jpg, .gif, .bmp,.png,图片大小不得超过8M</asp:Label>
                        </div>

                    </div>
                </div>
     <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">成员姓名</label>
                        <div class="col-sm-3">
                       <asp:TextBox runat="server" ID="txtMName"></asp:TextBox>
                            <asp:Literal ID="Literal7" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                          <label class="col-sm-2 align-right control-label no-padding-right">学历</label>
                        <div class="col-sm-3">
                          <asp:TextBox runat="server" ID="txtQualification"></asp:TextBox>
                        </div>
                      
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">电话</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                         <%--   <asp:Literal ID="Literal5" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>--%>
                        </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">Email</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal1" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right  control-label no-padding-right">所在机构</label>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" ID="ttxOrgName"></asp:TextBox>
                          <%--  <asp:Literal ID="Literal2" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>--%>
                        </div>
                       
                    </div>
                </div>


               
            
      

            </div>
            <div class="clearfix form-actions">
                <div class="col-md-offset-5 col-md-12">
                    <input id="Return" class="btn btn-sm btn-info" type="button" value="返回" onclick="window.location.href = 'TDMemberManage.aspx'" />
                    &nbsp;
                    <input id="Reset1" class="btn btn-sm btn-warning" type="reset" value="清空" />
                    &nbsp;
                    <cc1:ZButton ID="btnAdd" runat="server" CssClass="btn btn-sm btn-primary" Text="添加" OnClientClick="return CheckForm();" OnClick="btnAdd_OnClick" ModuleCode="TDMemberManage" Operate="添加" />
                    &nbsp;
                   
                </div>
            </div>
        </div>
    </form>
</body>
</html>
