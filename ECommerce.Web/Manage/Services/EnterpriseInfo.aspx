<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterpriseInfo.aspx.cs" Inherits="ECommerce.Web.Manage.Services.EnterpriseInfo" %>
<%@ Import Namespace="ECommerce.Lib.Security" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8" />
    <title><%= SecurityMgr.GetEntName() %></title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
</head>
<script type="text/javascript">
    $(function () {
        $("#cboSelectAll").click(function () {
            if ($(this).attr("checked")) {
                $("#tabRole input").attr("checked", $(this).attr("checked"));
            } else {
                $("#tabRole input").attr("checked", false);
            }
        });
    });
    function addData() {
        window.top.$op = this;
        window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddEnterprise.aspx', title: '新增企业' });
        window.top.$modal.show();
    }
    function editData(aId) {
        window.top.$op = this;
        window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddEnterprise.aspx?empId=' + aId, title: '编辑企业信息' });
        window.top.$modal.show();
    }
    function openModal(url, title) {
        window.top.$op = this;
        window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
        window.top.$modal.show();
    }
</script>
<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel">
            <div class="pannel-header">
                <strong>企业管理</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    企业名称：<input type="text" runat="server" id="txtRealName" placeholder="企业名称" class="input-small" />
                    <asp:Button ID="btnSearchRole" runat="server" CssClass="btn btn-success" OnClick="btnSearchRole_Click" Text="搜索" />
                </div>
                <div class="btn-toolbar">
                    <a href="javascript:void(0);" class="btn btn-mini" onclick="addData();">新增</a>
                    <asp:LinkButton ID="btndelRole" class="btn btn-mini" OnCommand="btnDelAll_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
                </div>
                <table class="table table-bordered" border="0" id="tabRole">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cboSelectAll" id="cboSelectAll"></th>
                        <th nowrap="nowrap">企业ID</th>
                        <th nowrap="nowrap">企业名称</th>
                        <th nowrap="nowrap">创建时间</th>
                        <th nowrap="nowrap" class="act">操作</th>
                    </tr>
                    <asp:Repeater ID="RepeaterMyRole" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbSalesRole" Name="cbSalesRole" ToolTip='<%#Eval("ELID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("EnterpriseID")%> </td>
                                <td style="text-align: center"><%#Eval("EnterpriseName")%></td>
                                <td style="text-align: center"><%#Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td style="text-align: center">
                                    <a href="javascript:void(0);" class="btn btn-mini" onclick="editData('<%#Eval("ELID")%>')">编辑</a>
                                    <asp:LinkButton ID="btnDeleteRole" CssClass="btn btn-mini" CommandName='<%#Eval("ELID")%>' OnCommand="lbtnDel_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
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
