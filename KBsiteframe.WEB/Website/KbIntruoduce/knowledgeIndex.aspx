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


        function ShowMore() {
            var rec = parseInt($("#hfrec").val());
            var pageindex = $('.list1_content3_neirong_text_middle').length + 1;
            if (rec <= pageindex * 4) {
                $("#showmore").hide();
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
                    for (var i = 0; i < data.d.length; i++) {
                        HtmlStr += "<div class=\"list1_content3_neirong_text_middle_one\">";
                        HtmlStr += "<div class=\"list1_content3_neirong_text_middle_one_shang\">";
                        HtmlStr += "<img src=\"../image/picture_22.jpg\" /></div>";
                        HtmlStr += "</div>";
                    }
                }
            });
        
            return false;
        }

  
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="list1_content">
	<div class="list1_content_middle">
		<div class="list1_daohang">
			<div class="list1_icon"><img src="../image/locate.png" /></div>
			<div class="list1_text">当前位置：<a href="../index.html">首页</a> / <a href="list1.html">知识建构</a></div>
		</div>
		<div class="list1_content1_neirong">
			<div class="list1_content1_neirong_title">
				<div class="list1_content1_neirong_title_shang">知识建构原则</div>
				<div class="list1_content1_neirong_title_xia"><img src="../image/picture_07.png" /></div>
			</div>
			<div class="list1_content1_neirong_text">
				<div class="list1_content1_neirong_text_one"><a href="list1_show_shouduan.html"><img src="../image/picture_11.png" /></a></div>
				<div class="list1_content1_neirong_text_one"><a href="list1_show_guandian.html"><img src="../image/picture_14.png" /></a></div>
				<div class="list1_content1_neirong_text_one1"><a href="list1_show_shequ.html"><img src="../image/picture_16.png" /></a></div>
			</div>
		</div>
		<div class="list1_content2_neirong">
			<div class="list1_content1_neirong_title">
				<div class="list1_content1_neirong_title_shang">知识建构理论</div>
				<div class="list1_content1_neirong_title_xia"><img src="../image/picture_07.png" /></div>
			</div>
		</div>
	</div>
	<div class="list1_content2_neirong_text">
		<div class="list1_content2_neirong_text_middle">
			<div class="list1_content2_neirong_text_jianjie"><a href="list1_list_show.html">　　4月10日，江苏省学前教育学会第三次会员代表大会在南京召开。省教育厅副厅长朱卫国出席会议并讲话，省民政厅领导及中国学前教育研究会理事长虞永平到会致辞，全省各地的学前教育学会会员代表和相关理事单位成员共计300多人参加了会议。大会选举产生了省学前教育学会新一届领导班子，张建明当选为学会会长李运生、顾爱军、郑英舜、封留才、杜悦艳、王薇、崔利玲当选副会长，殷雅竹当选秘书长。朱卫国代表省教育厅充分肯定了学会自2007年12月20日成立以来开展的工作及取得的成绩。这10年，是我省学前教育加快发展、成果丰硕的十年，是省学前教育学会从无到有、蓬勃发展的十年...</a></div>
			<div class="list1_more">
				<div class="list1_more_middle"><a href="list1_list_show.html">MORE</a></div>
			</div>
		</div>
	</div>
	<div class="list1_content2_neirong">
		<div class="list1_content1_neirong_title">
			<div class="list1_content1_neirong_title_shang">知识建构专家</div>
			<div class="list1_content1_neirong_title_xia"><img src="../image/picture_07.png" /></div>
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
					<div class="list1_content3_neirong_text_middle_one_shang"><img style="border-radius: 50%; width: 154px;height: 154px " src='<%#GetFullPath(Eval("EPicPath")) %>'/></div>
					<div class="list1_content3_neirong_text_middle_one_xia">
						<div class="list1_content3_neirong_text_middle_one_xia_name"><%#Eval("EName") %></div>
						<div class="list1_content3_neirong_text_middle_one_xia_in"><a href='ShowExpert.aspx?ID=<%#Eval("ExpertID") %>'><%#Utils.CutString(Eval("ESummary") ,20)%></a></div>
					</div>
				</div> 
				    </ItemTemplate>
				</asp:Repeater>
                <asp:HiddenField runat="server" ID="hfrec"/>
                   <asp:HiddenField runat="server" ID="hfPicFilePathV"/>
                
			</div>
		</div>
  
        	<div class="list1_moren" runat="server" id="showmore">
			<div class="list1_L"><a href="#" onclick="return ShowMore()">MORE</a></div>
		</div>
           

		
		
         	
	
		
	
</div>
         </div>
</asp:Content>
