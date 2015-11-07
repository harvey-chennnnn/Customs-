<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="ECommerce.Web.Manage.Companies.Detail" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <style>
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
    </style>
</head>
<body class="pd" style="overflow-y: auto;">
    <form id="form5" runat="server" style="padding: 0px">
        <div class="pannel">
            <div class="pannel-header"><strong>消息明细</strong></div>
            <div class="pannel-body">
                <div class="btn-toolbar">
                    <input type="button" class="btn btn-mini" value="返回" onclick="javascript: history.back();">
                </div>
                <div class="chats-list chats" style="margin-bottom: 100px">
                    <ul>
                        <asp:Literal ID="litMsg" runat="server"></asp:Literal>
                    </ul>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
