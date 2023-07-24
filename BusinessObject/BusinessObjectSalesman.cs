namespace BusinessObject
{
    public class BusinessObjectSalesman
    {
        private string _name;
        private string _city;
        private decimal _commission;

        public string Name { get => _name; set => _name = value; }
        public string City { get => _city; set => _city = value; }
        public decimal Commission { get => _commission; set => _commission = value; }
    }
}
