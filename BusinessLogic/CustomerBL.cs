using BusinessObject;
using DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CustomerBL
    {
        CustomerDA da = new CustomerDA();
        public List<BusinessObjectCustomer> GetCustomerDetails(List<BusinessObjectCustomer> bo)
        {
            List<BusinessObjectCustomer> businessObject = da.GetCustomerDetails(bo);
            return businessObject;
        }
        public int InsertCustomer(BusinessObjectCustomer customer)
        {
            int result = da.InsertCustomer(customer);
            return result;
        }
    }
}
