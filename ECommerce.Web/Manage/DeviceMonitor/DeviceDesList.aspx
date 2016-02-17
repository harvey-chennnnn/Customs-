<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeviceDesList.aspx.cs" Inherits="ECommerce.Web.Manage.DeviceMonitor.DeviceDesList" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>销毁列表</title>
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
        function editData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/DesData.aspx?OrgId=' + aId, title: '数据销毁' });
            window.top.$modal.show();
        }
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
                <strong>销毁列表</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    设备名称：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="设备名称" />
                    借出人：<input type="text" runat="server" id="Text1" class="input-small" placeholder="借出人" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">设备名称</th>
                        <th nowrap="nowrap">借出时间</th>
                        <th nowrap="nowrap">借出人</th>
                        <th nowrap="nowrap">当前状态</th>
                        <th nowrap="nowrap">销毁指令发送时间</th>
                        <th nowrap="nowrap">状态改变时间</th>
                    </tr>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("DID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("DeviceName")%></td>
                                <td style="text-align: center"><%#Eval("LoanDate")!=DBNull.Value?Convert.ToDateTime(Eval("LoanDate")).ToString("yyyy-MM-dd"):""%></td>
                                <td style="text-align: center"><%#Eval("Name")%></td>
                                <td style="text-align: center"></td>
                                <td style="text-align: center"></td>
                                <td style="text-align: center"></td>
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
