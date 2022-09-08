using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusManagement.Pages
{
    public partial class SearchBusPage : System.Web.UI.Page
    {
        List<int> list = new List<int> { 1, 2, 3, 4, 5 };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDownList();
            }
        }

        protected void LoadDropDownList()
        {
            this.RoutesList.DataSource = list;
            this.RoutesList.DataBind();
            this.RoutesList.Items.Insert(0, "Tuyen");

            this.BusTypeList.DataSource = HRFunctions.Instance.SelectAllBusType();
            this.BusTypeList.DataTextField = "Name";
            this.BusTypeList.DataValueField = "BusTypeID";
            this.BusTypeList.DataBind();
            this.BusTypeList.Items.Insert(0, "Loai xe");
        }

        protected void Search(object sender, EventArgs e)
        {
            string licensePlate = LicensePlate.Text != "" ? $"LicensePlates='{LicensePlate.Text}' and " : "";
            string busNumber = BusNumber.Text != "" ? $"BusNumber='{BusNumber.Text}' and " : "";
            string sumSeats = SumSeat.Text != "" ? $"SumSeats='{SumSeat.Text}' and " : "";
            string status = Status.Text != "" ? $"Status='{Status.Text}' and " : "";
            string busType = this.BusTypeList.Text != "Loai xe" ? $"BusTypeID={int.Parse(this.BusTypeList.Text)} and " : "";
            string routes = RoutesList.Text != "Tuyen" ? $"RoutesID={RoutesList.Text} and " : "";

            string multiQuery = $"{licensePlate + busNumber + sumSeats + busType + status + routes}";
            Debug.WriteLine(multiQuery);
            if (multiQuery == "")
            {
                this.GridView1.DataSource = HRFunctions.Instance.SelectAllBus();
                this.GridView1.DataBind();
                return;
            }
            int lastPs = multiQuery.LastIndexOf("and");
            multiQuery = multiQuery.Substring(0, lastPs);
            this.GridView1.DataSource = HRFunctions.Instance.SearchBusByCriteria(multiQuery);
            this.GridView1.DataBind();
        }
    }
}