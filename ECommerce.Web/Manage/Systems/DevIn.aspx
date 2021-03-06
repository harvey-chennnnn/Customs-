﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevIn.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.DevIn" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <%--<script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>--%>
    <title>归还</title>
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
                    <label class="control-label" for="inputPassword">借出人：</label>
                    <div class="controls">
                        <asp:Literal ID="litLoaner" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword">借出时间：</label>
                    <div class="controls">
                        <asp:Literal ID="litLoanDate" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword">借出备注：</label>
                    <div class="controls">
                        <asp:Literal ID="litLoanDescri" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>归还时间：</label>
                    <div class="controls">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <input type="text" id="txtReturnDate" placeholder="" runat="server" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'HiddenField1\')}'})" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;"></span>归还备注：</label>
                    <div class="controls">
                        <textarea id="txtdescr" placeholder="备注" runat="server" rows="4"></textarea>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnSub" CssClass="btn btn-success" runat="server" Text="确定" OnClick="btnSub_Click" />
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script>
            function getNowFormatDate() {
                var day = new Date();
                var Year = 0;
                var Month = 0;
                var Day = 0;
                var CurrentDate = "";
                Year = day.getFullYear();
                Month = day.getMonth() + 1;
                Day = day.getDate();
                CurrentDate += Year + "-";
                if (Month >= 10) {
                    CurrentDate += Month + "-";
                }
                else {
                    CurrentDate += "0" + Month + "-";
                }
                if (Day >= 10) {
                    CurrentDate += Day;
                }
                else {
                    CurrentDate += "0" + Day;
                }
                return CurrentDate;
            }
            $("#<%=txtReturnDate.ClientID%>").attr('placeholder', getNowFormatDate);
        </script>
    </form>
</body>
</html>
