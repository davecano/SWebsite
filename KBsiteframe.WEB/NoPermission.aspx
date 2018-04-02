<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoPermission.aspx.cs" Inherits="KBsiteframe.Web.NoPermission" %>

<%@ Register Assembly="ZLib" Namespace="Z" TagPrefix="cc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Z" TagPrefix="webdiyer" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
    </script>
    <style type="text/css">
        .show-grid [class ^="col-"] {
            padding-bottom: 5px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
       <div class="page-content" style="margin-left:-20px;">
			<div class="row">
				<div class="col-xs-12">

					<div class="error-container">
						<div class="well">
							<h1 class="grey lighter smaller">
								<span class="blue bigger-125">
									<i class="icon-random"></i>
									500
								</span>
								您没有权限查看此页面
							</h1>

							<hr />
							<h3 class="lighter smaller">
								如您需访问该页面，请与管理员联系！
							</h3>

							<div class="space"></div>

							<div>
								<h4 class="lighter smaller">您还可以做如下操作：</h4>

								<ul class="list-unstyled spaced inline bigger-110 margin-15">
									<li>
										<i class="icon-hand-o-right blue"></i>
										返回上个页面
									</li>

									<li>
										<i class="icon-hand-o-right blue"></i>
										返回首页
									</li>
								</ul>
							</div>

							<hr />
							<div class="space"></div>

							<div class="center">
								<a href="javascript:void(0);" class="btn btn-grey" onclick="javascript:history.go(-1);">
									<i class="icon-arrow-left"></i>
									返回上个页面
								</a>
                                &nbsp;
								<a href="/Share/right.aspx" class="btn btn-primary">
									<i class="icon-home"></i>
									返回首页
								</a>
							</div>
						</div>
					</div>

				</div>
			</div>
		</div>
    </form>
</body>
</html>
