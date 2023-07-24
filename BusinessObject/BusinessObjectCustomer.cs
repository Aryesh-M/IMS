namespace BusinessObject
{
    public class BusinessObjectCustomer
    {
        private string _cust_name;
        private string _city;
        private int _grade;
        private int _salesman_id;

        public string CustName { get => _cust_name; set => _cust_name = value; }
        public string City { get => _city; set => _city = value; }
        public int Grade { get => _grade; set => _grade = value; }
        public int SalesmanId { get => _salesman_id; set => _salesman_id = value; }
    }
}
