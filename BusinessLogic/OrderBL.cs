using BusinessObject;
using DataAcess;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class OrderBL
    {
        OrderDA da = new OrderDA();
        public List<BusinessObjectOrder> GetOrderDetails(List<BusinessObjectOrder> bo)
        {
            List<BusinessObjectOrder> businessObject = da.GetOrderDetails(bo);
            return businessObject;
        }
        public int InsertOrder(BusinessObjectOrder order)
        {
            int result = da.InsertOrder(order);
            return result;
        }
    }
}
