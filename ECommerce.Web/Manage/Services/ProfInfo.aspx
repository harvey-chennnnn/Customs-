<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfInfo.aspx.cs" Inherits="ECommerce.Web.Manage.Services.ProfInfo" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>设备列表</title>
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
        function addData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddProfInfo.aspx?aId=' + aId, title: '新增设备信息' });
            window.top.$modal.show();
        }
        function editData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddProfInfo.aspx?OrgId=' + aId, title: '编辑设备信息' });
            window.top.$modal.show();
        }
        function devOut(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/DevOut.aspx?OrgId=' + aId, title: '借出' });
            window.top.$modal.show();
        }
        function devIn(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/DevIn.aspx?OrgId=' + aId, title: '归还' });
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
                <strong>设备列表</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    设备名称：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="设备名称" />
                    借出人：<input type="text" runat="server" id="Text1" class="input-small" placeholder="借出人" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                </div>
                <div class="btn-toolbar">
                    <a href="javascript:void(0);" class="btn btn-mini" onclick="addData();">新增</a>
                    <asp:LinkButton ID="btnDelAll" class="btn btn-mini" OnClientClick="return confirm('你确定要删除吗？')" runat="server" OnClick="btnDelAll_Click">删除</asp:LinkButton>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">设备名称</th>
                        <th nowrap="nowrap">可否借出</th>
                        <th nowrap="nowrap">借出状态</th>
                        <th nowrap="nowrap">借出时间</th>
                        <th nowrap="nowrap">借出人</th>
                        <th nowrap="nowrap">入库时间</th>
                        <th nowrap="nowrap">查看明细</th>
                        <th nowrap="nowrap" class="act">操作</th>
                    </tr>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("DID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("DeviceName")%></td>
                                <td style="text-align: center"><%#Eval("Loanable").ToString()=="1"?"是":"否"%></td>
                                <td style="text-align: center"><%#Eval("LoanStatus").ToString()=="1"?"已借出":"未借出"%></td>
                                <td style="text-align: center"><%#Eval("LoanDate")!=DBNull.Value?Convert.ToDateTime(Eval("LoanDate")).ToString("yyyy-MM-dd"):""%></td>
                                <td style="text-align: center"><%#Eval("Name")%></td>
                                <td style="text-align: center"><%#Convert.ToDateTime(Eval("EnteringDate")).ToString("yyyy-MM-dd")%></td>
                                <td style="text-align: center"><a href="/Manage/Services/DevDetail.aspx?did=<%#Eval("DID")%>&name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>" class="btn btn-mini" data-title="查看明细">查看</a></td>
                                <td style="text-align: center">
                                    <a href="javascript:void(0);" class="btn btn-mini" data-title="编辑设备信息" onclick="editData('<%#Eval("DID")%>')">编辑</a>
                                    <%#GetBtn(Eval("LoanStatus"),Eval("Loanable"),Eval("DID"))%>
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
