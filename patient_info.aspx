<%@ Page Title="بيانلت المريض" Language="C#" MasterPageFile="~/master3.Master" AutoEventWireup="true" CodeBehind="patient_info.aspx.cs" Inherits="Royal_Elshrouq.patient_info" %>
<%@ Import NameSpace="System.Data.SqlClient" %>
<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Web.UI.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    
     <div  runat="server" class="auto-style4" >
    <asp:Label ID="lbl2_m" runat="server" Text="Label" class="lbl_hello"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_m" runat="server" Text="Label" class="lbl_hello"></asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="head" runat="server">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/css/bootstrap-datepicker.min.css" />
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/js/bootstrap-datepicker.min.js"></script>
    
     <script type="text/javascript">
         function digitcount() {
             var cardTextBox = document.getElementById('<%= card.ClientID %>');
             var digitcountlabel = document.getElementById('<%= digitcount.ClientID %>');
             if (cardTextBox) {
                 var maxlength = 14;

                 if (cardTextBox.value.length > maxlength) {

                     cardTextBox.value = cardTextBox.value.substring(0, maxlength);
                 }

                 var digitCount = cardTextBox.value.length;
                 digitcountlabel.innerHTML = "تم ادخال  : " + digitCount + " رقم ";
             }
           
         }

         function whatscount() {
                       var whatsTextBox = document.getElementById('<%= whats.ClientID %>');
                      var digitcountlabel2 = document.getElementById('<%= whatscount.ClientID %>');
             if (whatsTextBox) {
                 var maxlength = 11;

                 if (whatsTextBox.value.length > maxlength) {

                     whatsTextBox.value = whatsTextBox.value.substring(0, maxlength);
                 }

                 var whatscount = whatsTextBox.value.length;
                 digitcountlabel2.innerHTML = "تم ادخال  : " + whatscount + " رقم ";
             }

         }
     </script>    
    <style>

        .container {
            width: 80%;
            margin: auto;
            background-color: white;
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 20px;
            text-align: center;
            align-items:center;
            align-content:center;
        }

        .txtrow {
            display: flex;
          justify-content: center; 
            align-items: center;
            margin-bottom: 20px;
            width:70%;
           
        }

        .row .label {
            font-size: 16px;
            color: black;
            text-align:center;
            display: flex;
            align-items: center;
            width: 100%;
        }

        .txtrow input[type="text"] {
            width: 100%; 
            padding: 10px;
            font-size: 18px;
            border: 1px solid #ccc;
            border-radius: 5px;
      
        }

        .txtrow input[type="button"] {
            background: #bf0c0c;
            color: white;
            padding: 10px 15px;
            border-radius: 5px;
            border: none;
            font-size: 18px;
            cursor: pointer;
          
        }

        .txtrow input[type="button"]:hover {
            background: #990000;
        }

        .radio-group {
            width: 50%; 
            display: flex;
            justify-content: center; 
            align-items: center;
            margin-top: 10px;
        }

        .auto-style5,
        .auto-style7 {
            width: 50%;
            height: 1px;
            background: #ccc;
            margin-top: 10px;
        }

        .submit-button {
            margin-top: 20px;
            align-items:center
        }
         .auto-style12 {
          width: 100%;
         
         }
        .auto-style13 {
            width: 101%;
        }

      
    .label-container {
        display: flex;
        flex-direction: column;
    }

    .label-container label,
    .label-container input {
        margin-bottom: 5px;
    }
</style>
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <form runat="server"  class="container" style="width: 70%;">   
<!----------------------------------------------------------- group 1--------------------------------------------------------- -->
     <div class="row">

              <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label7" runat="server" Text="الجنسية"></asp:Label>
                      <asp:DropDownList ID="nation" runat="server" CssClass="form-control">
                          <asp:ListItem Value="مصرى">مصرى</asp:ListItem>
                          <asp:ListItem Value="اجنبى">اجنبى</asp:ListItem>
                      </asp:DropDownList>
                  </div>
              </div>
              <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label5" runat="server" Text="رقم البطاقة"></asp:Label>
                      <asp:TextBox ID="card" runat="server" CssClass="form-control" Width="240px" AutoPostBack="true" onkeyup="digitcount()"></asp:TextBox>
                      <asp:Label ID="digitcount" runat="server" ForeColor="Red"></asp:Label>
                  </div>
              </div>
            <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label4" runat="server" Text="رقم الجواز"></asp:Label>
                      <asp:TextBox ID="gaz" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
                  </div>
              </div>
          </div>
