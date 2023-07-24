using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _3LayerInventory
{
    public partial class Customer : System.Web.UI.Page
    {
        CustomerBL logic = new CustomerBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetCustomerData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertData();
        }
        private void GetCustomerData()
        {
            List<BusinessObjectCustomer> businessObjectCustomer = new List<BusinessObjectCustomer>();
           
            businessObjectCustomer = logic.GetCustomerDetails(businessObjectCustomer);
            gvCustomerData.DataSource = businessObjectCustomer;

            gvCustomerData.DataBind();
        }
        private void InsertData()
        {
            string custName = txtCustName.Text;
            string city = txtCity.Text; 
            string grade = txtGrade.Text;
            string salesmanId = txtSalesId.Text;

            BusinessObjectCustomer customerBO = new BusinessObjectCustomer()
            {
                CustName = custName,
                City = city,
                Grade = Convert.ToInt32(grade),
                SalesmanId = Convert.ToInt32(salesmanId)
            };

            int result = logic.InsertCustomer(customerBO);
            if (result > 0)
            {
               GetAllCustomers();
                lblMessage.Text = "Customer added sucessfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                ClearFields();
            }
            else
            {
                lblMessage.Text = "An Error has occurred";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void GetAllCustomers()
        {
            List<BusinessObjectCustomer> businessObjectCustomer = new List<BusinessObjectCustomer>();
            businessObjectCustomer = logic.GetCustomerDetails(businessObjectCustomer);
            gvCustomerData.DataSource = businessObjectCustomer;

            gvCustomerData.DataBind();
        }
        private void ClearFields()
        {
            txtCustName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtGrade.Text = string.Empty;
            txtSalesId.Text = string.Empty;
            txtCustName.Focus();
        }

    }
}