<%@ Page Title="حجز ميعاد" Language="C#" MasterPageFile="~/patient.Master" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="Royal_Elshrouq.book" %>
<%@ Import NameSpace="System.Data.SqlClient" %>
<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Web.UI.WebControls" %>

 <asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
     <div  runat="server" class="auto-style4" >
    <asp:Label ID="lbl2_m" runat="server" Text="Label" class="lbl_hello"> </asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_m" runat="server" Text="Label" class="lbl_hello"></asp:Label>
</div>
 
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/css/bootstrap-datepicker.min.css" />
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/js/bootstrap-datepicker.min.js"></script>
 


  <script type="text/javascript">

      function showDay() {


          var today = new Date();
          var selectedDate = new Date(document.getElementById('<%= txtDate.ClientID %>').value);


            if (selectedDate < today) {
                alert("لا يمكن اختيار تاريخ قديم. الرجاء اختيار تاريخ لاحق أو يوم اليوم.");
                document.getElementById('<%= txtDate.ClientID %>').value = "";
            }

            var selectedDate = document.getElementById('<%= txtDate.ClientID %>').value;
        var dateObject = new Date(selectedDate);

        var options = { weekday: 'long' };
        var formatter = new Intl.DateTimeFormat('ar', options);
        var formattedDay = formatter.format(dateObject);

    
        var textBox1 = document.getElementById('<%= day.ClientID %>');
        textBox1.value = formattedDay;
        textBox1.readOnly = true;

        }


      function validateInput(input) {
          var regex = /^[a-zA-Z]+$|^[ء-ي\s]+$/;
          var lblValidation = document.getElementById('<%= lblValidation.ClientID %>');

          if (!regex.test(input.value)) {
              lblValidation.textContent = "الرجاء إدخال حروف عربية أو إنجليزية .";
              input.value = input.value.replace(/[^a-zA-Zء-ي\s]/g, '');
          } else {
              lblValidation.textContent = "";
          }
      }


  </script>
