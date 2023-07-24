using System;
using BusinessObject;
using BusinessLogic;
using System.Collections.Generic;

namespace _3LayerInventory
{
    public partial class Order : System.Web.UI.Page
    {
        OrderBL logic = new OrderBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                GetAllOrders();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            decimal purchaseAmount = Convert.ToDecimal(txtPurchAmount.Text);
            DateTime orderDate = Convert.ToDateTime(txtOrderDate.Text);
            int customerId = Convert.ToInt32(txtCustomerId.Text);
            int salesmanId = Convert.ToInt32(txtSalesId.Text);

            BusinessObjectOrder orderBO = new BusinessObjectOrder()
            {
                PurchaseAmount = purchaseAmount,
                OrderDate = orderDate,
                CustomerId = customerId,
                SalesmanId = salesmanId
            };
            int result = logic.InsertOrder(orderBO);
            if (result > 0)
            {
                GetAllOrders();
                lblMessage.Text = "Sales data added sucessfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                ClearFields();
            }
            else
            {
                lblMessage.Text = "An Error has occurred";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void GetAllOrders()
        {
            List<BusinessObjectOrder> businessObjectOrder = new List<BusinessObjectOrder>();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("PurchaseAmount");
            //dt.Columns.Add("OrderDate");
            //dt.Columns.Add("CustomerId");
            //dt.Columns.Add("SalesmanId");
            //dt.Columns.Add("Update");
            //dt.Columns.Add("Delete");
            businessObjectOrder = logic.GetOrderDetails(businessObjectOrder);
            gvOrders.DataSource = businessObjectOrder;

            gvOrders.DataBind();
        }

        private void ClearFields()
        {
            txtPurchAmount.Text = string.Empty;
            txtOrderDate.Text = string.Empty;
            txtCustomerId.Text = string.Empty;
            txtSalesId.Text = string.Empty;
            txtPurchAmount.Focus();
        }
    }
}