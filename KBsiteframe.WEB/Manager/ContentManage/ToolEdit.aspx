<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToolEdit.aspx.cs" Inherits="KBsiteframe.WEB.Manager.ContentManage.ToolEdit" %>


<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加工具</title>
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

            if ($.trim($("#dpToolType").val()) == "") {
                layer.tips("请选择工具类型", $("#dpToolType"), { guide: 1, time: 3 });
                $("#dpToolType").focus();
                return false;
            }
            if ($.trim($("#txtToolTitle").val()) == "") {
                layer.tips("请输入工具标题", $("#txtToolTitle"), { guide: 1, time: 3 });
                $("#txtToolTitle").focus();
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
     


    </script>
    <style type="text/css">
        .show-grid [class ^="col-"] {
            padding-bottom: 5px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="page-content">
            <div class="page-header">
                <h1>
                    <small>添加工具
                    </small>
                </h1>
            </div>
            <div class="row show-grid">

                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">工具类型</label>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="dpToolType" runat="server"></asp:DropDownList>
                            <asp:Literal ID="Literal1" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">工具名称</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtToolName" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal2" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                    </div>
                </div>
                   <div class="col-xs-12">
                    <div class="form-group">
                             <label class="col-sm-2 align-right control-label no-padding-right">路径来源</label>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="dppathtype" runat="server"></asp:DropDownList>
                            <asp:Literal ID="Literal4" runat="server" Text="&lt;font color=red&gt;*&lt;/font&gt;"></asp:Literal>
                        </div>
                        <label class="col-sm-2 align-right control-label no-padding-right">工具附件地址</label>
                        <div class="col-sm-3">
                             <asp:TextBox ID="txtToolPath" runat="server"></asp:TextBox>
                            <asp:Literal ID="Literal3" runat="server" Text="&lt;font color=red&gt;提示：若附件已经上传至服务器，只需填写附件名，否则请填写完整链接，如http://vjs.zencdn.net/v/oceans.mp4. &nbsp;：&lt;/font&gt;"></asp:Literal>
                        </div>
                 
                    </div>
                </div>
           <%--     <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">工具原件：</label>
                        <div class="col-sm-10" style="vertical-align: middle;">
                            <span class="red">可以上传单个"xls,xlsx,rar,zip,doc,docx,pdf,ppt,pptx,mp4,webm,ogv"文件</span>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right"></label>
                        <div class="col-sm-8">
                            <input type="file" name="FileUpload1" id="FileUpload1" class="multi" accept="xls|xlsx|rar|zip|doc|docx|pdf|ppt|pptx|mp4|webm|ogv" />
                            <div class="MultiFile-list" id="FileUpload1_wrap_list">
                                  <asp:Repeater runat="server" ID="ralist">
                                    <ItemTemplate>

                                        <div class="MultiFile-label" data-value='<%#PicFilePathV+Eval("ToolPath")%>' onclick="showOrdown($(this))">
                                            <div class='MultiFile-view pdf_bg' title='<%#Eval("ToolName")%>'></div>
                                            <a class="MultiFile-remove" href="javascript:void(0)" data-value='<%#Eval("ToolIID")%>' onclick="delToolUpload($(this),'ToolEdit.aspx','DeleteAttach')"></a>
                                            <span class="MultiFile-title" title='<%#Eval("ToolName")%>'><%#Eval("ToolName")%>'</span>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>--%>


                <div class="clearfix form-actions">
                    <div class="col-md-offset-5 col-md-12">
                        <input id="Return" class="btn btn-sm btn-info" type="button" value="返回" onclick="window.location.href = 'ToolManage.aspx'" />
                        &nbsp;
                    <input id="Reset1" class="btn btn-sm btn-warning" type="reset" value="清空" />
                        &nbsp;
                    <cc1:ZButton ID="btnAdd" runat="server" Text="添加" OnClientClick="return CheckForm();" OnClick="btnAdd_Click" ModuleCode="ToolManage" Operate="添加" Width="38px" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
