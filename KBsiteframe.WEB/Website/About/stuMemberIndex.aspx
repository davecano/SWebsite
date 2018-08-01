<%@ Page Title="" Language="C#" MasterPageFile="~/Website/Master/KBSiteframe.Master" AutoEventWireup="true" CodeBehind="StuMemberIndex.aspx.cs" Inherits="KBsiteframe.WEB.Website.About.StuMemberIndex" %>

<%@ Register TagPrefix="webdiyer" Namespace="Z" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="list3_content">
        <div class="list3_content_middle">
            <div class="list3_daohang">
                <div class="list3_icon">
                    <img src="../image/locate.png" />
                </div>
                <div class="list3_text">当前位置：<a href="../index.html">首页</a> / <a href="#">研究联盟</a></div>
            </div>
        </div>
        <%--    <div class="list3_content1">
            <div class="list3_content1_first">
                <div class=" list3_content1_first_one" style="border: 1px solid red">
                   
               <div class="text-center margin_bottom_16">
                         <asp:Repeater runat="server" ID="rplist">
                        <ItemTemplate>
                            <div class="list3_content_custom_member ">
                                <div class="text-center">
                                    <div class="list3_content_custom_member_content">
                                        <div class="list3_picture">
                                            <img width="206px" height="134px" src='<%#PicFilePathV+Eval("MemberPic") %> ' />
                                        </div>
                                    </div>
                                    <div class="list3_content_custom_member_content">
                                        <div class="list3_content1_first_one_left_text_shang">联盟成员:<%#Eval("MemberName") %></div>
                                        <div class="list3_content1_first_one_left_text_xia">
                                            所在机构:<%#Eval("Organization")%><br />学历:<%#Eval("Qualification") %><br />联系方式:<%#Eval("Phone") %></div>
                                        <div class="list3_chakan"><a href='ShowMember.aspx?ID=<%#Eval("MemberID") %>'>【查看详细】</a></div>
                                    </div>


                                </div>
                             
                            </div>
                       
                        </ItemTemplate>
                    </asp:Repeater> 
                    </div>
                   
                </div>
               </div>
        </div>--%>
        <div class="list3_content1">
            <div class="list3_content1_first">
                <div class=" list3_content1_first_one_custom">
                    <div class="text-center">
                        <asp:Repeater runat="server" ID="rplist">
                            <ItemTemplate>
                   
                                  <div class=" margin_bottom_16 list3_content_custom_member_content" >
                            <div class="list3_content1_first_one">
                                <div class="list3_content1_first_one_left_picture">
                                    <div class="list3_picture">
                                             <img width="206px" height="134px" src='<%#PicFilePathV+Eval("MemberPic") %> '/></div>
                                </div>
                                <div class="list3_content1_first_one_left_text">
                                    <div class="list3_content1_first_one_left_text_shang">联盟成员:<%#Eval("MemberName") %></div>
                                    <div class="list3_content1_first_one_left_text_xia">
                                        所在机构:<%#Eval("Organization")%><br />学历:<%#Eval("Qualification") %><br />联系方式:<%#Eval("Phone") %></div>
                                    <div class="list3_chakan"><a href='../AcademicAlliance/ShowMember.aspx?ID=<%#Eval("MemberID") %>'>【查看详细】</a></div>
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
            <div class="fenye_middle fenye_middle_special">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_OnPageChanged" CssClass="pagination" CurrentPageButtonClass="active" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" LayoutType="Ul" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" NumericButtonCount="5" PrevPageText="上一页" PageSize="6" EnableTheming="False">
                </webdiyer:AspNetPager>

            </div>
        </div>

    </div>

</asp:Content>
