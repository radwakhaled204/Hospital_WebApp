<%@ Page Title="عرض الحجوزات" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="show_books.aspx.cs" Inherits="Royal_Elshrouq.show_books" %>
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
        width: 774px;
    }
.auto-style1 {
             width: 100%;
              text-align: center;
             
}
    </style>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="contner" > 
        <h2 class="auto-style1">الحجوزات</h2>
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
                     <asp:DropDownList ID="doc" runat="server"  CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="doc_SelectedIndexChanged" ></asp:DropDownList>
                  </div>
              </div>

           </div>   

<!----------------------------------------------------------- group 2------------------------------------------------------ -->


<asp:GridView ID="books" runat="server" AutoGenerateColumns="False" Style="text-align: center" Visible="False" CssClass="auto-style4" width="100%">
    <Columns>
        <asp:BoundField DataField="day" HeaderText="اليوم" />
          <asp:BoundField DataField="book_date" HeaderText="التاريخ" SortExpression="book_date" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="book_time" HeaderText="الساعة" />
        <asp:BoundField DataField="sick_code" HeaderText="كود المريض" />
        <asp:BoundField DataField="sick_n" HeaderText="اسم المريض" />
        <asp:BoundField DataField="mob" HeaderText="رقم الهاتف" />
        <asp:BoundField DataField="spec_n" HeaderText="الخدمة" />
        <asp:BoundField DataField="company" HeaderText="الجهة المتعاقده" />
        <asp:BoundField DataField="contract_cash" HeaderText="تعاقد او نقدى " />
        <asp:BoundField DataField="internet_" HeaderText="وسيلة التعارف " />
        <asp:BoundField DataField="rem_" HeaderText="ملاحظات المريض" />
    </Columns>
</asp:GridView>



<!----------------------------------------------------------- group 3------------------------------------------------------ -->

</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
