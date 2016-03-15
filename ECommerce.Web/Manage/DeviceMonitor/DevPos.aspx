<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevPos.aspx.cs" Inherits="ECommerce.Web.Manage.DeviceMonitor.DevPos" %>

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
</head>
<body class="pd">
    <form id="form5" runat="server" style="padding: 0px;">
        <div class="pannel">
            <div class="pannel-header">
                <strong>
                    <asp:Literal ID="litDevName" runat="server"></asp:Literal></strong>
                <div class="pull-right">
                    <a href="/Manage/DeviceMonitor/DevPos.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>&did=<%=Request.QueryString["did"] %>" class="btn btn-small active">列表</a>
                    <a href="/Manage/DeviceMonitor/DevMap.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>&did=<%=Request.QueryString["did"] %>" class="btn btn-small">地图</a>
                </div>
            </div>

            <div class="pannel-body">
                <div class="btn-toolbar">
                    <a href="/Manage/DeviceMonitor/DeviceMonitor.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>" class="btn btn-mini">返回</a>
                </div>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <h5>记录<%# Container.ItemIndex+1 %>：</h5>
                        <div class="dev-pos">
                            <p>记录时间=<%#Eval("TraceTime")!=DBNull.Value?Convert.ToDateTime(Eval("TraceTime")).ToString("yyyy-MM-dd hh:mm:ss"):""%></p>
                            <p>Wi-Fi定位经纬度=<%#Eval("WifiLat")%> <a href="/Manage/DeviceMonitor/DevMap.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>&did=<%=Request.QueryString["did"] %>&tid=<%#Eval("TraceId")%>">查看地图</a></p>
                            <p>服务器地址=<%#Eval("ServiceIp")%></p>
                            <p>Windows登陆名=<%#Eval("LogonName")%></p>
                            <p>计算机名称=<%#Eval("ComputerName")%></p>
                            <p>本机IP地址=<%#GetIp(Eval("LocalIp"))%></p>
                            <p>穿透代理,直接获得的IP地址=<%#GetIp(Eval("ProxyIpFirst"))%></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
