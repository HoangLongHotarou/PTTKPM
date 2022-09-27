using BusinessLayer;
using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusManagement.Pages
{
    public partial class BusTypePage : System.Web.UI.Page
    {
        int PageSize;

        public List<BusType> BustypeList;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadListBusType();
            if (!IsPostBack)
            {
                this.hPageIndex.Value = "0";
                LoadDropDownList();
                LoadBusTypeListPage(0);
            }
            LoadPhanTrang();
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

        private void LoadPhanTrang()
        {
            try
            {
                int TotalRows = int.Parse(this.hTotalRows.Value);
                int count = TotalRows / PageSize;
                if (TotalRows % PageSize > 0)
                    count++;
                if (count > 20)
                    count = 20;
                this.pnButton.Controls.Clear();
                for (int i = 0; i < count; i++)
                {
                    Button bt = new Button()
                    {
                        ID = "bt" + i,
                        Text = (i + 1).ToString()
                    };
                    bt.Attributes.Add("runat", "server");
                    bt.Click += new EventHandler(this.btPhanTrang_Click);
                    bt.CssClass = "btn btn-dark";
                    this.pnButton.Controls.Add(bt);
                }

            }
            catch { }
        }

        public void btPhanTrang_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int PageIndex = int.Parse(this.hPageIndex.Value);
            switch (btn.ID)
            {
                case "btTruoc":
                    PageIndex = int.Parse(this.hPageIndex.Value);
                    PageIndex = (PageIndex > 0) ? PageIndex - 1 : 0;
                    this.hPageIndex.Value = PageIndex.ToString();
                    break;
                case "btSau":
                    int TotalRows = int.Parse(hTotalRows.Value);
                    PageIndex = ((PageIndex + 1) * PageSize < TotalRows) ? PageIndex + 1 : PageIndex;
                    break;
                default:
                    PageIndex = int.Parse(btn.Text) - 1;
                    break;
            }
            this.hPageIndex.Value = PageIndex.ToString();
            LoadBusTypeListPage(PageIndex);
        }

        private void LoadBusTypeListPage(int pIndex)
        {
            int TotalRows = 0;
            this.BustypeList = HRFunctions.Instance.Bus_Type_Pagination(PageSize, pIndex, out TotalRows);
            this.hTotalRows.Value = TotalRows.ToString();
            if (BustypeList == null || BustypeList.Count == 0)
            {
                this.pnPhanTrang.Visible = false;
            }
        }
    }
}