<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PurchaseBillDetails.aspx.cs" Inherits="RohiniBankBilling.PurchaseBillEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="box box-success">

                <div class="box-body">
                    <h3>Purchase Bill Details</h3>
                    <div class="row">
                        
                        <div class="col-md-12">
                            <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:GridView ID="GridView1" class="table table-bordered table-striped" runat="server" DataKeyNames="Id" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                    <asp:BoundField DataField="date" HeaderText="Date" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                    <asp:BoundField DataField="village" HeaderText="Village" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                    <asp:BoundField DataField="company" HeaderText="Company" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                    <asp:BoundField DataField="invoiceno" HeaderText="Invoice No" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                    <asp:BoundField DataField="invoicedate" HeaderText="Invoice Date" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                    <asp:BoundField DataField="vehical" HeaderText="Vehical " HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                    <asp:BoundField DataField="billamount" HeaderText="Bill Amount" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                    <asp:BoundField DataField="billpdf" HeaderText="Bill PDF" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" Visible="false" />
                                    <asp:TemplateField HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkpdf" CausesValidation="false" runat="server" href='<%# Eval("billpdf1") %>'><i class="fa fa-file-pdf-o"></i></asp:LinkButton>                                           
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <asp:Literal ID="ltEmbed" runat="server" />
                        <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
