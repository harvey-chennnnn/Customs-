<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevMap.aspx.cs" Inherits="ECommerce.Web.Manage.DeviceMonitor.DevMap" %>

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设备位置</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
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
        <div class="pannel">
            <div class="pannel-header">
                <strong>
                    <asp:Literal ID="litDevName" runat="server"></asp:Literal></strong>
                <div class="pull-right">
                    <a href="/Manage/DeviceMonitor/DevPos.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>&did=<%=Request.QueryString["did"] %>" class="btn btn-small">列表</a>
                    <a href="/Manage/DeviceMonitor/DevMap.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>&did=<%=Request.QueryString["did"] %>" class="btn btn-small active">地图</a>
                </div>
            </div>

            <div class="pannel-body">
                <div class="btn-toolbar">
                    <a href="/Manage/DeviceMonitor/DeviceMonitor.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>" class="btn btn-mini">返回</a>
                </div>
                <div id="container" style="height: 550px; width: 100%;"></div>
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
                    var level = 5;
                    if (ps.length === 1) {
                        level = 19;
                    }
                    if (ps.length > 0) {
                        for (var i = 0; i < ps.length; i++) {
                            var po = ps[i].split(',');
                            if (po.length === 3) {
                                point = new BMap.Point(po[1], po[0]);
                                if (pointtmp == undefined) {
                                    pointtmp = point;
                                    map.centerAndZoom(point, level);
                                }
                                addMarker(point, po[2]);
                            }
                        }
                    }
                </script>
            </div>
        </div>
    </form>
</body>
</html>
