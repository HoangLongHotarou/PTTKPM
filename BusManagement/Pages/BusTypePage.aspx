<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BusTypePage.aspx.cs" Inherits="BusManagement.Pages.BusTypePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="mt-3" style="text-align: center; color: #008000; font-weight: bold;">Quản lý loại xe buýt</h1>
    <hr />
    <%--<asp:GridView ID="BusTypeAll" runat="server" Width="100%" BorderWidth="1px" HorizontalAlign="Center">
            <HeaderStyle BackColor="#009933" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Size="16px" ForeColor="White" Height="30px" HorizontalAlign="Center" />
            <RowStyle BackColor="#F1F1F1" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>--%>
    <%--<div style="background-color: #f1f1f1; padding: 20px 0;">
        <div style="margin: 20px">
            <asp:Label ID="Label1" runat="server" Text="ID: " Width="80px"></asp:Label><asp:DropDownList ID="DropDownListIDLoaiXe" ViewStateMode="Enabled" EnableViewState="true" runat="server" Height="24px" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListIDLoaiXe_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div style="margin: 20px">
            <asp:Label ID="Label2" runat="server" Text="Tên Loại:" Width="80px"></asp:Label><asp:TextBox ID="TenLoai" runat="server" Height="24px" Width="200px"></asp:TextBox>
        </div>
        <div style="margin: 20px">
            <asp:Label ID="Label3" runat="server" Text="Hãng Xe: " Width="80px"></asp:Label><asp:TextBox ID="HangXe" runat="server" Height="24px" Width="200px"></asp:TextBox>
        </div>        
        <div style="padding: 0 20px;">
            <asp:Button ID="Insert" class="btn btn-primary" runat="server" Text="Thêm mới" OnClick="Insert_Click" BackColor="#339933" BorderColor="#339933" />
            <asp:Button ID="Update" class="btn btn-primary" runat="server" Text="Cập nhật" OnClick="Update_Click" BackColor="#339933" BorderColor="#339933" />
            <asp:Button ID="Delete" class="btn btn-primary" runat="server" Text="Xóa" OnClick="Delete_Click" BackColor="red" BorderColor="red" />
        </div>            
    </div>
    <hr />
    <table class="table table-primary caption-top table-striped table-hover table-bordered">
        <caption class="text-center">DANH SÁCH CÁC LOẠI XE</caption>
        <thead>
            <tr>
                <th class="text-center" scope="col">ID</th>
                <th class="text-center" scope="col">Tên Loại</th>
                <th class="text-center" scope="col">Hãng Xe</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var busType in BustypeList)
                { %>
            <tr>
                <th class="text-center" scope="row"><%= busType.BusTypeID %></th>
                <td><%= busType.Name %></td>
                <td><%= busType.CarMaker %></td>
            </tr>
            <% } %>
        </tbody>
    </table>    --%>

    <div class="container mt-3">
        <div class="row mb-3">
            <label for="IDLoaiXe" class="form-label col-2">ID</label>
            <input style="background: #f1f1f1;" id="IDLoaiXe" type="text" readonly class="form-control col" placeholder="ID Loại Xe" runat="server">
        </div>
        <div class="row mb-3">
            <label for="TenLoai" class="form-label col-2">Tên loại</label>
            <input id="TenLoai" type="text" class="form-control col" placeholder="Nhập vào tên loại xe" runat="server">
        </div>
         <div class="row mb-3">
            <label for="HangXe" class="form-label col-2">Hãng xe</label>
            <input id="HangXe" type="text" class="form-control col" placeholder="Nhập vào hãng xe" runat="server">
        </div>
    </div>

    <div class="d-flex justify-content-end">
        <asp:Button ID="AddBusButton" OnClick="Insert_Click" runat="server" Text="Thêm Mới" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary" />
        <asp:Button ID="UpdateBusButton" href="?page=<%=this.pivot%>" OnClick="Update_Click" runat="server" Text="Cập Nhật" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary ms-2" />
        <asp:Button ID="DeleteBusButton" OnClientClick="return confirm('Bạn có muốn xóa không?')" OnClick="Delete_Click" runat="server" Text="Xóa" BackColor="#ff1a1a" BorderColor="#ff1a1a" CssClass="btn btn-primary ms-2" />
    </div>

    <div class="mt-3">
        <h5>Danh sách loại xe buýt</h5>
        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th class="text-center" scope="col">
                        <input id="selectAll" type="checkbox"><label for='selectAll'></label></th>
                    <th class="text-center" scope="col">ID</th>
                    <th class="text-center" scope="col">Tên Loại</th>
                    <th class="text-center" scope="col">Hãng xe</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var busType in BustypeList)
                    { %>
                <tr>
                    <td style="width: 40px; text-align: center">
                        <input name='cbID' value='<%=busType.BusTypeID %>' type='checkbox' /></td>
                    <td class="text-center"><%= busType.BusTypeID %></td>
                    <td class="text-center"><%= busType.Name %></td>
                    <td class="text-center"><%= busType.CarMaker %></td>
                    <td class="text-center">
                        <a href="?idEdit=<%=busType.BusTypeID %>&page=<%=this.pivot%>">Sửa</a>
                    </td>
                </tr>
                <% } %>
            </tbody>
        </table>
        <div class="card-footer text-right">
            <asp:Panel ID="pnPhanTrang" runat="server">
                <div class="row">
                    <div class="col-auto">
                        <asp:Button ID="btTruoc" runat="server" Text="Trước" BackColor="#339933" BorderColor="#339933" class="btn btn-primary" href="?page=<%=this.pivot%>" OnClick="btPhanTrang_Click" />
                    </div>
                    <div class="col-auto">
                        <asp:HiddenField ID="hPageIndex" runat="server" />
                        <asp:HiddenField ID="hTotalRows" runat="server" />
                        <asp:HiddenField ID="hPageSize" runat="server" />
                        <asp:Panel ID="pnButton" runat="server"></asp:Panel>
                    </div>
                    <div class="col-auto">
                        <asp:Button ID="btSau" runat="server" Text="Sau" BackColor="#339933" BorderColor="#339933" class="btn btn-primary" href="?page=<%=this.pivot%>" OnClick="btPhanTrang_Click" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

     <script>
        $("#selectAll").click(function () {
            $("input[type=checkbox]").prop('checked', $(this).prop('checked'));
        });
    </script>
</asp:Content>
