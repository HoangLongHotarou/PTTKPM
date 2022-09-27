<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchBusPage.aspx.cs" Inherits="BusManagement.Pages.SearchBusPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="mt-3" style="text-align: center; color: #008000; font-weight: bold;">Tìm kiếm xe buýt</h1>
    <%--<div style="background: #f1f1f1; padding: 20px;">
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
    </div>--%>
    <%--<asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center"></asp:GridView>--%>
    <%--<hr />
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
    <% } %>--%>

    <div class="container mt-3">
        <div class="row mb-3">
            <div class="col">
                <div class="row align-items-center">
                    <label for="BusNumber" class="form-label col-3">Số xe buýt</label>
                    <input id="BusNumber" type="number" class="form-control col" placeholder="Nhập vào số xe buýt" runat="server">
                </div>
            </div>
            <div class="col">
                <div class="row align-items-center">
                    <label for="LicensePlate" class="form-label col-3">Biển số xe</label>
                    <input id="LicensePlate" type="text" class="form-control col" placeholder="Nhập vào biển số xe" runat="server">
                </div>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col">
                <div class="row align-items-center">
                    <label for="SumSeat" class="form-label col-3">Số chỗ ngồi</label>
                    <input id="SumSeat" type="number" class="form-control col" placeholder="Nhập vào số chỗ ngồi" runat="server" min="4">
                </div>

            </div>
            <div class="col">
                <div class="row align-items-center">
                    <label for="Status" class="form-label col-3">Trạng thái</label>
                    <input id="Status" type="text" class="form-control col" placeholder="Nhập vào trạng thái" runat="server">
                </div>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col">
                <div class="row align-items-center">
                    <label for="BusTypeList" class="form-label col-3">Loại xe</label>
                    <asp:DropDownList ID="BusTypeList" runat="server" CssClass="form-select col"></asp:DropDownList>
                </div>
            </div>
            <div class="col">
                <div class="row align-items-center">
                    <label for="RoutesList" class="form-label col-3">Tuyến</label>
                    <asp:DropDownList ID="RoutesList" runat="server" CssClass="form-select col"></asp:DropDownList>
                </div>
            </div>
        </div>
    </div>

    <div>
        <asp:Button ID="SearchButton" runat="server" OnClick="Search" Text="Tìm kiếm" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary" />
    </div>
    <% if (listResult != null)
    { %>
    <div class="mt-3">
        <h5>Danh sách xe buýt</h5>
        <table class="table table-striped table-hover table-bordered">
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
    </div>
    <% } %>
</asp:Content>
