<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEnterprise.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.AddEnterprise" %>
<%@ Import Namespace="ECommerce.Lib.Security" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title><%= SecurityMgr.GetEntName() %></title>
</head>
<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <div class="control-label"><span style="color: red">*</span>企业ID：</div>
                    <div class="controls">
                        <input type="text" id="txtEnterpriseID" runat="server" placeholder="请输入企业ID" />
                    </div>
                </div>
                <div class="control-group">
                    <div class="control-label">企业名称：</div>
                    <div class="controls">
                        <input type="text" id="txtEnterpriseName" runat="server" placeholder="请输入企业名称" />
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
