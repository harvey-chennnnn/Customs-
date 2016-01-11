<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAUInfo.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.AddAUInfo" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <%--<script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>--%>
    <title>员工管理</title>
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
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>姓名：</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="名称" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>小天使帐户名：</label>
                    <div class="controls">
                        <input type="text" id="txtDId" placeholder="小天使帐户名" runat="server" />
                        <span id="spError" style="color: red;"></span>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
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
                $("#txtDId").autocomplete({
                    minLength: 1,
                    source: function (request, response) {
                        $.ajax({
                            type: "GET",
                            url: "AUserAutoComplete.aspx",
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
                                    $("#<%=HiddenField2.ClientID%>").val('');
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
                        $("#<%=HiddenField2.ClientID%>").val(b.item.entId);
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
