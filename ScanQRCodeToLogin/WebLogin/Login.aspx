<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebLogin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>扫码登录页面</title>
    <script src="Scripts/jquery-1.6.4.min.js"></script>
    <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src="http://localhost:9999/signalr/hubs"></script>
    <script>
        $(function () {
            var uuid, timer, hub = $.connection.myHub;
            $.connection.hub.url = "http://localhost:9999/signalr";

            //客户端注册getUserInfo 事件
            hub.client.getUserInfo = function (n) {
                window.clearInterval(timer);
                $("#lblUserInfo").text(n);
            }

            //客户端注册getUUID事件
            hub.client.getUUID = function (n) {
                $("#lblUUID").text(n);
            }

            //初始化连接
            hubInit = function (refreshInterval) {
                refreshInterval == null && (refreshInterval = 30000);

                //它封装了 webSockets、foreverFrame、serverSentEvents、longPolling四种主要的传输协议。
                //① webSockets：它是HTML5提供的一种在单个 TCP 连接上进行全双工通讯的协议。
                //② foreverFrame(永久帧)：它适用于IE浏览器，是在页面中插入一个隐藏的iframe，利用其src属性在服务器和客户端之间创建一条长链接，服务器向iframe传输数据（通常是HTML，内有负责插入信息的javascript），来实时更新页面。
                //③ severSentEvents（服务器发送事件，也成EventSourse）：顾名思义。
                //④ longPolling(Ajax长轮询)：长轮询是对轮询的改进，客户端通过请求连接到服务器，并保持一段时间的连接状态，直到消息更新或超时才返回Response并中止连接，可以有效减少无效请求的次数。

                //$.connection.hub.start({ transport: ['webSockets'] }).done(function () {
                $.connection.hub.start().done(function () {
                    //调用服务端注册事件
                    hub.server.register();
                });

                //指定时间刷新二维码 默认30000,0为永不刷新
                window.clearInterval(timer);
                refreshInterval == 0 || (timer = window.setInterval(function () {
                    hub.server.register();
                }, refreshInterval));
            }

            //停止二維碼刷新
            stopRefresh = function () {
                window.clearInterval(timer);
            }

            //启动喽
            hubInit(0);
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>这是一个扫码登录页面</h1>
            <br />
            <span>我是一个二维码:</span><label id="lblUUID"></label>
            <br />
            <span>这里是登录结果:</span><label id="lblUserInfo"></label>
        </div>
    </form>
</body>
</html>
