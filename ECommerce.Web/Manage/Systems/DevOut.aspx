<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevOut.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.DevOut" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
    <title>借出</title>
    <style>
        .form-horizontal .controls {
            line-height: 28px;
        }
    </style>
</head>
<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword">名称：</label>
                    <div class="controls">
                        <asp:Literal ID="litDevName" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword">唯一编号：</label>
                    <div class="controls">
                        <asp:Literal ID="litPkey" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword">设备备注：</label>
                    <div class="controls">
                        <asp:Literal ID="litDescri" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>借出人：</label>
                    <div class="controls">
                        <asp:DropDownList ID="ddltype" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>借出时间：</label>
                    <div class="controls">
                        <input type="text" id="txtBirthDay" placeholder="借出时间 2114-01-01" runat="server" onfocus="WdatePicker()" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;"></span>借出备注：</label>
                    <div class="controls">
                        <textarea id="txtdescr" placeholder="借出备注" runat="server" rows="4"></textarea>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnSub" CssClass="btn btn-success" runat="server" Text="确定" OnClick="btnSub_Click" />
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
    </form>
</body>
</html>
