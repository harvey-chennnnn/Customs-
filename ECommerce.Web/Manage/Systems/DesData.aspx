<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesData.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.DesData" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>警告</title>
    <style>
        .modal-header {
            background-color: red;
        }

        .btn, .btn:hover, .btn:focus {
            background-position: 0 30px;
        }
        .btn-success {
            background-image: -webkit-gradient(linear,0 0,0 100%,from(red),to(red));
            background-image: -webkit-linear-gradient(top,red,red);
        }
    </style>
</head>
<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body" id="dcontext">
                <h1 style="text-align: center; color: red">警告</h1>
                <div>
                    <p>
                        您现在要 销毁
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>上的数据。
                    </p>
                    <p>点击确定销毁后，该电脑上除系统盘外所有数据将被清空并且不可恢复！</p>
                    <p>请谨慎操作！</p>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAdd(this);" class="btn btn-success" style="background-color: red">确定销毁</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script type="text/javascript">
            function goAdd(obj) {
                $.ajax({
                    type: 'POST', url: '/Manage/Systems/Ajax/DesData.aspx?did=<%=Request.QueryString["did"]%>', success: function (data) {
                        if (data != "") {
                            $("#dcontext").html(data);
                            $(obj).hide();
                        }
                    }
                });
            }
        </script>
    </form>
</body>
</html>
