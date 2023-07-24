<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="_3LayerInventory.Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2>Welcome to Inventory Management System Orders!</h2>

    <br />
    <br />
    <h2><span class="badge badge-info btn-lg btn-block">Enter a New Order</span></h2>
    <br />
    <div class="form-group row">
        <label for="orderNo" class="col-sm-2 col-form-label">Purchase Amount</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtPurchAmount" runat="server" placeholder="Purchase Amount"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label for="orderDate" class="col-sm-2 col-form-label">Order Date</label>
        <div class="col-sm-10">
            <asp:TextBox type="date" class="form-control" ID="txtOrderDate" runat="server" placeholder="Order Date"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label for="customerId" class="col-sm-2 col-form-label">Customer Id</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtCustomerId" runat="server" placeholder="Customer Id"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label for="salesmanId" class="col-sm-2 col-form-label">Salesman Id</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtSalesId" runat="server" placeholder="Salesman Id"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-sm-10">
            <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Enter Order"></asp:Button>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>
    </div>

    <h1><span class="badge badge-success btn-lg btn-block">Existing Orders</span></h1>
    <asp:GridView ID="gvOrders" runat="server"></asp:GridView>

</asp:Content>
