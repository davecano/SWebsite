<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowPdf.aspx.cs" Inherits="KBsiteframe.WEB.Pub.ShowPdf" %>


<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>在线预览PDF文档</title>
    <link rel="stylesheet" href="/css/bootstrap.min.css">
    <script type="text/javascript" src="/js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="/js/jquery.media.js"></script>
    <script type="text/javascript">
        $(function () {
            $('a.media').media({ width: 800, height: 600 });
        });
    </script>
  <style type="text/css">
      body {
	background-color: #191919
}
  </style>
</head>

    
<body>
<center>
 <div class="panel panel-primary">
   <div class="panel-heading" align="center">
      <h2>预览pdf文件</h2>
   </div>
   <div class="panel-body">
	   <a class="media" href="/Upload/ArticleFile/2018_4/3/20180403172716490.pdf"></a></div>
     </div>
</center>

</html>
