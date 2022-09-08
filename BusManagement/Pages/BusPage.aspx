<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusPage.aspx.cs" Inherits="BusManagement.Pages.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <h1>Quản lý xe bus</h1>
        <form id="form1" runat="server">
        <div>
            <center>
                <h2>Danh sách xe bus : </h2>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </center>
            <div>
                <h3>Thêm, sửa và xóa xe: </h3>
                <asp:Label>ID của xe :</asp:Label><asp:DropDownList ID="BusList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="BusList_SelectedIndexChanged"></asp:DropDownList><br />
                <asp:Label>Biển số xe :</asp:Label><asp:TextBox ID="BienSoXe" runat="server"></asp:TextBox><br />
                <asp:Label>Số của xe :</asp:Label><asp:TextBox ID="SoXe" runat="server"></asp:TextBox><br />
                <asp:Label>Số chổ ngồi :</asp:Label><asp:TextBox ID="SoChoNgoi" runat="server"></asp:TextBox><br />
                <asp:Label>Trạng thái :</asp:Label><asp:TextBox ID="TrangThai" runat="server"></asp:TextBox><br />
                <asp:Label>Loại xe :</asp:Label><asp:DropDownList ID="bustypelist" runat="server"></asp:DropDownList><br />
                <asp:Label>Tuyến :</asp:Label><asp:DropDownList ID="tuyenlist" runat="server"></asp:DropDownList><br />
                <asp:Button ID="AddBusButton" runat="server" Text="Thêm Xe" OnClick="AddBusButton_Click"/>
                <asp:Button ID="UpdateBusButton" runat="server" Text="Sửa Xe" OnClick="UpdateBusButton_Click"/>
                <asp:Button ID="DeleteBusButton" runat="server" Text="Xóa Xe" OnClick="DeleteBusButton_CLick"/>
            </div>
        </div>
    </form>
</body>
</html>
