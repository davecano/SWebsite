<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowPicture.aspx.cs" Inherits="ECIS.Web.Pub.ShowPicture" %>

<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Z" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>资质图片</title>
    <link type="text/css" rel="stylesheet" href="../css/viewer.css" />
    <style type="text/css">
        .show_pic {
            width:90%;
            height:auto;
            margin:0 auto;
        }
        .parentFileBox {
	        width:auto;
	        height:auto;
	        overflow:hidden;
	        position:relative;
        }
        .parentFileBox>.docs-pictures {
	        position:relative;
	        width:100%;
	        height:auto;
	        overflow:hidden;
	        padding-bottom:5px;
        }
        .parentFileBox>.docs-pictures >li {
	        float:left;
	        border:1px solid #09F;
	        border-radius:5px;
	        width:170px;
	        height:150px;
	        margin-top:5px;
	        margin-left:5px;
	        overflow:hidden;
	        position:relative;
            cursor:pointer;
	        background-color:#099;
        }
        .parentFileBox>.docs-pictures>li>.viewThumb {
	        position:absolute;
	        top:0;
	        left:0;
	        width:170px;
	        height:150px;
	        overflow:hidden;
        }
        .parentFileBox>.docs-pictures>li>.viewThumb>img {
	        width:100%;
	        height:100%;
        }
        .parentFileBox>.docs-pictures>li>.diyFileName {
	        position:absolute;
	        bottom:0px;
	        left:0px;
	        width:100%;
	        height:20px;
	        line-height:20px;
	        text-align:center;
	        color:#fff;
	        font-size:12px;
	        display:block;
	        background:url(../images/bgblack.png);
        }
    </style>
    <script type="text/javascript" src="../js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="../js/viewer.js"></script>
    <script type="text/javascript" src="../js/showFile_img.js"></script>
    <script src="../js/Common.js"></script>
    <script type="text/ecmascript">
        $(document).ready(function () {
            var id = getQueryString("attach_id");
            $("#" + id + " img").click();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="show_pic">
            <div class="parentFileBox docs-galley">
                <ul class="docs-pictures clearfix">
                    <asp:Repeater ID="rpfileupload" runat="server">
                        <ItemTemplate>
                            <li id='<%#Eval("AttachID") %>'>
                                <div class="viewThumb"><img data-original='<%#Eval("AttachPath") %>' src='<%#Eval("AttachThumbnailPath") %>'></div>
                                <div class="diyFileName"><%#Eval("AttachName") %></div>	
                             </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>				
            </div>
        </div>
    </form>
</body>
</html>
