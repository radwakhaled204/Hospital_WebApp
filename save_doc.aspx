<%@ Page Title="تسجيل مواعيد الدكاتره" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="save_doc.aspx.cs" Inherits="Royal_Elshrouq.save_doc" %>

<%@ Import NameSpace="System.Data.SqlClient" %>
<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Web.UI.WebControls" %>

 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
     <div  runat="server" class="auto-style4" >
    <asp:Label ID="lbl2_m" runat="server" Text="Label" class="lbl_hello"></asp:Label>
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
 

<style type="text/css">
        .table-container {
        display: flex;
        justify-content: space-between;
        width: 90%;
        margin: 0 auto;
        margin-top:25px;
        }

    table {
        border: 1px solid #ccc;
        border-radius: 5px;
         width: 90%;
        margin-bottom: 10px;
   
          text-align:center;
    }

           .contner {
           width: 65%;
           margin: auto;
           background-color: white;
           border: 1px solid #ccc;
           border-radius: 5px;
           padding: 20px;
           text-align: center;
           align-items:center;
           align-content:center;
           margin-top: 20px;
           margin-bottom: 20px;
           }



        .column.middle {
            width:55%;
            text-align: center;
            margin-bottom: 0px; 
            height: 400px;
        }

        .txtrow {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 2px;
            width: 100%;
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
.textarea-container {
    width: 700px; 
}
.auto-style26 {
        width: 700px;
        margin-top: 10px;
}
    .auto-style27 {
        position: relative;
        width: 100%;
        min-height: 1px;
        -webkit-box-flex: 0;
        -ms-flex: 0 0 33.333333%;
        flex: 0 0 33.333333%;
        max-width: 33.333333%;
        right: -2px;
        top: 0px;
        padding-left: 15px;
        padding-right: 15px;
    }
    </style>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="contner" style="width: 65%;"> 
<!----------------------------------------------------------- group 1--------------------------------------------------------- -->
<div class="row">

              <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="lbl_clinic" runat="server" Text="العياده"></asp:Label>
                      <asp:DropDownList ID="clinic" runat="server"   CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="clinic_SelectedIndexChanged"></asp:DropDownList>
                  </div>
              </div>
              <div class="col-md-4">
                  <div class="form-group text-right">
                      <asp:Label ID="lbl_doc" runat="server" Text="الدكتور"></asp:Label>
                     <asp:DropDownList ID="doc" runat="server"  CssClass="form-control" AutoPostBack="true" ></asp:DropDownList>
                  </div>
              </div>

           </div>   
<!----------------------------------------------------------- group 2------------------------------------------------------ -->
<div class="row">    
            <div class="col-md-4">
              <div class="form-group text-right">
                     <asp:Label ID="lbl_pic" runat="server" Text="الصورة"></asp:Label>
                     <asp:FileUpload ID="img" runat="server"   CssClass="form-control"/> 
                      <asp:Image ID="img_preview" runat="server" CssClass="img-preview" visible="False"/>
                  </div>
          </div>        
         <div class="col-md-4">
            <div class="form-group text-right">  
               <asp:Label ID="lbl_vid" runat="server" Text="الفيديو"></asp:Label>
                <asp:FileUpload ID="vid" runat="server"  CssClass="form-control"/>  
                    <video id="vid_preview" runat="server"  style=" float:right;" class="img-fluid" visible="False"></video>

            </div>
        </div>
</div>
<!----------------------------------------------------------- group 3--------------------------------------------------------- -->

        <div class="row">
               <div class="auto-style27">
                   <div class="textarea-container">
                     <div class="form-group text-right">
                      <asp:Label ID="lbl_note" runat="server" Text="تعريف بالدكتور" width="500px"  ></asp:Label>
  
                     <textarea ID="notes" runat="server" rows="3"  class="form-control auto-style26"></textarea>      
                   </div>
                  </div>  
              </div>      
     </div>

<!----------------------------------------------------------- Dates--------------------------------------------------------- -->

<div class="table-container">
    <table border="1">
     <tr>
       <th  colspan="3" style="color:red">جدول مواعيد الدكتور </th>
    </tr>     
        
<tr>
    <th>ايام الاسبوع</th>
    <th>من</th>
    <th>الى</th>
</tr>
<tr>
    <td>الجمعه</td>
 
    <td><asp:TextBox runat="server" type="time"  ID="fri_from"  CssClass="form-control" Width="200px"></asp:TextBox></td>
    <td><asp:TextBox runat="server" type="time"  ID="fri_to"  CssClass="form-control" Width="200px"></asp:TextBox></td>
</tr>
<tr>
    <td>السبت</td>
 
    <td><asp:TextBox runat="server" type="time"  ID="sat_from"  CssClass="form-control" Width="200px"></asp:TextBox></td>
    <td><asp:TextBox runat="server" type="time"  ID="sat_to"  CssClass="form-control" Width="200px"></asp:TextBox></td>
</tr>
 <tr>
    <td>الاحد</td>
 
    <td><asp:TextBox runat="server" type="time"  ID="sun_from"  CssClass="form-control" Width="200px"></asp:TextBox></td>
    <td><asp:TextBox runat="server" type="time"  ID="sun_to"  CssClass="form-control" Width="200px"></asp:TextBox></td>
</tr>
 <tr>
    <td>الاتنين</td>
 
    <td><asp:TextBox runat="server" type="time"  ID="mon_from"  CssClass="form-control" Width="200px"></asp:TextBox></td>
    <td><asp:TextBox runat="server" type="time"  ID="mon_to"  CssClass="form-control" Width="200px"></asp:TextBox></td>
</tr>
 <tr>
    <td>الثلاثاء</td>
 
    <td><asp:TextBox runat="server" type="time"  ID="tues_from"  CssClass="form-control" Width="200px"></asp:TextBox></td>
    <td><asp:TextBox runat="server" type="time"  ID="tues_to"  CssClass="form-control" Width="200px"></asp:TextBox></td>
</tr>
 <tr>
    <td>الاربعاء</td>
 
    <td><asp:TextBox runat="server" type="time"  ID="wed_from"  CssClass="form-control" Width="200px"></asp:TextBox></td>
    <td><asp:TextBox runat="server" type="time"  ID="wed_to"  CssClass="form-control" Width="200px"></asp:TextBox></td>
</tr>
 <tr>
    <td>الخميس</td>
 
    <td><asp:TextBox runat="server" type="time"  ID="thures_from"  CssClass="form-control" Width="200px"></asp:TextBox></td>
    <td><asp:TextBox runat="server" type="time"  ID="thures_to"  CssClass="form-control" Width="200px"></asp:TextBox></td>
</tr>

</table>
</div>      

<!----------------------------------------------------------- finish--------------------------------------------------------- -->
              <div class="label" >
                <asp:Label ID="lbl_message" runat="server" class="text-center" Font-Bold="True" ForeColor="black" Font-Size="18px" ></asp:Label>
            </div>
<div class="row">
                <div class="col-md-12 text-center">
                    <asp:Button ID="save" runat="server" Text="تخزين"  OnClick=" Save_Click" CssClass="btn btn-primary" Width="125px" style="background-color: #41AB88;"/>
                </div>                     
            </div>
        
    </div>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
