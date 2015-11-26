<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProfInfo.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.AddProfInfo" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <%--<script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>--%>
    <title>设备维护</title>
</head>
<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>名称：</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="名称" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>唯一编号：</label>
                    <div class="controls">
                        <input type="text" id="Text1" placeholder="唯一编号" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>可否借出：</label>
                    <div class="controls">
                        <asp:DropDownList ID="ddltype" runat="server">
                            <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="否" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;"></span>采购部门：</label>
                    <div class="controls">
                        <input type="text" id="txtage" placeholder="采购部门" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;"></span>采购人：</label>
                    <div class="controls">
                        <input type="text" id="txtaddr" placeholder="采购人" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>入库时间：</label>
                    <div class="controls">
                        <input type="text" id="txtBirthDay" placeholder="" runat="server" onfocus="WdatePicker()" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;"></span>备注：</label>
                    <div class="controls">
                        <textarea id="txtdescr" placeholder="备注" runat="server" rows="10"></textarea>
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
            $("#<%=txtBirthDay.ClientID%>").attr('placeholder', getNowFormatDate);
        </script>
    </form>
</body>
</html>
