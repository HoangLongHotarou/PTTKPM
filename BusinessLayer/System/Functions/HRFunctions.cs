using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HRFunctions: BaseFunctions
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

        public List<Bus> SelectAllBus()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return BusExt.Instance.Bus_Select_All();
        }


        public List<BusType> SelectAllBusType()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return BusTypeExt.Instance.BusType_Select_All();
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

        public void DeleteBusByID(int id)
		  {
            BusExt.Instance.Bus_Delete(id);
		  }
    }
}
