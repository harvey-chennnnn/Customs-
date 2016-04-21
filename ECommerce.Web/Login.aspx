<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ECommerce.Web.Login" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title>登录</title>
    <style>
        * {
            margin: 0;
            padding: 0;
        }

        .clearfix:after {
            visibility: hidden;
            display: block;
            font-size: 0;
            content: " ";
            clear: both;
            height: 0;
        }

        .clearfix {
            zoom: 1;
        }

        html, body {
            width: 100%;
            height: 100%;
        }

        .wrap {
            width: 100%;
            height: 100%;
            background: url(image/login-bg.jpg) 0 0 no-repeat;
            -webkit-background-size: 100% 100%;
            background-size: 100% 100%;
        }

        .logo-text {
            width: 446px;
            height: 225px;
            background: url(image/login.png) no-repeat;
            margin: 50px auto 50px;
        }

        .user-name-icon, .text-box, .user-password-icon {
            background-image: url(image/sp.png);
            background-repeat: no-repeat;
        }

        .login-box {
            margin: 0 auto;
            width: 354px;
        }

        .text-box {
            background-position: -52px -155px;
            width: 355px;
            height: 47px;
        }

            .text-box .user-name-icon {
                float: left;
                background-position: -186px 0;
                width: 23px;
                height: 26px;
                margin-left: 25px;
                margin-top: 10px;
            }

            .text-box input {
                float: left;
                height: 47px;
                padding: 0;
                background: transparent;
                outline: none;
                border-width: 0px;
                font-size: 20px;
                letter-spacing: 1px;
                padding-left: 15px;
                line-height: 47px;
            }

        .password-box .user-password-icon {
            background-position: 0 -76px;
            width: 22px;
        }

        .password-box {
            position: relative;
            margin-top: 20px;
        }

        .forget-tips {
            position: absolute;
            right: -80px;
            line-height: 47px;
            font-size: 12px;
            color: #ffffff;
            text-decoration: none;
        }

        .login-miss {
            line-height: 40px;
            text-align: center;
            font-size: 13px;
            color: #fbdb00;
        }

        .login-btn {
            width: 120px;
            height: 37px;
            line-height: 37px;
            text-align: center;
            font-size: 14px;
            color: #ffffff;
            text-align: center;
            margin: 0 auto;
            display: block;
            background: #39a0ff;
            border-radius: 5px;
            text-decoration: none;
        }

        .login-ok-box {
            text-align: center;
            padding-top: 15px;
            width: 354px;
            margin: 0 auto;
        }

            .login-ok-box a {
                color: #ffffff;
                font-size: 24px;
                text-decoration: none;
            }

        .forget-tips2 {
            /*margin-right: 15px;*/
        }

        .login-ok-box span {
            padding: 0 5px;
            color: #ffffff;
        }

        .login .forget-tips, .login .login-miss-box {
            display: none;
        }

        .login .login-ok-box {
            display: block;
        }

        .login-false .forget-tips, .login-false .login-miss-box {
            display: block;
        }

        .login-false .login-ok-box {
            display: none;
        }
    </style>

</head>

<body>
    <div class="wrap">
        <div class="login">
            <form id="focus" name="form1" runat="server" autocomplete="off">
                <input style="display: none">
                <input type="password" style="display: none">
                <p>&nbsp;</p>
                <div class="logo-text"></div>
                <div class="login-box">
                    <div class="text-box clearfix">
                        <i class="user-name-icon"></i>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="user-name" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="text-box password-box clearfix">
                        <i class="user-name-icon user-password-icon"></i>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="user-name"></asp:TextBox>
                    </div>
                </div>
                <div class="login-miss-box">
                    <p class="login-miss">登陆错误，请检查系统服务器设置</p>
                </div>
                <div class="login-ok-box">
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="登录" OnClick="btnLogin_Click" CssClass="forget-tips2"></asp:LinkButton>
                    <%--<span>|</span><a href="javascript:;" class="forget-tips2">忘记密码?</a>--%>
                </div>
            </form>
        </div>
    </div>
</body>

</html>
