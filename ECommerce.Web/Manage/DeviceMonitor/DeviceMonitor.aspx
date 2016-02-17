﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeviceMonitor.aspx.cs" Inherits="ECommerce.Web.Manage.DeviceMonitor.DeviceMonitor" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>设备监控</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
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
        function openModal(url, title) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
            window.top.$modal.show();
        }
        function navIframe(url) {
            $("#mainFrame", top.document.body).attr("src", url);
        }
    </script>
</head>
<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel" style="border-top: none">
            <div class="pannel-header">
                <strong>设备监控</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    设备名称：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="设备名称" />
                    借出人：<input type="text" runat="server" id="Text1" class="input-small" placeholder="借出人" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                </div>
                <%--<div class="btn-toolbar">
                    <a href="javascript:void(0);" class="btn btn-mini" onclick="addData();">新增</a>
                    <asp:LinkButton ID="btnDelAll" class="btn btn-mini" OnClientClick="return confirm('你确定要删除吗？')" runat="server" OnClick="btnDelAll_Click">删除</asp:LinkButton>
                </div>--%>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">设备名称</th>
                        <th nowrap="nowrap">借出时间</th>
                        <th nowrap="nowrap">借出人</th>
                        <th nowrap="nowrap">最后记录时间</th>
                        <th nowrap="nowrap">查看位置</th>
                        <%--<th nowrap="nowrap" class="act">操作</th>--%>
                    </tr>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("DID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("DeviceName")%></td>
                                <td style="text-align: center"><%#Eval("LoanDate")!=DBNull.Value?Convert.ToDateTime(Eval("LoanDate")).ToString("yyyy-MM-dd"):""%></td>
                                <td style="text-align: center"><%#Eval("Name")%></td>
                                <td style="text-align: center"><%#GetLastRecord(Eval("DID"))%></td>
                                <td style="text-align: center"><a href="/Manage/DeviceMonitor/DevPos.aspx?did=<%#Eval("DID")%>&name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>"  data-title="查看明细">查看</a></td>
                                <%--<td style="text-align: center">
                                    <a href="javascript:void(0);" class="btn btn-mini" data-title="编辑设备信息" onclick="editData('<%#Eval("DID")%>')">编辑</a>
                                    <%#GetBtn(Eval("LoanStatus"),Eval("Loanable"),Eval("DID"))%>
                                </td>--%>
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
