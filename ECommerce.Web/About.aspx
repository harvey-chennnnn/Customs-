<%@ Page Title="关于我们" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ECommerce.Web.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHeader" runat="server">
</asp:Content>
<asp:Content runat="server" ID="CpBody" ContentPlaceHolderID="CPBody">
    <div class="inner-page">
        <div class="container">
            <h2>关于我们</h2>
        </div>
    </div>
    <div class="about">
        <div class="row">
            <asp:Literal ID="litDescri" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
