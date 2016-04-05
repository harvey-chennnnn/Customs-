<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevPos.aspx.cs" Inherits="ECommerce.Web.Manage.DeviceMonitor.DevPos" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
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
</head>
<body class="pd">
    <form id="form5" runat="server" style="padding: 0px;">
        <div class="contents">
            <div class="position-history-box">
                <div class="map-btn-box"><a href="/Manage/DeviceMonitor/DevPos.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>&did=<%=Request.QueryString["did"] %>" class="on">列表</a><a href="/Manage/DeviceMonitor/DevMap.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>&did=<%=Request.QueryString["did"] %>">地图</a></div>
                <p class="position-history-title"><span>
                    <asp:Literal ID="litLoaner" runat="server"></asp:Literal></span><asp:Literal ID="litDevName" runat="server"></asp:Literal>的位置记录</p>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="position-history-list">
                            <p class="position-history-list-title"><span><%#(pageNum-1)*pageSize+ Container.ItemIndex+1 %></span>记录时间=<%#Eval("TraceTime")!=DBNull.Value?Convert.ToDateTime(Eval("TraceTime")).ToString("yyyy-MM-dd hh:mm:ss"):""%></p>
                            <div class="clearfix position-history-imformation">
                                <p class="position1">
                                    <span>Wi-Fi定位经纬度</span> = <%#Eval("WifiLat")%><br>
                                    <span>服务器地址</span> = <%#Eval("ServiceIp")%><br>
                                    <span>Windows登陆名</span> = <%#Eval("LogonName")%>
                                </p>
                                <a href="/Manage/DeviceMonitor/DevMap.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>&did=<%=Request.QueryString["did"] %>&tid=<%#Eval("TraceId")%>" class="search-map-btn">查看地图</a>
                                <p class="position2">
                                    <span>计算机名称</span> = <%#Eval("ComputerName")%><br>
                                    <span>本机IP地址</span> = <%#GetIp(Eval("LocalIp"))%><br>
                                    <span>穿透代理,直接获得的IP地址</span> = <%#GetIp(Eval("ProxyIpFirst"))%>
                                </p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <uc1:Pager ID="Pager" runat="server" />
            </div>
        </div>

    </form>
</body>
</html>
