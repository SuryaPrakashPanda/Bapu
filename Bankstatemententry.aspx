<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Bankstatemententry.aspx.cs" Inherits="RohiniBankBilling.Bankstatemententry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="box">
        <div class="box-header">
            <h2 class="box-title" style="font-size: 24px; color: green; font-weight: bold;">Add Cash</h2>
            <hr />
        </div>
        <!-- /.box-header -->

        <div class="box-body">
            <div class="row">
                <div class="col-md-3">

                    <strong>Transaction</strong>
                    <asp:RadioButtonList ID="radiotran" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">Debit</asp:ListItem>
                        <asp:ListItem Value="1">Credit</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="radiotran" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row">


                <div class="col-md-3">
                    <div class="form-group">
                        Date<asp:TextBox ID="txtdate" CssClass="form-control" runat="server" AutoPostBack="true"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtdate" Format="yyyy-MM-dd" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtdate" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="form-group">
                        Company<asp:DropDownList ID="drpcompany" runat="server" CssClass="form-control" OnTextChanged="drpcompany_TextChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>

                                <div class="col-md-3">
                    <div class="form-group">
                        Bank<asp:DropDownList ID="ddlbank" runat="server" CssClass="form-control" OnTextChanged="ddlbank_TextChanged"  AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>


                <div class="col-md-3">
                    <div class="form-group">
                        Account Number<asp:DropDownList ID="drpaccno" runat="server" CssClass="form-control" OnTextChanged="drpaccno_TextChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="drpaccno" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                </div>
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        Village<asp:DropDownList ID="drpvillage" runat="server" CssClass="form-control" OnTextChanged="drpvillage_TextChanged" AutoPostBack="true" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="drpvillage" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="form-group">
                        Customer Company<asp:DropDownList ID="drpcustcmpny" runat="server" CssClass="form-control" OnTextChanged="drpcustcmpny_TextChanged" AutoPostBack="true" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="drpvillage" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

           

          
                 <div class="col-md-3">
                    <div class="form-group">
                        CustomerName<asp:DropDownList ID="drpcustomer" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="drpcustomer" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class="col-md-3">
                    <div class="form-group">
                        Amount<asp:TextBox ID="txtamount" CssClass="form-control" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtamount" FilterType="Numbers" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtamount" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                </div>
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        Transaction Type<asp:DropDownList ID="drptrathrough" runat="server" CssClass="form-control" OnTextChanged="drptrathrough_TextChanged" AutoPostBack="true">
                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                            <asp:ListItem Value="1" Text="Cash"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Card"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Cheque"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                
                <asp:UpdatePanel ID="updatepanel1" runat="server">
                    <ContentTemplate>
                        <div id="div1" runat="server" visible="false">

                        <div class="col-md-3">
                            <div class="form-group">
                                Cheque Number<asp:TextBox ID="txtchequeno" CssClass="form-control" runat="server"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtchequeno" FilterType="Numbers" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtchequeno" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        </div>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>

                 <div class="col-md-3">
                    <div class="form-group">
                        Status<asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Done</asp:ListItem>
                            <asp:ListItem>Under process</asp:ListItem>
                            <asp:ListItem>Not Clear</asp:ListItem>
                            <asp:ListItem>Cheque Return</asp:ListItem>
                              </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlstatus" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                </div>
            <div class="row">
               <div class="col-md-3" style="padding-top:18px">
                <div class="form-group">
                    <asp:Button ID="btnadd" CssClass="btn btn-success" runat="server" Text="Add" OnClick="btnadd_Click" />
                    </div>
                  </div>
            </div>
           
            </div>
        </div>
       
</asp:Content>

