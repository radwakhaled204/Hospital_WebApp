<%@ Page Title="تحميل ملفات" Language="C#" MasterPageFile="~/patient.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="Royal_Elshrouq.upload" %>
<%@ Import NameSpace="System.Data.SqlClient" %>
<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Web.UI.WebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/css/bootstrap-datepicker.min.css" />
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/js/bootstrap-datepicker.min.js"></script>
 

<style type="text/css">
.textarea-container {
    width: 700px; 
}
.auto-style26 {
        width: 700px;
        margin-top: 10px;
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
.container {
    width: 80%;
    margin: auto;
    background-color: white;
    border: 1px solid #ccc;
    border-radius: 5px;
    padding: 15px;
    text-align: center;
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    align-content: center;
    justify-content: center;
}

.row {
    display: flex;
    width: 100%;
}

.col-md-4 {
    width: 50%;  
    box-sizing: border-box;
}

.crd {
    width: 100%;  
    padding: 15px;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-shadow: 2px 2px 5px #ccc;
    margin-top: 20px;
    margin-bottom: 20px;
    height: 150px;
    display: flex;
    background-color: #f2f2f2;

}

.crd-text {
    display: flex;
    padding: 20px;
   width: 300px; 
    background-color: white;



}
.crd-txt {
    display: flex;
    padding: 20px;
    width: 300px; 
    background-color: white;



}
.p {
    margin: 10px 0 0 0;
    font-size: 16px;
    color: #555;
    text-align: center;
    background-color: red;
}



 
    .auto-style27 {
        display: flex;
        padding: 20px;
        width: 420px;
        background-color: white;
        height: 100px;
        border: 1px solid #ccc;
        border-radius: 5px;

    }
    .auto-style28 {
        display: flex;
        padding: 20px;
        width: 420px;
        background-color:white ;
        margin-right:130px;
        height: 100px;
        border: 1px solid #ccc;
        border-radius: 5px;
    }



 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div runat="server" class="auto-style4" >
    <asp:Label ID="lbl2_m" runat="server" Text="Label" class="lbl_hello"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_m" runat="server" Text="Label" class="lbl_hello"></asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container" style="width: 80%; margin:auto;"> 
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

<!----------------------------------------------------------- button--------------------------------------------------------- -->
              <div class="label" >
                <asp:Label ID="lbl_message" runat="server" class="text-center" Font-Bold="True" ForeColor="black"  Font-Size="18px" ></asp:Label>
            </div>
<div class="row">
     <div class="col-md-12 text-center">
        <asp:Button ID="save" runat="server" Text="ارسل الملفات"  CssClass="btn btn-primary" Width="125px" style="background-color: #41AB88;"/>
     </div>                     
</div>
<!--------------------------------------------------------- respond--------------------------------------------------------- -->

   </div>
 

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
