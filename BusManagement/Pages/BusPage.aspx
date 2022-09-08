<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BusPage.aspx.cs" Inherits="BusManagement.Pages.WebForm1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        Demo Bus
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button_Click"/>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
</asp:Content>