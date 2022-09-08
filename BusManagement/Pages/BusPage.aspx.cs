using BusinessLayer;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.DataSource = HRFunctions.Instance.SelectAllBus();
            this.GridView1.DataBind();

            if (!IsPostBack)
            {
                LoadDropDownList();
            }
        }

        protected void LoadList()
        {
            this.GridView1.DataSource = HRFunctions.Instance.SelectAllBus();
            this.GridView1.DataBind();
        }

        protected void AddBusButton_Click(object sender, EventArgs e)
        {
            Bus bus = new Bus
            {
                LicensePlates = this.BienSoXe.Text,
                BusNumber = this.SoXe.Text,
                SumSeats = int.Parse(this.SoChoNgoi.Text),
                Status = this.TrangThai.Text,
                BusTypeID = int.Parse(this.bustypelist.Text),
                RoutesID = int.Parse(this.tuyenlist.Text),
            };

            HRFunctions.Instance.AddBus(bus);
            ClearInput();
            LoadList();
            LoadDropDownList();
            ClearInput();

        }

        protected void ClearInput()
        {
            this.BienSoXe.Text = "";
            this.SoXe.Text = "";
            this.SoChoNgoi.Text = "";
            this.TrangThai.Text = "";
        }

        protected void BusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int busID = 0;
            bool check = int.TryParse(this.BusList.Text, out busID);
            if (check == false) return;
            Bus bus = HRFunctions.Instance.FindBusByID(busID);

            this.BienSoXe.Text = bus.LicensePlates;
            this.SoXe.Text = bus.BusNumber;
            this.SoChoNgoi.Text = bus.SumSeats.ToString();
            this.TrangThai.Text = bus.Status;

            BusType busType = HRFunctions.Instance.FindBusTypeByID(bus.BusTypeID);

            this.bustypelist.SelectedValue = busType.BusTypeID.ToString();
            this.tuyenlist.Text = bus.RoutesID.ToString();
        }

        protected void UpdateBusButton_Click(object sender, EventArgs e)
        {
            Bus bus = HRFunctions.Instance.FindBusByID(int.Parse(this.BusList.Text));

            bus.LicensePlates = this.BienSoXe.Text;
            bus.BusNumber = this.SoXe.Text;
            bus.SumSeats = int.Parse(this.SoChoNgoi.Text);
            bus.Status = this.TrangThai.Text;
            bus.BusTypeID = int.Parse(this.bustypelist.Text);
            bus.RoutesID = int.Parse(this.tuyenlist.Text);

            HRFunctions.Instance.AddBus(bus);
            LoadList();
            LoadDropDownList();
            ClearInput();

        }

        protected void LoadDropDownList()
        {
            this.bustypelist.DataSource = HRFunctions.Instance.SelectAllBusType();
            this.bustypelist.DataTextField = "Name";
            this.bustypelist.DataValueField = "BusTypeID";
            this.bustypelist.DataBind();
            this.bustypelist.Items.Insert(0, "Loai xe");

            this.tuyenlist.DataSource = list;
            this.tuyenlist.DataBind();
            this.tuyenlist.Items.Insert(0, "Tuyen");

            this.BusList.DataSource = HRFunctions.Instance.SelectAllBus();
            this.BusList.DataTextField = "BusID";
            this.BusList.DataValueField = "BusID";
            this.BusList.DataBind();
            this.BusList.Items.Insert(0, "ID xe");
        }

        protected void DeleteBusButton_CLick(object sender, EventArgs e)
        {
            HRFunctions.Instance.DeleteBusByID(int.Parse(this.BusList.Text));
            LoadList();
            LoadDropDownList();
            ClearInput();
        }

    }
}