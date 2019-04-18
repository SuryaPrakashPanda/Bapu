<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="accountlist.aspx.cs" Inherits="RohiniBankBilling.accountlist" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content-header">
        <asp:ScriptManager runat="server">
    </asp:ScriptManager>
      <h3>Bank Details</h3></section>
   <br style="color:red"; />
        
    
    <section class="content">

        <div class="row">
            <div class="col-md-3">
                    <div class="form-group">
                      <asp:TextBox ID="txtsearch" CssClass="form-control" runat="server"></asp:TextBox>
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
                                <asp:GridView ID="GridView1" class="table table-bordered table-striped" runat="server" DataKeyNames="id" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="id" Visible="false" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:BoundField DataField="sno" HeaderText="Sno" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:BoundField DataField="companyname" HeaderText="Company Name" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />
                                        <asp:BoundField DataField="bankname" HeaderText="Bank" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />  
                                        <asp:BoundField DataField="AccountNo" HeaderText="A/C Number" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" />  
                                        <asp:TemplateField  HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkedit" CausesValidation="false" runat="server" OnClick="linkedit_Click"
                                                    CommandArgument='<%# Eval("id") %>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>

                                         <asp:TemplateField  HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkdelete" CausesValidation="false" runat="server" OnClick="linkdelete_Click"
                                                    CommandArgument='<%# Eval("id") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" Animations="" PopupControlID="Panel1" CancelControlID="btncancel" TargetControlID="HiddenField1"></cc1:ModalPopupExtender>
                            <asp:Panel ID="Panel1" runat="server" Style="background-color: rgba(0,0,0,0.8); box-shadow: 10px 12px 15px gray; color: #fff" BorderColor="#cecece" BorderStyle="Solid" BorderWidth="1px" Height="280px" Width="600px">
                                <h3 class="text-center">Update Details</h3>
                                <hr />
                                <div class="col-md-5">
                                    <div class="form-group">
                                        Bank 
                                        <asp:TextBox ID="txtbank" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        A/C Number 
                                        <asp:TextBox ID="txtacno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3" style="padding-top: 20px">
                                    <div class="form-group">
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        <asp:Button ID="btnupdate" CssClass="btn btn-success" Style="margin-top: -2px;" runat="server" Text="Update" OnClick="btnupdate_Click" CausesValidation="false" />
                                    </div>
                                </div>
                                <div class="col-md-3" style="padding-top: 20px">
                                    <div class="form-group">
                                        <asp:Button ID="btncancel" CssClass="btn btn-danger" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Label ID="lblid" runat="server" Text="" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


</asp:Content>

