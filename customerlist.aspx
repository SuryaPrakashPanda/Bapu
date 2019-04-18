<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="customerlist.aspx.cs" Inherits="RohiniBankBilling.customerlist" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
 <script type="text/javascript">
           function Search_Gridview(strKey) {
               var strData = strKey.value.toLowerCase().split(" ");
               var tblData = document.getElementById("<%=GridView1.ClientID %>");
               var rowData;
               for (var i = 1; i < tblData.rows.length; i++) {
                   rowData = tblData.rows[i].innerHTML;
                   var styleDisplay = 'none';
                   for (var j = 0; j < strData.length; j++) {
                       if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                           styleDisplay = '';
                       else {
                           styleDisplay = 'none';
                           break;
                       }
                   }
                   tblData.rows[i].style.display = styleDisplay;
               }
           }  
       </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content-header">
        <asp:ScriptManager runat="server">
    </asp:ScriptManager>
      <h3>Customer List</h3></section>
   <br style="color:red"; />
        
    
    <section class="content">

        <div class="row">
            <div class="col-md-3" style="padding-left: 10px;">
                <asp:TextBox ID="TextBox1" runat="server" Font-Size="15px" placeholder="Search....." CssClass="form-control" onkeyup="GridView1(this)"></asp:TextBox><br />
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
                                        <asp:BoundField DataField="villagename" HeaderText="Village Name" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" /> 
                                        <asp:BoundField DataField="custcompany" HeaderText="Customer Company " HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" /> 
                                        <asp:BoundField DataField="custName" HeaderText="Customer Name" HeaderStyle-BackColor="#1a94d8" HeaderStyle-ForeColor="white" /> 
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
                             <asp:Button ID="Button5" runat="server" style="display:none" />
                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Button5" PopupControlID="Panel1" CancelControlID="cancel" BackgroundCssClass="tableBackground"></cc1:ModalPopupExtender>
                            <asp:Panel ID="Panel1" runat="server" BackColor="Gray" Style="background-color: rgba(0,0,0,0.8); box-shadow: 10px 12px 15px gray; color: #fff">
                                <h3 class="text-center">Update Details</h3>
                                <hr />
                                <div class="col-md-5">
                                    <div class="form-group">
                                        Customer
                                        <asp:TextBox ID="txtcustmoredit" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <br />
                                        <asp:Button ID="update" runat="server" class="btn btn-success" OnClick="update_Click" Text="Update" />
                                        <asp:Button ID="cancel" runat="server" class="btn btn-danger" Text="Cancel"></asp:Button>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


