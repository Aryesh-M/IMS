using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace _3LayerInventory
{
    public partial class Salesman : System.Web.UI.Page
    {
        SalesmanBL logic = new SalesmanBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllSalesmen();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtSalesmanName.Text;
            string city = txtCity.Text;
            string commission = txtCommission.Text;

            BusinessObjectSalesman salesmanBO = new BusinessObjectSalesman()
            {
                Name = name,
                City = city,
                Commission = Convert.ToDecimal(commission)
            };
            int result = logic.InsertSalesman(salesmanBO);
            if (result > 0)
            {
                GetAllSalesmen();
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

        private void GetAllSalesmen()
        {
            List<BusinessObjectSalesman> businessObjectSalesman = new List<BusinessObjectSalesman>();
            businessObjectSalesman = logic.GetSalesmanDetails(businessObjectSalesman);
            gvSalesman.DataSource = businessObjectSalesman;

            gvSalesman.DataBind();
        }

        private void ClearFields()
        {
            txtSalesmanName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCommission.Text = string.Empty;
            txtSalesmanName.Focus();
        }

        protected void ShowData()
        {
        }
    }
}