<style type="text/css">

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

          .contner {
            display: flex;
            flex-direction: column;
            align-items: center;
            background-color: white;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-top: 5px;
            margin-bottom: 0px;
            margin: 0 auto;
            width: 50%;
            height: 450px;
          }

        .column.middle {
            width:55%;
            text-align: center;
            margin-bottom: 0px; 
            height: 400px;
        }

        .auto-style11 {
            text-align: center;
            align-items: center;
            width: 100%;
            margin-top: 10px;
        }

        .txtrow {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 2px;
            width: 100%;
        }


         .label {
            color: black;
            text-align:center;
            display: flex;
            align-items: center;
            width: 100%;
            align-content:center;
            justify-content:center;
         }

        .txtrow input[type="text"],
        .txtrow input[type="password"] {
            width: 100%;     
            font-size: 18px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .auto-style5,
        .auto-style7 {
            width: 100%; 
            height: 1px;
            background: #ccc;
            margin-top: 10px;
        }
    .auto-style26 {
        width: 774px;
    }
    </style>


</asp:Content>
    
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:Button ID="patient_save" runat="server" Text="تسجيل مريض جديد" OnClick="user_patient_signup"    Style="border-style: none;border-color: inherit; border-width: medium; background: gray; color: white; padding: 10px 15px; border-radius: 5px;" Width="195px" CssClass="auto-style14" Height="42px" Visible =" false" />    
     <asp:Panel runat="server" ID="p_sinup" class="contner" Visible =" false" >
        <div class="column middle">
           <h4 class="auto-style11">تسجيل مستخدم جديد</h4>           
            <div class="form-check form-check-inline auto-style18">
                <asp:RadioButton ID="employee" runat="server" GroupName="patient" Text="" Enabled="False" CssClass="form-check-input"/>         
                <label class="form-check-label">موظف</label>
               <asp:RadioButton ID="doctor" runat="server"  GroupName="patient"   Text="" Enabled="False"  CssClass="form-check-input"/>
                <label class="form-check-label">طبيب</label>
                <asp:RadioButton ID="patient" runat="server" GroupName="patient" text=""  checked="true" CssClass="form-check-input"/>
                <label class="form-check-label">مريض</label>
               <asp:RadioButton ID="user" runat="server" GroupName="patient" Text="" Enabled="False" CssClass="form-check-input"/>
               <label class="form-check-label">مستخدم</label>
            </div>
    <br />
    <br />   
        <div class="form-check form-check-inline auto-style18">                
                   <asp:RadioButtonList ID="nat" runat="server" RepeatDirection="Horizontal" CssClass="form-check-input" style="align-items:center;">
                       <asp:ListItem  >مصرى</asp:ListItem>
                       <asp:ListItem >اجنبى</asp:ListItem>
                   </asp:RadioButtonList>
        </div>
       <div class="form-group txtrow">
            <asp:Label ID="lblname" runat="server" class="label"> الاسم</asp:Label>
            <asp:TextBox ID="txtname" runat="server"  Width="240px"  CssClass="form-control" oninput="validateInput(this)"></asp:TextBox>
            <asp:Label ID="lblValidation" runat="server" ForeColor="Red"></asp:Label>
        </div>
      
          <div class="form-group txtrow">
              <asp:Label ID="lblphone" runat="server" class="label"> رقم الهاتف</asp:Label>
              <asp:TextBox ID="txtphone" runat="server" Width="240px"  CssClass="form-control" AutoPostBack="true"></asp:TextBox>
              <asp:Label ID="phonecount" runat="server" ForeColor="Red"></asp:Label>

        </div>      
  


    <div class="txtrow">
            <asp:TextBox ID="code" runat="server" Visible="False" Height="16px"></asp:TextBox>
            <asp:TextBox ID="sick_code" runat="server" Visible="False" Height="16px"></asp:TextBox>
            <asp:TextBox ID="txtpass" runat="server" Visible="False" Width="248px" CssClass="mr-0" Height="16px"></asp:TextBox>
    </div>
  <div class=" label ">
            <asp:Label ID="lbl_sign" runat="server" Style="margin-left: 485px" Font-Bold="True" Font-Size="16px" ForeColor="black" margin-top="30px"></asp:Label>
   </div>
         <div class="form-group txtrow text-center">
            <asp:Button ID="Sign_up" runat="server" Text="تسجيل" OnClick="Sign_up_Click"  CssClass="btn btn-primary"  Width="125px" style="background-color: #41AB88;" />
        </div>
   </div>
</asp:Panel>
     

  
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<!----------------------------------------------------------- start book--------------------------------------------------------- -->

     <div class="container" style="width: 70%; margin:auto;"> 
<!----------------------------------------------------------- group 1--------------------------------------------------------- -->
        <div class="row">

              <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label7" runat="server" Text="العياده"></asp:Label>
                      <asp:DropDownList ID="clinic" runat="server"   CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="clinic_SelectedIndexChanged"></asp:DropDownList>
                  </div>
              </div>
              <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label2" runat="server" Text="الدكتور"></asp:Label>
                     <asp:DropDownList ID="doc" runat="server"  CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="doc_SelectedIndexChanged"></asp:DropDownList>
                  </div>
              </div>
              <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label4" runat="server" Text="الخدمة"></asp:Label>
                <asp:DropDownList ID="serv" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                  </div>
              </div>
          </div>
<!----------------------------------------------------------- group 2--------------------------------------------------------- -->
        <div class="row">
               <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="ro2l1" runat="server" Text="التاريخ"></asp:Label>
                      <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" Width="240px" AutoPostBack="true" onchange="showDay()" textmode="date"></asp:TextBox>
                  </div>
            </div>
               <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label5" runat="server" Text="اليوم"></asp:Label>
                      <asp:TextBox ID="day" runat="server" CssClass="form-control" Width="240px" ></asp:TextBox>
                  </div>
            </div>
               <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label6" runat="server" Text="الساعة"></asp:Label>
                      <asp:TextBox runat="server" type="time" min="9:00" max="17:00"  ID="hour"  CssClass="form-control" Width="240px"></asp:TextBox>
                  </div>
            </div>
        
        </div>
<!----------------------------------------------------------- group 3--------------------------------------------------------- -->
        <div class="row">
              <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="lbl_internet" runat="server" Text="وسيلة التعارف"></asp:Label>
                      <asp:DropDownList ID="internet" runat="server" CssClass="form-control" DataValueField="1"  AutoPostBack="true" OnSelectedIndexChanged="internet_SelectedIndexChanged"></asp:DropDownList>
                  </div>
              </div>
              <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="lbl_company" runat="server" Text="الجهه المتعاقدة"></asp:Label>
                    <asp:DropDownList ID="company" runat="server" CssClass="form-control"  BackColor="White"  AutoPostBack="true" OnSelectedIndexChanged="company_SelectedIndexChanged"></asp:DropDownList>
                  </div>
              </div>
              <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="lbl_contract" runat="server" Text="الجهه "></asp:Label>
                      <asp:DropDownList ID="contract" runat="server" CssClass="form-control" >
                        <asp:ListItem Value="نقدى">نقدى</asp:ListItem>
                        <asp:ListItem Value="تعاقد">تعاقد</asp:ListItem>
                    </asp:DropDownList>
                  </div>
              </div>
  </div>
<!-----------------------------------------------------------visible false--------------------------------------------------------- -->
        <div class="row" id="div_type"  runat="server" visible="false">            
         <div class="col-md-4" id="internet_type" runat="server" visible="false">
                  <div class="form-group text-right">
                      <asp:Label ID="Label1" runat="server" Text="اكتب وسيلة التعارف"></asp:Label>
                      <asp:TextBox ID="type_internet" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
                  </div>
              </div>
         <div class="col-md-4" id="company_type" runat="server" visible="false">
                  <div class="form-group text-right">
                      <asp:Label ID="Label3" runat="server" Text="اكتب الجهة المتعاقده"></asp:Label>
                      <asp:TextBox ID="type_company" runat="server" CssClass="form-control" Width="240px"></asp:TextBox>
                  </div>
              </div>
  </div>
<!----------------------------------------------------------- group 4--------------------------------------------------------- -->
        <div class="row">
               <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="Label11" runat="server" Text="ملاحظات" width="400px"  ></asp:Label>
                     <textarea ID="notes" runat="server" rows="3" CssClass="form-control" class="auto-style26"></textarea>      
                   </div>
               </div>            
     </div>
<!----------------------------------------------------------- group 5--------------------------------------------------------- -->
              <div class="label" >
                <asp:Label ID="lbl_message" runat="server" class="text-center" Font-Bold="True" ForeColor="black"  Font-Size="18px" ></asp:Label>
            </div>
         
         <div class="row">
                <div class="col-md-12 text-center">
                   <asp:Button ID="login" runat="server" Text="تخزين" CssClass="btn btn-primary" Width="125px" OnClick="login_Click" style="background-color: #41AB88;" />
                    <asp:Button ID="print" runat="server" Text="طباعة" CssClass="btn btn-primary" Width="125px" OnClick="btnPrint_Click" style="background-color: #41AB88;"/>
                </div>
            </div>                     
<!----------------------------------------------------------- finish--------------------------------------------------------- -->
        </div>
</asp:Content>







 

