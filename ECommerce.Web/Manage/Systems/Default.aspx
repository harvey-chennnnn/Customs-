<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.Default" %>

<!DOCTYPE html>
<html>
<head>
    <link rel="shortcut icon" href="favicon.ico">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta charset="utf-8">
    <title>海关笔记本防盗系统</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css">
    <link href="/themes/sco.js/css/scojs.css" rel="stylesheet" />
    <script src="/themes/js/jquery.min.js"></script>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/themes/sco.js/js/sco.modal.js"></script>
    <script src="/themes/plugins/jquerylayout/jquery.ui.all.js"></script>
    <script src="/themes/plugins/jquerylayout/jquery.layout.min.js"></script>
    <link href="/Scripts/jquery-ui-1.8.7.custom.css" rel="stylesheet" />
    <script src="/Scripts/jquery-ui-1.8.7.custom.min.js"></script>
    <script type="text/javascript">
        $('body').on('hidden', '.modal', function () {
            $(this).removeData('modal');
        });
        var $modal;
        var $op;
        var $tmp;
        var $ajaxget;
        $(document).ready(function () {
            $('body').layout({ resizable: false, south__closable: false });
        });
        function openModal(url, title) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
            window.top.$modal.show();
        }
    </script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <!--[if lt IE 9]>
        <script src="/js/html5shiv.min.js"></script>
        <script src="/js/respond.min.js"></script>
    <![endif]-->
</head>

<body>
    <form runat="server" id="form86">
        <div class="ui-layout-center" style="overflow: hidden;">
            <iframe id="mainFrame" name="mainFrame" width="100%" height="100%" frameborder="0" scrolling="auto" src="Welcome.aspx"></iframe>
        </div>
        <div class="ui-layout-north" style="overflow: visible;">
            <div class="top clearfix">
                <div class="pull-left">
                    <div class="logo" onclick="window.location='/Manage/Systems/Default.aspx'" style="cursor: pointer">
                        <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="pull-right">
                    <div class="top-info">
                        <i class="icon-user icon-white"></i>
                        <asp:Literal ID="litUserName" runat="server"></asp:Literal>
                        登陆成功！<br>
                        <a href="javascript:void(0);" onclick="openModal('/Manage/Systems/ChangePass.aspx','修改密码')"><i class="icon-lock icon-white"></i>修改密码</a>
                        <asp:LinkButton ID="lbtnLogout" runat="server" OnClick="lbtnLogout_Click"><i class=" icon-remove-circle icon-white"></i>退出系统</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="bar">
                <div class="pull-left"><i class="icon-user"></i>当前用户角色 <strong style="color: #C30;">系统管理员</strong></div>
                <div class="pull-right"><i class="icon-time"></i>年月日 时分秒</div>
            </div>
        </div>
        <div class="ui-layout-west">
            <h3 class="titbar mb">系统菜单</h3>
            <div class="dl-menu">
                <asp:Literal ID="litRoleTree" runat="server"></asp:Literal>
            </div>
            <div style="bottom: 30px; position: absolute; text-align: center; line-height: 30px;">
                <img width="50%" height="50%" src="/images/sitelogo.png" /><br/>
                <strong>西安擎天软件科技有限公司</strong><br />
                service@angeletsoft.cn<br />
                <strong style="font-size: 16px;color:dodgerblue">4000291776</strong><br />
                西安高新技术产业开发区<br />
                锦业路69号创业研发园<br />
                瞪羚谷B座五楼504<br />
            </div>
        </div>
        <%--<div class="ui-layout-south" style="overflow: visible">
            <div class="bottom clearfix">
                <div class="pull-left">
                    <div class="logo">
                        &nbsp;
                    </div>
                </div>
                <div>
                    <strong>西安擎天软件科技有限公司</strong>
                    <div style="line-height: 14px">
                        联系电话：4000291776<br />
                        邮件地址：service@angeletsoft.cn<br />
                        联系地址：国家级西安高新技术产业开发区锦业路69号创业研发园瞪羚谷B座五楼504                        
                    </div>
                </div>
            </div>
        </div>--%>
    </form>
</body>
</html>

