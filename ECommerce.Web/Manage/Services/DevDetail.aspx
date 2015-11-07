<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevDetail.aspx.cs" Inherits="ECommerce.Web.Manage.Services.DevDetail" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设备明细</title>

    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <script charset="utf-8" src="/themes/js/kindeditor-4.1.6/kindeditor-min.js"></script>
    <script charset="utf-8" src="/themes/js/kindeditor-4.1.6/lang/zh_CN.js"></script>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/themes/sco.js/js/sco.modal.js"></script>
    <link href="/themes/sco.js/css/scojs.css" rel="stylesheet" />
    <style>
        .table-form .tf-label {
            padding-top: 4px;
        }

        img {
            border: 0;
        }


        ul, ol {
            margin-top: 0px;
            margin-bottom: 10px;
        }



        .chats ul {
            padding: 15px;
            list-style: none;
            margin: 0;
        }

            .chats ul li {
                overflow: hidden;
                zoom: 1;
                padding: 8px 0;
                text-shadow: none;
            }

        img {
            vertical-align: middle;
        }

        img {
            max-width: 100%;
        }

        .img-circle {
            border-radius: 50%;
        }

        .img-circle {
            width: 32px;
            height: 32px;
        }

        .chats ul li.out .avatar {
            float: right;
        }

        .chats ul li .message {
            float: left;
            padding: 15px;
            background-color: #fff;
            word-wrap: break-word;
            break-word: break-all;
            border-radius: 8px;
            margin-left: 5px;
        }

        .chats ul li.out .message {
            float: right;
            background-color: #2f90be;
            color: #fff;
        }

        .chats ul li .message .name {
            font-size: 12px;
        }

        .chats ul li.out .message .name {
            color: #fff;
        }

        .chats ul li .message .datetime {
            font-size: 11px;
        }

        .chats ul li .message .body {
            display: block;
            padding-top: 8px;
        }

        .chats ul li.in .avatar {
            float: left;
        }

        .chats ul li.in .message {
            float: left;
            background-color: #fff;
            box-shadow: 0px 3px 2px #ddd;
            border: 1px solid #ddd;
        }

        .form-control {
            width: 100%;
            border-radius: 0;
            box-shadow: none;
            border: solid 1px #ddd;
        }

        textarea.form-control {
            height: auto;
        }

        .pull-right {
            float: right !important;
        }

        .pull-right {
            float: right !important;
        }

        .table th {
            border-bottom-width: 1px;
            background-image: none;
            background-color: transparent;
            border-bottom-color: #ccc;
        }
    </style>
</head>
<body class="pd">
    <form id="form5" runat="server" style="padding: 0px">
        <div class="pannel">
            <div class="pannel-header">
                <strong>设备明细</strong>
            </div>

            <div class="pannel-body">
                <div class="btn-toolbar">
                    <a href="/Manage/Services/ProfInfo.aspx?name=<%=Request.QueryString["name"] %>&loaner=<%=Request.QueryString["loaner"] %>&Page=<%=Request.QueryString["Page"] %>" class="btn btn-mini">返回</a>
                </div>
                <table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="table-form">
                    <tr>
                        <td class="tf-label">名称：
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="litDevName" runat="server"></asp:Literal>
                        </td>
                        <td class="tf-label">唯一编号
                        </td>
                        <td class="tf-con">
                            <asp:Literal ID="litPkey" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="tf-label">备注：</td>
                        <td colspan="3" valign="top" class="tf-con">
                            <div style="width: 450px;">
                                <asp:Literal ID="litDescri" runat="server"></asp:Literal>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="tf-label">状态：</td>
                        <td colspan="3" valign="top" class="tf-con">
                            <asp:Literal ID="litStatus" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="tf-label">借出人：</td>
                        <td valign="top" class="tf-con">
                            <asp:Literal ID="litLoaner" runat="server"></asp:Literal>
                        </td>
                        <td valign="top" class="tf-label">借出时间：</td>
                        <td valign="top" class="tf-con">
                            <asp:Literal ID="litLoanDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
                <div id="dMsg" runat="server" visible="False">
                    <strong>消息：</strong>
                    <div class="chats-list chats" style="border: solid 1px #ddd;">
                        <asp:Literal ID="litMsg" runat="server"></asp:Literal>
                    </div>
                    <div style="margin-top: 10px;">
                        <textarea name="textarea" class="form-control" rows="3" cols="20"></textarea>
                        <div style="margin-top: 5px;">
                            <div class="pull-right">
                                <div class="btn-group btn-group-sm" style="margin-left: 15px;">
                                    <button type="submit" class="btn btn-success">发送消息</button>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div style="margin-top: 50px;">
                    <strong>借出历史：</strong>
                    <table class="table table-bordered" border="0" id="tabList" style="/*width: 70%; margin: 0*/">
                        <tr>
                            <th nowrap="nowrap">借出人</th>
                            <th nowrap="nowrap">借出时间</th>
                            <th nowrap="nowrap">归还时间</th>
                            <th nowrap="nowrap">经办人</th>
                        </tr>
                        <asp:Repeater ID="rptListWork" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="text-align: center"><%#Eval("Loaner")%></td>
                                    <td style="text-align: center"><%#Eval("LoanDate")!=DBNull.Value?Convert.ToDateTime(Eval("LoanDate")).ToString("yyyy-MM-dd"):""%></td>
                                    <td style="text-align: center"><%#Eval("ReturnDate")!=DBNull.Value?Convert.ToDateTime(Eval("ReturnDate")).ToString("yyyy-MM-dd"):""%></td>
                                    <td style="text-align: center"><%#Eval("OpName")%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
