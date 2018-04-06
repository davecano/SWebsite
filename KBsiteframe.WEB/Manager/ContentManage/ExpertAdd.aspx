<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ExpertAdd.aspx.cs" Inherits=" KBsiteframe.WEB.Manager.ContentManage.ExpertAdd" %>

<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加专家</title>
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
        $(document).ready(function() {
            //var $dpistop = $("#dpIstop");
            //var $dpsort = $("#dpsort");
            //alert($dpistop.val());
            //if ($dpistop.val() == "1")
            //    $dpsort.show();
            //else $dpsort.hide();
        });
        function onFileChange(sender) {
            document.getElementById("ImgNews").src = window.URL.createObjectURL(sender.files[0]);

        }
        function CheckForm() {
            var ret = true;

            if ($.trim($("#txtEName").val()) == "") {
                layer.tips("请输入专家名称", $("#txtEName"), { guide: 1, time: 3 });
                $("#txtEName").focus();
                return false;
            }
            if ($.trim($("#txtECountry").val()) == "") {
                layer.tips("请输入国别", $("#txtECountry"), { guide: 1, time: 3 });
                $("#txtECountry").focus();
                return false;
            }

          
            if ($.trim($("#txtESummary").val()) == "") {
                layer.tips("请输入简介", $("#txtESummary"), { guide: 1, time: 3 });
                $("#txtESummary").focus();
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
                    <small>添加专家
                    </small>
                </h1>
            </div>
            <div class="row show-grid">

                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">专家名称</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtEName" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal5" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">国别</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtECountry" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal1" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                    </div>
                </div>
               
  <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">置顶(排序)</label>
                        <div class="col-sm-3">
                       <asp:DropDownList runat="server" ID="dpIstop">
                           <asp:ListItem value="">==请选择==</asp:ListItem>
                             <asp:ListItem value="1">是</asp:ListItem>
                             <asp:ListItem value="0">否</asp:ListItem>
                       </asp:DropDownList>
                       <%--  <asp:DropDownList runat="server" ID="dpsort"/>--%>
                        </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">标识</label>
                        <div class="col-sm-3">
                       <asp:DropDownList runat="server" ID="dpEIdentification"/>
                           
                        </div>
                    </div>
                </div>
                  <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">专家图片</label>
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
                        <label class="col-sm-2 align-right control-label no-padding-right">简介</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtESummary" runat="server" TextMode="MultiLine" Width="600px" Height="150px"></asp:TextBox>
                            <asp:Literal ID="Literal4" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>

                    </div>
                </div>
           
              
            </div>
            <div class="clearfix form-actions">
                <div class="col-md-offset-5 col-md-12">
                    <input id="Return" class="btn btn-sm btn-info" type="button" value="返回" onclick="window.location.href = 'ExpertManage.aspx'" />
                    &nbsp;
                    <input id="Reset1" class="btn btn-sm btn-warning" type="reset" value="清空" />
                    &nbsp;
                    <cc1:ZButton ID="btnAdd" runat="server" CssClass="btn btn-sm btn-primary" Text="添加" OnClientClick="return CheckForm();" OnClick="btnAdd_OnClick" ModuleCode="ExpertManage" Operate="添加" />
                    &nbsp;
                   
                </div>
            </div>
        </div>
    </form>
</body>
</html>
