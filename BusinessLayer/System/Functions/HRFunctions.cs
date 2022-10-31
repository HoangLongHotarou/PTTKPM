using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HRFunctions : BaseFunctions
    {
        private static HRFunctions instance = null;
        public static HRFunctions Instance
        {
            get
            {
                if (instance == null)
                    instance = new HRFunctions();
                return instance;
            }
        }

        public BusType GetBusTypeByID(int id)
        {
            return BusTypeExt.Instance.BusType_Select_BusTypeID(id);
        }

        public BusRoute GetBusRouteByID(int id)
        {
            return BusExt.Instance.BusRoute_Select_ID(id);
        }

        public List<Bus> SelectAllBus()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return BusExt.Instance.Bus_Select_All();
        }

        public List<BusRoute> SelectAllBusRoutes()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return BusExt.Instance.BusRoute_Select_All();
        }

        public List<Bus> SearchBusByCriteria(string multiColumn,int pageSize, int pageIndex, out int total)
        {
            return BusExt.Instance.Bus_Find_By_Criteria(multiColumn,pageSize, pageIndex, out total);
        }

        public List<BusType> SearchBusTypeByCrieria(string multiColumn, int pageSize, int pageIndex, out int total)
        {
            return BusTypeExt.Instance.Bus_Type_Find_By_Criteria(multiColumn, pageIndex, pageSize, out total);
        }

        public List<BusType> SelectAllBusType()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return BusTypeExt.Instance.BusType_Select_All();
        }

        public int InsertUpdateBusType(int id, string name, string carMaker)
        {
            BusType busType;
            busType = new BusType
            {
                BusTypeID = id,
                Name = name,
                CarMaker = carMaker
            };
            return BusTypeExt.Instance.BusType_InsertUpdate(busType);
        }


        public int AddBus(Bus bus)
        {
            return BusExt.Instance.Bus_InsertUpdate(bus);
        }

        public Bus FindBusByID(int id)
        {
            return BusExt.Instance.Bus_Select_ID(id);
        }

        public BusType FindBusTypeByID(int id)
        {
            return BusTypeExt.Instance.BusType_Select_BusTypeID(id);
        }

        public BusType SelectBusTypeByID(int id)
        {
            return BusTypeExt.Instance.BusType_Select_BusTypeID(id);
        }

        public void DeleteBusType(int id)
        {
            BusTypeExt.Instance.BusType_Delete(id);
        }

        public void DeleteBusTypeIDs(List<string> ids)
        {
            BusTypeExt.Instance.BusType_Delete_BusTypeIDs(ids);
        }

        public void DeleteBusBusTypeIDs(List<string> ids)
		  {
            BusExt.Instance.Bus_Delete_BusTypeIDs(ids);
		  }

        public void DeleteBusByID(int id)
        {
            BusExt.Instance.Bus_Delete(id);
        }

        public List<Bus> Bus_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            return BusExt.Instance.Bus_Pagination(PageSize, PageIndex, out TotalRows);
        }

        public List<BusType> Bus_Type_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            return BusTypeExt.Instance.BusType_Pagination(PageSize,PageIndex,out TotalRows);
        }

        public int Get_Bus_Total_Row()
        {
            return BusExt.Instance.Get_Total_Rows();
        }
        public void DeleteBusByIDs(List<string> list)
        {
            BusExt.Instance.Bus_Delete_IDs(list);
        }

        public Bus FindBusByBienSoXe(string biensoxe)
		  {
            return BusExt.Instance.Bus_Select_BienSoXe(biensoxe);
		  }

        public BusType FindBusTypeByBusTypeNameAndCarMarker(string bustypename,string carmarker)
        {
            return BusTypeExt.Instance.BusType_Select_BusTypeName(bustypename, carmarker);
        }


    }
}
