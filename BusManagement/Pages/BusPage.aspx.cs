﻿using BusinessLayer;
using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusManagement.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<int> list = new List<int> { 1, 2, 3, 4, 5 };
        int PageSize = Global.g_PageSize;
        public List<Bus> listBus;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                //this.hPageIndex.Value = "0";
                LoadDropDownList();
                LoadEditButton();
                LoadList();        
            }
            //LoadPhanTrang();
        }

        private void LoadList()
        {
            listBus = HRFunctions.Instance.SelectAllBus();
            //this.hTotalRows.Value = listBus.Count.ToString();
        }

        protected void AddBusButton_Click(object sender, EventArgs e)
        {
            Bus bus = new Bus
            {
                LicensePlates = this.BienSoXe.Value,
                BusNumber = this.SoXe.Value,
                SumSeats = int.Parse(this.SoChoNgoi.Value),
                Status = this.TrangThai.Value,
                BusTypeID = int.Parse(this.bustypelist.Text),
                RoutesID = int.Parse(this.tuyenlist.Text),
            };

            HRFunctions.Instance.AddBus(bus);
            ClearInput();
            //int TotalRows = int.Parse(this.hTotalRows.Value);
            //int count = TotalRows / PageSize;
            LoadList();
            //LoadListBusPage(count);
            LoadDropDownList();
            ClearInput();
        }

        protected void ClearInput()
        {
            this.BusID.Value = "";
            this.BienSoXe.Value = "";
            this.SoXe.Value = "";
            this.SoChoNgoi.Value = "";
            this.TrangThai.Value = "";
        }

        private void LoadEditButton()
        {
            try
            {
                int idEdit = int.Parse(Request.QueryString["idedit"]);
                Bus bus = HRFunctions.Instance.FindBusByID(idEdit);
                if (bus != null)
                {
                    this.BusID.Value = bus.BusID.ToString();
                    this.BienSoXe.Value = bus.LicensePlates;
                    this.SoXe.Value = bus.BusNumber;
                    this.SoChoNgoi.Value = bus.SumSeats.ToString();
                    this.TrangThai.Value = bus.Status;

                    BusType busType = HRFunctions.Instance.FindBusTypeByID(bus.BusTypeID);

                    this.bustypelist.SelectedValue = busType.BusTypeID.ToString();
                    this.tuyenlist.Text = bus.RoutesID.ToString();
                }
            }
            catch { }

        }

        //protected void BusList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int busID = 0;
        //    bool check = int.TryParse(this.BusList.Text, out busID);
        //    if (check == false) return;
        //    Bus bus = HRFunctions.Instance.FindBusByID(busID);

        //    this.BienSoXe.Text = bus.LicensePlates;
        //    this.SoXe.Text = bus.BusNumber;
        //    this.SoChoNgoi.Text = bus.SumSeats.ToString();
        //    this.TrangThai.Text = bus.Status;

        //    BusType busType = HRFunctions.Instance.FindBusTypeByID(bus.BusTypeID);

        //    this.bustypelist.SelectedValue = busType.BusTypeID.ToString();
        //    this.tuyenlist.Text = bus.RoutesID.ToString();
        //}

        protected void UpdateBusButton_Click(object sender, EventArgs e)
        {
            Bus bus = HRFunctions.Instance.FindBusByID(int.Parse(this.BusID.Value));

            bus.LicensePlates = this.BienSoXe.Value;
            bus.BusNumber = this.SoXe.Value;
            bus.SumSeats = int.Parse(this.SoChoNgoi.Value);
            bus.Status = this.TrangThai.Value;
            bus.BusTypeID = int.Parse(this.bustypelist.Text);
            bus.RoutesID = int.Parse(this.tuyenlist.Text);

            HRFunctions.Instance.AddBus(bus);
            LoadList();
            //LoadListBusPage(int.Parse(this.hPageIndex.Value));
            LoadDropDownList();
            ClearInput();
        }

        protected void LoadDropDownList()
        {
            this.bustypelist.DataSource = HRFunctions.Instance.SelectAllBusType();
            this.bustypelist.DataTextField = "Name";
            this.bustypelist.DataValueField = "BusTypeID";
            this.bustypelist.DataBind();

            this.tuyenlist.DataSource = list;
            this.tuyenlist.DataBind();

            //this.BusList.DataSource = HRFunctions.Instance.SelectAllBus();
            //this.BusList.DataTextField = "BusID";
            //this.BusList.DataValueField = "BusID";
            //this.BusList.DataBind();
            //this.BusList.Items.Insert(0, "ID xe");
        }

        //protected void DeleteBusButton_CLick(object sender, EventArgs e)
        //{
        //    HRFunctions.Instance.DeleteBusByID(int.Parse(this.BusList.Text));
        //    LoadList();
        //    LoadDropDownList();
        //    ClearInput();
        //}

        //private void LoadPhanTrang()
        //{
        //    try
        //    {
        //        int TotalRows = int.Parse(this.hTotalRows.Value);                
        //        int count = TotalRows / PageSize;
        //        if (TotalRows % PageSize > 0)
        //            count++;
        //        if (count > 20)
        //            count = 20;
        //        this.pnButton.Controls.Clear();
        //        for (int i = 0; i < count; i++)
        //        {
        //            Button bt = new Button()
        //            {
        //                ID = "bt" + i,
        //                Text = (i + 1).ToString()
        //            };
        //            bt.Attributes.Add("runat", "server");
        //            bt.Click += new EventHandler(this.btPhanTrang_Click);
        //            bt.CssClass = "btn btn-dark";
        //            this.pnButton.Controls.Add(bt);                
        //        }

        //    }
        //    catch { }
        //}

        //public void btPhanTrang_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    int PageIndex = int.Parse(this.hPageIndex.Value);
        //    TestLabel.Text = PageIndex.ToString();
        //    //switch (btn.ID)
        //    //{
        //    //    case "btTruoc":
        //    //        PageIndex = int.Parse(this.hPageIndex.Value);
        //    //        PageIndex = (PageIndex > 0) ? PageIndex - 1 : 0;
        //    //        this.hPageIndex.Value = PageIndex.ToString();
        //    //        break;
        //    //    case "btSau":
        //    //        int TotalRows = int.Parse(hTotalRows.Value);
        //    //        PageIndex = ((PageIndex + 1) * PageSize < TotalRows) ? PageIndex + 1 : PageIndex;
        //    //        break;
        //    //    default:
        //    //        PageIndex = int.Parse(btn.Text) - 1;
        //    //        break;
        //    //}
        //    //this.hPageIndex.Value = PageIndex.ToString();
        //}

        //private void LoadListBusPage(int pIndex)
        //{
        //    int TotalRows = 0;
        //    this.listBus = HRFunctions.Instance.Bus_Pagination(PageSize, pIndex, out TotalRows);
        //    this.hTotalRows.Value = TotalRows.ToString();
        //    if (listBus == null || listBus.Count == 0)
        //    {
        //        this.pnPhanTrang.Visible = false;
        //    }
        //}
    }
}