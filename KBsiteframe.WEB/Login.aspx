
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KBsiteframe.WEB.Login" %>

<!DOCTYPE html>
<html>

<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>用户登录</title>
    <link type="text/css" rel="stylesheet" href="css/login/bootstrap.min.css" />
	<!--[if lte IE 7]
	<link rel="stylesheet" type="text/css" href="css/login/bootstrap-ie6.min.css">
	<link rel="stylesheet" type="text/css" href="css/login/ie.css">
	<![endif]-->
	<style type="text/css">
	body { background: url(images/banner.png) fixed center center; }
    .tit { margin: auto; margin-top: 170px; text-align: center; width: 450px; padding-bottom: 20px; text-shadow: 1px 1px 2px #000000; line-height: 40px; }
    .login-wrap { width: 50%; min-width: 570px; margin: 0 auto; }
    /*
    .login_user { background: url(images/input_icon_1.png) 98% 50% no-repeat; }
    .login_passwd { background: url(images/input_icon_2.png) 98% 50% no-repeat; }*/
    .login-wrap img#logo { min-height: 300px; }
    .copyright { margin: auto; margin-top: 10px; text-align: center; width: 370px; color: #CCC }
    .moshi{padding:35px;background-color:#54934c; border:1px solid #54934c; box-shadow:1px 1px 2px #000;}
    .user{width:24px;height:24px;background:url(images/yh.png);position: absolute;margin:8px 8px; background-repeat:no-repeat;}
    .uuser{width:24px;height:24px;background:url(images/mm.png);position: absolute;margin:8px 8px; background-repeat:no-repeat;}
    @media (max-height: 700px) {.tit { margin: auto; margin-top: 100px; }}
    @media (max-height: 500px) {.tit { margin: auto; margin-top: 50px; }}
	</style>
    <script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="js/layer/layer.min.js"></script>
    <script> 
        function CheckForm() {
            var ret = true;
            if ($.trim($("#txtUserName").val()) == "") {
                layer.tips("请输入登录名称", $("#txtUserName"), { guide: 1, time: 3 });
                $("#txtUserName").focus();
                return false;
            }
            if ($.trim($("#txtPassword").val()) == "") {
                layer.tips("请输入登录密码", $("#txtPassword"), { guide: 1, time: 3 });
                $("#txtPassword").focus(); 
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
    <div class="tit">
        <label style="font-size:36px;font-family:'华康俪金黑W8(P)';color:white;">kbsiteframe后台管理</label>
    </div>
	<div class="panel panel-default login-wrap">
		<div class="panel-body">
			<div class="row">
				<div class="col-md-6"><img id="logo" src="images/tu.png" width="100%" height="100%" alt=""/></div>
				<div class="col-md-6">
					<form id="form1" runat="server" name="form1" class="moshi">
						<div class="form-group">
							<span class="user"></span>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control login_user" placeholder="登录帐号"></asp:TextBox>
						</div>
						<div class="form-group">
							<span class="uuser"></span>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control login_passwd"    placeholder="登录密码"></asp:TextBox>
						</div>
                        <div class="form-group" style=" margin-bottom:26px;">
                            <div class="input-group">
                                <asp:TextBox ID="txtImg" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon">
                                    <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="~/share/ImgCreator.aspx?id=1" onclick="this.src = '../share/ImgCreator.aspx?id=1&amp;flag=' + Math.random() " title="看不清楚，双击图片换一张。不区分大小写。" Width="85px" />
                                </span>
                            </div>
                            
                            
                        </div>
						<div class="btn-group-justified">
							<div class="btn-group">
                                <asp:Button ID="Button1" OnClientClick="return CheckForm();" runat="server" Text="登&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;录" OnClick="Button1_Click" CssClass=" btn btn-success" />
							</div>
						</div>
					</form>
				</div>
			</div>
		</div>
	</div>
	<div class="copyright">建议使用IE9及以上版本或谷歌浏览器</div>
</body>
</html>
