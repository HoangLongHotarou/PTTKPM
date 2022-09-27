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
            {
                LoadEditButton();
            }                
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TenLoai.Value) || string.IsNullOrWhiteSpace(HangXe.Value))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Chưa điền đầy đủ thông tin')", true);
            }
            else
            {
                int id = HRFunctions.Instance.InsertUpdateBusType(0, TenLoai.Value, HangXe.Value);
                LoadListBusType();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thêm thành công!')", true);
                ClearAll();
            }                  
        }       

        private void LoadListBusType()
        {
            BustypeList = HRFunctions.Instance.SelectAllBusType();
        }

        private void LoadEditButton()
        {
            try
            {
                int idEdit = int.Parse(Request.QueryString["idedit"]);
                BusType busType = HRFunctions.Instance.FindBusTypeByID(idEdit);
                if (busType != null)
                {
                    this.IDLoaiXe.Value = busType.BusTypeID.ToString();
                    this.TenLoai.Value = busType.Name;
                    this.HangXe.Value = busType.CarMaker;
                }
            }
            catch { }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDLoaiXe.Value) || string.IsNullOrWhiteSpace(TenLoai.Value) || string.IsNullOrWhiteSpace(HangXe.Value))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Chưa điền đầy đủ thông tin')", true);
            }
            else
            {
                HRFunctions.Instance.InsertUpdateBusType(int.Parse(IDLoaiXe.Value), TenLoai.Value, HangXe.Value);
                LoadListBusType();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cập nhật thông tin thành công!')", true);
                ClearAll();
            }
            
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string selected = Request.Form["cbID"];
            if (selected != null && selected.Trim().Length > 0)
            {
                List<string> list = selected.Split(',').ToList();
                HRFunctions.Instance.DeleteBusTypeIDs(list);
            }
            LoadListBusType();
        }

        private void ClearAll()
        {
            IDLoaiXe.Value = "";
            TenLoai.Value = "";
            HangXe.Value = "";            
        }
    }
}