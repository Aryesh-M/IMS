<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="_3LayerInventory.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2>Welcome to Customers Page!</h2>

    <br />
    <br />
    <h2><span class="badge badge-info btn-lg btn-block">Enter a New Customer</span></h2>
    <br />
    <div class="form-group row">
        <label for="txtCustName" class="col-sm-2 col-form-label">Customer Name</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtCustName" runat="server" placeholder="Customer Name"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label for="txtCity" class="col-sm-2 col-form-label">City</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtCity" runat="server" placeholder="City"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label for="txtGrade" class="col-sm-2 col-form-label">Grade</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtGrade" runat="server" placeholder="Grade"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label for="txtSalesId" class="col-sm-2 col-form-label">Salesman Id</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtSalesId" runat="server" placeholder="Salesman Id"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-sm-10">
            <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Enter Customer" OnClick="btnSubmit_Click"></asp:Button>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>
    </div>

    <h1><span class="badge badge-success btn-lg btn-block">Existing Customers</span></h1>
    <p>
        <asp:GridView ID="gvCustomerData" runat="server">
        </asp:GridView>
    </p>
</asp:Content>
