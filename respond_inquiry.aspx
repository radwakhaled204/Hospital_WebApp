<%@ Page Title="الرد على الاستفسارات" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="respond_inquiry.aspx.cs" Inherits="Royal_Elshrouq.respond_inquiry" %>
<%@ Import NameSpace="System.Data.SqlClient" %>
<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Web.UI.WebControls" %>

 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
<div runat="server" class="auto-style4" >
    <asp:Label ID="lbl2_m" runat="server" Text="Label" class="lbl_hello"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_m" runat="server" Text="Label" class="lbl_hello"></asp:Label>
</div>
 
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/css/bootstrap-datepicker.min.css" />
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/js/bootstrap-datepicker.min.js"></script>
 

<style type="text/css">

.contner {
           width: 95%;
           margin:auto;
           background-color: white;
           border: 1px solid #ccc;
           border-radius: 5px;
           padding: 5px;
           text-align:center;
           align-items: center;
           align-content: center;
           margin-top: 20px;
           margin-bottom: 20px;
       
}


.auto-style26 {
        width: 700px;
        margin-top: 10px;
}
.auto-style1 {
        width: 100%;
        text-align: center;
    }
.right-padding  {
  padding-right: 5px;

}
.grid{
           margin-top: 30px;
           margin-bottom: 20px;
}       
.row {
    display: flex;
    justify-content: center;
    align-items: center; 
    margin-top: 30px;
    margin-bottom: 20px;
}

.textarea-container {
    width: 700px; 
}

textarea#notes {
    margin: auto; 
    

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
    </style>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="contner" > 
        <h2 class="auto-style1">الرد على الاستفسارات</h2>

<!----------------------------------------------------------- group 1------------------------------------------------------ -->

<asp:GridView ID="res_inquries" runat="server" AutoGenerateColumns="False"  Width="100%" class="grid">

    <Columns>
        <asp:BoundField DataField="inquiry_date" HeaderText="التاريخ" ItemStyle-HorizontalAlign="right" ItemStyle-CssClass="right-padding"/>
        <asp:BoundField DataField="sick_code" HeaderText="كود المريض" />
        <asp:BoundField DataField="n1" HeaderText="اسم المريض" ItemStyle-HorizontalAlign="right" ItemStyle-CssClass="right-padding"/>
        <asp:BoundField DataField="mob1" HeaderText="رقم الهاتف" ItemStyle-HorizontalAlign="right" ItemStyle-CssClass="right-padding"/>
        <asp:BoundField DataField="inquiry" HeaderText="الاستفسار" ItemStyle-HorizontalAlign="right" ItemStyle-CssClass="right-padding"/>
    </Columns>

</asp:GridView>



<!----------------------------------------------------------- group 3------------------------------------------------------ -->
<div class="row">
    <div class="textarea-container">
        <div class="form-group text-right">
            <asp:Label ID="lbl_note" runat="server" Text="اكتب ردك على الاستفسار" style="text-align:center;"></asp:Label>
            <textarea ID="notes" runat="server" rows="8" class="form-control auto-style26"></textarea>
        </div>
    </div>
</div>

<!----------------------------------------------------------- button--------------------------------------------------------- -->
              <div class="label" >
                <asp:Label ID="lbl_message" runat="server" class="text-center" Font-Bold="True" ForeColor="black"  Font-Size="18px" ></asp:Label>
            </div>
<div class="btn">
     <div class="col-md-12 text-center">
        <asp:Button ID="save" runat="server" Text="ارسل ردك"  OnClick=" Save_Click" CssClass="btn btn-primary" Width="125px" style="background-color: #41AB88;"/>
        <asp:Button ID="update" runat="server" Text="تعديل الرد"  OnClick=" Save_Click" CssClass="btn btn-primary" Width="125px" style="background-color: #41AB88;"/>

         </div>                     
</div>
<!----------------------------------------------------------- group 3------------------------------------------------------ -->

 </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
