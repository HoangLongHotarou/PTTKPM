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
    }
}
