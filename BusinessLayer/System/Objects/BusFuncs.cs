using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusFuncs
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }

        public List<Bus> Bus_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Buses.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<Bus>();
            }
        }
    }
}
