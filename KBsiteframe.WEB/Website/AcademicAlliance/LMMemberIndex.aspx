<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="LMMemberIndex.aspx.cs" Inherits="KBsiteframe.WEB.Website.AcademicAlliance.LMMemberIndex" %>
<%@ Register TagPrefix="webdiyer" Namespace="Z" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="list3_content">
	<div class="list3_content_middle">
		<div class="list3_daohang">
			<div class="list3_icon"><img src="../image/locate.png" /></div>
			<div class="list3_text">当前位置：<a href="../index.html">首页</a> / <a href="list3.html">研究联盟</a></div>
		</div>
		<div class="list3_content1">
			<div class="list3_content1_first">
			    <asp:Repeater runat="server" ID="rplist">
			        <ItemTemplate>
			            <div class="list3_content1_first_one1">
					<div class="list3_content1_first_one_left">
						<div class="list3_content1_first_one_left_picture">
							<div class="list3_picture"><img src="../image/picture.png" /></div>
						</div>
						<div class="list3_content1_first_one_left_text">
							<div class="list3_content1_first_one_left_text_shang">联盟成员:<%#Eval("MemberName") %></div>
							<div class="list3_content1_first_one_left_text_xia">所在机构:<%#Eval("Organization")%><br />学历:<%#Eval("Qualification") %><br />联系方式:<%#Eval("Phone") %></div>
							<div class="list3_chakan"><a href='ShowMemberMsg?ID=<%#Eval("MemberID") %>'>【查看详细】</a></div>
						</div>
					</div>
					<div class="list3_content1_first_one_right">
						<div class="list3_content1_first_one_left">
							<div class="list3_content1_first_one_left_picture">
								<div class="list3_picture"><img src="../image/picture.png" /></div>
							</div>
							<div class="list3_content1_first_one_left_text">
								<div class="list3_content1_first_one_left_text_shang">联盟成员:xxxxxxx</div>
								<div class="list3_content1_first_one_left_text_xia">主要负责人:xxxxx <br />
									起止时间:xxxxxxx<br />
									研究方向:xxxxxxxxxxxxx</div>
								<div class="list3_chakan"><a href="list3_show.html">【查看详细】</a></div>
							</div>
						</div>
					</div>
				</div>
			        </ItemTemplate>
			    </asp:Repeater>
				
			</div>
		</div>
	</div>
</div>
       <div class="fenye">
                <div class="fenye_middle">
                     <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_OnPageChanged">
            </webdiyer:AspNetPager>
                </div>
            </div>
</asp:Content>
