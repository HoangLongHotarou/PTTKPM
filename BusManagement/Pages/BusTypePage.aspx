<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BusTypePage.aspx.cs" Inherits="BusManagement.Pages.BusTypePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="text-align: center; color: #008000; font-weight: bold;">Quản lý loại xe buýt</h1>
    <h2 style="text-align: center">Danh sách các loại xe buýt</h2>
    <hr />
    <center>
        <asp:GridView ID="BusTypeAll" runat="server" Width="100%" BorderWidth="1px" HorizontalAlign="Center">
            <HeaderStyle BackColor="#009933" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Size="16px" ForeColor="White" Height="30px" HorizontalAlign="Center" />
            <RowStyle BackColor="#F1F1F1" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
    </center>
    <hr />
    <div style="background-color: #f1f1f1; padding: 20px 0;">
        <div style="margin: 20px">
            <asp:Label ID="Label1" runat="server" Text="ID: " Width="60px"></asp:Label><asp:DropDownList ID="DropDownListIDLoaiXe" ViewStateMode="Enabled" EnableViewState="true" runat="server" Height="24px" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListIDLoaiXe_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div style="margin: 20px">
            <asp:Label ID="Label2" runat="server" Text="TenLoai: " Width="60px"></asp:Label><asp:TextBox ID="TenLoai" runat="server" Height="24px" Width="200px"></asp:TextBox>
        </div>
        <div style="margin: 20px">
            <asp:Label ID="Label3" runat="server" Text="HangXe: " Width="60px"></asp:Label><asp:TextBox ID="HangXe" runat="server" Height="24px" Width="200px"></asp:TextBox>
        </div>
        <div style="padding: 0 20px;">
            <asp:Button ID="Insert" runat="server" Text="Thêm mới" Width="100px" OnClick="Insert_Click" Height="30px" BackColor="#339933" BorderColor="#339933" ForeColor="White" />
            <asp:Button ID="Update" runat="server" Text="Cập nhật" Width="100px" OnClick="Update_Click" Height="30px" BackColor="#339933" BorderColor="#339933" ForeColor="White" />
            <asp:Button ID="Delete" runat="server" Text="Xóa" Width="100px" OnClick="Delete_Click" Height="30px" BackColor="#339933" BorderColor="#339933" ForeColor="White" />
        </div>
    </div>
</asp:Content>
