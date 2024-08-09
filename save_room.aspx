<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="save_room.aspx.cs" Inherits="Royal_Elshrouq.save_room" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <style>
     label {
         display: block;
         margin-bottom: 8px;
     }

     input, select, button {
       
         box-sizing: border-box;
     }

     .h_button {
         border-style: none;
         border-color: inherit; 
         border-width: medium;
         background: gray; 
         color: white;
         padding: 10px 15px;
         border-radius: 5px;
         Width:130px ;
         Height:42px;

     }
     button {
         background-color: #4caf50;
         color: #fff;
         border: none;
         border-radius: 5px;
         cursor: pointer;
     }
         .auto-style1 {
             width: 100%;
              text-align: center;
             
         }
         .form {
             width: 50%;
             border-radius: 5px;
             border: 1px solid #ccc;
             box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
             max-width: 1140px;
             min-width: 992px;
             margin-left: auto;
             margin-right: auto;
             margin-top: 10px;
             margin-bottom: 0px;
             padding: 20px;
             background-color: white;
             height: 500px;
         }
         
         .divfloor {
             height: 74px;
             margin-top: 20px;
             border-radius: 5px;
             border: 1px solid #ccc;
         }
         .auto-style3 {
             height: 74px;
             margin-top: 20px;
         }
         .auto-style4 {
             align-items:center;
         }

         .auto-style6 {
             float: right;
             height: 67px;
         }
         .auto-style7 {
            align-items:center;
             height: 86px;
            Width:304px;
            float: right;
         }
         .panel{

             float:left;
             border: 1px solid #ccc;
             border-radius: 5px;
         }
         .auto-style11 {
             height: 126px;
         }
         .auto-style12 {
             float: right;
             margin-top: 10px;
         }
         .auto-style13 {
             float: right;
             margin-left: 10px;
         }

         .auto-style14 {
             height: 86px;
         }

         .auto-style15 {
             float: right;
             height: 61px;
         }
         .dropdown_con{
             float: right;
             
         }
         .dropdowngrid{
            height: 74px;
            margin-top: 30px;

         }






</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
    <asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form   class="form" runat="server">
        <h2 class="auto-style1">نظام تسجيل الغرف</h2>

<div class="auto-style3">
                    <div  runat="server" >
    <div class="auto-style6">
 <div style="display: flex; ">

       <asp:TextBox ID="tryco" runat="server" Width="136px"  Visible="false"></asp:TextBox>
    <asp:TextBox ID="tryfloor" runat="server" AutoPostBack="true" Width="136px" CssClass="auto-style12" ></asp:TextBox>
     <asp:Label ID="Label3" runat="server" Width="93px" CssClass="auto-style13"> دور </asp:Label> 
         <asp:TextBox ID="tryname" runat="server" AutoPostBack="true" Width="136px" CssClass="auto-style12" ></asp:TextBox>
     <asp:Label ID="Label4" runat="server" Width="93px" CssClass="auto-style13"> اسم المريض</asp:Label>  
         <asp:TextBox ID="trysick" runat="server" AutoPostBack="true" Width="136px" CssClass="auto-style12" ></asp:TextBox>
     <asp:Label ID="Label5" runat="server" Width="93px" CssClass="auto-style13"> كود </asp:Label>
              <asp:TextBox ID="trystat" runat="server" AutoPostBack="true" Width="136px" CssClass="auto-style12" ></asp:TextBox>
     <asp:Label ID="Label6" runat="server" Width="93px" CssClass="auto-style13"> حالة</asp:Label> 
</div>

    </div>
</div>

    
    <div class="auto-style6">
 <div style="display: flex; ">

          <asp:Button ID="trybtn" runat="server" Text="اضافه" style="align-items: center;" Width="95px" OnClick="trybedno_room"/>
                <asp:TextBox ID="trybedno" runat="server" AutoPostBack="true" Width="136px" CssClass="auto-style12" ></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Width="93px" CssClass="auto-style13"> عدد الاسرة </asp:Label>   
    <asp:TextBox ID="tryroom" runat="server" AutoPostBack="true" Width="136px" CssClass="auto-style12" ></asp:TextBox>
     <asp:Label ID="Label2" runat="server" Width="93px" CssClass="auto-style13"> اسم الغرفه</asp:Label>             
 
</div>

    </div>
     
            <div style="text-align: center">

                <asp:Label ID="lbl_2" runat="server" ></asp:Label>
     </div>
    </div>
 </form>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script src="script.js"></script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
