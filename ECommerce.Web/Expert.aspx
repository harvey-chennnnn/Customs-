﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Expert.aspx.cs" Inherits="ECommerce.Web.Expert" %>

<%@ Register Src="UserControl/Pager1.ascx" TagName="Pager1" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content runat="server" ID="CpBody" ContentPlaceHolderID="CPBody">
    <div class="inner-page">
        <div class="container">
            <h2>提升服务</h2>
            <p class="lead">提升服务介绍</p>
        </div>
    </div>
    <div class="service-box">
        <div class="row">
            <div class="left-menu media-left">
                <ul class="nav">
                    <li><a href="Promote.aspx">提升服务介绍</a></li>
                    <li><a href="Mechanism.aspx">专业机构</a></li>
                    <li><a class="active" href="Expert.aspx">专家顾问库</a></li>
                    <li><a href="Message.aspx">提升服务留言咨询</a></li>
                    <li><a href="Apply.aspx">提升服务申请</a></li>
                </ul>
            </div>
            <!--/left-menu-->
            <div class="right-box">
                <h2>专家顾问库</h2>
                <div class="mechanism-list exprtlist">
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <div class="media">
                                <div class="media-left">
                                    <img src="<%#Eval("Photo")%>">
                                </div>
                                <div class="media-body">
                                    <h4 class="media-heading"><a href="Expert-show.aspx?id=<%#Eval("PIID")%>"><%#Eval("Name")%></a></h4>
                                    <%#Eval("Descri").ToString().Length>100? Eval("Descri").ToString().Substring(0,100)+"...":Eval("Descri").ToString()%>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <uc1:Pager1 ID="Pager11" runat="server" />
            </div>
            <!--/right-box-->
        </div>
    </div>
</asp:Content>
