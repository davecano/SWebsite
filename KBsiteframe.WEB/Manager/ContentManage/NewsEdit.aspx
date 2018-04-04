<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" ValidateRequest="false" Inherits="KBsiteframe.Web.Manager.ContentManage.NewsEdit" %>
<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/assets/css/font-awesome.min.css" />
    <script type="text/javascript" src="/Ueditor/ueditor.config.js"></script>
 6     <script type="text/javascript" src="/Ueditor/ueditor.all.js"></script>
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
   </script> 
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-content">
            <div class="page-header">
                <h1>
				    <small>
					   修改新闻
				    </small>
			    </h1>
            </div>
            <div class="row show-grid">
           
            <asp:HiddenField runat="server" ID="hfNewsID"/>
                <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">新闻标题</label>
					    <div class="col-sm-3">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
					    </div>
                    
				    </div>
                </div>
                <div class="col-xs-12">
                    <div class="form-group">
                         <label class="col-sm-2 align-right control-label no-padding-right">是否置顶</label>
					    <div class="col-sm-3 checkbox">
                            <asp:CheckBox ID="CbIstop" runat="server" />
					    </div>
                            <label class="col-sm-2 align-right control-label no-padding-right">是否热门</label>
					    <div class="col-sm-3 checkbox">
                            <asp:CheckBox ID="CbIsHot" runat="server" />
					    </div>
                       
				    </div>
                </div>
        
         
                  <div class="col-xs-12">
                    <div class="form-group">
                        <label class="col-sm-2 align-right control-label no-padding-right">新闻内容</label>
					    <div class="col-sm-8">
                            <asp:TextBox ID="container" runat="server" Width="100%" Height="400px" TextMode="MultiLine" name="container" ClientIDMode="Static"></asp:TextBox>
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
                    <cc1:ZButton ID="btnEdit"  CssClass="btn btn-sm btn-primary" runat="server" Text="修改" class="btn btn-sm btn-primary"  ModuleCode="NewsManage" Operate="修改" OnClick="btnEdit_OnClick"/>
              
                </div>
            </div>
        </div>
    </form>
</body>
</html>