<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchBusPage.aspx.cs" Inherits="BusManagement.Pages.SearchBusPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="text-align: center; color: #008000; font-weight: bold;">Tìm kiếm xe buýt</h1>
    <div style="background: #f1f1f1; padding: 20px;">
        <div class="row">
            <div class="col-6">
                <asp:Label ID="Label2" runat="server" Font-Size="12pt" Text="Số xe buýt" Width="100px"></asp:Label>
                <asp:TextBox ID="BusNumber" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:Label ID="Label3" runat="server" Font-Size="12pt" Text="Biển số xe" Width="100px"></asp:Label>
                <asp:TextBox ID="LicensePlate" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-6">
                <asp:Label ID="Label1" runat="server" Font-Size="12pt" Text="Số chỗ ngồi" Width="100px"></asp:Label>
                <asp:TextBox ID="SumSeat" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:Label ID="Label5" runat="server" Font-Size="12pt" Text="Trạng thái" Width="100px"></asp:Label>
                <asp:TextBox ID="Status" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-6">
                <asp:Label ID="Label6" runat="server" Font-Size="12pt" Text="Loại xe" Width="100px"></asp:Label>
                <asp:DropDownList ID="BusTypeList" runat="server" AutoPostBack="True" Height="24px"></asp:DropDownList>
            </div>
            <div class="col-6">
                <asp:Label ID="Label4" runat="server" Font-Size="12pt" Text="Tuyến" Width="100px"></asp:Label>
                <asp:DropDownList ID="RoutesList" runat="server" AutoPostBack="True" Height="24px"></asp:DropDownList>
            </div>
        </div>
        <div>
            <asp:Button ID="Button1" CssClass="btn btn-primary" BackColor="#339933" BorderColor="#339933" runat="server" Text="Tìm" OnClick="Search" />
        </div>
    </div>
    <%--<asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center"></asp:GridView>--%>
    <hr />
    <% if (listResult != null)
        { %>
    <table class="table table-primary caption-top table-striped table-hover table-bordered">
        <caption class="text-center">DANH SÁCH XE BUÝT</caption>
        <thead>
            <tr>
                <th class="text-center" scope="col">ID</th>
                <th class="text-center" scope="col">Biến Số Xe</th>
                <th class="text-center" scope="col">Số Của Xe</th>
                <th class="text-center" scope="col">Số Chỗ Ngồi</th>
                <th class="text-center" scope="col">Trạng Thái</th>
                <th class="text-center" scope="col">Loại Xe</th>
                <th class="text-center" scope="col">Tuyến</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var bus in listResult)
                { %>
            <tr>
                <th class="text-center" scope="row"><%= bus.BusID %></th>
                <td class="text-center"><%= bus.LicensePlates %></td>
                <td class="text-center"><%= bus.BusNumber %></td>
                <td class="text-center"><%= bus.SumSeats %></td>
                <td class="text-center"><%= bus.Status %></td>
                <td class="text-center"><%= bus.BusTypeID %></td>
                <td class="text-center"><%= bus.RoutesID %></td>
            </tr>
            <% } %>
        </tbody>
    </table>
    <% } %>
</asp:Content>
