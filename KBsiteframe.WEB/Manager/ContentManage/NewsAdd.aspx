<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="NewsAdd.aspx.cs" Inherits="KBsiteframe.Web.Manager.ContentManage.NewsAdd" %>

<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
        <script type="text/javascript" src="/js/Common.js"></script>
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

       
            if ($.trim($("#txtTitle").val()) == "") {
                layer.tips("请输入新闻标题", $("#txtTitle"), { guide: 1, time: 3 });
                $("#txtTitle").focus();
                ret= false;
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
                    <small>发布新闻
                    </small>
                </h1>
            </div>
            <div class="row show-grid">

                <div class="col-xs-12">
                    <%--     <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">所属栏目</label>
					    <div class="col-sm-3">
                           <asp:DropDownList ID="DpClass" runat="server"></asp:DropDownList>
					    </div>                   
				    </div>--%>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">新闻标题</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                            <label class="col-sm-1 align-right control-label no-padding-right">静态类别（知识建构）</label>
                        <div class="col-sm-3">
                       <asp:DropDownList runat="server" ID="dpstatictype"/>
                           
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">新闻图片</label>
                        <div class="col-sm-3">
                            <asp:Image ID="ImgNews" runat="server" ImageUrl="~/images/nopic.gif" Width="160" Height="150" />

                        </div>

                    </div>
                    <div class="col-xs-12">
                        <div class="form-group">


                            <div class="col-sm-3 col-sm-offset-2">
                                <asp:FileUpload ID="pic_upload" runat="server" onchange="onFileChange(this);" /><asp:Label ID="lbl_pic" runat="server" Style="color: red">上传图片格式为.jpg, .gif, .bmp,.png,图片大小不得超过8M</asp:Label>
                            </div>

                        </div>
                    </div>


                </div>
                <div class="col-xs-12">
                    <label class="col-sm-1 align-right control-label no-padding-right">是否置顶</label>
                    <div class="col-sm-3 checkbox">
                        <asp:CheckBox ID="CbIstop" runat="server" />
                    </div>
                    <label class="col-sm-1 align-right control-label no-padding-right">是否热门</label>
                    <div class="col-sm-3 checkbox">
                        <asp:CheckBox ID="CbIsHot" runat="server" />
                    </div>
                         <label class="col-sm-1 align-right control-label no-padding-right">类别</label>
                        <div class="col-sm-3">
                       <asp:DropDownList runat="server" ID="dpNewstype"/>
                           
                        </div>
                </div>
                   <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">新闻简介(用于前台展示)</label>
					    <div class="col-sm-8">
                            <asp:TextBox ID="txtsummary" runat="server" TextMode="MultiLine"  Width="100%" Height="200px"></asp:TextBox>
					    </div>
                       
				    </div>
                </div>
                <%--    <div class="col-xs-12">
                    <div class="form-group">
                     
                            
					   <div class="col-sm-3 col-sm-offset-2">
                            <asp:FileUpload ID="pic_upload" runat="server" onchange="onFileChange(this);" /><asp:Label ID="lbl_pic" runat="server">上传图片格式为.jpg, .gif, .bmp,.png,图片大小不得超过8M</asp:Label>
					    </div>
                       
				    </div>
                </div>--%>
                <div class="col-xs-12">
                    <%--  <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">新闻内容</label>
					    <div class="col-sm-8">
                         <CKEditor:CKEditorControl ID="ckNewsContent" BasePath="~/ckeditor" runat="server"></CKEditor:CKEditorControl>
					    </div>
				    </div>--%>
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">新闻内容</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="container" runat="server" TextMode="MultiLine" Width="100%" Height="400px" name="container" ClientIDMode="Static"></asp:TextBox>
                            <script type="text/javascript">
                                var ue = UE.getEditor('container');

                            </script>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">

                        <label class="col-sm-2 align-right control-label no-padding-right">作者</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtauthor" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>


            </div>
            <div class="clearfix form-actions">
                <div class="col-md-offset-5 col-md-12">
                    <input id="Return" class="btn btn-sm btn-info" type="button" value="返回" onclick="window.location.href = 'NewsManage.aspx'" />
                    &nbsp;
                    <input id="Reset1" class="btn btn-sm btn-warning" type="reset" value="清空" />
                    &nbsp;
                    <cc1:ZButton ID="btnAdd" runat="server" Text="添加"  OnClientClick="return CheckForm();"   OnClick="btnAdd_OnClick" ModuleCode="NewsManage" Operate="添加" />
            
                    &nbsp;
                <%--   <asp:PlaceHolder ID="PHMsg" runat="server"></asp:PlaceHolder>--%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
