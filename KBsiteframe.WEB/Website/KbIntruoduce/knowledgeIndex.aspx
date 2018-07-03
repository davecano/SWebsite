<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="knowledgeIndex.aspx.cs" Inherits="KBsiteframe.WEB.Website.KbIntruoduce.knowledgeIndex" %>

<%@ Import Namespace="Z" %>

<%@ Register Assembly="AspNetPager" Namespace="Z" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <%--   javascript--%>
    <script type="text/javascript" src="../js/jquery-1.2.6.min.js"></script>
    <script type="text/javascript" src="../Js/jquery-easing-1.3.pack.js"></script>
    <script type="text/javascript" src="../Js/jquery-easing-compatibility.1.2.pack.js"></script>
    <script type="text/javascript" src="../Js/coda-slider.1.1.1.pack.js"></script>
    <script type="text/javascript" src="../Js/js.js"></script>

    <script type="text/javascript" src="../Js/bootstrap.js"></script>
    <script type="text/javascript" src="/js/layer/layer.min.js"></script>
    <script type="text/javascript" src="/js/Common.js"></script>
    <script>
        $(document).ready(function () {


        });

        function GetID(pagename, type) {
            var ID;
            // 表明id 类型 type 1 = project ,2=expert,3=lmmember,4=tdmember,5代表国内,6代表国外
            if (type == 1)
                ID = $("#ContentPlaceHolder1_hfnew1").val();
            else if (type == 2)
                ID = $("#ContentPlaceHolder1_hfnew2").val();
            else if (type == 3)
                ID = $("#ContentPlaceHolder1_hfnew3").val();
            else if (type == 4)
                ID = $("#ContentPlaceHolder1_hfnew4").val();
            window.location.href = pagename + ".aspx?ID=" + ID;

            return false;
        }
        function ShowMore() {

            var rec = parseInt($("#ContentPlaceHolder1_hfrec").val());
            var picpathv = $("#ContentPlaceHolder1_hfPicFilePathV").val();

            var pageindex = $(".list1_content3_neirong_text").length + 1;
          
            if (rec <= pageindex * 4) {

                $("#ContentPlaceHolder1_showmore").hide();
            }
            var HtmlStr = "";
            var pageurl = "knowledgeIndex.aspx/GetExpertsByPageIndex";
            var senddata = '{pageindex: "' + pageindex + '"}';
            $.ajax({
                type: 'POST',//使用get方法访问后台
                dataType: 'json',//返回json格式的数据
                contentType: "application/json;charset=utf-8",
                url: pageurl,//要访问的后台地址
                data: senddata,//要发送的数据
                error: function (errorThrown) {//请求错误 时执行的方法 
                    alert("error!" + errorThrown.error);
                },
                success: function (data) {
                    HtmlStr += "<div class=\"list1_content3_neirong_text\">";
                    HtmlStr += "<div class=\"list1_content3_neirong_text_middle\">";
                    for (var i = 0; i < data.d.length; i++) {
                        HtmlStr += "<div class=\"list1_content3_neirong_text_middle_one\">";
                        HtmlStr += "<div class=\"list1_content3_neirong_text_middle_one_shang\">";
                        HtmlStr += "<img  style=\"border-radius: 50%; width: 154px;height: 154px \" src=\"" + picpathv + data.d[i].EPicPath + "\" /></div>";
                        HtmlStr += "<div class=\"list1_content3_neirong_text_middle_one_xia\">";
                        HtmlStr += "<div class=\"list1_content3_neirong_text_middle_one_xia_name\">";
                        HtmlStr += data.d[i].EName;
                        HtmlStr += "</div>";
                        HtmlStr += "<div class=\"list1_content3_neirong_text_middle_one_xia_in\">";
                        HtmlStr += "<a href='ShowExpert.aspx?ID=" + data.d[i].ExpertID + "'>" + data.d[i].ESummary + "</a></div>";
                        HtmlStr += "</div>";
                        HtmlStr += "</div>";
                    }
                    HtmlStr += "</div>";
                    HtmlStr += "</div>";
                    $(".list1_content3_neirong_text:last").after(HtmlStr);
                }
            });


        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="list1_content">
        <div class="list1_content_middle">
            <div class="list1_daohang">
                <div class="list1_icon">
                    <img src="../image/locate.png" /></div>
                <div class="list1_text">当前位置：<a href="../index.aspx">首页</a> / <a href="#">知识建构</a></div>
            </div>
            <div class="list1_content1_neirong">
                <div class="list1_content1_neirong_title">
                    <div class="list1_content1_neirong_title_shang">知识建构原则</div>
                    <div class="list1_content1_neirong_title_xia">
                        <img src="../image/picture_07.png" /></div>
                </div>
                <div class="list1_content1_neirong_text">
                    <div class="list1_content1_neirong_text_one"><asp:HiddenField runat="server" ID="hfnew2"/><a href="javascript:GetID('../ShowNews',2);">
                        <img src="../image/picture_11.png" /></a></div>
                    <div class="list1_content1_neirong_text_one"> <asp:HiddenField runat="server" ID="hfnew3"/><a href="javascript:GetID('../ShowNews',3);">
                        <img src="../image/picture_14.png" /></a></div>
                    <div class="list1_content1_neirong_text_one1"> <asp:HiddenField runat="server" ID="hfnew4"/><a href="javascript:GetID('../ShowNews',4);">
                        <img src="../image/picture_16.png" /></a></div>
                </div>
            </div>
            <div class="list1_content2_neirong">
                <div class="list1_content1_neirong_title">
                    <div class="list1_content1_neirong_title_shang">知识建构理论</div>
                    <div class="list1_content1_neirong_title_xia">
                        <img src="../image/picture_07.png" /></div>
                </div>
            </div>
        </div>
        <div class="list1_content2_neirong_text">
            <div class="list1_content2_neirong_text_middle">
                <div class="list1_content2_neirong_text_jianjie"><asp:Literal runat="server" ID="ltjgsummary"></asp:Literal>
                    <asp:HiddenField runat="server" ID="hfnew1"/>
                </div>
                <div class="list1_more">
                    <div class="list1_more_middle"><a href="javascript:GetID('../ShowNews',1);">MORE</a></div>
                </div>
            </div>
        </div>
        <div class="list1_content2_neirong">
            <div class="list1_content1_neirong_title">
                <div class="list1_content1_neirong_title_shang">知识建构专家</div>
                <div class="list1_content1_neirong_title_xia">
                    <img src="../image/picture_07.png" /></div>
            </div>
            <%-- 	<div class="list1_content3_neirong_text_middle_one">
					<div class="list1_content3_neirong_text_middle_one_shang"><img src="../image/picture_22.jpg" /></div>
					<div class="list1_content3_neirong_text_middle_one_xia">
						<div class="list1_content3_neirong_text_middle_one_xia_name"><a href="list1_list.html">xxx</a></div>
						<div class="list1_content3_neirong_text_middle_one_xia_in"><a href="list1_list_show.html">内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容</a></div>
					</div>
				</div>--%>
            <div class="list1_content3_neirong_text">
                <div class="list1_content3_neirong_text_middle">
                    <asp:Repeater runat="server" ID="rplist_new">
                        <ItemTemplate>
                            <div class="list1_content3_neirong_text_middle_one">
                                <div class="list1_content3_neirong_text_middle_one_shang">
                                    <img style="border-radius: 50%; width: 154px; height: 154px" src='<%#GetFullPath(Eval("EPicPath")) %>' /></div>
                                <div class="list1_content3_neirong_text_middle_one_xia">
                                    <div class="list1_content3_neirong_text_middle_one_xia_name"><%#Eval("EName") %></div>
                                    <div class="list1_content3_neirong_text_middle_one_xia_in"><a href='ShowExpert.aspx?ID=<%#Eval("ExpertID") %>'><%#Utils.CutString(Eval("ESummary") ,20)%></a></div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:HiddenField runat="server" ID="hfrec" />
                    <asp:HiddenField runat="server" ID="hfPicFilePathV" />

                </div>
            </div>

            <div class="list1_moren" runat="server" id="showmore">
                <div class="list1_L"><a href="#" onclick="ShowMore()">MORE</a></div>
            </div>








        </div>
    </div>
</asp:Content>