<!----------------------------------------------------------- group 2--------------------------------------------------------- -->
     <div class="row">
              <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro2l3" runat="server" Text="المحافظه"></asp:Label>
                      <asp:DropDownList ID="gov" runat="server" CssClass="form-control">
                      <asp:ListItem Value="القاهره">القاهره</asp:ListItem>
                      <asp:ListItem Value="الجيزه">الجيزه</asp:ListItem>
                      </asp:DropDownList>
                  </div>
              </div>
               <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro2l2" runat="server" Text="المدينه"></asp:Label>
                      <asp:DropDownList ID="city" runat="server" CssClass="form-control">
                       <asp:ListItem Value="الخليفة">الخليفة</asp:ListItem>
                        <asp:ListItem Value="الفسطاط">الفسطاط</asp:ListItem>

                      </asp:DropDownList>
                  </div>
              </div>

          <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro2l1" runat="server" Text="العنوان"></asp:Label>
                      <asp:TextBox ID="address" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
                  </div>
            </div>
 </div>
<!----------------------------------------------------------- group 3--------------------------------------------------------- -->
     <div class="row">
               <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro3l2" runat="server" Text="الشركة"></asp:Label>
                      <asp:DropDownList ID="work" runat="server" CssClass="form-control">
                      <asp:ListItem Value=" بتروجيت"> بتروجيت</asp:ListItem>
                      </asp:DropDownList>
                  </div>
              </div>  
               <div class="col-md-4">
                  <div class="form-group text-right">
                 <asp:Label ID="ro3l3" runat="server" Text="الوظيفة"></asp:Label>
                      <asp:DropDownList ID="job" runat="server" CssClass="form-control">
                      <asp:ListItem Value="مدير">مدير</asp:ListItem>
                      <asp:ListItem Value="محاسب">محاسب</asp:ListItem>
                      </asp:DropDownList>
                  </div>
                     
                
             </div>
               <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label6" runat="server" Text="اساسى"></asp:Label>
                      <asp:DropDownList ID="sick_type" runat="server" CssClass="form-control">
                      <asp:ListItem Value="اساسى">اساسى</asp:ListItem>
                       <asp:ListItem Value="تابع">تابع</asp:ListItem>
                      </asp:DropDownList>
                  </div>
              </div>
 </div>
<!----------------------------------------------------------- group 4--------------------------------------------------------- -->
     <div class="row">
             <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro4l1" runat="server" Text="رقم الوثيقة"></asp:Label>
                      <asp:TextBox ID="doc_n" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
                  </div>
              </div>
             <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro4l2" runat="server" Text="الرقم التامينى"></asp:Label>
                      <asp:TextBox ID="tam_n" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
                  </div>
              </div>
               <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro4l3" runat="server" Text=" النوع"></asp:Label>
                      <asp:DropDownList ID="sex" runat="server" CssClass="form-control">
                      <asp:ListItem Value="ذكر">ذكر</asp:ListItem>
                       <asp:ListItem Value="انثى">انثى</asp:ListItem>
                      </asp:DropDownList>
                  </div>
              </div>
 </div>    
<!----------------------------------------------------------- group 5--------------------------------------------------------- -->
     <div class="row">

             <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label1" runat="server" Text="تحمل المريض"></asp:Label>                 
                      <asp:TextBox ID="pat_per" runat="server" AutoPostBack="true" OnTextChanged="CalculatePercentage" CssClass="form-control" Width="240px"></asp:TextBox>
                  </div>
              </div>
             <div class="col-md-4">
                  <div class="form-group text-right">
                       <asp:Label ID="Label2" runat="server" Text="تحمل الجهه"></asp:Label>
                       <asp:TextBox ID="sup_per" runat="server"  Width="240px" AutoPostBack="true"  ReadOnly="true" CssClass="form-control"></asp:TextBox>  
                  </div>
              </div>
      <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="pat_per" MinimumValue="0" MaximumValue="100" Type="Integer" Text="Enter a valid percentage (0-100)" />





 </div>  
