<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerce.Web.Manage.Systems.Default" %>

<%@ Import Namespace="ECommerce.Lib.Security" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title><%= SecurityMgr.GetEntName() %><asp:Literal ID="litTitle" runat="server"></asp:Literal></title>
    <link rel="stylesheet" href="/style.css">
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css">
    <link href="/themes/sco.js/css/scojs.css" rel="stylesheet" />
    <script src="/themes/js/jquery.min.js"></script>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/themes/sco.js/js/sco.modal.js"></script>
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
        function openModal(url, title) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
            window.top.$modal.show();
        }
        function resizeIframe(obj) {
            var mainheight = $(obj).contents().find("body").height();
            $(obj).height(mainheight);
            //obj.style.height = obj.contentWindow.document.body.scrollHeight + 'px';
        }
    </script>
    <%--<script src="/themes/plugins/adminjs/admin.page.js"></script>--%>
</head>

<body>
    <form runat="server" id="form86">
        <div class="wrap">
            <div class="top-thing">
				<i class="logo1"></i>
				<i class="logo2"></i>
				<div class="user-box clearfix">
					<div class="user-icon-box"><%--<img src="/image/user-img.png" alt="">--%><i></i></div>
					<div class="user-name clearfix">
						<a href="javascript:;"><asp:Literal ID="litUserName" runat="server"></asp:Literal></a>
						<i class="btn1"></i>
					</div>
					<div class="other-btn">
						<a href="javascript:;" onclick="openModal('/Manage/Systems/ChangePass.aspx','修改密码')">修改密码</a>
                        <asp:LinkButton ID="lbtnLogout" runat="server" OnClick="lbtnLogout_Click">退出系统</asp:LinkButton>
					</div>
				</div>
			</div>
            
            <div class="content clearfix">
                <div class="left-box" id="left-box">
                    <asp:Literal ID="litRoleTree" runat="server"></asp:Literal>
                </div>
                <div class="right" id="right-box">
                    <h2 class="title" id="tname">&nbsp;</h2>
                    <div class="right-main-box right-main-box2">
                    <iframe id="mainFrame" name="mainFrame" width="100%" height="100%" frameborder="0" scrolling="auto"  src="Welcome.aspx"></iframe></div>
                </div>
            </div>
            <div class="footer">
                <div class="footer-text clearfix">
                    <p class="footer-left">
                        西安擎天软件科技有限公司&nbsp;service@angeletsoft.cn
						<br />
                        <span>地址：西安高新技术产业开发区 锦业路69号创业研发园 瞪羚谷B座五楼504</span>
                    </p>
                    <a href="javascript:;" class="telephone"></a>
                    <a href="javascript:;" class="angle-logo"></a>
                </div>
            </div>
        </div>
    </form>
</body>
<script src="/base.js"></script>
<script>
    $("#tab4").find("td").hover(function () {
        $(this).parent('tr').addClass('on').siblings().removeClass('on')
    }, function () {
        $(this).parent('tr').removeClass('on').siblings().removeClass('on')
    })

    $('.left-box dl').click(function() {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
            $(this).siblings().find("dd").hide();
        } else {
            $(this).removeClass('active');
            $(this).addClass('active');
            $(this).siblings().find("dd").hide();
            $(this).find("dd").slideDown();
        }
    });
    var frame = $("#mainFrame");
    var alink = $(".left-box dd ");
    alink.click(function () {
        //alert("跳转到页面"+$(this).children().find('a').attr('name'));	
        $("#tname").html($(this).text());
        frame.attr("src", $(this).attr('name'));
    })

</script>
</html>
