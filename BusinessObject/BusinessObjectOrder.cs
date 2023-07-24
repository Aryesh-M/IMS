using System;

namespace BusinessObject
{
    public class BusinessObjectOrder
    {
        private decimal _purchase_amt;
        private DateTime _order_date;
        private int _customer_id;
        private int _salesman_id;

        public decimal PurchaseAmount
        {
            get { return _purchase_amt; }
            set { _purchase_amt = value; }
        }
        public DateTime OrderDate
        {
            get { return _order_date; }
            set { _order_date = value; }
        }
        public int CustomerId
        {
            get { return _customer_id; }
            set { _customer_id = value; }
        }
        public int SalesmanId
        {
            get { return _salesman_id; }
            set { _salesman_id = value; }
        }
    }
}
