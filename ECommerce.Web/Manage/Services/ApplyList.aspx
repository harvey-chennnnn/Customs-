<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyList.aspx.cs" Inherits="ECommerce.Web.Manage.Services.ApplyList" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>消息列表</title>
    <link rel="stylesheet" href="/style.css">
    <%--<link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript" src="/themes/js/jquery-1.8.0.min.js"></script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <script src="/themes/sco.js/js/sco.modal.js"></script>
</head>
<script type="text/javascript">

    $(function () {
        $("#cbSelectAll").click(function () {
            if ($(this).attr("checked")) {

                $("#tabList input").attr("checked", $(this).attr("checked"));
            }
            else {
                $("#tabList input").attr("checked", false);
            }
        })
    })


</script>
<body class="pd">
    <form id="form1" runat="server">
        <div class="modal hide fade" id="myModal">
            <div class="modal-body">
            </div>
        </div>
        <div class="pannel">
            <%--<div class="pannel-header">
                <strong>消息列表</strong>
            </div>--%>
            <div class="pannel-body">

                <div class="form-inline">
                    <span>发送人：</span><input type="text" runat="server" id="txtProName" placeholder="发送人" class="input-small" />

                    <%--状态：<asp:DropDownList runat="server" ID="ddlStatus" Width="120px" OnSelectedIndexChanged="btnSearch_Click" AutoPostBack="True">
                        <asp:ListItem Value="-1" Selected="True">处理状态</asp:ListItem>
                        <asp:ListItem Value="0">未处理</asp:ListItem>
                        <asp:ListItem Value="1">已处理</asp:ListItem>
                    </asp:DropDownList>--%>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" OnClick="btnSearch_Click" Text="搜索" />
                </div>
                <%--<div class="btn-toolbar" style="margin-top: 10px">

                    <asp:LinkButton ID="btnCheck" class="btn btn-mini" OnCommand="btnCheck_Click" runat="server">处理</asp:LinkButton>
                    <asp:LinkButton ID="btnoBackCheck" class="btn btn-mini" OnCommand="btnBackCheck_Click" OnClientClick="return confirm('你确定要取消吗？')" runat="server">取消</asp:LinkButton>

                </div>--%>
                <div class="contents">
                    <table class="table table-bordered" border="0" style="width: 100%" id="tabList">
                        <tr><th class="thd"></th>
                            <th class="id" nowrap="nowrap" style="text-align: center">
                                <input type="checkbox" name="cbSelectAll" id="cbSelectAll"></th>
                            <th nowrap="nowrap" style="text-align: center">发送人
                            </th>
                            <th nowrap="nowrap" style="text-align: center">接收人
                            </th>
                            <th nowrap="nowrap" style="text-align: center">内容
                            </th>
                            <th nowrap="nowrap" style="text-align: center">发送时间
                            </th><th class="thd"></th>
                        </tr>
                        <asp:Repeater ID="rptArticle" runat="server">
                            <ItemTemplate>
                                <tr><td class="tbd"></td>
                                    <td style="text-align: center">
                                        <asp:CheckBox ID="cbSelect" Name="cbSelect" ToolTip='<%#Eval("InfoId") %>' Text="" runat="server" /></td>
                                    <td style="text-align: center">
                                        <%#Eval("FromUser")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%#GetName(Eval("username"))%>
                                    </td>
                                    <td style="text-align: center">
                                        <a class="btn btn-mini" href="/Manage/Companies/Detail.aspx?fu=<%#Eval("FromUser") %>&tu=<%#Eval("username") %>"><%#Eval("Message")%></a>
                                    </td>
                                    <td style="text-align: center"><%#Convert.ToDateTime(Eval("CreateTime")).ToString("yyyy-MM-dd")%></td>
                                <td class="tbd"></td></tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <uc1:Pager ID="Pager" runat="server" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
