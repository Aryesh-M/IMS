using BusinessObject;
using DataAcess;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class SalesmanBL
    {
        SalesmanDA da = new SalesmanDA();
        public List<BusinessObjectSalesman> GetSalesmanDetails(List<BusinessObjectSalesman> bo)
        {
            List<BusinessObjectSalesman> businessObject = da.GetSalesmanDetails(bo);
            return businessObject;
        }
        public int InsertSalesman(BusinessObjectSalesman salesman)
        {
            int result = da.InsertSalesman(salesman);
            return result;
        }
    }
}
