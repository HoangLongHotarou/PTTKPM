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
    public partial class BusTypePage : System.Web.UI.Page
    {
        public List<BusType> BustypeList;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadListBusType();
            if (!IsPostBack)
                LoadDropDownList();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            int id = HRFunctions.Instance.InsertUpdateBusType(0, TenLoai.Text, HangXe.Text);
            LoadListBusType();
            LoadDropDownList();       
        }

        private void LoadDropDownList()
        {
            GetAllBusTypeToDropDownList();
            this.DropDownListIDLoaiXe.Items.Insert(0, "---Chọn ID loại xe---");                      
        }

        protected void DropDownListIDLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;   
            bool check = int.TryParse(DropDownListIDLoaiXe.Text, out id);     
            if (check)
            {
                BusType busType = HRFunctions.Instance.SelectBusTypeByID(id);
                TenLoai.Text = busType.Name;
                HangXe.Text = busType.CarMaker;
            }         
            else
            {
                ClearAll();
            }         
        }

        private void LoadListBusType()
        {
            BustypeList = HRFunctions.Instance.SelectAllBusType();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            HRFunctions.Instance.InsertUpdateBusType(int.Parse(DropDownListIDLoaiXe.Text), TenLoai.Text, HangXe.Text);
            LoadListBusType();
        }      
        
        private void GetAllBusTypeToDropDownList()
        {
            this.DropDownListIDLoaiXe.DataSource = HRFunctions.Instance.SelectAllBusType();
            this.DropDownListIDLoaiXe.DataTextField = "BusTypeID";
            this.DropDownListIDLoaiXe.DataValueField = "BusTypeID";
            this.DropDownListIDLoaiXe.DataBind();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            int id;
            bool check = int.TryParse(DropDownListIDLoaiXe.Text, out id);
            if (check)
            {
                HRFunctions.Instance.DeleteBusType(id);
                LoadListBusType();
                LoadDropDownList();
                ClearAll();
            }
        }

        private void ClearAll()
        {
            TenLoai.Text = "";
            HangXe.Text = "";
            DropDownListIDLoaiXe.SelectedIndex = 0;
        }
    }
}