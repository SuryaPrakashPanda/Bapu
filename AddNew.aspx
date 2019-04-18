<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddNew.aspx.cs" Inherits="RohiniBankBilling.AddNew" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @import url(https://fonts.googleapis.com/css?family=Lato:400,900,700,300);

        .heading4 {
            font-size: 18px;
            font-weight: 400;
            font-family: 'Lato', sans-serif;
            color: #111111;
            margin: 0px 0px 5px 0px;
        }

        .heading1 {
            font-size: 30px;
            line-height: 20px;
            font-family: 'Lato', sans-serif;
            text-transform: uppercase;
            color: #1b2834;
            font-weight: 900;
        }

        .content-quality {
            float: left;
            width: 193px;
        }

            .content-quality p {
                margin-left: 10px;
                font-family: 'Open Sans', sans-serif;
                font-size: 14px;
                font-weight: 600;
                line-height: 17px;
            }

                .content-quality p span {
                    display: block;
                }

        .tabtop li a {
            font-family: 'Lato', sans-serif;
            font-weight: 700;
            color: #1b2834;
            border-radius: 0px;
            margin-right: 22.008px;
            border: 1px solid #ebebeb !important;
        }

        .tabtop .active a:before {
            content: " ";
            position: absolute;
            top: 15px;
            left: 82px;
            color: green;
            font-size: 30px;
        }

        .tabtop li a:hover {
            color: #e31837 !important;
            text-decoration: none;
        }

        .tabtop .active a:hover {
            color: green !important;
        }

        .tabtop .active a {
            background-color: #5cb85c !important;
            color: #FFF !important;
        }

        .margin-tops {
            margin-top: 0px;
        }

        .tabtop li a:last-child {
            padding: 10px 22px;
        }

        .thbada {
            padding: 10px 28px !important;
        }

        section p {
            font-family: 'Lato', sans-serif;
        }

        .margin-tops4 {
            margin-top: 20px;
        }

        .tabsetting {
            border-top: 2px solid #68caf0;
            padding-top: 6px;
        }

        .services {
            background-color: #d4d4d4;
            min-height: 710px;
            padding: 65px 0 27px 0;
        }

            .services a:hover {
                color: #000;
            }

            .services h1 {
                margin-top: 0px !important;
            }

        .heading-container p {
            font-family: 'Lato', sans-serif;
            text-align: center;
            font-size: 16px !important;
            text-transform: uppercase;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <section id="main-content">
        <section class="wrapper site-min-height">
            <div class="row mt">
                <div class=" col-lg-12 panel" style="padding: 20px">

                    <div class=" col-lg-12">
                        <h4 class=" ">Add Information</h4>



                        <div class="clearfix"></div>

                        <div class="tabbable-panel margin-tops4 ">
                            <div class="tabbable-line">
                                <ul class="nav nav-tabs tabtop  tabsetting">
                                    <li class="active"><a href="#tab_default_1" data-toggle="tab">Add Company</a> </li>
                                    <li><a href="#tab_default_2" data-toggle="tab">Add Bank</a> </li>
                                    <li><a href="#tab_default_3" data-toggle="tab">Add Village</a> </li>
                                    <li><a href="#tab_default_4" data-toggle="tab">Add Customer</a> </li>

                                </ul>
                                <div class="tab-content margin-tops">
                                    <div class="tab-pane active fade in" id="tab_default_1">
                                        <div class="row">
                                            <div class=" col-sm-offset-10 col-md-2">
                                                <h2 style="float: right"><a href="Comapnylist.aspx"><i class=" fa fa-search"></i></a></h2>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-4">
                                                Company Name 
                <span class="style1" style="color: red;">*</span>
                                                <asp:TextBox ID="txtcompany" class="form-control" runat="server"></asp:TextBox>
                                              
                                            </div>
                                            <div class="col-sm-4">
                                                Address               
                <asp:TextBox ID="txtcmpnyaddress" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-4" style="padding-top: 16px">
                                                    <asp:Button ID="Btncompany" class="btn btn-success " runat="server" Text="Submit" OnClick="Btncompany_Click" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="tab-pane fade" id="tab_default_2">
                                        <div class="row">
                                            <div class=" col-sm-offset-10 col-md-2">
                                                <h2 style="float: right"><a href="accountlist.aspx"><i class=" fa fa-search"></i></a></h2>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-4">
                                                Company
                <span class="style1" style="color: red;">*</span>
                                                <asp:DropDownList ID="drpcompanyac" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-sm-3">
                                                Bank                
                        <asp:DropDownList ID="ddlbank" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-md-1" style="padding-top: 18px">
                <div class="form-group">
                    <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#myModal4">+</button>
                </div>
            </div>

                                            <div class="col-sm-4">
                                                Account Number               
                <asp:TextBox ID="txtaccount" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                           
                                        </div>
                                        <br>
                                        <div class="row">
                                             <div class="col-sm-4">
                                                IFSC                
                <asp:TextBox ID="txtifsc" class="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-4" style="padding-top: 16px">
                                                <asp:Button ID="btnaccount" class="btn btn-success " runat="server" Text="Submit" OnClick="btnaccount_Click" />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="tab-pane fade" id="tab_default_3">
                                        <div class="row">
                                            <div class=" col-sm-offset-10 col-md-2">
                                                <h2 style="float: right"><a href="villagelist.aspx"><i class=" fa fa-search"></i></a></h2>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-4">
                                                Company
                <span class="style1" style="color: red;">*</span>
                                                <asp:DropDownList ID="drpcompanyvlg" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4">
                                                Village <span class="style1" style="color: red;">*</span>
                                                <asp:TextBox ID="txtvillage" class="form-control" runat="server"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-sm-4" style="padding-top: 16px">
                                                <asp:Button ID="btnvillage" class="btn btn-success " runat="server" Text="Submit" OnClick="btnvillage_Click" />
                                            </div>
                                        </div>

                                    </div>

                                    <div class="tab-pane fade" id="tab_default_4">
                                        <div class="row">
                                            <div class=" col-sm-offset-10 col-md-2">
                                                <h2 style="float: right"><a href="customerlist.aspx"><i class=" fa fa-search"></i></a></h2>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-4">
                                                Company
                <span class="style1" style="color: red;">*</span>
                                                <asp:DropDownList ID="drpcompanycust" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4">
                                                Village <span class="style1" style="color: red;">*</span>
                                                <asp:DropDownList ID="drpvilagecus" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                             <div class="col-sm-4">
                                                Customer Company Name <span class="style1" style="color: red;">*</span>
                                                <asp:TextBox ID="txtcustcmpname" class="form-control" runat="server"></asp:TextBox>

                                            </div>
                                            </div>
                                       <br />
                                        <div class="row">
                                            <div class="col-sm-4">
                                                CustomerName <span class="style1" style="color: red;">*</span>
                                                <asp:TextBox ID="txtcust" class="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        
                                            <div class="col-sm-4" style="padding-top: 16px">
                                                <asp:Button ID="btncust" class="btn btn-success " runat="server" Text="Submit" OnClick="btncust_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="modal fade" id="myModal4" role="dialog">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Add Bank</h4>
                        </div>
                        <div class="modal-body">
                            <p>
                                <asp:TextBox ID="Textbank" runat="server" class="form-control" />
                            </p>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="Button1" CommandName="Update" class="btn btn-default" runat="server" CausesValidation="false" Text="Add" OnClick="Button1_Click" />
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>

                            </div>


                        </div>
                    </div>

                </div>
            </div>


        </section>
    </section>
</asp:Content>



