﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerce.Web.Manage.Companies.Default" %>
<%@ Import Namespace="ECommerce.Lib.Security" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title><%= SecurityMgr.GetEntName() %></title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#cbSelAll").click(function () {
                if ($(this).attr("checked")) {
                    $("#tabList input").attr("checked", $(this).attr("checked"));
                } else {
                    $("#tabList input").attr("checked", false);
                }
            });
        });
    </script>
</head>
<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel" style="border-top: none">
            <div class="pannel-header">
                <strong>测评企业</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    企业名称：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="企业名称" />
                    测评日期：<input type="text" placeholder="开始日期" runat="server" onfocus="WdatePicker()" id="Text1" class="input-small" />
                    - <input type="text" placeholder="结束日期" runat="server" onfocus="WdatePicker()" id="Text2" class="input-small" />
                    测评师：<input type="text" runat="server" id="txtUser" class="input-small" placeholder="测评师" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                    <%--<asp:Button ID="btnExport" runat="server" CssClass="btn btn-success" Text="导出" OnClick="btnExport_Click"/>--%>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">企业编号</th>
                        <th nowrap="nowrap">企业名称</th>
                        <%--<th nowrap="nowrap">性别</th>
                        <th nowrap="nowrap">电话</th>
                        <th nowrap="nowrap">人员类型</th>--%>
                        <th nowrap="nowrap">测评师</th>
                        <th nowrap="nowrap">录入时间</th>
                        <th class="act" nowrap="nowrap" style="width: 300px;">查看详情</th>
                    </tr>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("ID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("ComID")%></td>
                                <td style="text-align: center"><%#Eval("ComName")%></td>
                                <%--<td style="text-align: center"><%#Eval("Sex").ToString()=="1" ? "男":"女"%></td>
                                <td style="text-align: center"><%#Eval("Phone")%></td>
                                <td style="text-align: center"><%#GetRoleName(Eval("Type"))%></td>
                                <td style="text-align: center"><%#Eval("OrgName")%></td>--%>
                                <td style="text-align: center"><%#Eval("EmplName")%></td>
                                <td style="text-align: center"><%#Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td class="act" style="width: 300px;">
                                    <a href="Detail.aspx?id=<%#Eval("ID") %>" class="btn btn-mini">基本信息</a> <a href="/Manage/BaselineData/Detail.aspx?id=<%#Eval("ComID") %>" class="btn btn-mini">测评数据</a> <a href="/Manage/MeasurementData/Detail.aspx?id=<%#Eval("ComID") %>" class="btn btn-mini">对比数据</a> <a href="Report.aspx?id=<%#Eval("ComID") %>" class="btn btn-mini">报告下载</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <uc1:Pager ID="Pager1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
