<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleEdit.aspx.cs" Inherits="KBsiteframe.WEB.Manager.ContentManage.ArticleEdit" %>


<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改文章</title>
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
    <link rel="stylesheet" href="/css/custom.css" />
    <script type="text/javascript" src="/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="/js/My97DatePicker4.7.2/WdatePicker.js"></script>
    <script type="text/javascript" src="/js/layer/layer.min.js"></script>
    <script type="text/javascript" src="/js/jquery.MultiFile.js"></script>
    <script type="text/javascript" src="/js/Common.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {


        });

        function CheckForm() {
            var ret = true;
            if ($.trim($("#dpArticleType").val()) == "") {
                layer.tips("请选择文章类型", $("#dpArticleType"), { guide: 1, time: 3 });
                $("#dpArticleType").focus();
                return false;
            }
            if ($.trim($("#txtArticleTitle").val()) == "") {
                layer.tips("请输入文章标题", $("#txtArticleTitle"), { guide: 1, time: 3 });
                $("#txtArticleTitle").focus();
                return false;
            }
            if ($.trim($("#txtKryword").val()) == "") {
                layer.tips("请输入关键词", $("#txtKryword"), { guide: 1, time: 3 });
                $("#txtKryword").focus();
                return false;
            }
            if ($.trim($("#dpLanguage").val()) == "") {
                layer.tips("请选择语言", $("#dpLanguage"), { guide: 1, time: 3 });
                $("#dpLanguage").focus();
                return false;
            }
            if ($.trim($("#txtPublication").val()) == "") {
                layer.tips("请输入发表刊物", $("#txtPublication"), { guide: 1, time: 3 });
                $("#txtPublication").focus();
                return false;
            }


            if ($.trim($("#StarTime").val()) == "") {
                layer.tips("请选择发表时间", $("#StarTime"), { guide: 1, time: 3 });
                $("#StarTime").focus();
                return false;
            }
        
            if ($.trim($("#txtSummary").val()) == "") {
                layer.tips("请输入摘要", $("#txtSummary"), { guide: 1, time: 3 });
                $("#txtSummary").focus();
                return false;
            }
            //if ($.trim($("#txtAuthor").val()) == "") {
            //    layer.tips("请输入作者", $("#txtAuthor"), { guide: 1, time: 3 });
            //    $("#txtAuthor").focus();
            //    return false;
            //}
            if ($("div[class=MultiFile-label]").length > 1) {
                alert("只能输入一个pdf文件");

                return false;
            }
            return ret;
        }
        function onFileChange(sender) {
            document.getElementById("ImgNews").src = window.URL.createObjectURL(sender.files[0]);
        }


    </script>
    <style type="text/css">
        .show-grid [class ^="col-"] {
            padding-bottom: 5px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <asp:HiddenField runat="server" ID="hfArticleID" />
        <div class="page-content">
            <div class="page-header">
                <h1>
                    <small>添加文章
                    </small>
                </h1>
            </div>
            <div class="row show-grid">
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">文章类型</label>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="dpArticleType" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:Literal ID="Literal1" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">文章标题</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtArticleTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Literal ID="Literal2" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                    </div>
                </div>
                  <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">图片</label>
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
                        <label class="col-sm-1 align-right control-label no-padding-right">关键词</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtKryword" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Literal ID="Literal3" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                        <label class="col-sm-1 align-right control-label no-padding-right">语言</label>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="dpLanguage" runat="server" ></asp:DropDownList>
                            <asp:Literal ID="Literal4" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                        <label class="col-sm-1 align-right control-label no-padding-right">国内</label>
					    <div class="col-sm-3">
                     <asp:CheckBox runat="server" ID="ckIsinternal"/>
                         
					    </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">发表刊物</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtPublication" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Literal ID="Literal5" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">发表时间</label>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" name="ExecuteDateStart" type="text" class="Wdate" ID="StarTime" onFocus="WdatePicker({maxDate:'#F{$dp.$D(\'StarTime\',{d:730});}',minDate:'#F{$dp.$D(\'StarTime\',{d:0});}',startDate:'#F{$dp.$D(\'StarTime\',{d:365});}',alwaysUseStartDate:true})" Width="70px"></asp:TextBox>
                            <asp:Literal ID="Literal6" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">摘要</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <asp:Literal ID="Literal8" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <%-- <label class="col-sm-2 align-right control-label no-padding-right">作者</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:Literal ID="Literal7" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
					    </div>--%>
                        <label class="col-sm-2 align-right control-label no-padding-right">所属专家</label>
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" ID="dpExpert" CssClass="form-control" />
                        </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">所属项目</label>
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" ID="dpProject" CssClass="form-control" />
                        </div>
                    </div>
                </div>
            <div class="col-xs-12">
                    <div class="form-group">
                        <%-- <label class="col-sm-2 align-right control-label no-padding-right">作者</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                              <asp:Literal ID="Literal7" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
					    </div>--%>
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
                <div class="col-xs-12">
                    <div class="form-group">
                        <%-- <label class="col-sm-2 align-right control-label no-padding-right">作者</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                              <asp:Literal ID="Literal7" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
					    </div>--%>
                        <label class="col-sm-2 align-right control-label no-padding-right">普通学生</label>
                        <div class="col-sm-3">
                            <asp:DropDownList runat="server" ID="dpstu" />
                        </div>

                    </div>

                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">文章原件：</label>
                        <div class="col-sm-10" style="vertical-align: middle;">
                            <span class="red">可以上传单个pdf文件,文件大小不超过3M</span>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right"></label>
                        <div class="col-sm-8">
                            <input type="file" name="FileUpload1" id="FileUpload1" class="multi" accept="pdf" />
                            <div class="MultiFile-list" id="FileUpload1_wrap_list"></div>
                        </div>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-5 col-md-12">
                        <input id="Return" class="btn btn-sm btn-info" type="button" value="返回" onclick="window.location.href = 'ArticleManage.aspx'" />
                        &nbsp;
                    <input id="Reset1" class="btn btn-sm btn-warning" type="reset" value="清空" />
                        &nbsp;
                    <cc1:ZButton ID="btnAdd" runat="server" Text="修改" OnClientClick="return CheckForm();" OnClick="btnAdd_Click" ModuleCode="ArticleManage" Operate="修改" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
