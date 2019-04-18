<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="purchesbillentry.aspx.cs" Inherits="RohiniBankBilling.purchesbillentry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-success {border-radius: 12px !important;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="box">
        <div class="box-header">
            <h3 class="box-title" style="font-size:large; font-weight:bold; color:green;">Bill Entry</h3>
        
        </div>
        <div class="box-body">
           
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                    Date:<asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="cal1" runat="server" TargetControlID="txtdate" Format="yyyy-MM-dd" />
                        
                        </div>
                </div>
                <div class="col-md-3">
                     <div class="form-group">
                    Village:<asp:DropDownList ID="drpvillage" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpvillage_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                </div>
                
                <div class="col-md-3">
                     <div class="form-group">
                    Company:<asp:DropDownList ID="drpcomp" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                </div>
                
                <div class="col-md-3">
                     <div class="form-group">
                    Invoice Number:<asp:TextBox ID="txtinvoiceno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                </div>
               </div>
                
            <div class="row">
            
                
                    <div class="col-md-3">
                     <div class="form-group">
                    Invoice Date:<asp:TextBox ID="txtinvdate" runat="server" CssClass="form-control"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtinvdate" Format="yyyy-MM-dd" />
                        </div>
                </div>
               
                <div class="col-md-3">
                    
                     <div class="form-group">
                    Vehical Number:<asp:TextBox ID="txtvehical" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                </div>
               
                
                    <div class="col-md-3">
                     <div class="form-group">
                    Bill Amount:<asp:TextBox ID="txtbillamnt" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
               
                </div>
                
                    <div class="col-md-3">
                        <div class="form-group">
                            Bill:<asp:FileUpload ID="billpdf" runat="server" CssClass="form-control" />
                        </div>
                </div>
                </div>
            <div class="row">

                <div class="form-group">
                    <div class="col-md-3">
                        <asp:Button ID="save" runat="server" CssClass="btn btn-success" Text="save" OnClick="save_Click"/>
                    </div>
                </div>
            </div>
                </div>
            </div>
     
    

</asp:Content>
