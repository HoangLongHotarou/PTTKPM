<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchBusPage.aspx.cs" Inherits="BusManagement.Pages.SearchBusPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 20px">
        <asp:Label ID="Label2" runat="server" Font-Size="12pt" Text="Số xe buýt" Width="100px"></asp:Label>
        <asp:TextBox ID="BusNumber" runat="server"></asp:TextBox>
    </div>
    <div style="margin: 20px">
        <asp:Label ID="Label3" runat="server" Font-Size="12pt" Text="Biển số xe" Width="100px"></asp:Label>
        <asp:TextBox ID="LicensePlate" runat="server"></asp:TextBox>
    </div>
    <div style="margin: 20px">
        <asp:Label ID="Label1" runat="server" Font-Size="12pt" Text="Số chỗ ngồi" Width="100px"></asp:Label>
        <asp:TextBox ID="SumSeat" runat="server"></asp:TextBox>
    </div>
    <div style="margin: 20px">
        <asp:Label ID="Label5" runat="server" Font-Size="12pt" Text="Trạng thái" Width="100px"></asp:Label>
        <asp:TextBox ID="Status" runat="server"></asp:TextBox>
    </div>
    <div style="margin: 20px">
        <asp:Label ID="Label6" runat="server" Font-Size="12pt" Text="Loại xe" Width="100px"></asp:Label>
        <asp:DropDownList ID="BusTypeList" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div style="margin: 20px">
        <asp:Label ID="Label4" runat="server" Font-Size="12pt" Text="Tuyến" Width="100px"></asp:Label>
        <asp:DropDownList ID="RoutesList" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div style="margin: 20px">
        <asp:Button ID="Button1" runat="server" Text="Tìm kiếm" OnClick="Search"/>
    </div>
    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center">
    </asp:GridView>
</asp:Content>
