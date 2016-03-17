<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevMap.aspx.cs" Inherits="ECommerce.Web.Manage.DeviceMonitor.DevMap" %>

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设备位置</title>
    <link rel="stylesheet" href="/style.css">
    <%--<link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />--%>
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <style type="text/css">
        body {
            height: 100%;
            margin: 0px;
            padding: 0px;
        }

        #container {
            height: 100%;
        }
    </style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=SRkUQaDbD9KVsHZGmikTgCG1"></script>
    <script>
        function s2list(obj) {
            $("#container").hide();
            $("#dlist").show();
            $(".pannel-header a").toggleClass("active");
        }
        function s2map() {
            $("#dlist").hide();
            $("#container").show();
            $(".pannel-header a").toggleClass("active");
        }
    </script>
</head>
<body class="pd">
    <form id="form5" runat="server" style="padding: 0px;">
        <asp:HiddenField ID="hfPos" runat="server" />
        <div class="contents">
        <div class="position-history-box" style="padding-right: 28px;">
							<div class="map-btn-box"><a href="/Manage/DeviceMonitor/DevPos.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>&did=<%=Request.QueryString["did"] %>">列表</a><a href="/Manage/DeviceMonitor/DevMap.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>&did=<%=Request.QueryString["did"] %>" class="on">地图</a></div>
							<p class="position-history-title"><span><asp:Literal ID="litLoaner" runat="server"></asp:Literal></span><asp:Literal ID="litDevName" runat="server"></asp:Literal>的位置记录</p>
							<div class="map-box" id="container" style="height: 625px; width: 100%;"></div>
            <script type="text/javascript">
                    var map = new BMap.Map("container");          // 创建地图实例  
                    map.enableScrollWheelZoom(true);
                    map.enableDragging();
                    function addMarker(point, title) {
                        var marker = new BMap.Marker(point);
                        var label = new BMap.Label(title, { offset: new BMap.Size(15, -5) });
                        label.setStyle({
                            display: "none",
                            border: 0
                        });
                        marker.setLabel(label);
                        marker.addEventListener("mouseover", function () {
                            label.setStyle({
                                display: "block"
                            });
                        });
                        marker.addEventListener("mouseout", function () {
                            label.setStyle({
                                display: "none"
                            });
                        });
                        map.addOverlay(marker);
                    }
                    var pointtmp;
                    var posi = $("#<%=hfPos.ClientID%>").val();
                    var ps = posi.split('|');
                    //var level = 5;
                    //if (ps.length === 1) {
                    //    level = 19;
                    //}
                    if (ps.length > 0) {
                        for (var i = 0; i < ps.length; i++) {
                            var po = ps[i].split(',');
                            if (po.length === 3) {
                                point = new BMap.Point(po[1], po[0]);
                                if (pointtmp == undefined) {
                                    pointtmp = point;
                                    map.centerAndZoom(point, 19);
                                }
                                addMarker(point, po[2]);
                            }
                        }
                    }
                </script>
						</div></div>        
    </form>
</body>
</html>
