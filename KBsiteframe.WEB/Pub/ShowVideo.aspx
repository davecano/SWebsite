<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowVideo.aspx.cs" Inherits="KBsiteframe.WEB.Pub.ShowVideo" %>

<!doctype html>
<html>
	<head>
	<meta charset="utf-8">
	<title>视频播放</title>
	<link href="/css/video-js.min.css" rel="stylesheet">
	<style>
body {
	background-color: #191919
}
.m {
	width: 960px;
	height: 400px;
	margin-left: auto;
	margin-right: auto;
	margin-top: 100px;
}
</style>
	</head>

	<body>
    <div class="m">
      <video id="my-video" class="video-js" controls preload="auto" width="960" height="400"
		  poster="/images/banner.png" data-setup="{}">
		 <source src="<%=VideoSource %>" type="<%=VideoType %>">
    <%--    <source src="http://vjs.zencdn.net/v/oceans.mp4" type="video/mp4">
    	<source src="http://vjs.zencdn.net/v/oceans.webm" type="video/webm">
    	<source src="http://vjs.zencdn.net/v/oceans.ogv" type="video/ogg">--%>
        <p class="vjs-no-js"> To view this video please enable JavaScript, and consider upgrading to a web browser that <a href="http://videojs.com/html5-video-support/" target="_blank">supports HTML5 video</a> </p>
      </video>
      <script src="../js/video.min.js"></script> 
      <script src="http://vjs.zencdn.net/5.19/lang/zh-CN.js"></script>
      <script type="text/javascript">
			var myPlayer = videojs('my-video');
			videojs("my-video").ready(function(){
				var myPlayer = this;
				myPlayer.play();
			});
			  
		</script> 
    </div>
</body>
</html>
