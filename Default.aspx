<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RohiniBankBilling.Default" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Rohini | Log in</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href=" dist/css/AdminLTE.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href=" plugins/iCheck/square/blue.css">

   
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->


 <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"> 
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>


    <link href="animate.css" rel="stylesheet" />
    <style>
        .btn-default{
            margin-left:288px;
            margin-top:-50px;
        }
    </style>
</head>

 
<body class="hold-transition login-page"  style="background:linear-gradient(rgba(0,0,0,0.2),rgba(0,0,0,0.2)), url(https://besthqwallpapers.com/img/original/40103/business-money-transfer-euro-bundle-of-money-payment.jpg) center fixed !important;  ">
    <form id="form1" runat="server">
       <div class="login-box">
  <div class="login-logo">
      
      <a href=" index2.html"><h2 class='animated bounceInDown'><b style="color:#fff; background-color:rgba(0,0,0,0.6); padding:0px 7px;">Rohini</b></h2></a>
  </div>
  <!-- /.login-logo -->

           

  <div class="login-box-body animated slideInUp" style="background-color:rgba(0,0,0,0.6) !important; border-radius:10px">
    <p class="login-box-msg" style="color:white">Sign in to start your session</p>

    
      <div class="form-group has-feedback">
            <asp:TextBox ID="txtuname" class="form-control"  placeholder="User Name"  style="border-radius:15px"
                        runat="server" ></asp:TextBox><span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <asp:TextBox ID="txtpass" class="form-control" TextMode="Password" style="border-radius:15px"
                        placeholder="Password" runat="server"></asp:TextBox>

         
          <button id="show_password" class="btn btn-default"  type="button">
              <span class="fa fa-eye-slash icon"></span>
          </button>

      </div>
      <div class="row">
        
        <!-- /.col -->
        <div class="col-md-offset-8 col-xs-4">
       <asp:Button ID="btnsignin" runat="server" Text="Sign in" class="btn btn-success btn-block " OnClick="btnsignin_Click" />
        </div>
        <!-- /.col -->
      </div>
    
    
    
   
  </div>
  <!-- /.login-box-body -->
</div>
    </form>

    <script type="text/javascript">  
        $(document).ready(function () {  
            $('#show_password').hover(function show() {  
                
                $('#txtpass').attr('type', 'text');  
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');  
            },  
            function () {  
             
                $('#txtpass').attr('type', 'password');  
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');  
            });  
             
            $('#ShowPassword').click(function () {  
                $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');  
            });  
        });  
    </script>  

<!-- jQuery 2.2.3 -->
<script src=" plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src=" bootstrap/js/bootstrap.min.js"></script>
<!-- iCheck -->
<script src=" plugins/iCheck/icheck.min.js"></script>
<script>
  $(function () {
    $('input').iCheck({
      checkboxClass: 'icheckbox_square-blue',
      radioClass: 'iradio_square-blue',
      increaseArea: '20%' // optional
    });
  });
</script>
</body>
</html>
