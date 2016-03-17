<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevDetail.aspx.cs" Inherits="ECommerce.Web.Manage.Services.DevDetail" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设备明细</title>

    <link rel="stylesheet" href="/style.css">
    <%--<link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />--%>
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <script charset="utf-8" src="/themes/js/kindeditor-4.1.6/kindeditor-min.js"></script>
    <script charset="utf-8" src="/themes/js/kindeditor-4.1.6/lang/zh_CN.js"></script>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/themes/sco.js/js/sco.modal.js"></script>
    <link href="/themes/sco.js/css/scojs.css" rel="stylesheet" />
    
</head>
<body class="pd">
    <form id="form5" runat="server" style="padding: 0px">
        <div class="contents">
            <div class="right-main">
                <h3 class="title2">明细查询</h3>
                <p class="computer-name">
                    <asp:Literal ID="litDevName" runat="server"></asp:Literal><span>SN:<asp:Literal ID="litPkey" runat="server"></asp:Literal></span>
                </p>
                <p class="computer-config">配置<span><asp:Literal ID="litDescri" runat="server"></asp:Literal></span></p>
                <table width="617" cellspacing="0" class="tab1">
                    <tbody>
                        <tr>
                            <th>状态</th>
                            <th>借出人</th>
                            <th>借出时间</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litStatus" runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="litLoaner" runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="litLoanDate" runat="server"></asp:Literal></td>
                        </tr>
                    </tbody>
                </table>
                <div class="message-box" id="dMsg" runat="server" visible="False">
                    <p class="message-tit">消息：<span>(下一次借出时消息转移至历史)</span> </p>
                    <asp:Literal ID="litMsg" runat="server"></asp:Literal>
                    
                    <p class="message-input-box clearfix">
                        <textarea name="textarea" class="message-input"></textarea>
                        <button type="submit" class="message-btn">发送消息</button>
                    </p>
                </div>
                <p class="history">借出历史</p>
                <table width="617" cellspacing="0" class="tab2">
                    <tbody>
                        <tr>
                            <th>借出人</th>
                            <th>借出时间</th>
                            <th>归还时间</th>
                            <th>经办人</th>
                        </tr>
                        <asp:Repeater ID="rptListWork" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="text-align: center"><%#Eval("Name")%></td>
                                    <td style="text-align: center"><%#Eval("LoanDate")!=DBNull.Value?Convert.ToDateTime(Eval("LoanDate")).ToString("yyyy-MM-dd"):""%></td>
                                    <td style="text-align: center"><%#Eval("ReturnDate")!=DBNull.Value?Convert.ToDateTime(Eval("ReturnDate")).ToString("yyyy-MM-dd"):""%></td>
                                    <td style="text-align: center"><%#Eval("OpName")%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