<!----------------------------------------------------------- group 6--------------------------------------------------------- -->
     <div class="row">
               <div class="col-md-4">
                  <div class="form-group text-right">
                     <asp:Label ID="ro5l3" runat="server" Text="رقم الحجز"></asp:Label>
                      <asp:DropDownList ID="b_n" runat="server" CssClass="form-control">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                      </asp:DropDownList>
                  </div>
              </div>
               <div class="col-md-4">
                  <div class="form-group text-right">
                     <asp:Label ID="ro5l2" runat="server" Text="رقم الشركة"></asp:Label>
                      <asp:DropDownList ID="c_n" runat="server" CssClass="form-control">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                      </asp:DropDownList>
                  </div>
              </div>

             <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro5l1" runat="server" Text="رقم العضويه"></asp:Label>
                      <asp:TextBox ID="memb_n" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
                  </div>
              </div>
         
  </div>         
<!----------------------------------------------------------- group 7--------------------------------------------------------- -->
     <div class="row">     
             <div class="col-md-4">
                  <div class="form-group text-right">
                     <asp:Label ID="ro6l2" runat="server" Text="رقم الدوسيه"></asp:Label>
                      <asp:TextBox ID="dos_n" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
                  </div>
              </div>
        
              <div class="col-md-4">
                  <div class="form-group text-right">
                   <asp:Label ID="ro6l1" runat="server" Text="رقم الرف"></asp:Label>
                      <asp:TextBox ID="raf_n" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
                  </div>
              </div>       
   </div>        
 <!----------------------------------------------------------- group 8--------------------------------------------------------- -->
     <div class="row">   
                   <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro7l3" runat="server" Text="Facebook"></asp:Label>
                      <asp:TextBox ID="face" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>                   
                  </div>
              </div>
             <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro7l2" runat="server" Text="WhatsApp"></asp:Label>
                      <asp:TextBox ID="whats" runat="server" CssClass="form-control" Width="240px" AutoPostBack="true"   onkeyup="whatscount()"></asp:TextBox>
                      <asp:Label ID="whatscount" runat="server" ForeColor="Red"></asp:Label>
                  </div>
              </div>
             <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro7l1" runat="server" Text="E_mail"></asp:Label>
                      <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
  <asp:RegularExpressionValidator ID="regexEmail" runat="server"
    ControlToValidate="txtEmail"
    ValidationExpression="\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b"
    ErrorMessage="البريد الإلكتروني غير صحيح"
    Display="Dynamic"
    ForeColor="Red">
</asp:RegularExpressionValidator>                 
                      </div>
              </div>


 </div>  
 <!----------------------------------------------------------- group 9--------------------------------------------------------- -->
     <div class="row">
                <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label22" runat="server" Text="الصورة الشخصيه"></asp:Label>
                      <asp:FileUpload ID="p_pic" runat="server"  CssClass="form-control" />
                     <asp:Image ID="Im_p_pic" runat="server" Width="50%" Height="50%" Visible="False" />
                  </div>
              </div>         
                <div class="col-md-4">
                  <div class="form-group text-right">
                        <asp:Label ID="Label3" runat="server" Text="صورة البطاقة" ></asp:Label>
                        <asp:FileUpload ID="card_pic" runat="server" CssClass="form-control"/>
                       <asp:Image ID="Im_card_pic" runat="server" Width="50%" Height="50%" Visible="False"/>  
                  </div>
              </div>

                <div class="col-md-4">
                  <div class="form-group text-right">
                         <asp:Label ID="Label21" runat="server" Text="صوره الكارنيه"></asp:Label>
                         <asp:FileUpload ID="pic" runat="server"   CssClass="form-control"/>            
                        <asp:Image ID="Im_pic" runat="server" Width="50%" Height="50%" Visible="False"/>
                  </div>
              </div>
 
    </div>        
 <!----------------------------------------------------------- group 10--------------------------------------------------------- -->       
 
          <div class=" label ">
               <asp:Label ID="lbl_message" runat="server" style="  align-content: center;" Font-Bold="True" ForeColor="black"></asp:Label>
           </div>
                <div class="col-md-12 text-center">
                 <asp:Button ID="update_data" runat="server" Text="تخزين" CssClass="btn btn-primary" Width="125px" style="background-color: #41AB88;" OnClick="info_Click" />                </div>
          
 <!----------------------------------------------------------- finish--------------------------------------------------------- -->       


</form>
</asp:Content>






  
       