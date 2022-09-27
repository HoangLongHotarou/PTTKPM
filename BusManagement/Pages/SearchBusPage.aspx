<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchBusPage.aspx.cs" Inherits="BusManagement.Pages.SearchBusPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="mt-3" style="text-align: center; color: #008000; font-weight: bold;">Tìm kiếm xe buýt</h1>
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
                    <input id="SumSeat" type="number" class="form-control col" placeholder="Nhập vào số chỗ ngồi" runat="server" min="4" max="40">
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
