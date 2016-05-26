<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevOut.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.DevOut" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <%--<script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>--%>
    <%--<link href="/Scripts/jquery-ui-1.8.7.custom.css" rel="stylesheet" />
    <script src="/Scripts/jquery-ui-1.8.7.custom.min.js"></script>--%>
    <title>借出</title>
    <style>
        .form-horizontal .controls {
            line-height: 28px;
        }

        .ui-menu .ui-menu-item {
            WIDTH: 214px;
        }

        .ui-autocomplete {
            max-height: 150px;
            overflow-y: auto;
            /* prevent horizontal scrollbar */
            overflow-x: hidden;
        }

        * html .ui-autocomplete {
            height: 100px;
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
                        <input type="text" id="txtDId" placeholder="借出人" runat="server" />
                        <span id="spError" style="color: red;"></span>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <%--<asp:DropDownList ID="ddltype" runat="server">
                        </asp:DropDownList>--%>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>借出时间：</label>
                    <div class="controls">
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                        <input type="text" id="txtBirthDay" placeholder="" runat="server" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'HiddenField2\')}'})" />
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
        <script>
            $(document).ready(function () {
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
                $("#txtDId").autocomplete({
                    minLength: 1,
                    source: function (request, response) {
                        $.ajax({
                            type: "GET",
                            url: "ProductAutoComplete.aspx",
                            dataType: "json",
                            data: {
                                term: request.term
                            },
                            //error: function (xhr, textStatus, errorThrown) {
                            //    alert('Error: ' + xhr.responseText);
                            //},
                            success: function (data) {
                                response(data);
                                if (data == "" || data == null) {
                                    $("#<%=HiddenField1.ClientID%>").val('');
                                    $("#spError").html("查无此人");
                                } else {
                                    $("#spError").html("");
                                }
                            }
                        });
                    },
                    open: function (event, ui) {
                        $(this).autocomplete("widget").css({ "width": "214px" });
                    },
                    select: function (a, b) {
                        $(this).val(b.item.label);
                        $(".ui-autocomplete").addClass("txb");
                        $("#<%=HiddenField1.ClientID%>").val(b.item.value);
                        $(this).addClass("txb");
                        $(this).blur();
                        return false;
                    },
                    close: function () {
                        if (!$(".ui-autocomplete").hasClass("txb")) {
                            $(this).val('');
                        }
                        $(".ui-autocomplete").removeClass("txb");
                        $(this).blur();
                        return false;
                    }
                }).bind("input.autocomplete", function () {
                    $(this).trigger('keydown.autocomplete');
                });
            });

        </script>
    </form>
</body>
</html>
