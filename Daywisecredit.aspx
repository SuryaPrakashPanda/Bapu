<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Daywisecredit.aspx.cs" Inherits="RohiniBankBilling.Daywisecredit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content-header">
        <asp:ScriptManager runat="server">
    </asp:ScriptManager>
      <h3> Credit Reports</h3></section>
   <br style="color:red"; />
        
    
    <section class="content">

        <div class="row">
            <div class="col-md-3">
                    <div class="form-group">
                        Date<asp:TextBox ID="txtdate" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtdate_TextChanged"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtdate" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtdate" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
        </div>

        <div class="row">

            <div class="col-md-12">
                <div class="box box-success">

                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">

                                <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:GridView ID="GridView1" class="table table-bordered table-striped" runat="server" DataKeyNames="Id" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:BoundField DataField="sno" HeaderText="Sno" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:BoundField DataField="date1" HeaderText="Date" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:BoundField DataField="companyname" HeaderText="CompanyName" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:BoundField DataField="accountno" HeaderText="A/C No" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:BoundField DataField="village" HeaderText="Village" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:BoundField DataField="Customename" HeaderText="CustomerName" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:BoundField DataField="amount" HeaderText="RFID No" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" Visible="false" />
                                        <asp:BoundField DataField="tranthrough" HeaderText="Transaction Mode" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:BoundField DataField="trantype" HeaderText="Transaction Type" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                         <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="White">
                                            <ItemTemplate>
                                                <div class="btn-group text-center">
                                                    <button type="button" class="btn btn-warning btn-sm dropdown-toggle" data-toggle="dropdown" aria-expanded="false" runat="server">
                                                        Actions
                                                    <span class="caret"></span>
                                                    </button>
                                                    <ul class="dropdown-menu " role="menu">
                                                        <li>
                                                            <p style="padding: 5px; margin-bottom: 0rem !important">
                                                                <asp:LinkButton ID="lnkDone" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ID") %>' ForeColor="#006600" OnClick="lnkDone_Click"><i class=""></i>Done</asp:LinkButton>
                                                            </p>
                                                        </li>
                                                        <li>
                                                            <p style="padding: 5px; margin-bottom: 0rem !important">
                                                                <asp:LinkButton ID="lnkUnderProcess" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ID") %>'  ForeColor="#ff9900" OnClick="lnkUnderProcess_Click" ><i class=""></i> Under Process</asp:LinkButton>
                                                            </p>
                                                        </li>
                                                          <li>
                                                            <p style="padding: 5px; margin-bottom: 0rem !important">
                                                                <asp:LinkButton ID="lnkNotClear" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ID") %>' ForeColor="#6600cc" OnClick="lnkNotClear_Click"><i class=""></i> Not Clear</asp:LinkButton>
                                                            </p>
                                                        </li>
                                                        <li>
                                                            <p style="padding: 5px; margin-bottom: 0rem !important">
                                                                <asp:LinkButton ID="lnkChequeReturn" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ID") %>'  ForeColor="#ff0066" OnClick="lnkChequeReturn_Click"><i class=""></i>Cheque Return</asp:LinkButton>
                                                            </p>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <asp:Label ID="lblid" runat="server" Visible=" false"></asp:Label> 
                      
                    </div>

                </div>
              
            </div>
        </div>


    </section>



</asp:Content>
