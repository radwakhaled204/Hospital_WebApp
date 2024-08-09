<%@ Page Title="تسجيل مستخدم جديد" Language="C#" MasterPageFile="~/master1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Royal_Elshrouq.signup" %>
<%@ Import NameSpace="System.Data.SqlClient" %>
<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Web.UI.WebControls" %>


<asp:Content ID="Content4" ContentPlaceHolderID="head" runat="server">
    
    <style>
             .contner {
            display: flex;
            flex-direction: column;
            align-items: center;
            background-color: white;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-top: 5px;
            margin-bottom: 5px;
            margin: 0 auto;
            width:39%;
            height: 450px;
             }

        .column.middle {
            width:55%;
            text-align: center;
            margin-bottom: 0px; 
            height: 400px;
        }


        .auto-style18 {
            width: 100%;
        }

        .txtrow {
            display: flex;
        
            align-items: center;          
            width: 100%;
           position: relative;
           margin-bottom: 5px;
        }

        .txtrow .label {
            font-size: 16px;
            color: black;
            text-align:center;
            display: flex;
            align-items: center;
            width: 100%;
        }

        .txtrow input[type="text"],
        .txtrow input[type="password"] {
            width: 100%;
            margin-bottom: 5px;
            font-size: 18px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }



    .label {
        display: block;
  
    }

    #<%= txtname.ClientID %>, #<%= lblValidation.ClientID %> {
        margin-top:15px; 
    }

    #<%= lblValidation.ClientID %> {
        display: block;
        position: absolute;
        bottom: 0;
        left: 0;
        color: red;
        margin-top: 15px; 
    }
    #<%= txtphone.ClientID %>, #<%= phonecount.ClientID %> {
        margin-top:15px; 
    }

    #<%= phonecount.ClientID %> {
        display: block;
        position: absolute;
        bottom: 0;
        left: 0;
        color: red;
        margin-top:15px; 
     
    }

    </style>

     
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:Panel runat="server" ID="p_sinup" class="contner" >
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
        <div class="form-check form-check-inline auto-style18" style="align-items:center; justify-content:center ">                
                   <asp:RadioButtonList ID="nat" runat="server" RepeatDirection="Horizontal" CssClass="form-check-input" >
                       <asp:ListItem  >مصرى</asp:ListItem>
                       <asp:ListItem >اجنبى</asp:ListItem>
                   </asp:RadioButtonList>
        </div>
       <div class="form-group txtrow">
            <asp:Label ID="lblname" runat="server" class="label"> الاسم</asp:Label>
            <asp:TextBox ID="txtname" runat="server"  Width="240px"  CssClass="form-control" oninput="validateInput(this)"></asp:TextBox>
        </div>
       <div class="form-group txtrow">
            <asp:Label ID="lblValidation" runat="server" ForeColor="Red"></asp:Label>

        </div>        
            <div class="form-group txtrow">
              <asp:Label ID="lblphone" runat="server" class="label"> رقم الهاتف</asp:Label>
              <asp:TextBox ID="txtphone" runat="server" Width="240px"  CssClass="form-control" AutoPostBack="true" onkeyup="phonecount()"></asp:TextBox>

        </div>      
            <div class="form-group txtrow">
              <asp:Label ID="phonecount" runat="server" ForeColor="Red"></asp:Label>
        </div>   


    <div class="txtrow">
            <asp:TextBox ID="code" runat="server" Visible="False" Height="16px"></asp:TextBox>
            <asp:TextBox ID="sick_code" runat="server" Visible="False" Height="16px"></asp:TextBox>
            <asp:TextBox ID="txtpass" runat="server" Visible="False" Width="248px" CssClass="mr-0" Height="16px"></asp:TextBox>
    </div>
  <div class=" label ">
            <asp:Label ID="lbl_message" runat="server"  Font-Bold="True" Font-Size="16px" ForeColor="black" margin-top="30px"></asp:Label>
   </div>
         <div class="form-group txtrow text-center">
            <asp:Button ID="Sign_up" runat="server" Text="تسجيل" OnClick="Sign_up_Click"  CssClass="btn btn-primary"  Width="125px" style="background-color: #41AB88;" />
        </div>
   </div>
</asp:Panel>



<script type="text/javascript">
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

    function phonecount() {
        var whatsTextBox = document.getElementById('<%= txtphone.ClientID %>');
             var digitcountlabel2 = document.getElementById('<%= phonecount.ClientID %>');
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


        </div>      
</asp:Content>




