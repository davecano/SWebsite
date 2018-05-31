<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="KBsiteframe.WEB.Website.UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户注册</title>
    <link rel="stylesheet" type="text/css" href="Css/style.css"/>
        <script> 
        function CheckForm() {
            var ret = true;
            if ($.trim($("#txtUserName").val()) == "") {
                layer.tips("请输入用户名", $("#txtUserName"), { guide: 1, time: 3 });
                $("#txtUserName").focus();
                return false;
            }
            if ($.trim($("#txtMail").val()) == "") {
                layer.tips("请输入邮箱", $("#txtMail"), { guide: 1, time: 3 });
                $("#txtMail").focus();
                return false;
            }
            if (!$("#txtMail").val().match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/)) {
                //alert("邮箱格式不正确");
                layer.tips("邮箱格式不正确", $("#txtMail"), { guide: 1, time: 3 });
                //$("#confirmMsg").html("<font color='red'>邮箱格式不正确！请重新输入！</font>"); 
                $("#txtMail").focus();
                return false;
            }
            if ($.trim($("#txtPhone").val()) == "") {
                layer.tips("请输入手机号码", $("#txtPhone"), { guide: 1, time: 3 });
                $("#txtPhone").focus();
                return false;
            }
            if (!$("#txtPhone").val().match(/^1[34578]\d{9}$/)) {
                //alert("手机号码格式不正确！");
                layer.tips("手机号码格式不正确", $("#txtPhone"), { guide: 1, time: 3 });
                //$("#moileMsg").html("<font color='red'>手机号码格式不正确！请重新输入！</font>"); 
                $("#txtPhone").focus();
                return false;
            }
          
            if ($.trim($("#txtPsw").val()) == "") {
                layer.tips("请输入密码", $("#txtPsw"), { guide: 1, time: 3 });
                $("#txtPsw").focus();
                return false;
            }
            if ($.trim($("#txtPsw2").val()) == "") {
                layer.tips("请确认密码", $("#txtPsw2"), { guide: 1, time: 3 });
                $("#txtPsw2").focus();
                return false;
            }
            if ($.trim($("#txtPsw2").val()) != $.trim($("#txtPsw").val())) {
                layer.tips("两次密码输入不一致，请重试", $("#txtPsw2"), { guide: 1, time: 3 });
                $("#txtPsw2").focus();
                return false;
            }
            if ($.trim($("#txtImg").val()) == "") {
                layer.tips("请输入验证码", $("#txtImg"), { guide: 1, time: 3 });
                $("#txtImg").focus();
                return false;
            }

            return ret;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
  <div class="dl-bg">
<div class="dl-logo">
<div class="dl-logo-pic"></div>
</div>
<div class="dl-mian">
<div class="dl-biao">
<div class="dl-biao-title">新用户注册</div>
<div class="dl-biao-table">
<div class="dl-biao-table-input">
<div style="width: 362px;height: 400px;">
 <p>&nbsp;&nbsp;&nbsp;&nbsp;用户名:
    <%-- <input class="dl-input1" type="text" name="用户名">--%>
     <asp:TextBox runat="server" CssClass="dl-input1"  ID="txtUserName"></asp:TextBox>
    <br>
	
	<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 邮箱:&nbsp;
  <%-- <input class="dl-input1" type="text" name="邮箱">--%>
     <asp:TextBox runat="server" ID="txtMail" CssClass="dl-input1" ></asp:TextBox>
   <br>
   <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 手机:&nbsp;
  <%-- <input class="dl-input1" type="text" name="手机号码">--%>
     <asp:TextBox runat="server" ID="txtPhone" CssClass="dl-input1" ></asp:TextBox>
   <br>
    <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 密码:&nbsp;
 <%--  <input class="dl-input1" type="text" name="密码">--%>
     <asp:TextBox runat="server" ID="txtPsw" CssClass="dl-input1"></asp:TextBox>
   <br>
   <br>
   确认密码:&nbsp; 
 <%--  <input class="dl-input1" type="text" name="确认密码">--%>
     <asp:TextBox runat="server" ID="txtPsw2" CssClass="dl-input1" TextMode="Password" ></asp:TextBox>
     <br>
     <br>
&nbsp;&nbsp;&nbsp; 验证码:&nbsp;
  <%-- <input class="dl-input2" type="text" name="验证码">--%>
       <asp:TextBox ID="txtImg" runat="server" CssClass="dl-input2" TextMode="Password"></asp:TextBox>
  </p>
 <div class="dl-yan">
         <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="~/share/ImgCreator.aspx?id=1" onclick="this.src = '../share/ImgCreator.aspx?id=1&amp;flag=' + Math.random() " title="看不清楚，双击图片换一张。不区分大小写。" Width="85px" />
 </div>
 <div class="dl-an">
<%--<button type="button" id="dl-button">立即注册</button>--%>
     <asp:Button runat="server" ID="btnReg" CssClass="dl-button-unique" Text="立即注册" OnClientClick="return CheckForm();" OnClick="btnReg_OnClick"/>
</div>
</div> 
</div>
</div>
</div>
</div>

</div>
    </form>
</body>
</html>
